using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Clients;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class LanguageParameters:RequestParameters
    {
        /// <summary>
        /// Gets or sets source language
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// Gets or sets target language
        /// </summary>
        public string Target { get; set; }

        public LanguageParameters(string source,string target)
        {
            Source = source;
            Target = target;
        }
    }
}
