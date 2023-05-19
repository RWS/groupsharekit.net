namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class LanguageDetailsRequest
    {
        public string SourceText { get; set; }
        public string SourceLanguageCode { get; set; }
        public string TargetText { get; set; }
        public string TargetLanguageCode { get; set; }

        public LanguageDetailsRequest(string sourceText,string sourceLanguageCode,string targetText,string targetLanguageCode)
        {
            SourceText = sourceText;
            SourceLanguageCode = sourceLanguageCode;
            TargetText = targetText;
            TargetLanguageCode = targetLanguageCode;
        }
    }
}
