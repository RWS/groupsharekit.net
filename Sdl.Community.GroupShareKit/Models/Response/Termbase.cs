using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class Termbase
    {
        /// <summary>
        /// Gets or sets the number of termbases
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// Gets or sets a list of termbase information
        /// </summary>
        public List<TermbaseInformations> Termbases { get; set; }
    }
}
