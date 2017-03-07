using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class FileVersionsClientTests
    {
        [Theory]
        [InlineData("c6ece69e-baec-46ed-8275-53d848ae3b70")]
        public async Task GetFileVersions(string languageFileId)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var fileVersion = await groupShareClient.FileVersion.GetFileVersions(languageFileId);

            Assert.True(fileVersion.Count>0);
        }

        [Theory]
        [InlineData("c1f47d9c-a9dd-4069-b636-3405d4fb98a8", "c6ece69e-baec-46ed-8275-53d848ae3b70",0)]
        public async Task DownloadFileVersion(string projectId, string languageFileId, int version)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var downloadedFile =
                await groupShareClient.FileVersion.DownloadFileVersion(projectId, languageFileId, version);

            Assert.True(downloadedFile.Length!=0);
        }
    }
}
