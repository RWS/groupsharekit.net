using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class FilesTest
    {

        [Theory]
        [InlineData("6472c9e1-b082-4af9-9d1a-361609141974")]
        public async Task GetProjectFiles(string projectId)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();


            var projectFiles = await groupShareClient.Project.GetAllFilesForProject(projectId);

            Assert.True(projectFiles.Count > 0);

        }

    }
}
