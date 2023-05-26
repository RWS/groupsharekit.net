using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class ImportDocRequest
    {
        /// <summary>
        /// Gets or sets document details
        /// </summary>
        public TranslationUnitDetailsResponse Document { get; set; }
        /// <summary>
        /// Gets or sets document urls
        /// </summary>
        public List<string> DocumentUrls { get; set; }
        /// <summary>
        /// Gets or sets import settings
        /// </summary>
        public ImportSettings Settings { get; set; }
        /// <summary>
        /// Gets or sets callback url
        /// </summary>
        public string CallbackUrl { get; set; }
    }
}
