using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public OrganizationResourcesRequest(List<string> resurceIds, string organizatonId)
        {
            ResourceIds = resurceIds;
            OrganizationId = organizatonId;
        }
    }
}
