using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class ReportingServiceProjectsPerMonth
    {
        public int Year { get; set; }

        public int Month { get; set; }

        public int NumberOfProjects { get; set; }
    }
}
