using Sdl.Community.GroupShareKit.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Models.Response;
using Xunit;
using Sdl.Community.GroupShareKit.Tests.Integration.Setup;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class PhasesTests : IClassFixture<IntegrationTestsProjectData>
    {
        private readonly GroupShareClient GroupShareClient = Helper.GsClient;
        private readonly Guid _projectId;
        private readonly List<Guid> _languageFileIds;
        private readonly List<Phase> _phases;

        public PhasesTests()
        {
            var projectRequest = new ProjectsRequest("/", true, 7) { Page = "0", Limit = "1" };
            var project = GroupShareClient.Project.GetProject(projectRequest).Result.Items.FirstOrDefault();

            _projectId = project != null ? Guid.Parse(project.ProjectId) : Guid.Empty;

            _languageFileIds = GroupShareClient
                .Project
                .GetProjectFiles(_projectId).Result.Where(f => f.FileRole == "Translatable")
                .Select(lf => lf.UniqueId).ToList();

            _phases = GroupShareClient
                .Project
                .GetProjectPhases(_projectId)
                .Result.ToList();
        }

        [Fact]
        public async Task GetProjectPhases()
        {
            var projectPhases = await GroupShareClient.Project.GetProjectPhases(_projectId);

            Assert.NotEmpty(projectPhases);
        }

        [Fact]
        public async Task ChangeProjectPhases()
        {
            var languageFile = (await GroupShareClient.Project.GetProjectFiles(_projectId)).First(f => f.FileRole == "Translatable");

            var currentPhaseId = languageFile.Assignment.ProjectPhaseId;
            var newPhaseId = _phases.First(p => p.ProjectPhaseId != currentPhaseId).ProjectPhaseId;

            var request = new[]
            {
                new ChangePhaseRequest.File
                {
                    LanguageFileId = _languageFileIds.First().ToString(),
                    PhaseId = newPhaseId
                },
            };

            await GroupShareClient.Project.ChangePhase(_projectId, new ChangePhaseRequest("Changed phase ", request));

            var updatedLanguageFile = (await GroupShareClient.Project.GetProjectFiles(_projectId)).First(f => f.UniqueId == languageFile.UniqueId);
            Assert.Equal(newPhaseId, updatedLanguageFile.Assignment.ProjectPhaseId);
        }

        [Fact]
        public async Task GetPhasesWithAssignees()
        {
            var phaseId = _phases[3].ProjectPhaseId;
            var phases = await GroupShareClient.Project.GetPhasesWithAssignees(_projectId, phaseId);

            foreach (var projectPhase in phases.SelectMany(phase => phase.Phases))
            {
                Assert.Equal(phaseId, projectPhase.ProjectPhaseId);
            }
        }

        [Fact]
        public async Task ChangeProjectAssignments()
        {
            var request = new[]
            {
                new ChangeAssignmentRequest.File
                {
                    LanguageFileId = _languageFileIds.First().ToString(),
                    DueDate =  DateTime.Now.AddDays(1),
                    PhaseId = _phases[2].ProjectPhaseId,
                    AssignedUsers = new[] { Helper.GsUser }
                }
            };

            await GroupShareClient.Project.ChangeAssignment(_projectId, new ChangeAssignmentRequest("test assignment", request));
        }
    }
}