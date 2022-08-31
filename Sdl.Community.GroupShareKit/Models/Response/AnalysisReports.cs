namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class AnalysisReports
    {
        public string LanguageCode { get; set; }
        
        public Report Report { get; set; }

        public bool IsFull { get; set; }

        public string TriggeredBy { get; set; }

        public int ReportId { get; set; }
    }
}
