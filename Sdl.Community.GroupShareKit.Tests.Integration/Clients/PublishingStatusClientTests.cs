using System.Linq;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Clients;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class PublishingStatusClientTests
    {
        private readonly string ProjectId;

        public PublishingStatusClientTests()
        {
            var groupShareClient = Helper.GsClient;

            var projectRequest = new ProjectsRequest("/", true, 7) { Page = "0", Limit = "1" };
            var project = groupShareClient.Project.GetProject(projectRequest).Result.Items.FirstOrDefault();

            ProjectId = project != null ? project.ProjectId : string.Empty;
        }

        [Fact]
        public async Task PublishingStatusProject()
        {
            var groupShareClient = Helper.GsClient;
            var project = await groupShareClient.Project.PublishingStatus(ProjectId);

            Assert.True(project != null);
        }
    }
}