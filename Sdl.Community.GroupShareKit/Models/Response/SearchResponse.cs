using System.Collections.Generic;

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
