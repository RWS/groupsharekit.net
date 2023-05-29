using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class ParagraphUnitLanguageDetails
    {
        /// <summary>
        /// Gets or sets the id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets the type
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Gets or sets metadata
        /// </summary>
        public Metadata Metadata { get; set; }
        /// <summary>
        /// Gets or sets children information
        /// </summary>
        public List<Children> Children { get; set; }
    }
}
