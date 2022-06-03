using Sdl.Community.GroupShareKit.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Models.Response;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class PhasesTests
    {
        private readonly string ProjectId;
        private readonly List<string> LanguageFileIds;
        private readonly List<Phase> Phases;

        public PhasesTests()
        {
            var groupShareClient = Helper.GsClient;

            var projectRequest = new ProjectsRequest("/", true, 7) { Page = "0", Limit = "1" };
            var project = groupShareClient.Project.GetProject(projectRequest).Result.Items.FirstOrDefault();

            ProjectId = project != null ? project.ProjectId : string.Empty;

            LanguageFileIds = groupShareClient
                .Project
                .GetAllFilesForProject(ProjectId).Result.Where(f => f.FileRole == "Translatable")
                .Select(lf => lf.UniqueId.ToString()).ToList();

            Phases = groupShareClient
                .Project
                .GetAllPhasesForProject(ProjectId)
                .Result.ToList();
        }

        [Fact]
        public async Task GetProjectPhases()
        {
            var groupShareClient = Helper.GsClient;
            var projectPhases = await groupShareClient.Project.GetAllPhasesForProject(ProjectId);

            Assert.True(projectPhases.Count != 0);
        }

        [Fact]
        public async Task ChangeProjectPhases()
        {
            var groupShareClient = Helper.GsClient;

            var request = new[]
            {
                new ChangePhaseRequest.File
                {
                    LanguageFileId = LanguageFileIds.First(),
                    PhaseId = Phases[1].ProjectPhaseId
                },
            };
            await groupShareClient.Project.ChangePhases(ProjectId, new ChangePhaseRequest("Changed phase ", request));
        }

        [Fact]
        public async Task GetPhasesWithAssignees()
        {
            var groupShareClient = Helper.GsClient;

            var phaseId = Phases[3].ProjectPhaseId;
            var phases = await groupShareClient.Project.GetPhasesWithAssignees(ProjectId, phaseId);

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
                    LanguageFileId = LanguageFileIds.First(),
                    DueDate =  DateTime.Now.AddDays(1),
                    PhaseId = Phases[2].ProjectPhaseId,
                    AssignedUsers = new[] { Helper.GsUser }
                }
            };

            await groupShareClient.Project.ChangeAssignments(ProjectId, new ChangeAssignmentRequest("test assignment", request));
        }
    }
}