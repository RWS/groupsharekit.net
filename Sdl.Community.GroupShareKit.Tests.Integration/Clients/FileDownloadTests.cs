using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Tests.Integration.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class FileDownloadTests : IClassFixture<IntegrationTestsProjectData>
    {
        private readonly GroupShareClient GroupShareClient = Helper.GsClient;
        private readonly Guid _projectId;
        private readonly List<Guid> _languageFileIds;

        public FileDownloadTests()
        {
            var projectRequest = new ProjectsRequest("/", true, 7) { Page = "0", Limit = "1" };
            var project = GroupShareClient.Project.GetProject(projectRequest).Result.Items.LastOrDefault();

            _projectId = project != null ? Guid.Parse(project.ProjectId) : Guid.Empty;

            _languageFileIds = GroupShareClient
                .Project
                .GetProjectFiles(_projectId).Result.Where(f => f.FileRole == "Translatable")
                .Select(lf => lf.UniqueId).ToList();
        }

        [Fact]
        public async Task DownloadFile()
        {
            var file = await GroupShareClient.Project.DownloadFile(new FileDownloadRequest(_projectId.ToString(), null, FileDownloadRequest.Types.All));
            Assert.NotNull(file);
        }

        [Fact]
        public async Task DownloadNative()
        {
            var file = await GroupShareClient.Project.DownloadNative(_projectId);

            Assert.NotNull(file);
        }

        [Fact]
        public async Task FinalizeFile()
        {
            var projectFiles = await GroupShareClient.Project.GetProjectFiles(_projectId);

            var translatableFileId = projectFiles.First(f => f.FileRole == "Translatable").UniqueId;
            var languageFileIds = new List<Guid> { translatableFileId };

            var projectPhases = await GroupShareClient.Project.GetProjectPhases(_projectId);
            var finalisationPhase = projectPhases.Single(p => p.Name.Equals("Finalisation", StringComparison.Ordinal));

            var phaseChangeRequest = new[]
            {
                new ChangePhaseRequest.File
                {
                    LanguageFileId = _languageFileIds.First().ToString(),
                    PhaseId = finalisationPhase.ProjectPhaseId
                },
            };

            await GroupShareClient.Project.ChangePhase(_projectId, new ChangePhaseRequest("Changed phase ", phaseChangeRequest));

            var file = await GroupShareClient.Project.Finalize(_projectId, languageFileIds);

            Assert.NotNull(file);
        }

        [Fact]
        public async Task DownloadFiles()
        {
            var files = await GroupShareClient.Project.DownloadFiles(_projectId, _languageFileIds);

            Assert.NotNull(files);
        }
    }
}