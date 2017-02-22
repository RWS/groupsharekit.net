using System;
using System.Linq;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Models.Response;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class OrganizationClientTests
    {
        [Fact]
        public async Task GetOrganizations()
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();

            var response = await groupShareClient.Organization.GetAll(new OrganizationRequest(false));

            Assert.True(response.Count>0);
        }

        [Theory]
        [InlineData("5bdb10b8-e3a9-41ae-9e66-c154347b8d17")]
        public async Task GetOrganizationById(string organizationId)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();

        

            var organization = await groupShareClient.Organization.Get(organizationId);

            Assert.Equal(organization.UniqueId.ToString(),organizationId);

        }


        [Fact]
        public async Task Update( string organizationId)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();

            var organization = await groupShareClient.Organization.Get(organizationId);

            organization.Name = "Updated Name";
 
            var updatedOrgId=await groupShareClient.Organization.Update(organization);
            var updatedOrganization = await groupShareClient.Organization.Get(updatedOrgId);

             Assert.Equal(updatedOrganization.Name, "Updated Name");
        }

        [Fact]
        public async Task Create()
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
             var organization = new Organization()
             {
                 UniqueId = Guid.NewGuid(),
                 Name = "Test organization",
                 IsLibrary = true,
                 Description = null,
                 Path = null,
                 ParentOrganizationId = new Guid("5bdb10b8-e3a9-41ae-9e66-c154347b8d17"),
                 ChildOrganizations = null
                

             };
            var organizationId = await groupShareClient.Organization.Create(organization);

            Assert.True(organizationId != string.Empty);

            await Update(organizationId);

            await groupShareClient.Organization.DeleteOrganization(organizationId);
        }
    }
}
