using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class Assignment
    {
        public DateTime? DueDate { get; set; }
        public int Version { get; set; }
        public int ProjectPhaseId { get; set; }
        public string ProjectPhase { get; set; }
        public string ProjectCustomPhase { get; set; }
    }
}
