using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Tests.Integration.Setup;
using System.IO;
using System.Text;
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

            byte[] byteArray = Encoding.UTF8.GetBytes(export.ToString());
            File.WriteAllBytes("C:\\Temp\\ExportGSKit.xlsx", byteArray);

            using (FileStream fileStream = new FileStream("C:\\Temp\\ExportGSKit_1.xlsx", FileMode.Create, FileAccess.Write))
            {
                fileStream.Write(byteArray, 0, byteArray.Length);
            }
        }
    }
}
