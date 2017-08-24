using Sdl.Community.GroupShareKit.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class Analyse
    {
        public AnalyseDetails Perfect { get; set; }
        public AnalyseDetails InContextExact { get; set; }
        public AnalyseDetails Exact { get; set; }
        public AnalyseDetails Locked { get; set; }
        public AnalyseDetails CrossFileRepeated { get; set; }
        public AnalyseDetails Repeated { get; set; }
        public AnalyseDetails Total { get; set; }
        public AnalyseDetails New { get; set; }
        public List<Fuzzy> Fuzzy { get; set; }
    }
}
