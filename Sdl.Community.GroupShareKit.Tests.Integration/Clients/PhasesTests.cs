using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Clients;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class PhasesTests
    {
        [Theory]
        [InlineData("6472c9e1-b082-4af9-9d1a-361609141974")]
        public async Task GetProjectPhases(string projectId)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();



            var projectPhases = await groupShareClient.Project.GetAllPhasesForProject(projectId);

            Assert.True(projectPhases.Count != 0);
        }
        [Theory]
        [InlineData("a885af0c-d476-4265-97b3-9ecc8a2b4dc5")]
        public async Task ChangeProjectPhases(string projectId)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();

            var request = new[]
            {
                new ChangePhaseRequest.File()
                {
                    LanguageFileId = "f07ed07f-6864-45a0-979e-afcc0fd250a1",
                    PhaseId = 38
                },
            };

                await
                    groupShareClient.Project.ChangePhases(projectId,
                        new ChangePhaseRequest("Changed phase ", request));
       
        }


        [Theory]
        [InlineData("a885af0c-d476-4265-97b3-9ecc8a2b4dc5", 37)]
        public async Task GetPhasesWithAssignees(string projectId, int phaseId)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var phases = await groupShareClient.Project.GetPhasesWithAssignees(projectId, phaseId);

            foreach (var projectPhase in phases.SelectMany(phase => phase.Phases))
            {
                Assert.Equal(projectPhase.ProjectPhaseId, 37);
            }

        }

        [Theory]
        [InlineData("a885af0c-d476-4265-97b3-9ecc8a2b4dc5", "f07ed07f-6864-45a0-979e-afcc0fd250a1")]
        public async Task ChangeProjectAssignments(string projectId, string fileId)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();


            var request = new[]
            {
                new ChangeAssignmentRequest.File()
                {
                    LanguageFileId =fileId,
                    DueDate =  DateTime.Now.AddDays(1),
                    PhaseId = 37,
                    AssignedUsers = new[] { "sdlcommunity" }
                }
            };
                await
                    groupShareClient.Project.ChangeAssignments(projectId,
                        new ChangeAssignmentRequest("test assignement", request));
        }

    }
}
