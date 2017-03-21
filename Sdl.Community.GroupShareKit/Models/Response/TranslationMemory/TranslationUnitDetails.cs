using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class TranslationUnitDetails
    {
        /// <summary>
        /// Gets or sets the source language details
        /// </summary>
        public LanguageDetails Source { get; set; }
        /// <summary>
        /// Gets or sets target language details
        /// </summary>
        public LanguageDetails Target { get; set; }
    }
}
