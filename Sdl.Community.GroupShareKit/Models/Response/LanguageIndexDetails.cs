using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class LanguageIndexDetails
    {
        /// <summary>
        /// Gets or sets language name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets terms number 
        /// </summary>
        public int? TermCount { get; set; }
        /// <summary>
        /// Gets or sets entry number
        /// </summary>
        public int? EntryCount { get; set; }
    }
}
