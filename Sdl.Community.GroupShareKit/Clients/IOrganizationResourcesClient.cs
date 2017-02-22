using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Models.Response;

namespace Sdl.Community.GroupShareKit.Clients
{
   public  interface IOrganizationResourcesClient
    {
        Task<IReadOnlyList<OrganizationResources>> GetAllOrganizationResources(string organizationId);

       Task<string> MoveResourceToOrganization(OrganizationResourcesRequest request);
    }
}
