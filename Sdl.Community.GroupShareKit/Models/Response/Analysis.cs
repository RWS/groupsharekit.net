using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class Analysis
    {
        /// <summary>
        /// Gets or sets the analysis status
        /// </summary>
        public AnalysisStatus Status { get; set; }

        /// <summary>
        /// Checks to see if the analysis is done
        /// </summary>
        public bool IsFinal { get; set; }

        /// <summary>
        /// Gets the last error message
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
