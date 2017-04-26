using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class Attributes
    {
        public string Id     { get; set; }
        public string Name { get; set; }
        public string Delete { get; set; }
        public List<Types> Value { get; set; }
       // public List<Attributes> Attributes { get; set; }
    }

    public class Types
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }
}
