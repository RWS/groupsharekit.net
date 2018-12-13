namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class DetailedDocumentStatistics
    {
        public string User { get; set; }

        public string TranslationOrigin { get; set; }

        public string ConfirmationLevel { get; set; }

        public bool? Locked { get; set; }

        public CountData Value { get; set; }

        public FuzzyBand FuzzyBand { get; set; }
    }
}
