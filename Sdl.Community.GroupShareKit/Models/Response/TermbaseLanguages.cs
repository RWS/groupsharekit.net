using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class TermbaseLanguages
    {
        public Language Language { get; set; }
        public List<TermbaseTerms> Terms { get; set; }
        public List<Attributes> Attributes { get; set; }
    }
}
