using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
   public  class Fuzzy
    {
        public string MinimumMatchValue { get; set; }
        public string MaximumMatchValue { get; set; }
        public string Segments { get; set; }
        public string Words { get; set; }
        public string Chars { get; set; }
        public string Placeables { get; set; }
        public string Tags { get; set; }
    }

}
