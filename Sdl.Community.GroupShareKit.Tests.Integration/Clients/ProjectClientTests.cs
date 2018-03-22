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
        [Fact]
        public async Task GetProjectByName()
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            //  var project = await GetProject(groupShareClient);
            var projects = await groupShareClient.Project.GetAllProjects();
            var project = projects.Items.FirstOrDefault();

            var projectRequest = new ProjectsRequest("/", true, 7) { Filter = { ProjectName = project.Name } };
            var result =
                await
                    groupShareClient.Project.GetProject(projectRequest);

            Assert.True(result.Items[0].Name == project.Name);
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
            var projects = await groupShareClient.Project.GetAllProjects();
            Assert.True(sortedProjects.Items.Count == projects.Items.Count);
        }

        [Fact]
        public async Task GetProjectFiles()
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var projects = await groupShareClient.Project.GetAllProjects();
            var project = projects.Items.FirstOrDefault();

            var projectFiles = await groupShareClient.Project.GetAllFilesForProject(project.ProjectId);

            Assert.True(projectFiles.Count > 0);

        }

        [Fact]
        public async Task GetAllProjects()
        {
            var groupShareClient = await Helper.GetGroupShareClient();

            var projects = await groupShareClient.Project.GetAllProjects();

            Assert.True(projects.Count > 0);

        }

        [Fact]
        public async Task AnalysisReports()
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var report = await groupShareClient.Project.GetAnalysisReports("522dde85-7f5b-4aa5-a4d9-af97d78798f2", null);
                    Assert.True(report.Count > 0);
        }

        [Fact]
        public async Task AnalysisReportsAsHtml()
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            // var report = await groupShareClient.Project.GetAnalysisReportsAsHtml("522dde85-7f5b-4aa5-a4d9-af97d78798f2", "en-US");
            var report = await groupShareClient.Project.GetAnalysisReportsAsHtml("522dde85-7f5b-4aa5-a4d9-af97d78798f2",null);
            Assert.True(report!=null);
        }

        //[Fact]
        //public async Task AnalysisReports()
        //{
        //    var groupShareClient = await Helper.GetGroupShareClient();
        //    var projectId = await CreateProject();
        //    if (!string.IsNullOrEmpty(projectId))
        //    {
        //        var report = await groupShareClient.Project.GetAnalysisReports(projectId, "en-US");
        //        Assert.True(report.Count > 0);

        //        int publishingStatus;

        //        do
        //        {
        //            var statusResponse = await groupShareClient.Project.PublishingStatus(projectId);
        //            publishingStatus = statusResponse.Status;
        //        } while (publishingStatus != 3);

        //        await groupShareClient.Project.DeleteProject(projectId);
        //    }
        //}


        [Fact]
        public async Task GetProjectById()
        {
            var groupShareClient = await Helper.GetGroupShareClient();

            var projects = await groupShareClient.Project.GetAllProjects();
            var project = projects.Items.FirstOrDefault();


            var actualProject = await groupShareClient.Project.Get(project.ProjectId);

            Assert.Equal(actualProject.ProjectId, project.ProjectId);
        }
        // test fails because of a bug that has to be fixed in the REST API

        //[Fact]
        //public async Task GetProjectLanguageStatistics()
        //{
        //    var groupShareClient = await Helper.GetGroupShareClient();

        //    var projects = await groupShareClient.Project.GetAllProjects();
        //    var project = projects.Items.FirstOrDefault();

        //    var response = await groupShareClient.Project.GetProjectLanguageStatistics(project.ProjectId);

        //    Assert.Equal(response.Keys.First(), "en-US");
        //}

        [Fact]
        public async Task GetProjectFileStatistics()
        {
            var groupShareClient = await Helper.GetGroupShareClient();

            var projects = await groupShareClient.Project.GetAllProjects();
            var project = projects.Items.FirstOrDefault();

            var response = await groupShareClient.Project.GetAllProjectFileStatistics(project.ProjectId);

            Assert.True(response.Count > 0);
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

        //[Fact]
        public async Task<string> CreateProject()
        {
            var groupShareClient = await Helper.GetGroupShareClient();

            var projectRequest = new ProjectsRequest("/", true, 7) { Filter = { ProjectName = "today" } };
            var result =
                await
                    groupShareClient.Project.GetProject(projectRequest);
            if (result.Items.Count ==0)
            {
                var rawData =
                File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\Grammar.zip"));
                var projectName = Guid.NewGuid().ToString();
                var projectId =
                    await groupShareClient.Project.CreateProject(new CreateProjectRequest(projectName, "ee72759d-917e-4c60-ba30-1ed595699c4d", null, DateTime.Today, "7bf6410d-58a7-4817-a559-7aa8a3a99aa9", rawData));

                Assert.True(!string.IsNullOrEmpty(projectId));
                return projectId;
            }
            return null;
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


        //private static async Task<ProjectDetails> GetProject(GroupShareClient groupShareClient)
        //{
        //    var projects = await groupShareClient.Project.GetAllProjects();
        //    return projects.Items.FirstOrDefault();
        //}

    }
}
