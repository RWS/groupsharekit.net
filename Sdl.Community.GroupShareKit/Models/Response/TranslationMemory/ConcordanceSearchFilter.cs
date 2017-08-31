using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class ConcordanceSearchFilter
    {
        public string Name { get; set; }
        public FieldFilterRequest Expression { get; set; }
        public int Penalty { get; set; }
    }
}
