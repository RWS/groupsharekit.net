using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class TaskInfo
    {
        public Guid TaskId { get; set; }
        public DateTime? RunAt { get; set; }
        public string RunTime { get; set; }
        public ProjectAnalyseDetails Project { get; set; }
    }
}
