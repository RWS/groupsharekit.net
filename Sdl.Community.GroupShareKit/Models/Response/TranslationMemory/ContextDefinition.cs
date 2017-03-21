using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class ContextDefinition
    {
        /// <summary>
        /// Gets or sets the id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets if is tm context
        /// </summary>
        public bool IsTmContext { get; set; }
        /// <summary>
        /// Gets or sets if is structure context
        /// </summary>
        public bool IsStructureContext { get; set; }
        /// <summary>
        /// Gets or sets type id
        /// </summary>
        public string TypeId { get; set; }
        /// <summary>
        /// Gets or sets display name
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// Gets or sets display code
        /// </summary>
        public string DisplayCode { get; set; }
        /// <summary>
        /// Gets or sets description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets formating group id
        /// </summary>
        public int FormatingGroupId { get; set; }
        /// <summary>
        /// Gets or sets metadata
        /// </summary>
        public Metadata Metadata { get; set; }
    }
}
