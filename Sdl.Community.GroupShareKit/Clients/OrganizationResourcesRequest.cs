using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class OrganizationResourcesRequest 
    {
        public List<string> ResourceIds { get; set; }
        public string OrganizationId { get; set; }

        public OrganizationResourcesRequest(List<string> resurceIds, string organizatonId)
        {
            ResourceIds = resurceIds;
            OrganizationId = organizatonId;
        }
    }
}
