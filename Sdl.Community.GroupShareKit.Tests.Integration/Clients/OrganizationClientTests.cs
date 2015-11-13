using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Clients;
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
    }
}
