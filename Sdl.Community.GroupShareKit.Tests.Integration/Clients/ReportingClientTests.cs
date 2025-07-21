using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Models;
using Sdl.Community.GroupShareKit.Tests.Integration.Setup;
using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class ReportingClientTests : IClassFixture<IntegrationTestsProjectData>
    {
        private readonly GroupShareClient GroupShareClient = Helper.GsClient;

        [Fact]
        public async Task PredefinedProjectsData()
        {
            var filters = new PredefinedReportsFilters
            {
                ShowAll = true,
                Status = 7
            };

            var reportingData = await GroupShareClient.Reporting.PredefinedProjects(filters);
            Assert.True(reportingData.Count > 0);
        }

        [Fact]
        public async Task PredefinedProjectsDataV2()
        {
            var filters = new PredefinedReportsFiltersV2
            {
                ShowAll = true,
                Status = 31,
                OrderBy = "projectName",
                SortDirection = "ASC",
                Page = 1,
                PageSize = 3
            };

            var reportingData = await GroupShareClient.Reporting.PredefinedProjectsV2(filters);
            Assert.True(reportingData.Count > 0);
            Assert.True(reportingData.Items.Length <= 3);
        }

        [Fact]
        public async Task PredefinedTasksData()
        {
            var filters = new PredefinedReportsFilters
            {
                ShowAll = true,
                Status = 7
            };

            var reportingData = await GroupShareClient.Reporting.PredefinedTasks(filters);
            Assert.True(reportingData.Count > 0);
        }

        [Fact]
        public async Task PredefinedTasksDataV2()
        {
            var filters = new PredefinedReportsFiltersV2
            {
                ShowAll = true,
                Status = 31,
                OrderBy = "DueDate",
                SortDirection = "DESC",
                Page = 1,
                PageSize = 5
            };

            var reportingData = await GroupShareClient.Reporting.PredefinedTasksV2(filters);
            Assert.True(reportingData.Count > 0);
            Assert.True(reportingData.Items.Length <= 5);
        }

        [Fact]
        public async Task PredefinedTmLeverageData()
        {
            var filters = new PredefinedReportsFilters
            {
                ShowAll = true,
                Status = 7
            };

            var reportingData = await GroupShareClient.Reporting.PredefinedTmLeverage(filters);
            Assert.True(reportingData.Count > 0);
        }

        [Fact]
        public async Task DeliveriesDueSoonData()
        {
            var sortParameters = new ReportingServiceSortingParameters
            {
                OrderBy = "DueDate",
                OrderDirection = "DESC"
            };

            var reportingData = await GroupShareClient.Reporting.DeliveriesDueSoon(sortParameters);
            Assert.True(reportingData.Items.Count > 0);
            Assert.True(reportingData.Count > 0);
        }

        [Fact]
        public async Task YourTasksData()
        {
            var sortParameters = new ReportingServiceSortingParameters
            {
                OrderBy = "DueDate",
                OrderDirection = "DESC"
            };

            var reportingData = await GroupShareClient.Reporting.YourTasks(sortParameters);
            Assert.True(reportingData.Count > 0);
        }

        [Fact]
        public async Task ProjectsPerMonthData()
        {
            var reportingData = await GroupShareClient.Reporting.ProjectsPerMonth();
            Assert.True(reportingData.Count > 0);
        }

        [Fact]
        public async Task WordsPerMonthData()
        {
            var reportingData = await GroupShareClient.Reporting.WordsPerMonth();
            Assert.True(reportingData.Count > 0);
        }

        [Fact]
        public async Task TopLanguagePairsData()
        {
            var reportingData = await GroupShareClient.Reporting.TopLanguagePairs();
            Assert.True(reportingData.Count > 0);
        }

        [Fact]
        public async Task WordsPerOrganizationData()
        {
            var reportingData = await GroupShareClient.Reporting.WordsPerOrganization();
            Assert.True(reportingData.Count > 0);
        }

        [Fact]
        public async Task ExportPredefinedReports()
        {
            var filters = new ExportPredefinedReportsFilters
            {
                ShowAll = true,
                Status = 31,
                Language = ReportLanguage.Fr,
                TimeZone = "Europe/Paris"
            };

            var export = await GroupShareClient.Reporting.ExportPredefinedReports(filters);
            Assert.NotNull(export);
        }

        [Fact]
        public async Task DashboardProjectsPerMonth()
        {
            var projectCounts = await GroupShareClient.Reporting.DashboardProjectsPerMonth();

            Assert.NotNull(projectCounts);
        }

        [Fact]
        public async Task DashboardTopLanguagePairs()
        {
            var languagePairs = await GroupShareClient.Reporting.DashboardTopLanguagePairs();

            Assert.NotNull(languagePairs);
        }

        [Fact]
        public async Task DashboardWordsPerMonth()
        {
            var wordCounts = await GroupShareClient.Reporting.DashboardWordsPerMonth();

            Assert.NotNull(wordCounts);
        }

        [Fact]
        public async Task DashboardWordsPerOrganization()
        {
            var wordCounts = await GroupShareClient.Reporting.DashboardWordsPerOrganization();

            Assert.NotNull(wordCounts);
        }

        [Fact]
        public async Task DashboardStatistics()
        {
            var statistics = await GroupShareClient.Reporting.DashboardStatistics();

            Assert.NotNull(statistics);
            Assert.True(statistics.NoOfOrganizations > 0);
            Assert.True(statistics.NoOfUsers > 0);
        }
    }
}
