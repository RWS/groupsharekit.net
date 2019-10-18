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
        private readonly string ProjectId;
        private readonly string LanguageFileId;
        private readonly string ProjectTemplateId;

        public ProjectClientTests()
        {
            var groupShareClient = Helper.GsClient;

            var projectRequest = new ProjectsRequest("/", true, 7) { Page = "0", Limit = "1" };
            var project = groupShareClient.Project.GetProject(projectRequest).Result.Items.FirstOrDefault();

            ProjectId = project != null ? project.ProjectId : string.Empty;

            var languageFile = groupShareClient.Project.GetAllFilesForProject(ProjectId).Result.FirstOrDefault(f => f.FileRole == "Translatable");
            LanguageFileId = languageFile != null ? languageFile.UniqueId.ToString() : string.Empty;

            var projectTemplate = groupShareClient.Project.GetAllTemplates().Result.ToList().FirstOrDefault();
            ProjectTemplateId = projectTemplate != null ? projectTemplate.Id : string.Empty;
        }

        #region Project tests
        [Fact]
        public async Task Projects_GetProjectByName_Succeeds()
        {
            var groupShareClient = Helper.GsClient;
            var projects = await groupShareClient.Project.GetAllProjects();
            var project = projects.Items.FirstOrDefault();

            if (project == null)
                return;

            var projectRequest = new ProjectsRequest("/", true, 7) { Filter = { ProjectName = project.Name } };
            var result = await groupShareClient.Project.GetProject(projectRequest);

            Assert.True(result.Items[0].Name == project.Name);
        }

        [Fact]
        public async Task Projects_SortProjectsByName_Succeeds()
        {
            var groupShareClient = Helper.GsClient;
            var sortParameters = new SortParameters
            {
                Property = SortParameters.PropertyOption.ProjectName,
                Direction = SortParameters.DirectionOption.ASC
            };
            var projectRequest = new ProjectsRequest(sortParameters);

            var sortedProjects = await groupShareClient.Project.GetProject(projectRequest);
            var projects = await groupShareClient.Project.GetAllProjects();

            Assert.True(sortedProjects.Items.Count == projects.Items.Count);

            var projectsNames = projects.Items.Select(p => p.Name).ToList();
            projectsNames.Sort();

            int i = 0;
            foreach (var proj in sortedProjects.Items)
            {
                Assert.True(string.Compare(proj.Name, projectsNames[i++], StringComparison.CurrentCultureIgnoreCase) == 0);
            }
        }

        [Fact]
        public async Task Projects_GetProjectFiles_Succeeds()
        {
            var groupShareClient = Helper.GsClient;
            var projects = await groupShareClient.Project.GetAllProjects();
            var project = projects.Items.FirstOrDefault();

            var projectFiles = await groupShareClient.Project.GetAllFilesForProject(project.ProjectId);

            Assert.True(projectFiles.Count > 0);
        }

        [Fact]
        public async Task Projects_GetAllProjects_Succeeds()
        {
            var groupShareClient = Helper.GsClient;
            var projects = await groupShareClient.Project.GetAllProjects();
            Assert.True(projects.Count > 0);
        }

        [Fact]
        public async Task Projects_AnalysisReports_Succeeds()
        {
            var groupShareClient = Helper.GsClient;
            var report = await groupShareClient.Project.GetAnalysisReports(ProjectId, null);
            Assert.True(report.Count > 0);
        }

        [Fact]
        public async Task Projects_AnalysisReportsAsHtml_Succeeds()
        {
            var groupShareClient = Helper.GsClient;
            var report = await groupShareClient.Project.GetAnalysisReportsAsHtml(ProjectId, null);
            Assert.True(report != null);
        }

	    [Fact]
	    public async Task Projects_GetProjectSettings_Succeeds()
	    {
		    var groupShareClient = Helper.GsClient;
		    var projectSettings = await groupShareClient.Project.GetProjectSettings(ProjectId, LanguageFileId);

			Assert.True(projectSettings!=null);
	    }

        [Fact]
		public async Task Projects_IsUserAuthorizedToOpenTheFile_Succeeds()
	    {
		    var groupShareClient = Helper.GsClient;
		    var response = await groupShareClient.Project.IsUserAuthorizedToOpenFile(ProjectId, LanguageFileId);

		    Assert.True(string.IsNullOrEmpty(response));
	    }

        [Fact]
	    public async Task Projects_EditorProfile_Succeeds()
	    {
		    var groupShareClient = Helper.GsClient;
		    var editorProfile = await groupShareClient.Project.EditorProfile(ProjectId, LanguageFileId);

		    Assert.True(editorProfile!=null);
	    }

        [Fact]
	    public async Task Projects_IsCheckOutToSomeoneElse_Succeeds()
	    {
		    var groupShareClient = Helper.GsClient;
		    await groupShareClient.Project.IsCheckoutToSomeoneElse(LanguageFileId);  
	    }

		//[Fact(Skip = "")]
		//public async Task Projects_OnlineCheckIn_Succeeds()
		//{
		//	var groupShareClient = Helper.GsClient;	 

		//	var response =await groupShareClient.Project.OnlineCheckin(ProjectId, LanguageFileId).ConfigureAwait(true);
		//	Assert.True(response!=null);
		//}

        //[Fact]
        //public async Task OnlineCheckout()
        //{
        //    var groupShareClient = Helper.GsClient;

        //    var checkoutResponse = await groupShareClient.Project.OnlineCheckout(ProjectId, LanguageFileId);
        //    Assert.True(checkoutResponse != null);

        //    await groupShareClient.Project.UndoCheckout(ProjectId, LanguageFileId);
        //}

        //[Fact(Skip = "")]
        //public async Task ExternalCheckIn()
        //{
        //    var groupShareClient = Helper.GsClient;

        //    var response = await groupShareClient.Project.ExternalCheckout(ProjectId, LanguageFileId);
        //    Assert.True(response != null);
        //    await groupShareClient.Project.ExternalCheckin(ProjectId, LanguageFileId, "comment");
        //}

        [Fact]
	    public async Task Dashboard()
	    {
			var groupShareClient = Helper.GsClient;
		    var dashboard = await groupShareClient.Project.Dashboard();
			Assert.True(dashboard!=null);
	    }

        [Fact]
	    public async Task AuditTrial()
	    {
			var groupShareClient = Helper.GsClient;
		    var auditTrial = await groupShareClient.Project.AuditTrial(ProjectId);

			Assert.True(auditTrial?.Count>0);  
	    }

		[Fact]
	    public async Task OnlineCheckoutHealthCheck()
	    {
			var groupShareClient = Helper.GsClient;
		    var response = await groupShareClient.Project.OnlineCheckoutHealthCheck();
		    Assert.True(response != null);
	    }

		[Fact]
        public async Task GetProjectById()
        {
            var groupShareClient = Helper.GsClient;

            var projects = await groupShareClient.Project.GetAllProjects();
            var project = projects.Items.FirstOrDefault();		  

	        if (project != null)
	        {
		        var actualProject = await groupShareClient.Project.Get(project.ProjectId);

		        Assert.Equal(actualProject.ProjectId, project.ProjectId);
	        }
        }

		
        // test fails because of a bug that has to be fixed in the REST API
        //[Fact]
        //public async Task GetProjectLanguageStatistics()
        //{
        //    var groupShareClient = Helper.GsClient;

        //    var projects = await groupShareClient.Project.GetAllProjects();
        //    var project = projects.Items.FirstOrDefault();

        //    var response = await groupShareClient.Project.GetProjectLanguageStatistics(project.ProjectId);

        //    Assert.Equal(response.Keys.First(), "en-US");
        //}

        [Fact]
        public async Task GetProjectFileStatistics()
        {
            var groupShareClient = Helper.GsClient;

            var projects = await groupShareClient.Project.GetAllProjects();
            var project = projects.Items.FirstOrDefault();

            var response = await groupShareClient.Project.GetAllProjectFileStatistics(project.ProjectId);

            Assert.True(response.Count > 0);
        }

        [Theory]
        [InlineData("SDL Community Developers")]
        public void GetProjectsForOrganization(string organizationName)
        {
            var groupShareClient = Helper.GsClient;
            var projects = groupShareClient.Project.GetProjectsForOrganization(organizationName);

            foreach (var project in projects)
            {
                Assert.Equal(project.OrganizationName, organizationName);
            }
        }

        [Fact]
        public async Task<string> CreateProject()
        {
            var groupShareClient = Helper.GsClient;

            var projectRequest = new ProjectsRequest("/", true, 7) { Filter = { ProjectName = "today" } };
            var result = await groupShareClient.Project.GetProject(projectRequest);

            if (result.Items.Count == 0)
            {
                var rawData = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\Grammar.zip"));
                var projectName = $"Project - {Guid.NewGuid()}";

                var projectId = await groupShareClient.Project.CreateProject(new CreateProjectRequest(
                    projectName,
                    Helper.OrganizationId,
                    null,
                    DateTime.Now.AddDays(2),
                    ProjectTemplateId,
                    rawData));

                Assert.True(!string.IsNullOrEmpty(projectId));

                return projectId;
            }
            return null;
        }

        [Fact(Skip = "Used to work until GroupShare 2017 CU7")]
        public async Task PublishPackage()
        {
            var groupShareClient = Helper.GsClient;
            var rawData = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\ProjectPackage.sdlppx"));
            var createProjectRequest = new CreateProjectRequest(
                "ProjectForPublish",
                Helper.OrganizationId,
                null,
                DateTime.Today,
                "7bf6410d-58a7-4817-a559-7aa8a3a99aa9",
                rawData);

            await groupShareClient.Project.PublishPackage(createProjectRequest);
        }

        [Fact]
        public async Task GetProjectsAssignments()
        {
            var groupShareClient = Helper.GsClient;
            var projects = await groupShareClient.Project.GetUserAssignments();

            Assert.True(projects.Count > 0);
        }

        [Fact]
        public async Task GetProjectAssignmentsById()
        {
            var groupShareClient = Helper.GsClient;
            var fileIds = new List<string> { LanguageFileId };

            var assignments = await groupShareClient.Project.GetProjectAssignmentById(ProjectId, fileIds);

            Assert.True(assignments.Count > 0);
        }

        [Fact]
        public async Task ChangeProjectStatus()
        {
            var groupShareClient = Helper.GsClient;

            var projectStatusRequest = new ChangeStatusRequest(ProjectId, ChangeStatusRequest.ProjectStatus.Completed);
            await groupShareClient.Project.ChangeProjectStatus(projectStatusRequest);

            var project = await groupShareClient.Project.Get(ProjectId);
            Assert.Equal(4, project.Status);

            projectStatusRequest = new ChangeStatusRequest(ProjectId, ChangeStatusRequest.ProjectStatus.Started);
            await groupShareClient.Project.ChangeProjectStatus(projectStatusRequest);

            project = await groupShareClient.Project.Get(ProjectId);
            Assert.Equal(2, project.Status);
        }

        [Fact]
        public async Task ChangeProjectStatusDetach()
        {
            var groupShareClient = Helper.GsClient;

            var projectStatusRequest = new ChangeStatusRequest(ProjectId, ChangeStatusRequest.ProjectStatus.Completed);
            await groupShareClient.Project.ChangeProjectStatusDetach(projectStatusRequest);

            var project = await groupShareClient.Project.Get(ProjectId);
            Assert.Equal(4, project.Status);

            projectStatusRequest = new ChangeStatusRequest(ProjectId, ChangeStatusRequest.ProjectStatus.Started);
            await groupShareClient.Project.ChangeProjectStatus(projectStatusRequest);
        }
        #endregion

        #region Project template tests

        [Fact]
        public async Task GetAllProjectsTemplates()
        {
            var groupShareClient = Helper.GsClient;
            var templates = await groupShareClient.Project.GetAllTemplates();

            Assert.True(templates.Count > 0);
        }

        [Fact]
        public async Task<string> GetTemplateById()
        {
            var groupShareClient = Helper.GsClient;

            var template = await groupShareClient.Project.GetTemplateById(ProjectTemplateId);

            Assert.True(template != string.Empty);
            return template;
        }

        [Fact]
        public async Task CreateTemplate()
        {
            var groupShareClient = Helper.GsClient;
            var rawData = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\SampleTemplate.sdltpl"));

            var id = Guid.NewGuid().ToString();
			var templateName = Guid.NewGuid().ToString();
            var templateRequest = new ProjectTemplates(id, templateName, "", Helper.OrganizationId);
            var templateId = await groupShareClient.Project.CreateTemplate(templateRequest, rawData);

            Assert.True(templateId != string.Empty);

            await groupShareClient.Project.Delete(templateId);
        }
        #endregion

        #region File version tests
        [Fact]
        public async Task GetFileVersions()
        {
            var groupShareClient = Helper.GsClient;
            var fileVersion = await groupShareClient.Project.GetFileVersions(LanguageFileId);

            Assert.True(fileVersion.Count > 0);
        }

        [Fact]
        public async Task DownloadFileVersion()
        {
            var groupShareClient = Helper.GsClient;
            var downloadedFile = await groupShareClient.Project.DownloadFileVersion(ProjectId, LanguageFileId, 2);

            Assert.True(downloadedFile.Length != 0);
        }
        #endregion
    }
}