using System;
using System.Collections.Generic;
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

        [Theory]
        [InlineData("5bdb10b8-e3a9-41ae-9e66-c154347b8d17")]
        public async Task GetOrganizationResources(string organizationId)
        {
            var grClient = await Helper.GetAuthenticatedClient();
            var orgResources = await grClient.Organization.GetAllOrganizationResources(organizationId);

            Assert.True(orgResources.Count > 0);
        }

        [Theory]
        [InlineData("10356fd8-a087-4676-a320-d72c8f1fa0bd")]
        public async Task MoveResourceToOrganization(string organizartionId)
        {
            var grClient = await Helper.GetAuthenticatedClient();
            var resourceRequest =
                new OrganizationResourcesRequest(new List<string>() { "bb9c7d71-a7b5-46ba-9f42-47ffd41b80f7" },
                    organizartionId);
            await grClient.Organization.MoveResourceToOrganization(resourceRequest);

            var resources = await grClient.Organization.GetAllOrganizationResources(organizartionId);
            var addedResource = resources.FirstOrDefault(r => r.Id.ToString() == "bb9c7d71-a7b5-46ba-9f42-47ffd41b80f7");
            Assert.True(addedResource != null);

        }

        [Theory]
        [InlineData("10356fd8-a087-4676-a320-d72c8f1fa0bd")]
        public async Task LinkResourceToOrganization(string organizationId)
        {
            var grClient = await Helper.GetAuthenticatedClient();
            var resourceRequest =
                new OrganizationResourcesRequest(new List<string>() { "78df3807-06ac-438e-b2c8-5e233df1a6a2", "388d8bd2-f47d-4051-a951-95225f73dfe8" },
                    organizationId);

            await grClient.Organization.LinkResourceToOrganization(resourceRequest);

            var organizationResources = await grClient.Organization.GetAllOrganizationResources(organizationId);
             Assert.True(organizationResources.Count >0);

            await grClient.Organization.UnlinkResourceToOrganization(resourceRequest);

            var resources = await grClient.Organization.GetAllOrganizationResources(organizationId);
            Assert.Equal(resources.Count, 0);
        }

    }
}
