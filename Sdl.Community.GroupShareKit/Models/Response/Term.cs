using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class Term
    {
        /// <summary>
        /// Gets or sets term text
        /// </summary>
        public string TermText { get; set; }
        /// <summary>
        /// Gets or sets contept id
        /// </summary>
        public string ConceptId { get; set; }
        /// <summary>
        /// Gets or sets termbaseId (the name of the termsbase is the id)
        /// </summary>
        public string TermbaseId { get; set; }
    }
}
