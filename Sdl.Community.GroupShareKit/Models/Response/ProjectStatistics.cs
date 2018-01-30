using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class ProjectStatistics
    {
        /// <summary>
        /// Gets or sets the project analysis statistics
        /// </summary>
        public ProjectAnalysisStatistics AnalysisStatistics { get; set; }
        /// <summary>
        /// Gets or sets the project confirmation statistics
        /// </summary>
        public ProjectConfirmationStatistics ConfirmationStatistics { get; set; }
    }
}
