using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class PublishingStatusClientTests
    {
        [Theory]
        [InlineData("c1f47d9c-a9dd-4069-b636-3405d4fb98a8")]
        public async Task PublishingStatusProject(string projectId)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();

            var project = await groupShareClient.Project.PublishingStatus(projectId);

            Assert.True(project != null);
        }
    }
}
