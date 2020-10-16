using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class ReportingServiceTmLeverage
    {
        public int PerfectlyMatchedWords { get; set; }

        public int RepeatedWords { get; set; }

        public int FuzzyWords { get; set; }

        public int NewWords { get; set; }

        public int TotalWords { get; set; }

        public int ExactMatchedWords { get; set; }

        public int InContextExactMatchedWords { get; set; }
    }
}
