namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class ProjectConfirmationStatistics
    {
        public AnalyseDetails Unspecified { get; set; }
        public AnalyseDetails Draft { get; set; }
        public AnalyseDetails Translated { get; set; }
        public AnalyseDetails RejectedTranslation { get; set; }
        public AnalyseDetails ApprovedTranslation { get; set; }
        public AnalyseDetails RejectedSignOff { get; set; }
        public AnalyseDetails ApprovedSignOff { get; set; }
    }
}
