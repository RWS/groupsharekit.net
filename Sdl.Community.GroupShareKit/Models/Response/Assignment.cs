using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class Assignment
    {
        /// <summary>
        /// Gets or sets the due date
        /// </summary>
        public DateTime? DueDate { get; set; }
        /// <summary>
        /// Gets or sets the version number
        /// </summary>
        public int Version { get; set; }
        /// <summary>
        /// Gets or sets the project phase id
        /// </summary>
        public int ProjectPhaseId { get; set; }
        /// <summary>
        /// Gets or sets the project phase
        /// </summary>
        public string ProjectPhase { get; set; }
        /// <summary>
        /// Gets or sets the project custom phase
        /// </summary>
        public string ProjectCustomPhase { get; set; }
    }
}
