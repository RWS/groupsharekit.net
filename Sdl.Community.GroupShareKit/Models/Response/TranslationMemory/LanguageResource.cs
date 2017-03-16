using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class Resource
    {
        /// <summary>
        /// Gets or sets language resource id
        /// </summary>
        public string LanguageResourceId { get; set; }
        /// <summary>
        /// Gets or sets language resource template id
        /// </summary>
        public string LanguageResourceTemplateId { get; set; }
        /// <summary>
        /// Gets or sets language resource culture name
        /// </summary>
        public string CultureName { get; set; }
        /// <summary>
        /// Gets or sets type
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Gets or sets data
        /// </summary>
        public string Data { get; set; }

    }
}
