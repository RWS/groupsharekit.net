using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Http;
using Sdl.Community.GroupShareKit.Models.Response;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class OrganizationResourcesClient: ApiClient,IOrganizationResourcesClient
    {
        public OrganizationResourcesClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }
        public async Task<IReadOnlyList<OrganizationResources>> GetAllOrganizationResources(string organizationId)
        {
            return await ApiConnection.GetAll<OrganizationResources>(ApiUrls.OrganizationsResources(organizationId));
        }

        public Task<string> MoveResourceToOrganization(OrganizationResourcesRequest request)
        {
            return  ApiConnection.Put<string>(ApiUrls.OrganizationsResources(), request);
        }
    }
}
