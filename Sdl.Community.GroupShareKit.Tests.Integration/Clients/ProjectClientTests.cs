﻿using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Models;
using Sdl.Community.GroupShareKit.Models.Response;
using Sdl.Community.GroupShareKit.Tests.Integration.Setup;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using File = System.IO.File;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class ProjectClientTests : IClassFixture<IntegrationTestsProjectData>
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
            {
                return;
            }

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
            var reports = await groupShareClient.Project.GetAnalysisReports(ProjectId, null);
            Assert.True(reports.Count > 0);
        }

        [Fact]
        public async Task Projects_AnalysisReportsAsHtml_Succeeds()
        {
            var groupShareClient = Helper.GsClient;
            var report = await groupShareClient.Project.GetAnalysisReportsAsHtml(ProjectId, null);
            Assert.True(report != null);
        }

        [Fact]
        public async Task Projects_AnalysisReportsAsXml_Succeeds()
        {
            var groupShareClient = Helper.GsClient;
            var report = await groupShareClient.Project.GetAnalysisReportsAsXml(ProjectId, null);
            Assert.True(report != null);
        }

        [Fact]
        public async Task Projects_GetProjectSettings_Succeeds()
        {
            var groupShareClient = Helper.GsClient;
            var projectSettings = await groupShareClient.Project.GetProjectSettings(ProjectId, LanguageFileId);

            Assert.True(projectSettings != null);
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

            Assert.True(editorProfile != null);
        }

        [Fact]
        public async Task Projects_IsCheckOutToSomeoneElseBasicOnlineEditorMode_Succeeds()
        {
            var groupShareClient = Helper.GsClient;
            var editorProfileMode = OnlineCheckout.EditorProfileMode.Basic.ToString();
            await groupShareClient.Project.IsCheckoutToSomeoneElse(LanguageFileId, editorProfileMode);
        }

        [Fact]
        public async Task Projects_IsCheckOutToSomeoneElseAdvancedOnlineEditorMode_Succeeds()
        {
            var groupShareClient = Helper.GsClient;
            var editorProfileMode = OnlineCheckout.EditorProfileMode.Advanced.ToString();
            await groupShareClient.Project.IsCheckoutToSomeoneElse(LanguageFileId, editorProfileMode);
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
            Assert.True(dashboard != null);
        }

        [Fact]
        public async Task AuditTrial()
        {
            var groupShareClient = Helper.GsClient;
            var auditTrial = await groupShareClient.Project.AuditTrial(ProjectId);

            Assert.True(auditTrial?.Count > 0);
        }

        [Fact]
        public async Task OnlineCheckoutHealthCheckBasicOnlineEditorMode()
        {
            var groupShareClient = Helper.GsClient;
            var editorProfileMode = OnlineCheckout.EditorProfileMode.Basic.ToString();
            var response = await groupShareClient.Project.OnlineCheckoutHealthCheck(editorProfileMode);
            Assert.True(response != null);
        }

        [Fact]
        public async Task OnlineCheckoutHealthCheckAdvancedOnlineEditorMode()
        {
            var groupShareClient = Helper.GsClient;
            var editorProfileMode = OnlineCheckout.EditorProfileMode.Advanced.ToString();
            var response = await groupShareClient.Project.OnlineCheckoutHealthCheck(editorProfileMode);
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
        public async Task CreateProject()
        {
            var groupShareClient = Helper.GsClient;
            var projectTemplateId = await CreateTestProjectTemplate(groupShareClient);
            var projectId = await CreateTestProject(groupShareClient, projectTemplateId);

            Assert.True(!string.IsNullOrEmpty(projectId));

            await DeleteTestProject(groupShareClient, projectId);
            await DeleteTestProjectTemplate(groupShareClient, projectTemplateId);
        }

        [Fact]
        public async Task Projects_AddTranslatableFileToExistingProjectUsingZip_Succeeds()
        {
            var groupShareClient = Helper.GsClient;
            var projectTemplateId = await CreateTestProjectTemplate(groupShareClient);
            var projectId = await CreateTestProject(groupShareClient, projectTemplateId);

            var result = await groupShareClient.Project.AddFiles(projectId, @"Resources\TwoFiles.zip");

            Assert.True(result.CreateBackgroundTask);
            Assert.Empty(result.ResponseText);

            await DeleteTestProject(groupShareClient, projectId);
            await DeleteTestProjectTemplate(groupShareClient, projectTemplateId);
        }

        [Fact]
        public async Task Projects_AddTranslatableFileToExistingProject_Succeeds()
        {
            var groupShareClient = Helper.GsClient;
            var projects = await groupShareClient.Project.GetAllProjects();
            var projectId = projects.Items.FirstOrDefault().ProjectId;
            var result = await groupShareClient.Project.AddFiles(projectId, @"Resources\test.docx");

            Assert.True(result.CreateBackgroundTask);
            Assert.Empty(result.ResponseText);
        }

        [Fact]
        public async Task Projects_AddReferenceFileToExistingProjectUsingZip_Succeeds()
        {
            var groupShareClient = Helper.GsClient;
            var projectTemplateId = await CreateTestProjectTemplate(groupShareClient);
            var projectId = await CreateTestProject(groupShareClient, projectTemplateId);
            var result = await groupShareClient.Project.AddFiles(projectId, @"Resources\TwoFiles.zip", true);

            Assert.True(result.CreateBackgroundTask);
            Assert.Empty(result.ResponseText);

            await DeleteTestProject(groupShareClient, projectId);
            await DeleteTestProjectTemplate(groupShareClient, projectTemplateId);
        }

        [Fact]
        public async Task Projects_AddReferenceFileToExistingProject_Succeeds()
        {
            var groupShareClient = Helper.GsClient;
            var projects = await groupShareClient.Project.GetAllProjects();
            var projectId = projects.Items.FirstOrDefault().ProjectId;
            var result = await groupShareClient.Project.AddFiles(projectId, @"Resources\test.txt", true);

            Assert.True(result.CreateBackgroundTask);
            Assert.Empty(result.ResponseText);
        }

        [Fact]
        public async Task Projects_AddSameReferenceFileAsExistingTranslatableFile_Fails()
        {
            var groupShareClient = Helper.GsClient;
            var projects = await groupShareClient.Project.GetAllProjects();
            var projectId = projects.Items.FirstOrDefault().ProjectId;

            var result = await groupShareClient.Project.AddFiles(projectId, @"Resources\Grammar.zip", true);
            var expectedResponseText = "All specified files already exist in this project. If you want to create new versions for them, use the Update Files option instead.";

            Assert.False(result.CreateBackgroundTask);
            Assert.Equal(expectedResponseText, result.ResponseText);
        }

        [Fact]
        public async Task Projects_UpdateTranslatableFileWithoutSelection_Succeeds()
        {
            var groupShareClient = Helper.GsClient;
            var projects = await groupShareClient.Project.GetAllProjects();
            var projectId = projects.Items.FirstOrDefault().ProjectId;

            var result = await groupShareClient.Project.UpdateFiles(projectId, @"Resources\Grammar.zip");
            Assert.True(result.CreateBackgroundTask);
            Assert.Empty(result.ResponseText);
        }

        [Fact]
        public async Task Projects_UpdateTranslatableFileBySelection_Succeeds()
        {
            var groupShareClient = Helper.GsClient;
            var projectTemplateId = await CreateTestProjectTemplate(groupShareClient);
            var projectId = await CreateTestProject(groupShareClient, projectTemplateId, "TwoTranslatable_twoReference.zip");
            var projectFiles = await groupShareClient.Project.GetAllFilesForProject(projectId);

            var translatableFileId = projectFiles.FirstOrDefault(f => f.FileRole == "Translatable").UniqueId;

            var fileIds = new MidProjectFileIdsModel
            {
                FileIds = new[] { translatableFileId }
            };

            var result = await groupShareClient.Project.UpdateSelectedFiles(projectId, @"Resources\TwoTranslatable_twoReference.zip", fileIds);
            var expectedResponseText = "The following files will be skipped: FourWords.txt. These files are not part of this project or are not available for update. All other files will be uploaded.";

            Assert.True(result.CreateBackgroundTask);
            Assert.Equal(expectedResponseText, result.ResponseText);

            await DeleteTestProject(groupShareClient, projectId);
            await DeleteTestProjectTemplate(groupShareClient, projectTemplateId);
        }

        [Fact]
        public async Task Projects_UpdateReferenceFileBySelection_Succeeds()
        {
            var groupShareClient = Helper.GsClient;
            var projectTemplateId = await CreateTestProjectTemplate(groupShareClient);
            var projectId = await CreateTestProject(groupShareClient, projectTemplateId, "TwoTranslatable_twoReference.zip");
            var projectFiles = await groupShareClient.Project.GetAllFilesForProject(projectId);
            var referenceFileId = projectFiles.FirstOrDefault(f => f.FileRole == "Reference").UniqueId;

            var fileIds = new MidProjectFileIdsModel
            {
                FileIds = new[] { referenceFileId }
            };

            var result = await groupShareClient.Project.UpdateSelectedFiles(projectId, @"Resources\TwoTranslatable_twoReference.zip", fileIds, true);
            var expectedResponseText = "The following files will be skipped: Second.txt. These files are not part of this project or are not available for update. All other files will be uploaded.";

            Assert.True(result.CreateBackgroundTask);
            Assert.Equal(expectedResponseText, result.ResponseText);

            await DeleteTestProject(groupShareClient, projectId);
            await DeleteTestProjectTemplate(groupShareClient, projectTemplateId);
        }

        [Fact]
        public async Task Projects_CancelTranslatableFile_Succeeds()
        {
            var groupShareClient = Helper.GsClient;
            var projectTemplateId = await CreateTestProjectTemplate(groupShareClient);
            var projectId = await CreateTestProject(groupShareClient, projectTemplateId, "TwoTranslatable_twoReference.zip");
            var projectFiles = await groupShareClient.Project.GetAllFilesForProject(projectId);
            var translatableFileId = projectFiles.FirstOrDefault(f => f.FileRole == "Translatable").UniqueId;

            var fileIds = new MidProjectFileIdsModel
            {
                FileIds = new[] { translatableFileId }
            };

            await groupShareClient.Project.CancelProjectFiles(projectId, fileIds);

            projectFiles = await groupShareClient.Project.GetAllFilesForProject(projectId);

            var translatableFiles = projectFiles.Where(f => f.FileRole.Equals("Translatable", StringComparison.OrdinalIgnoreCase));
            var referenceFiles = projectFiles.Where(f => f.FileRole.Equals("Reference", StringComparison.OrdinalIgnoreCase));

            Assert.True(translatableFiles.First().IsCanceled);
            Assert.False(translatableFiles.Last().IsCanceled);
            Assert.All(referenceFiles, f => Assert.False(f.IsCanceled));

            await DeleteTestProject(groupShareClient, projectId);
            await DeleteTestProjectTemplate(groupShareClient, projectTemplateId);
        }

        [Fact]
        public async Task Projects_CancelReferenceFiles_Succeeds()
        {
            var groupShareClient = Helper.GsClient;
            var projectTemplateId = await CreateTestProjectTemplate(groupShareClient);
            var projectId = await CreateTestProject(groupShareClient, projectTemplateId, "TwoTranslatable_twoReference.zip");
            var projectFiles = await groupShareClient.Project.GetAllFilesForProject(projectId);
            var referenceFilesIds = projectFiles.Where(f => f.FileRole == "Reference").Select(f => f.UniqueId).ToArray();

            var fileIds = new MidProjectFileIdsModel
            {
                FileIds = referenceFilesIds
            };

            await groupShareClient.Project.CancelProjectFiles(projectId, fileIds);

            projectFiles = await groupShareClient.Project.GetAllFilesForProject(projectId);
            var referenceFiles = projectFiles.Where(f => f.FileRole.Equals("Reference", StringComparison.OrdinalIgnoreCase));
            var translatableFiles = projectFiles.Where(f => f.FileRole.Equals("Translatable", StringComparison.OrdinalIgnoreCase));

            Assert.All(referenceFiles, f => Assert.True(f.IsCanceled));
            Assert.All(translatableFiles, f => Assert.False(f.IsCanceled));

            await DeleteTestProject(groupShareClient, projectId);
            await DeleteTestProjectTemplate(groupShareClient, projectTemplateId);
        }

        [Fact]
        public async Task Projects_GetAnalysisReportsForProjectCreation_Succeeds()
        {
            var groupShareClient = Helper.GsClient;
            var projectTemplateId = await CreateTestProjectTemplate(groupShareClient);
            var projectId = await CreateTestProject(groupShareClient, projectTemplateId, "TwoTranslatable_twoReference.zip");
            var reports = await groupShareClient.Project.GetAnalysisReportsV3(projectId);
            var projectCreationReport = reports.FirstOrDefault(r => r.TriggeredBy == "ProjectCreation");

            Assert.Equal(1, reports.Count);
            Assert.NotNull(projectCreationReport);

            await DeleteTestProject(groupShareClient, projectId);
            await DeleteTestProjectTemplate(groupShareClient, projectTemplateId);
        }

        [Fact]
        public async Task Projects_GetAnalysisReportsForProjectAddFile_Succeeds()
        {
            var groupShareClient = Helper.GsClient;
            var projectTemplateId = await CreateTestProjectTemplate(groupShareClient);
            var projectId = await CreateTestProject(groupShareClient, projectTemplateId, "TwoTranslatable_twoReference.zip");

            await groupShareClient.Project.AddFiles(projectId, @"Resources\test.docx");
            await WaitForUpdateProjectBackgroundTaskToFinish(projectId);

            var reports = await groupShareClient.Project.GetAnalysisReportsV3(projectId);
            var projectCreationReport = reports.FirstOrDefault(r => r.TriggeredBy == "ProjectCreation");
            var addFileReport = reports.FirstOrDefault(r => r.TriggeredBy == "ProjectAddFile");

            Assert.Equal(3, reports.Count);
            Assert.NotNull(projectCreationReport);
            Assert.NotNull(addFileReport);

            await DeleteTestProject(groupShareClient, projectId);
            await DeleteTestProjectTemplate(groupShareClient, projectTemplateId);
        }

        [Fact]
        public async Task Projects_GetAnalysisReportsForProjectUpdateFile_Succeeds()
        {
            var groupShareClient = Helper.GsClient;
            var projectTemplateId = await CreateTestProjectTemplate(groupShareClient);
            var projectId = await CreateTestProject(groupShareClient, projectTemplateId, "TwoTranslatable_twoReference.zip");

            await groupShareClient.Project.UpdateFiles(projectId, @"Resources\FiveWords.txt");
            await WaitForUpdateProjectBackgroundTaskToFinish(projectId);

            var reports = await groupShareClient.Project.GetAnalysisReportsV3(projectId);
            var projectCreationReport = reports.FirstOrDefault(r => r.TriggeredBy == "ProjectCreation");
            var updateFileReport = reports.FirstOrDefault(r => r.TriggeredBy == "ProjectUpdateFile");

            Assert.Equal(3, reports.Count);
            Assert.NotNull(projectCreationReport);
            Assert.NotNull(updateFileReport);

            await DeleteTestProject(groupShareClient, projectId);
            await DeleteTestProjectTemplate(groupShareClient, projectTemplateId);
        }

        [Fact]
        public async Task Projects_GetAnalysisReportsV3AsHtml_Succeeds()
        {
            var groupShareClient = Helper.GsClient;
            var report = await groupShareClient.Project.GetAnalysisReportsV3AsHtml(ProjectId, null);
            Assert.True(report != null);
        }

        [Fact]
        public async Task Projects_GetAnalysisReportsV3AsXml_Succeeds()
        {
            var groupShareClient = Helper.GsClient;
            var report = await groupShareClient.Project.GetAnalysisReportsV3AsXml(ProjectId, null);
            Assert.True(report != null);
        }

        [Fact]
        public async Task Projects_GetAnalysisReportsV3WithReportId_Succeeds()
        {
            var groupShareClient = Helper.GsClient;
            var projectTemplateId = await CreateTestProjectTemplate(groupShareClient, "default_en-de_fr_it.sdltpl");
            var projectId = await CreateTestProject(groupShareClient, projectTemplateId, "Grammar.zip");

            await groupShareClient.Project.AddFiles(projectId, @"Resources\test.docx");
            await WaitForUpdateProjectBackgroundTaskToFinish(projectId);

            await groupShareClient.Project.UpdateFiles(projectId, @"Resources\FiveWords.txt");
            await WaitForUpdateProjectBackgroundTaskToFinish(projectId);

            var reports = await groupShareClient.Project.GetAnalysisReportsV3(projectId);
            var reportLanguageCode = reports.First().LanguageCode;
            var reportId = reports.First().ReportId;
            var individualReport = (await groupShareClient.Project.GetAnalysisReportsV3(projectId, reportLanguageCode, reportId)).Single();

            Assert.Equal(reportLanguageCode, individualReport.LanguageCode);
            Assert.Equal(reportId, individualReport.ReportId);
        }

        [Fact]
        public async Task Projects_GetAnalysisReportsForEachLanguageAfterProjectAddAndUpdateFiles_Succeeds()
        {
            var groupShareClient = Helper.GsClient;
            var projectTemplateId = await CreateTestProjectTemplate(groupShareClient, "default_en-de_fr_it.sdltpl");
            var projectId = await CreateTestProject(groupShareClient, projectTemplateId, "TwoTranslatable_twoReference.zip");

            await groupShareClient.Project.AddFiles(projectId, @"Resources\test.docx");
            await WaitForUpdateProjectBackgroundTaskToFinish(projectId);

            await groupShareClient.Project.UpdateFiles(projectId, @"Resources\FiveWords.txt");
            await WaitForUpdateProjectBackgroundTaskToFinish(projectId);

            var reports = await groupShareClient.Project.GetAnalysisReportsV3(projectId);
            var projectCreationReport = reports.FirstOrDefault(r => r.TriggeredBy == "ProjectCreation");
            var addFileReport = reports.FirstOrDefault(r => r.TriggeredBy == "ProjectAddFile");
            var updateFileReport = reports.FirstOrDefault(r => r.TriggeredBy == "ProjectUpdateFile");

            Assert.Equal(12, reports.Count);
            Assert.NotNull(projectCreationReport);
            Assert.NotNull(addFileReport);
            Assert.NotNull(updateFileReport);

            var individualLanguageReports = await groupShareClient.Project.GetAnalysisReportsV3(projectId, "de-de");
            Assert.Equal(4, individualLanguageReports.Count);
            foreach (var r in individualLanguageReports)
            {
                Assert.Equal("de-de", r.LanguageCode);
            }

            individualLanguageReports = await groupShareClient.Project.GetAnalysisReportsV3(projectId, "fr-fr");
            Assert.Equal(4, individualLanguageReports.Count);
            foreach (var r in individualLanguageReports)
            {
                Assert.Equal("fr-FR", r.LanguageCode);
            }

            individualLanguageReports = await groupShareClient.Project.GetAnalysisReportsV3(projectId, "it-it");
            Assert.Equal(4, individualLanguageReports.Count);
            foreach (var r in individualLanguageReports)
            {
                Assert.Equal("it-IT", r.LanguageCode);
            }

            await DeleteTestProject(groupShareClient, projectId);
            await DeleteTestProjectTemplate(groupShareClient, projectTemplateId);
        }

        [Fact]
        public async Task PublishProjectPackage()
        {
            var groupShareClient = Helper.GsClient;
            var rawData = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\ProjectPackage_1.sdlppx"));
            var createProjectRequest = new CreateProjectSkeletonRequest("ProjectForPublish", Helper.OrganizationId);

            var projectId = await groupShareClient.Project.CreateProjectSkeleton(createProjectRequest);
            await groupShareClient.Project.PublishPackage(projectId, rawData);

            var created = await WaitForProjectCreated(projectId);
            Assert.True(created);

            var project = await groupShareClient.Project.Get(projectId);
            Assert.Equal("ProjectPackage_1", project.Name);
            Assert.Equal("en-US", project.SourceLanguage, StringComparer.OrdinalIgnoreCase);
            Assert.Equal("de-de,fr-FR", project.TargetLanguage, StringComparer.OrdinalIgnoreCase);

            await groupShareClient.Project.DeleteProject(projectId);
        }

        [Fact]
        public async Task CancelPublishProjectPackage()
        {
            var groupShareClient = Helper.GsClient;
            var rawData = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\ProjectPackage.sdlppx"));
            var createProjectRequest = new CreateProjectSkeletonRequest("ProjectForPublish", Helper.OrganizationId);

            var projectId = await groupShareClient.Project.CreateProjectSkeleton(createProjectRequest);
            await groupShareClient.Project.PublishPackage(projectId, rawData);
            await groupShareClient.Project.CancelPublishPackage(projectId);
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

        [Fact]
        public async Task PerfectMatchWithZip()
        {
            var baseDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\PerfectMatch");
            var projectTemplateId = await CreateProjectTemplateForPerfectMatch(Path.Combine(baseDir, "project-template.sdltpl"));

            var basicProjectCreateRequest = CreateBasicCreateProjectRequest(projectTemplateId);
            var projectId = await Helper.GsClient.Project.CreateProject(basicProjectCreateRequest, Path.Combine(baseDir, "PerfectMatch.zip"));
            var created = await WaitForProjectCreated(projectId);

            Assert.True(created);
            var analysisReports = await Helper.GsClient.Project.GetAnalysisReports(projectId, "fr-fr");
            Assert.True(analysisReports[0].Report.Task.File.Count == 4);
            Assert.True(analysisReports[0].Report.Task.File[0].Analyse.Total.Segments == "3");
            Assert.True(analysisReports[0].Report.Task.File[0].Analyse.Perfect.Segments == "0");
            Assert.True(analysisReports[0].Report.Task.File[1].Analyse.Perfect.Segments == "1");
            Assert.True(analysisReports[0].Report.Task.File[2].Analyse.Perfect.Segments == "2");
            Assert.True(analysisReports[0].Report.Task.File[3].Analyse.Perfect.Segments == "3");

            await Helper.GsClient.Project.DeleteProject(projectId);
            await Helper.GsClient.Project.DeleteProjectTemplate(projectTemplateId);
        }

        [Fact]
        public async Task PerfectMatchWithFiles()
        {
            var baseDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\PerfectMatch");
            var projectTemplateId = await CreateProjectTemplateForPerfectMatch(Path.Combine(baseDir, "project-template.sdltpl"));

            var basicProjectCreateRequest = CreateBasicCreateProjectRequest(projectTemplateId);
            var projectId = await Helper.GsClient.Project.CreateProject(
                basicProjectCreateRequest, Path.Combine(baseDir, "project-files"), null,
                new string[] { Path.Combine(baseDir, "previous-translations") });
            var created = await WaitForProjectCreated(projectId);
            Assert.True(created);

            var analysisReports = await Helper.GsClient.Project.GetAnalysisReports(projectId, "fr-fr");
            Assert.True(analysisReports[0].Report.Task.File.Count == 4);
            Assert.True(analysisReports[0].Report.Task.File[0].Analyse.Total.Segments == "3");
            Assert.True(analysisReports[0].Report.Task.File[0].Analyse.Perfect.Segments == "0");
            Assert.True(analysisReports[0].Report.Task.File[1].Analyse.Perfect.Segments == "1");
            Assert.True(analysisReports[0].Report.Task.File[2].Analyse.Perfect.Segments == "2");
            Assert.True(analysisReports[0].Report.Task.File[3].Analyse.Perfect.Segments == "3");

            await Helper.GsClient.Project.DeleteProject(projectId);
            await Helper.GsClient.Project.DeleteProjectTemplate(projectTemplateId);
        }

        [Fact]
        public async Task IsProjectNameInUse()
        {
            var groupShareClient = Helper.GsClient;
            var orgGuid = (await groupShareClient.Organization.GetAll(new OrganizationRequest(true))).First().UniqueId;
            var isInUse = await groupShareClient.Project.IsProjectNameInUse(new IsProjectNameInUseRequest(orgGuid, new Guid().ToString()));

            // Random Guid name will not exist
            Assert.False(isInUse);
        }

        private async Task<string> CreateProjectTemplateForPerfectMatch(string projectTemplateFilePath)
        {
            var projectTemplateData = File.ReadAllBytes(projectTemplateFilePath);
            var projectTemplateRequest = new ProjectTemplates
            {
                Id = Guid.NewGuid().ToString(),
                Name = "PerfectMatchProjectTemplate_" + Guid.NewGuid(),
                Description = "",
                OrganizationId = Helper.OrganizationId
            };
            var projectTemplateId = await Helper.GsClient.Project.CreateTemplate(projectTemplateRequest, projectTemplateData);
            return projectTemplateId;
        }

        private static BasicCreateProjectRequest CreateBasicCreateProjectRequest(string projectTemplateId)
        {
            return new BasicCreateProjectRequest
            {
                Name = "PerfectMatch_" + Guid.NewGuid(),
                Description = "Perfect match from zip file",
                OrganizationId = Helper.OrganizationId,
                ProjectTemplateId = projectTemplateId,
                DueDate = null,
                ReferenceProjects = null,
                SuppressEmail = false,
                IsSecure = false
            };
        }

        private async Task<string> CreateTestProject(GroupShareClient groupShareClient, string projectTemplateId, string fileName = "")
        {
            var rawData = fileName == "" ?
                File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\Grammar.zip")) :
                File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\" + fileName));
            var projectName = $"Project - { Guid.NewGuid() }";

            var projectId = await groupShareClient.Project.CreateProject(new CreateProjectRequest(
                projectName,
                Helper.OrganizationId,
                null,
                DateTime.Now.AddDays(2),
                projectTemplateId,
                rawData));

            var statusInfo = await WaitForProjectCreated(projectId);
            Assert.True(statusInfo);

            return projectId;
        }

        private async Task<string> CreateTestProjectTemplate(GroupShareClient groupShareClient, string fileName = "")
        {
            var rawData = fileName == "" ? 
                File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\DefaultTemplate_en-de.sdltpl")) :
                File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\" + fileName));

            var id = Guid.NewGuid().ToString();
            var templateName = Guid.NewGuid().ToString();
            var templateRequest = new ProjectTemplates(id, templateName, "", Helper.OrganizationId);
            var templateId = await groupShareClient.Project.CreateTemplate(templateRequest, rawData);

            return templateId;
        }

        private async Task DeleteTestProject(GroupShareClient groupShareClient, string projectId)
        {
            await groupShareClient.Project.DeleteProject(projectId);
        }

        private async Task DeleteTestProjectTemplate(GroupShareClient groupShareClient, string projectTemplateId)
        {
            await groupShareClient.Project.DeleteProjectTemplate(projectTemplateId);
        }

        private async Task<bool> WaitForProjectCreated(string projectId, int retryInterval = 3, int maxTryCount = 15)
        {
            for (var i = 0; i < maxTryCount; i++)
            {
                var statusInfo = await Helper.GsClient.Project.PublishingStatus(projectId);
                switch (statusInfo.Status)
                {
                    case PublishProjectStatus.Uploading:
                    case PublishProjectStatus.Scheduled:
                    case PublishProjectStatus.Publishing:
                        break;
                    case PublishProjectStatus.Completed:
                        return true;
                    case PublishProjectStatus.Error:
                        throw new Exception(statusInfo.Description);
                }

                await Task.Delay(retryInterval * 1000);
            }

            return false;
        }

        // get only Update Project background tasks - type = 28
        private async Task WaitForUpdateProjectBackgroundTaskToFinish(string projectId)
        {
            var filter = new BackgroundTasksRequestFilter { Type = new[] { 28 } }.SerializeFilter();

            var projectUpdateBackgroundTasks = (await Helper.GsClient.Project.GetBackgroundTasks(filter)).Items;
            var backgroundTaskId = projectUpdateBackgroundTasks.First(task => task.ReferenceId.ToString() == projectId).Id;

            BackgroundTask backgroundTask;
            do
            {
                projectUpdateBackgroundTasks = (await Helper.GsClient.Project.GetBackgroundTasks(filter)).Items;
                backgroundTask = projectUpdateBackgroundTasks.Single(b => b.Id == backgroundTaskId);
            } while (backgroundTask.Status != (int)BackgroundTaskStatus.Done);
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

            await groupShareClient.Project.DeleteProjectTemplate(templateId);
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

        #region Dashboard

        //[Fact]
        //[Trait("GSVersion", "2017")]
        //public async Task Dashboard()
        //{
        //    var groupShareClient = await Helper.GetGroupShareClient();
        //    var dashboard = await groupShareClient.Project.Dashboard();
        //    Assert.True(dashboard != null);
        //}


        [Fact]
        public async Task DashboardProjectsPerMonth()
        {
            var groupShareClient = Helper.GsClient;
            var projectCounts = await groupShareClient.Project.DashboardProjectsPerMonth();
            Assert.True(projectCounts != null);
        }

        [Fact]
        public async Task DashboardTopLanguagePairs()
        {
            var groupShareClient = Helper.GsClient;
            var languagePairs = await groupShareClient.Project.DashboardTopLanguagePairs(5);
            Assert.True(languagePairs != null);
        }

        [Fact]
        public async Task DashboardWordsPerMonth()
        {
            var groupShareClient = Helper.GsClient;
            var wordCounts = await groupShareClient.Project.DashboardWordsPerMonth();
            Assert.True(wordCounts != null);
        }

        [Fact]
        public async Task DashboardWordsPerOrganization()
        {
            var groupShareClient = Helper.GsClient;
            var wordCounts = await groupShareClient.Project.DashboardWordsPerOrganization();
            Assert.True(wordCounts != null);
        }

        [Fact]
        public async Task DashboardStatistics()
        {
            var groupShareClient = Helper.GsClient;
            var statistics = await groupShareClient.Project.DashboardStatistics();
            Assert.True(statistics != null);
        }
        #endregion

        #region Reporting
        [Fact]
        public async Task ReportingProjectPredefinedReportData()
        {
            var groupShareClient = Helper.GsClient;
            var options = new ReportingOptions
            {
                Status = 7
            };

            var reportingData = await groupShareClient.Project.ReportingProjectPredefinedReportData(options);
            Assert.True(reportingData != null);
        }

        [Fact]
        public async Task ReportingTasksReportData()
        {
            var groupShareClient = Helper.GsClient;
            var options = new ReportingOptions
            {
                Status = 7
            };
            var reportingData = await groupShareClient.Project.ReportingTasksReportData(options);
            Assert.True(reportingData != null);
        }

        [Fact]
        public async Task ReportingTmLeverageData()
        {
            var groupShareClient = Helper.GsClient;
            var options = new ReportingOptions
            {
                Status = 7
            };

            var reportingData = await groupShareClient.Project.ReportingTmLeverageData(options);
            Assert.True(reportingData != null);
        }
        #endregion Reporting
    }
}