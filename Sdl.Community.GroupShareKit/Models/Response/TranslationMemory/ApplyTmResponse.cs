using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class ApplyTmResponse
    {
        /// <summary>
        /// Gets or sets the id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets a list of status
        /// </summary>
        public List<StatusDetails> Status { get; set; }
        
    }

    public class StatusDetails
    {
        /// <summary>
        /// Gets or sets url
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// Gets or sets the status
        /// </summary>
        public string Status { get; set; }
    }
}
