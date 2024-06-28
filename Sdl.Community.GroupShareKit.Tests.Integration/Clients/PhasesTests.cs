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
        private readonly Guid _projectId;
        private readonly List<Guid> _languageFileIds;
        private readonly List<Phase> _phases;

        public PhasesTests()
        {
            var groupShareClient = Helper.GsClient;

            var projectRequest = new ProjectsRequest("/", true, 7) { Page = "0", Limit = "1" };
            var project = groupShareClient.Project.GetProject(projectRequest).Result.Items.FirstOrDefault();

            _projectId = project != null ? Guid.Parse(project.ProjectId) : Guid.Empty;

            _languageFileIds = groupShareClient
                .Project
                .GetProjectFiles(_projectId).Result.Where(f => f.FileRole == "Translatable")
                .Select(lf => lf.UniqueId).ToList();

            _phases = groupShareClient
                .Project
                .GetProjectPhases(_projectId)
                .Result.ToList();
        }

        [Fact]
        public async Task GetProjectPhases()
        {
            var groupShareClient = Helper.GsClient;
            var projectPhases = await groupShareClient.Project.GetProjectPhases(_projectId);

            Assert.NotEmpty(projectPhases);
        }

        [Fact]
        public async Task ChangeProjectPhases()
        {
            var groupShareClient = Helper.GsClient;

            var request = new[]
            {
                new ChangePhaseRequest.File
                {
                    LanguageFileId = _languageFileIds.First().ToString(),
                    PhaseId = _phases[1].ProjectPhaseId
                },
            };

            await groupShareClient.Project.ChangePhase(_projectId, new ChangePhaseRequest("Changed phase ", request));
        }

        [Fact]
        public async Task GetPhasesWithAssignees()
        {
            var groupShareClient = Helper.GsClient;

            var phaseId = _phases[3].ProjectPhaseId;
            var phases = await groupShareClient.Project.GetPhasesWithAssignees(_projectId, phaseId);

            foreach (var projectPhase in phases.SelectMany(phase => phase.Phases))
            {
                Assert.Equal(phaseId, projectPhase.ProjectPhaseId);
            }
        }

        [Fact]
        public async Task ChangeProjectAssignments()
        {
            var groupShareClient = Helper.GsClient;

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

            await groupShareClient.Project.ChangeAssignment(_projectId, new ChangeAssignmentRequest("test assignment", request));
        }
    }
}