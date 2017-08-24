using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class TaskReport
    {
        public string Name { get; set; }
        public TaskInfo TaskInfo { get; set; }
        public BatchTotal BatchTotal { get; set; }
        public List<FileAnalyse> File { get; set; }
    }
}
