using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Clients;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
     public class OrganizationResourcesTests
    {
         [Theory]
         [InlineData("5bdb10b8-e3a9-41ae-9e66-c154347b8d17")]
         public async Task GetOrganizationResources(string organizationId)
         {
             var grClient =  await Helper.GetAuthenticatedClient();
             var orgResources = await grClient.OrganizationResources.GetAllOrganizationResources(organizationId);

            Assert.True(orgResources.Count>0);
         }

         [Fact]
         public async Task MoveResourceToOrganization()
         {
            var grClient = await Helper.GetAuthenticatedClient();
             var resourceRequest =
                 new OrganizationResourcesRequest(new List<string>() {"bb9c7d71-a7b5-46ba-9f42-47ffd41b80f7"},
                     "5bdb10b8-e3a9-41ae-9e66-c154347b8d17");
             var response = await grClient.OrganizationResources.MoveResourceToOrganization(resourceRequest);

            Assert.Equal(response,string.Empty);
         }
    }
}
