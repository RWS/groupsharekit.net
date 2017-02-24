using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class ProjectAssignment
    {
        public int PhaseId { get; set; }
        public DateTime? DueDate { get; set; }
        public List<UserDetails> Assignees { get; set; }
    }
}
