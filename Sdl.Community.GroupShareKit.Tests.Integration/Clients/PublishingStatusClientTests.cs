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
        [InlineData("3d7211e8-8b76-4f88-a76c-2ff4509f22c8")]
        public async Task PublishingStatusProject(string projectId)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();

            var project = await groupShareClient.Project.PublishingStatus(projectId);

            Assert.True(project != null);
        }
    }
}
