using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class OrganizationResourcesRequest
    {
        /// <summary>
        /// Gets or sets the resource id
        /// </summary>
        public List<string> ResourceIds { get; set; }
        /// <summary>
        /// Gets or sets the organization id
        /// </summary>
        public string OrganizationId { get; set; }

        public OrganizationResourcesRequest(List<string> resourceIds, string organizatonId)
        {
            ResourceIds = resourceIds;
            OrganizationId = organizatonId;
        }
    }
}
