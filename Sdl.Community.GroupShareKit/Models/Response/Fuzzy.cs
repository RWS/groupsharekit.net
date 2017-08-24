using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
   public  class Fuzzy
    {
        public string Min { get; set; }
        public string Max { get; set; }
        public string Segments { get; set; }
        public string Words { get; set; }
        public string Characters { get; set; }
        public string Placeables { get; set; }
        public string Tags { get; set; }
    }

}
