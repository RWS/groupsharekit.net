using Sdl.Community.GroupShareKit.Clients;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class PublishingStatusClientTests
    {
        [Fact]
        public async Task PublishingStatusProject()
        {
            var groupShareClient = Helper.GsClient;
            var projectRequest = new ProjectsRequest("/", true, 7) { Page = "0", Limit = "1" };
            var project = groupShareClient.Project.GetProject(projectRequest).Result.Items.FirstOrDefault();
            var projectId = project != null ? project.ProjectId : string.Empty;
            var publishingStatus = await groupShareClient.Project.PublishingStatus(projectId);

            Assert.True(publishingStatus != null);
        }
    }
}