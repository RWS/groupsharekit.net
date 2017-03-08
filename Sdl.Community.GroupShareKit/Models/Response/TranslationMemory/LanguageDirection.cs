using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class LanguageDirection
    {
        /// <summary>
        /// Gets or sets language direction id
        /// </summary>
        public string LanguageDirectionId { get; set; }
        /// <summary>
        /// Gets or sets source language
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// Gets or sets target language
        /// </summary>
        public string Target { get; set; }
        /// <summary>
        /// Gets or sets last recomputed number
        /// </summary>
        public int? LastRecomputeSize { get; set; }
        /// <summary>
        /// Gets or sets  last reindex number
        /// </summary>
        public int? LastReIndexSize { get; set; }
        /// <summary>
        /// Gets or sets last recomputed date
        /// </summary>
        public DateTime? LastRecomputeDate { get; set; }
        /// <summary>
        /// Gets or sets last reindex date
        /// </summary>
        public DateTime? LastReIndexDate { get; set; }
        /// <summary>
        /// Gets or sets tu's number
        /// </summary>
        public int? TuCount { get; set; }
    }
}
