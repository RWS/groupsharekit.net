using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class OrganizationResources
    {
        /// <summary>
        /// Gets or sets the organization resource id
        /// </summary>
        public Guid  Id { get; set; }
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }
        /// <summary> 
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the resource type
        /// </summary>
        public string ResourceType { get; set; }
        /// <summary>
        /// Gets or sets the parent organization id
        /// </summary>
        public string ParentOragnizationId { get; set; }
        /// <summary>
        /// Gets or sets the linked organizations ids
        /// </summary>
        public List<string> LinkedOragnizationIds { get; set; }
    }
}
