using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class TermbaseTerms
    {
        /// <summary>
        /// Gets or sets attributes
        /// </summary>
        public List<Attribute> Attributes { get; set; }
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
