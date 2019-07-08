using Sdl.Community.GroupShareKit.Clients;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class FileDownloadTests
    {
        [Fact]
        public async Task DownloadFile()
        {
            var groupShareClient = await Helper.GetGroupShareClient();

            //project id, type
            var file = await groupShareClient.Project.DownloadFile(new FileDownloadRequest("c1f47d9c-a9dd-4069-b636-3405d4fb98a8", null, FileDownloadRequest.Types.All));
            Assert.True(file != null);

            //project id, language code
            var request = await groupShareClient.Project.DownloadFile(new FileDownloadRequest("c1f47d9c-a9dd-4069-b636-3405d4fb98a8", "en-US", null));

            Assert.True(request != null);
        }

        [Fact]
        public async Task DownloadNative()
        {
            var groupShareClient = await Helper.GetGroupShareClient();

            var file = await groupShareClient.Project.DownloadNative("ff139f77-ebf4-41a5-85cd-fa1da47f958f");

            Assert.True(file != null);
        }

        [Theory]
        [InlineData("488e50d3-7098-43c9-a582-bda94ccf25bd")]
        public async Task Finalize(string projectId)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var languageFilesId = new List<string> { "273134d3-3230-4d9f-8669-b30fe9c417ef" };

            var files = await groupShareClient.Project.Finalize(projectId, languageFilesId);

            Assert.True(files != null);
        }

        [Theory]
        [InlineData("c1f47d9c-a9dd-4069-b636-3405d4fb98a8")]
        public async Task DownloadFiles(string projectId)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var languageFilesId = new List<string> { "c6ece69e-baec-46ed-8275-53d848ae3b70", "23ddbfcf-a015-47ff-9e05-f62a3bfb783a" };

            var files = await groupShareClient.Project.DownloadFiles(projectId, languageFilesId);

            Assert.True(files != null);
        }
    }
}