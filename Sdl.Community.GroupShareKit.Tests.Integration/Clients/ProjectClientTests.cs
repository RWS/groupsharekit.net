using System;
using System.IO;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Clients;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class ProjectClientTests
    {

        [Fact]
        public async Task GetOrganizationProjects()
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();

            var result =
                await
                    groupShareClient.Project.GetAllProjectsForOrganization(new ProjectsRequest(Helper.TestOrganization,
                        true));

            Assert.True(result != null);

        }

        [Fact]
        public async Task GetProjectFiles()
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();

            var projects =
                await
                    groupShareClient.Project.GetAllProjectsForOrganization(new ProjectsRequest(Helper.TestOrganization,
                        true));

            Assert.True(projects != null);
            Assert.True(projects.Count > 0, "There are no projects available");

            var project = projects[0];

            var projectFiles = await groupShareClient.Project.GetAllFilesForProject(project.ProjectId.ToString());

            Assert.True(projectFiles != null);

        }

        [Fact]
        public async Task GetProjectPhases()
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();

            var projects =
                await
                    groupShareClient.Project.GetAllProjectsForOrganization(new ProjectsRequest(Helper.TestOrganization,
                        true));

            Assert.True(projects != null);
            Assert.True(projects.Count > 0, "There are no projects available");

            var project = projects[0];

            var projectPhases = await groupShareClient.Project.GetAllPhasesForProject(project.ProjectId.ToString());

            Assert.True(projectPhases != null);
        }

        [Fact]
        public async Task CreateProject()
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var rawData =
                File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\ProjectPackage.sdlppx"));

            var projectId =
                await groupShareClient.Project.CreateProject(new CreateProjectRequest("ProjectPackage.sdlppx",
                    "c03a0a9e-a841-47ba-9f31-f5963e71bbb7", rawData));

            Assert.True(!string.IsNullOrEmpty(projectId));

            await groupShareClient.Project.DeleteProject(projectId);
        }

        [Fact]
        public async Task GetProject()
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();

            var projects =
                await
                    groupShareClient.Project.GetAllProjectsForOrganization(new ProjectsRequest(Helper.TestOrganization,
                        true));

            Assert.True(projects != null);
            Assert.True(projects.Count > 0, "There are no projects available");

            var project = projects[0];

            var actualProject = await groupShareClient.Project.Get(project.ProjectId.ToString());

            Assert.True(actualProject.ProjectId.Equals(project.ProjectId));
        }
    }
}
