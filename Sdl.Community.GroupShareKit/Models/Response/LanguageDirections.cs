using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class LanguageDirections
    {
        /// <summary>
        /// Gets or sets the language directions id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets source language code
        /// </summary>
        public string SourceLanguageCode { get; set; }

        /// <summary>
        /// Gets or sets target language code
        /// </summary>
        public string TargetLanguageCode { get; set; }
    }
}
