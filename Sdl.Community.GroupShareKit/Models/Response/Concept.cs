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
        public Entry EntryClass { get; set; }
        public  List<Attribute> Attributes { get; set; }
        public List<TermbaseLanguages> Languages { get; set; }
        public List<Transactions> Transactions { get; set; }

    }

    public class Entry
    {
        public string  Id { get; set; }
    }
}
