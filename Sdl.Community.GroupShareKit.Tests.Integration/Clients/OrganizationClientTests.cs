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

            Assert.True(response != null);
        }

        [Fact]
        public async Task GetOrganizationById()
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();

            var organizations = await groupShareClient.Organization.GetAll(new OrganizationRequest(false));

            Assert.True(organizations != null);
            Assert.True(organizations.Count >0, "No organizations for the specified account");

            var expectedOrganization = organizations[0];

            var actualOrganization = await groupShareClient.Organization.Get(expectedOrganization.UniqueId.ToString());

            Assert.True(expectedOrganization.Name.Equals(actualOrganization.Name));

        }


        [Fact]
        public async Task Update()
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();

            var organizations = await groupShareClient.Organization.GetAll(new OrganizationRequest(false));

            organizations[0].Name = "Test API";
            organizations[0].Path = "Test API";
 
            await groupShareClient.Organization.Update(organizations[0]);
            var updatedOrganization = await groupShareClient.Organization.GetAll(new OrganizationRequest(false));

             Assert.Equal(updatedOrganization.First().Name, "Test API");
        }

        [Fact]
        public async Task Create()
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
             var organization = new Organization()
             {
                 UniqueId = Guid.NewGuid(),
                 Name = "Test organization",
                 Description = null,
                 Path = null,
                 ParentOrganizationId = new Guid("c03a0a9e-a841-47ba-9f31-f5963e71bbb7"),
                 ChildOrganizations = null
                

             };
            var organizationId = await groupShareClient.Organization.Create(organization);

            Assert.True(organizationId != null);

            await groupShareClient.Organization.DeleteOrganization(organizationId);
        }
    }
}
