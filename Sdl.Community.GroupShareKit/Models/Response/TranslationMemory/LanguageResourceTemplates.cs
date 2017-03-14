using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class LanguageResourceTemplates
    {
        /// <summary>
        /// Gets or sets a list of language resource templates
        /// </summary>
        public List<LanguageResourceTemplate> Items { get; set; }
        /// <summary>
        /// Gets or sets number of language resource templates
        /// </summary>
        public int? Count { get; set; }
    }
}
