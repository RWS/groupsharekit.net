using Sdl.Community.GroupShareKit.Tests.Integration.Setup;
using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class ActivityClientTests : IClassFixture<IntegrationTestsProjectData>
    {
        private readonly GroupShareClient GroupShareClient = Helper.GsClient;

        [Fact]
        public async Task GetAllActivities()
        {
            var activities = await GroupShareClient.ActivityClient.GetActivities();
        }

    }
}
