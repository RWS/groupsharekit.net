using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class Documents
    {
        /// <summary>
        /// Gets or sets the source language
        /// </summary>
        public string SourceLanguage { get; set; }
        /// <summary>
        /// Gets or sets the target language
        /// </summary>
        public string TargetLanguage { get; set; }
        /// <summary>
        /// Gets or sets the document url
        /// </summary>
        public string Url { get; set; }
    }
}
