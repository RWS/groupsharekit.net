using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class TermbaseTerms
    {
        /// <summary>
        /// Gets or sets attributes
        /// </summary>
        public List<Attributes> Attributes { get; set; }
        /// <summary>
        /// Gets or sets term base entry text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets transactions list
        /// </summary>
        public List<Transactions> Transactions { get; set; }
    }
}
