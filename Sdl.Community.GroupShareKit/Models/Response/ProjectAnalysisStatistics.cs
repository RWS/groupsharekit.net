using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class ProjectAnalysisStatistics
    {
        public AnalyseDetails Exact { get; set; }
        public List<Fuzzy> Fuzzy { get; set; }
        public AnalyseDetails InContextExact { get; set; }
        public AnalyseDetails New { get; set; }
        public AnalyseDetails NewBaseline { get; set; }
        public AnalyseDetails NewLearnings { get; set; }
        public AnalyseDetails Perfect { get; set; }
        public AnalyseDetails Repetitions { get; set; }
        public AnalyseDetails Total { get; set; }
    }
}
