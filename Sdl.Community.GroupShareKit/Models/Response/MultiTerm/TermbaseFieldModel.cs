using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response.MultiTerm
{
    public class TermbaseFieldModel
    {
        public bool AllowMultipleValues { get; set; }

        public IEnumerable<string> PickListValues { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Id { get; set; }

        public bool Mandatory { get; set; }

        public bool AllowCustomValues { get; set; }
    }
}
