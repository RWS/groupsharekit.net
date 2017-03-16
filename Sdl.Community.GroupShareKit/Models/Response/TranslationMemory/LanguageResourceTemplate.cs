using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class LanguageResourceTemplate
    {
        /// <summary>
        /// Gets or sets language resource template id
        /// </summary>
        public string LanguageResourceTemplateId { get; set; }
        /// <summary>
        /// Gets or sets language resource name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets language resource description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets if is tm specific
        /// </summary>
        public bool IsTmSpecific { get; set; }

        /// <summary>
        /// Gets or sets a list of language resources
        /// </summary>
        public List<Resource> LanguageResources { get; set; }
        /// <summary>
        /// Gets or sets language resource location
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// Gets or sets the owner id
        /// </summary>
        public string OwnerId { get; set; }

    }
}
