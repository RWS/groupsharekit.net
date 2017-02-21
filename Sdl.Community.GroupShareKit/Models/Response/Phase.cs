using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class Phase
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public int ProjectPhaseId { get; set; }
        public List<string> Assignees { get; set; }
    }
}