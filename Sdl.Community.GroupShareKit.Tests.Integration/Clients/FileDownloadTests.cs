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
        private readonly string ProjectId;
        private readonly List<string> LanguageFileIds;

        public FileDownloadTests()
        {
            var groupShareClient = Helper.GsClient;

            var projectRequest = new ProjectsRequest("/", true, 7) { Page = "0", Limit = "1" };
            var project = groupShareClient.Project.GetProject(projectRequest).Result.Items.LastOrDefault();

            ProjectId = project != null ? project.ProjectId : string.Empty;

            LanguageFileIds = groupShareClient
                .Project
                .GetAllFilesForProject(ProjectId).Result.Where(f => f.FileRole == "Translatable")
                .Select(lf => lf.UniqueId.ToString()).ToList();
        }

        [Fact]
        public async Task DownloadFile()
        {
            var groupShareClient = Helper.GsClient;

            var file = await groupShareClient.Project.DownloadFile(new FileDownloadRequest(ProjectId, null, FileDownloadRequest.Types.All));
            Assert.NotNull(file);
        }

        [Fact]
        public async Task DownloadNative()
        {
            var groupShareClient = Helper.GsClient;
            var file = await groupShareClient.Project.DownloadNative(ProjectId);

            Assert.NotNull(file);
        }

        [Fact]
        public async Task FinalizeFile()
        {
            var groupShareClient = Helper.GsClient;

            var projectFiles = await groupShareClient.Project.GetAllFilesForProject(ProjectId);

            var translatableFileId = projectFiles.FirstOrDefault(f => f.FileRole == "Translatable").UniqueId;
            var languageFileIds = new List<string> { translatableFileId.ToString() };

            var projectPhases = await groupShareClient.Project.GetAllPhasesForProject(ProjectId);
            var finalisationPhase = projectPhases.Single(p => p.Name.Equals("Finalisation", StringComparison.Ordinal));

            var phaseChangeRequest = new[]
            {
                new ChangePhaseRequest.File
                {
                    LanguageFileId = LanguageFileIds.First(),
                    PhaseId = finalisationPhase.ProjectPhaseId
                },
            };

            await groupShareClient.Project.ChangePhases(ProjectId, new ChangePhaseRequest("Changed phase ", phaseChangeRequest));

            var file = await groupShareClient.Project.Finalize(ProjectId, languageFileIds);

            Assert.NotNull(file);
        }

        [Fact]
        public async Task DownloadFiles()
        {
            var groupShareClient = Helper.GsClient;
            var files = await groupShareClient.Project.DownloadFiles(ProjectId, LanguageFileIds);

            Assert.NotNull(files);
        }
    }
}