using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class TranslationUnitDetailsResponse
    {
        /// <summary>
        /// Get or sets the id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Get or sets model version
        /// </summary>
        public string ModelVersion { get; set; }

        /// <summary>
        /// Get or sets name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Get or sets source language code
        /// </summary>
        public string SourceLanguageCode { get; set; }

        /// <summary>
        /// Get or sets target language code
        /// </summary>
        public string TargetLanguageCode { get; set; }

        /// <summary>
        /// Get or sets a list of files
        /// </summary>
        public List<TmFile> Files { get; set; }

        /// <summary>
        /// Gets or sets metadata
        /// </summary>
        public Metadata Metadata { get; set; }
    }
}
