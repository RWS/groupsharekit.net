using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class Termbase
    {
        /// <summary>
        /// Gets or sets the number of termbases
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// Gets or sets a list of termbase informations
        /// </summary>
        public List<TermbaseInformations> Termbases { get; set; }
    }
}
