using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Clients;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
   public class Children
    {
        /// <summary>
        /// Gets or sets the id
        /// </summary>
       public string Id { get; set; }
        /// <summary>
        /// Gets or sets type
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Gets or sets metadata
        /// </summary>
        public Metadata Metadata { get; set; }
    }
}
