using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Tests.Integration.Setup;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class FileDownloadTests : IClassFixture<IntegrationTestsProjectData>
    {
        private readonly string ProjectId;
        private readonly List<string> LanguageFileIds;

        public FileDownloadTests()
        {
            var groupShareClient = Helper.GsClient;

            var projectRequest = new ProjectsRequest("/", true, 7) { Page = "0", Limit = "1" };
            var project = groupShareClient.Project.GetProject(projectRequest).Result.Items.FirstOrDefault();

            ProjectId = project != null ? project.ProjectId : string.Empty;

            LanguageFileIds = groupShareClient
                .Project
                .GetAllFilesForProject(ProjectId).Result.Where(f => f.FileRole == "Translatable")
                .Select(lf => lf.UniqueId.ToString()).ToList();
        }

        [Fact]
        public async Task DownloadFile()
        {
            var groupShareClient = Helper.GsClient;

            var file = await groupShareClient.Project.DownloadFile(new FileDownloadRequest(ProjectId, null, FileDownloadRequest.Types.All));
            Assert.True(file != null);
        }

        [Fact]
        public async Task DownloadNative()
        {
            var groupShareClient = Helper.GsClient;
            var file = await groupShareClient.Project.DownloadNative(ProjectId);

            Assert.True(file != null);
        }

        //[Theory]
        //[InlineData("c1f47d9c-a9dd-4069-b636-3405d4fb98a8")]
        //public async Task Finalize(string projectId)
        //{
        //    var groupShareClient = Helper.GsClient;
        //    var languageFilesId = new List<string> { "23ddbfcf-a015-47ff-9e05-f62a3bfb783a" };

        //    var files = await groupShareClient.Project.Finalize(projectId, languageFilesId);

        //    Assert.True(files != null);
        //}

        [Fact]
        public async Task DownloadFiles()
        {
            var groupShareClient = Helper.GsClient;
            var files = await groupShareClient.Project.DownloadFiles(ProjectId, LanguageFileIds);

            Assert.True(files != null);
        }
    }
}