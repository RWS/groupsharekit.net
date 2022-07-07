using System.Collections.Generic;

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
