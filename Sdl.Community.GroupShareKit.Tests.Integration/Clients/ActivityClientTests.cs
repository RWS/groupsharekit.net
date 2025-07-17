using Sdl.Community.GroupShareKit.Clients.Activities;
using Sdl.Community.GroupShareKit.Models;
using Sdl.Community.GroupShareKit.Tests.Integration.Setup;
using System.Collections.Generic;
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
            Assert.NotNull(activities);
        }

        [Fact]
        public async Task GetFilteredActivities()
        {
            var sortParameters = new SortParameters
            {
                Property = SortParameters.PropertyOption.LastActivity,
                Direction = SortParameters.DirectionOption.DESC
            };

            var filter = new ActivitiesRequestFilter { ActivitySources = new List<string> { "Trados GroupShare", "Trados Studio" } }.SerializeFilter();

            var activities = await GroupShareClient.ActivityClient.GetActivities(page: 1, start: 0, limit: 2, sort: sortParameters.Stringify(), filter: filter);
            Assert.True(activities.Items.Length <= 2);
        }

    }
}
