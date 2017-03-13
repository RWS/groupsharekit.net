using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class SearchResponse
    {
        /// <summary>
        /// Gets or sets a list of terms form termbase 
        /// </summary>
        public List<Term> Terms { get; set; }
        public string Hypermedia { get; set; }
    }
}
