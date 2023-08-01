using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Tests.Integration.Setup;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{

    public class ReportingClientTests : IClassFixture<IntegrationTestsProjectData>
    {
        [Fact]
        public async Task PredefinedProjectsData()
        {
            var groupShareClient = Helper.GsClient;
            var filters = new PredefinedReportsFilters
            {
                ShowAll = true,
                Status = 7
            };

            var reportingData = await groupShareClient.Reporting.PredefinedProjects(filters);
            Assert.True(reportingData.Count > 0);
        }

        [Fact]
        public async Task PredefinedProjectsDataV2()
        {
            var groupShareClient = Helper.GsClient;
            var filters = new PredefinedReportsFilters
            {
                ShowAll = true,
                Status = 31,
                OrderBy = "projectName",
                SortDirection = "ASC",
                Page = 1,
                PageSize = 3
            };

            var reportingData = await groupShareClient.Reporting.PredefinedProjectsV2(filters);
            Assert.True(reportingData.Count > 0);
            Assert.True(reportingData.Items.Count() <= 3);
        }

        [Fact]
        public async Task PredefinedTasksData()
        {
            var groupShareClient = Helper.GsClient;
            var filters = new PredefinedReportsFilters
            {
                ShowAll = true,
                Status = 7
            };

            var reportingData = await groupShareClient.Reporting.PredefinedTasks(filters);
            Assert.True(reportingData.Count > 0);
        }

        [Fact]
        public async Task PredefinedTasksDataV2()
        {
            var groupShareClient = Helper.GsClient;
            var filters = new PredefinedReportsFilters
            {
                ShowAll = true,
                Status = 31,
                OrderBy = "DueDate",
                SortDirection = "DESC",
                Page = 1,
                PageSize = 5
            };

            var reportingData = await groupShareClient.Reporting.PredefinedTasksV2(filters);
            Assert.True(reportingData.Count > 0);
            Assert.True(reportingData.Items.Count() <= 5);
        }

        [Fact]
        public async Task PredefinedTmLeverageData()
        {
            var groupShareClient = Helper.GsClient;
            var filters = new PredefinedReportsFilters
            {
                ShowAll = true,
                Status = 7
            };

            var reportingData = await groupShareClient.Reporting.PredefinedTmLeverage(filters);
            Assert.True(reportingData.Count > 0);
        }

        [Fact]
        public async Task DeliveriesDueSoonData()
        {
            var groupShareClient = Helper.GsClient;
            var sortParameters = new ReportingServiceSortingParameters
            {
                OrderBy = "DueDate",
                OrderDirection = "DESC"
            };

            var reportingData = await groupShareClient.Reporting.DeliveriesDueSoon(sortParameters);
            Assert.True(reportingData.Items.Count > 0);
            Assert.True(reportingData.Count > 0);
        }

        [Fact]
        public async Task YourTasksData()
        {
            var groupShareClient = Helper.GsClient;
            var sortParameters = new ReportingServiceSortingParameters
            {
                OrderBy = "DueDate",
                OrderDirection = "DESC"
            };

            var reportingData = await groupShareClient.Reporting.YourTasks(sortParameters);
            Assert.True(reportingData.Count > 0);
        }

        [Fact]
        public async Task ProjectsPerMonthData()
        {
            var groupShareClient = Helper.GsClient;

            var reportingData = await groupShareClient.Reporting.ProjectsPerMonth();
            Assert.True(reportingData.Count > 0);
        }

        [Fact]
        public async Task WordsPerMonthData()
        {
            var groupShareClient = Helper.GsClient;

            var reportingData = await groupShareClient.Reporting.WordsPerMonth();
            Assert.True(reportingData.Count > 0);
        }

        [Fact]
        public async Task TopLanguagePairsData()
        {
            var groupShareClient = Helper.GsClient;

            var reportingData = await groupShareClient.Reporting.TopLanguagePairs();
            Assert.True(reportingData.Count > 0);
        }

        [Fact]
        public async Task WordsPerOrganizationData()
        {
            var groupShareClient = Helper.GsClient;

            var reportingData = await groupShareClient.Reporting.WordsPerOrganization();
            Assert.True(reportingData.Count > 0);
        }

        [Fact]
        public async Task ExportPredefinedReports()
        {
            var groupShareClient = Helper.GsClient;
            var filters = new PredefinedReportsFilters
            {
                ShowAll = true,
                Status = 31
            };

            var export = await groupShareClient.Reporting.ExportPredefinedReports(filters);
            Assert.NotNull(export);
        }
    }
}
