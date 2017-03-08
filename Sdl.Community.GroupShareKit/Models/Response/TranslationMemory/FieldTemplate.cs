using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class FieldTemplate
    {
        /// <summary>
        /// Gets or sets field template id
        /// </summary>
        public string FieldTemplateId { get; set; }
        /// <summary>
        /// Gets or sets name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets if is tm specific
        /// </summary>
        public bool IsTmSpecific { get; set; }
        /// <summary>
        /// Gets or sets a fields list
        /// </summary>
        public List<Field> Field { get; set; }
    }
}
