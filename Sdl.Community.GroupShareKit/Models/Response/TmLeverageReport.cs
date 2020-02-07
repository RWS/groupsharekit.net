using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    /// <summary>
    /// TM Leverage report model.
    /// </summary>
    /// <returns>The list of TM Leverage values</returns>
    public class TmLeverageReport
    {
        public int PerfectMatch { get; set; }

        public int RepeatedWords { get; set; }

        public int FuzzyMatches { get; set; }

        public int NewWords { get; set; }

        public int ContextMatch { get; set; }

        public int TotalWords { get; set; }

        public int ExactMatchedWords { get; set; }
    }
}
