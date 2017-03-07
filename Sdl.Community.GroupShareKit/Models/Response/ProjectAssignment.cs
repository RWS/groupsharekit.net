using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class ProjectAssignment
    {
        /// <summary>
        /// Gets or sets the phase id
        /// </summary>
        public int PhaseId { get; set; }
        /// <summary>
        /// Gets or sets the due date
        /// </summary>
        public DateTime? DueDate { get; set; }
        /// <summary>
        /// Gets or sets a list of assignees <see cref="UserDetails"/>
        /// </summary>
        public List<UserDetails> Assignees { get; set; }
    }
}
