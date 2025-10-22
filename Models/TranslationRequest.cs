﻿namespace HealthcareTranslator.Shared.Models
{
    public class TranslationRequest
    {
        public string Text { get; set; }
        public string SourceLanguage { get; set; }
        public string TargetLanguage { get; set; }
    }
}
