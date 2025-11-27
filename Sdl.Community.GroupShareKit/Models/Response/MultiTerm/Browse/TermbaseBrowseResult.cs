using System;
using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response.MultiTerm.Browse
{
    public class TermbaseBrowseResult
    {
        public IEnumerable<FoundTerm> Terms { get; set; }

        public string Index { get; set; }

        public Guid TermbaseGuid { get; set; }
    }
}
