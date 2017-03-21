using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class StructureTagDefinition
    {
        /// <summary>
        /// Gets or sets the id
        /// </summary> 
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets display text
        /// </summary>
        public string DisplayText { get; set; }
        /// <summary>
        /// Gets or sets  tag content
        /// </summary>
        public string TagContent { get; set; }
        /// <summary>
        /// Gets or sets  metadata
        /// </summary>
        public Metadata Metadata { get; set; }
        /// <summary>
        /// Gets or sets a list of subcontent
        /// </summary>
        public List<SubContent> SubContent { get; set; }
    }
}
