using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class Concept
    {
        public string  Id { get; set; }
        public EntryClass EntryClass { get; set; }
        public  Attributes Attributes { get; set; }
        public List<TermbaseLanguages> TermbaseLanguages { get; set; }
    }
}
