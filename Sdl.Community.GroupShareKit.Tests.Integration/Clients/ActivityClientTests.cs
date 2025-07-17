using Sdl.Community.GroupShareKit.Clients.Activities;
using Sdl.Community.GroupShareKit.Models;
using Sdl.Community.GroupShareKit.Tests.Integration.Setup;
using System;
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

            var filter = new ActivitiesRequestFilter { 
                ActivitySources = new List<string> { "Trados GroupShare" }
            }.SerializeFilter();

            var activities = await GroupShareClient.ActivityClient.GetActivities(page: 1, start: 0, limit: 2, sort: sortParameters.Stringify(), filter: filter);

            Assert.True(activities.Items.Length <= 2);
            Assert.All(activities.Items, activity => Assert.Equal("Trados GroupShare", activity.ActivitySource));
        }

        [Fact]
        public async Task GetActivitiesWithUnknownSource()
        {
            var sortParameters = new SortParameters
            {
                Property = SortParameters.PropertyOption.LastActivity,
                Direction = SortParameters.DirectionOption.DESC
            };

            var filter = new ActivitiesRequestFilter { 
                ActivitySources = new List<string> { "Unknown" }
            }.SerializeFilter();

            var activities = await GroupShareClient.ActivityClient.GetActivities(page: 1, start: 0, limit: 10, sort: sortParameters.Stringify(), filter: filter);

            Assert.All(activities.Items, activity => Assert.Equal("Unknown", activity.ActivitySource));
        }

        [Fact]
        public async Task GetActivitiesWithRandomUserGuids()
        {
            var sortParameters = new SortParameters
            {
                Property = SortParameters.PropertyOption.UserDisplayName,
                Direction = SortParameters.DirectionOption.ASC
            };

            var filter = new ActivitiesRequestFilter
            {
                Users = new List<Guid> { Guid.NewGuid(), Guid.NewGuid() }
            }.SerializeFilter();

            var activities = await GroupShareClient.ActivityClient.GetActivities(page: 1, start: 0, limit: 10, sort: sortParameters.Stringify(), filter: filter);

            Assert.Equal(0, activities.Count);
            Assert.Empty(activities.Items);
        }

    }
}
