using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class TermbaseLanguages
    {
        public Language Language { get; set; }
        public List<TermbaseTerms> Terms { get; set; }
        public List<Attribute> Attributes { get; set; }
    }
}
