using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response.MultiTerm
{
    public class TermbasesV2
    {
        public int Count { get; set; }

        public IEnumerable<TermbaseListModelV2> Items { get; set; }
    }
}
