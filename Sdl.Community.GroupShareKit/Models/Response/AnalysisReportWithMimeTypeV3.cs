namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class AnalysisReportWithMimeTypeV3
    {
        public string LanguageCode { get; set; }

        public string Report { get; set; }

        public bool IsFullReport { get; set; }

        public string TriggeredBy { get; set; }

        public int ReportId { get; set; }
    }
}
