using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class PermissionClientTest
    {
        [Fact]
        public async Task GetAll()
        {
            var groupShareClient = Helper.GsClient;
            var response = await groupShareClient.Permission.GetAll();

            Assert.True(response.Count > 0);
        }

        [Fact]
        public async Task GetAllPermissionsName()
        {
            var grClient = Helper.GsClient;
            var response = await grClient.Permission.GetUsersPermisions();

            Assert.True(response.Count > 0);
        }
    }
}