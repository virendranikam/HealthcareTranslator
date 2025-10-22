using System.Text;
using System.Text.Json;

public class OpenAIService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey = "YOUR_OPENAI_API_KEY";

    public OpenAIService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> TranslateAsync(string text, string sourceLang, string targetLang)
    {
        var prompt = $"Translate this medical phrase from {sourceLang} to {targetLang}: {text}";
        var requestBody = new
        {
            model = "gpt-3.5-turbo",
            messages = new[] {
                new { role = "user", content = prompt }
            }
        };

        var request = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/chat/completions")
        {
            Content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json")
        };
        request.Headers.Add("Authorization", $"Bearer {_apiKey}");

        var response = await _httpClient.SendAsync(request);
        var json = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(json);
        return doc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();
    }
}
