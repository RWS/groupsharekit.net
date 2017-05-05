using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Models.Response;
using Xunit;
using File = System.IO.File;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class ProjectClientTests
    {

        #region Project tests
        [Theory]
        [InlineData("today")]
        public async Task GetProjectByName(string projectName)
        {
            var groupShareClient = await Helper.GetGroupShareClient();

            var projectRequest = new ProjectsRequest("/", true, 7) { Filter = { ProjectName = projectName } };
            var result =
                await
                    groupShareClient.Project.GetProject(projectRequest);

            Assert.True(result.Items[0].Name == projectName);
        }

        [Fact]
        public async Task SortProjectsByName()
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var sortParameters = new SortParameters()
            {
                Property = SortParameters.PropertyOption.ProjectName,
                Direction = SortParameters.DirectionOption.DESC
            };
            var projectRequest = new ProjectsRequest(sortParameters);

            var sortedProjects = await groupShareClient.Project.GetProject(projectRequest);
            Assert.True(sortedProjects.Items[0].Name == "wwww");
        }

        [Theory]
        [InlineData("6472c9e1-b082-4af9-9d1a-361609141974")]
        public async Task GetProjectFiles(string projectId)
        {
            var groupShareClient = await Helper.GetGroupShareClient();


            var projectFiles = await groupShareClient.Project.GetAllFilesForProject(projectId);

            Assert.True(projectFiles.Count > 0);

        }

        [Fact]
        public async Task GetAllProjects()
        {
            var groupShareClient = await Helper.GetGroupShareClient();

            var projects = await groupShareClient.Project.GetAllProjects();

            Assert.True(projects.Count > 0);

        }

        [Theory]
        [InlineData("c1f47d9c-a9dd-4069-b636-3405d4fb98a8")]
        public async Task GetProjectById(string projectId)
        {
            var groupShareClient = await Helper.GetGroupShareClient();

            var actualProject = await groupShareClient.Project.Get(projectId);

            Assert.Equal(actualProject.ProjectId, projectId);
        }

        [Theory]
        [InlineData("SDL Community Developers")]
        public async Task GetProjectsForOrganization(string organizationName)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var projects = groupShareClient.Project.GetProjectsForOrganization(organizationName);

            foreach (var project in projects)
            {
                Assert.Equal(project.OrganizationName, organizationName);
            }
        }

        [Fact]
        public async Task CreateProject()
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var rawData =
                File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\Grammar.zip"));
            var projectName = Guid.NewGuid().ToString();
            var projectId =
                await groupShareClient.Project.CreateProject(new CreateProjectRequest(projectName, "ee72759d-917e-4c60-ba30-1ed595699c4d", null, DateTime.Today, "7bf6410d-58a7-4817-a559-7aa8a3a99aa9", rawData));

            Assert.True(!string.IsNullOrEmpty(projectId));


        }

        [Fact]
        public async Task PublishPackage()
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var rawData =
                File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\ProjectPackage.sdlppx"));
            var createProjectRequest = new CreateProjectRequest("ProjectForPublish", "ee72759d-917e-4c60-ba30-1ed595699c4d", null,
                DateTime.Today, "7bf6410d-58a7-4817-a559-7aa8a3a99aa9", rawData);

            await groupShareClient.Project.PublishPackage(createProjectRequest);
        }
        [Fact]

        public async Task GetProjectsAssignments()
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var projects = await groupShareClient.Project.GetUserAssignments();

            Assert.True(projects.Count > 0);

        }

        [Theory]
        [InlineData("a885af0c-d476-4265-97b3-9ecc8a2b4dc5")]
        public async Task GetProjectAssignmentsById(string projectId)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var fileIds = new List<string>() { "675a1fc6-d7c1-4011-8080-9623ed1e4dec", "f07ed07f-6864-45a0-979e-afcc0fd250a1" };

            var assignments = await groupShareClient.Project.
                GetProjectAssignmentById(projectId, fileIds);

            Assert.True(assignments.Count > 0);

        }

        [Fact]
        public async Task ChangeProjectStatus()
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var projectStatusRequest = new ChangeStatusRequest("c1f47d9c-a9dd-4069-b636-3405d4fb98a8", ChangeStatusRequest.ProjectStatus.Completed);

            await groupShareClient.Project.ChangeProjectStatus(projectStatusRequest);

            var project = await groupShareClient.Project.Get("c1f47d9c-a9dd-4069-b636-3405d4fb98a8");
            Assert.Equal(project.Status, 4);

        }

        [Fact]
        public async Task ChangeProjectStatusDetach()
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var projectStatusRequest = new ChangeStatusRequest("5afaf0b5-05c8-4401-920c-d3366096cfc6", ChangeStatusRequest.ProjectStatus.Completed);
            await groupShareClient.Project.ChangeProjectStatusDetach(projectStatusRequest);

            var project = await groupShareClient.Project.Get("5afaf0b5-05c8-4401-920c-d3366096cfc6");
            Assert.Equal(project.Status, 4);

        }
        #endregion

        #region Project template tests
        [Fact]
        public async Task GetAllProjectsTemplates()
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var templates = await groupShareClient.Project.GetAllTemplates();

            Assert.True(templates.Count > 0);
        }

        [Theory]
        [InlineData("7bf6410d-58a7-4817-a559-7aa8a3a99aa9")]
        public async Task<string> GetTemplateById(string templateId)
        {
            var groupShareClient = await Helper.GetGroupShareClient();

            var template = await groupShareClient.Project.GetTemplateById(templateId);

            Assert.True(template != string.Empty);
            return template;
        }

        [Fact]
        public async Task CreateTemplate()
        {
            var groupShareClient = await Helper.GetGroupShareClient();

            var rawData =
               File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\SampleTemplate.sdltpl"));
            var id = Guid.NewGuid().ToString();
            var templateRequest = new ProjectTemplates(id, "kit", "", "5bdb10b8-e3a9-41ae-9e66-c154347b8d17");
            var templateId = await groupShareClient.Project.CreateTemplate(templateRequest, rawData);

            Assert.True(templateId != string.Empty);

            await groupShareClient.Project.Delete(templateId);
        }
        #endregion

        #region File version tests
        [Theory]
        [InlineData("c6ece69e-baec-46ed-8275-53d848ae3b70")]
        public async Task GetFileVersions(string languageFileId)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var fileVersion = await groupShareClient.Project.GetFileVersions(languageFileId);

            Assert.True(fileVersion.Count > 0);
        }

        [Theory]
        [InlineData("c1f47d9c-a9dd-4069-b636-3405d4fb98a8", "c6ece69e-baec-46ed-8275-53d848ae3b70", 0)]
        public async Task DownloadFileVersion(string projectId, string languageFileId, int version)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var downloadedFile =
                await groupShareClient.Project.DownloadFileVersion(projectId, languageFileId, version);

            Assert.True(downloadedFile.Length != 0);
        }

        #endregion
    }
}
