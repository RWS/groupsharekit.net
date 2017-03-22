using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class ImportResponse
    {
        /// <summary>
        /// Gets or sets the status
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Get or sets the id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets translation memory id
        /// </summary>
        public string TranslationMemoryId { get; set; }
        /// <summary>
        /// Gets or sets settings
        /// </summary>
        public ImportSettings Settings { get; set; }


    }
}
