using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class ProjectStatistics
    {
        public ProjectAnalysisStatistics AnalysisStatistics { get; set; }
        public ProjectConfirmationStatistics ConfirmationStatistics { get; set; }
    }
}
