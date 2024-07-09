using System;
using System.Linq;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Tests.Integration.Setup;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class PublishingStatusClientTests : IClassFixture<IntegrationTestsProjectData>
    {
        private readonly GroupShareClient GroupShareClient = Helper.GsClient;
        private readonly Guid _projectId;

        public PublishingStatusClientTests()
        {
            var projectRequest = new ProjectsRequest("/", true, 7) { Page = "0", Limit = "1" };
            var project = GroupShareClient.Project.GetProject(projectRequest).Result.Items.FirstOrDefault();

            _projectId = project != null ? Guid.Parse(project.ProjectId) : Guid.Empty;
        }

        [Fact]
        public async Task PublishingStatusProject()
        {
            var project = await GroupShareClient.Project.GetPublishingStatus(_projectId);

            Assert.NotNull(project);
        }
    }
}