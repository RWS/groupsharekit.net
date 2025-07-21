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

            var filter = new ActivitiesRequestFilter
            {
                ActivitySources = new List<string> { "Trados GroupShare" }
            }.SerializeFilter();

            var activitiesFilter = new ActivitiesFilter
            {
                Page = 1,
                Start = 0,
                Limit = 2,
                Filter = filter,
                Sort = sortParameters.Stringify(),
            };

            var activities = await GroupShareClient.ActivityClient.GetActivities(activitiesFilter);

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

            var filter = new ActivitiesRequestFilter
            {
                ActivitySources = new List<string> { "Unknown" }
            }.SerializeFilter();

            var activitiesFilter = new ActivitiesFilter
            {
                Page = 1,
                Start = 0,
                Limit = 10,
                Filter = filter,
                Sort = sortParameters.Stringify(),
            };

            var activities = await GroupShareClient.ActivityClient.GetActivities(activitiesFilter);

            Assert.All(activities.Items, activity => Assert.Equal("Unknown", activity.ActivitySource));
        }

        [Fact]
        public async Task GetActivitiesUsingSearchText()
        {
            var sortParameters = new SortParameters
            {
                Property = SortParameters.PropertyOption.LastActivity,
                Direction = SortParameters.DirectionOption.DESC
            };

            var filter = new ActivitiesRequestFilter
            {
                ShowOnlineOnly = false,
                SearchText = "Trados GroupShare"
            }.SerializeFilter();

            var activitiesFilter = new ActivitiesFilter
            {
                Page = 1,
                Start = 0,
                Limit = 3,
                Filter = filter,
                Language = ReportLanguage.En,
                TimeZone = "Europe/Paris",
                Sort = sortParameters.Stringify(),
            };

            var activities = await GroupShareClient.ActivityClient.GetActivities(activitiesFilter);

            Assert.All(activities.Items, activity => Assert.Equal("Trados GroupShare", activity.ActivitySource));
        }

        [Fact]
        public async Task GetActivitiesWithRandomUserGuids()
        {
            var sortParameters = new SortParameters
            {
                Property = SortParameters.PropertyOption.LastActivity,
                Direction = SortParameters.DirectionOption.ASC
            };

            var filter = new ActivitiesRequestFilter
            {
                Users = new List<Guid> { Guid.NewGuid(), Guid.NewGuid() }
            }.SerializeFilter();

            var activitiesFilter = new ActivitiesFilter
            {
                Page = 1,
                Start = 0,
                Limit = 10,
                Filter = filter,
                Language = ReportLanguage.En,
                Sort = sortParameters.Stringify(),
            };

            var activities = await GroupShareClient.ActivityClient.GetActivities(activitiesFilter);

            Assert.Equal(0, activities.Count);
            Assert.Empty(activities.Items);
        }

        [Fact]
        public async Task ExportAllActivities()
        {
            var export = await GroupShareClient.ActivityClient.ExportActivities();

            Assert.NotNull(export);
        }

        [Fact]
        public async Task ExportActivitiesWithFilter()
        {
            var filter = new ActivitiesRequestFilter
            {
                ActivitySources = new List<string> { "Trados GroupShare" }
            }.SerializeFilter();

            var exportFilter = new ExportActivitiesFilter
            {
                Page = 1,
                Limit = 3,
                Filter = filter,
                Language = ReportLanguage.Fr,
                TimeZone = "Europe/Paris"
            };

            var export = await GroupShareClient.ActivityClient.ExportActivities(exportFilter);

            Assert.NotNull(export);
        }

    }
}
