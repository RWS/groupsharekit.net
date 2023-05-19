using System;

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
