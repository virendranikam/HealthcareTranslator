using HealthcareTranslator.Shared.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TranslateController : ControllerBase
{
    private readonly OpenAIService _openAI;

    public TranslateController(OpenAIService openAI)
    {
        _openAI = openAI;
    }


    [HttpPost]
    public async Task<IActionResult> Translate([FromBody] TranslationRequest request)
    {
        var result = await _openAI.TranslateAsync(request.Text, request.SourceLanguage, request.TargetLanguage);

        return Ok(new { translatedText = result ?? "Translation failed." });

    }
}
