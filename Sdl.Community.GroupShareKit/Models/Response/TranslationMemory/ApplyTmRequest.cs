using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class ApplyTmRequest
    {
        /// <summary>
        /// Gets or sets a list of documents
        /// </summary>
        public List<Documents> Documents { get; set; }
        /// <summary>
        /// Gets or sets a list of translation memories names
        /// </summary>
        public List<string> TranslationMemories { get; set; }
        /// <summary>
        /// Gets or sets callback url
        /// </summary>
        public string CallbackUrl { get; set; }
    }
}
