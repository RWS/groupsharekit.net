using Sdl.Community.GroupShareKit.Models.Response;
using System.Collections.Generic;
using Attribute = Sdl.Community.GroupShareKit.Models.Response.Attribute;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class ConceptRequest
    {
        public List<TermbaseLanguages> Languages { get; set; }
        public List<Transactions> Transactions { get; set; }
        public List<Attribute> Attributes { get; set; }
    }
}
