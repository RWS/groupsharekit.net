using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Tests.Integration.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class ProjectPackageTests : IClassFixture<IntegrationTestsProjectData>
    {
        private readonly GroupShareClient GroupShareClient = Helper.GsClient;
        private readonly Guid _projectId;
        private readonly List<Guid> _languageFileIds;

        public ProjectPackageTests()
        {
            var projectRequest = new ProjectsRequest("/", true, 7) { Page = "0", Limit = "1" };
            var project = GroupShareClient.Project.GetProject(projectRequest).Result.Items.LastOrDefault();

            _projectId = project != null ? Guid.Parse(project.ProjectId) : Guid.Empty;

            _languageFileIds = GroupShareClient
                .Project
                .GetProjectFiles(_projectId).Result.Where(f => f.FileRole == "Translatable" && f.LanguageCode == project.TargetLanguage)
                .Select(lf => lf.UniqueId).ToList();
        }

        [Fact]
        public async Task ExportPackageWithoutLanguageFileIds()
        {
            var taskId = await GroupShareClient.Project.ProjectPackageExport(_projectId, null);
            Assert.NotNull(taskId);
        }

    }
}
