using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Models;
using Sdl.Community.GroupShareKit.Models.Response;
using Sdl.Community.GroupShareKit.Models.Response.ProjectPublishingInformation;
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
        private readonly GroupShareClient GroupShareClient = Helper.GsClient;
        private readonly Guid _projectTemplateId;
        private readonly Guid _projectId;
        private readonly Guid _languageFileId;
        private readonly List<Guid> _translatableFileIds;

        public ProjectClientTests()
        {
            var sortParameters = new SortParameters
            {
                Property = SortParameters.PropertyOption.CreatedAt,
                Direction = SortParameters.DirectionOption.DESC
            };

            var projectRequest = new ProjectsRequest(sortParameters);
            var project = GroupShareClient.Project.GetProject(projectRequest).Result.Items.FirstOrDefault();

            _projectId = project != null ? Guid.Parse(project.ProjectId) : Guid.Empty;

            var translatableFiles = GroupShareClient.Project.GetProjectFiles(_projectId).Result;
            _translatableFileIds = translatableFiles.Where(f => f.FileRole == "Translatable").Select(f => f.UniqueId).ToList();

            var languageFile = GroupShareClient.Project.GetProjectFiles(_projectId).Result.FirstOrDefault(f => f.FileRole == "Translatable");
            _languageFileId = languageFile != null ? languageFile.UniqueId : Guid.Empty;

            var projectTemplate = GroupShareClient.Project.GetProjectTemplates().Result.ToList().FirstOrDefault();
            _projectTemplateId = projectTemplate != null ? projectTemplate.Id : Guid.Empty;
        }

        #region Project tests
        [Fact]
        public async Task Projects_GetProjectByName_Succeeds()
        {
            var projects = await GroupShareClient.Project.GetAllProjects();
            var project = projects.Items.FirstOrDefault();

            if (project == null)
            {
                return;
            }

            var projectRequest = new ProjectsRequest("/", true, 7) { Filter = { ProjectName = project.Name } };
            var result = await GroupShareClient.Project.GetProject(projectRequest);

            Assert.True(result.Items[0].Name == project.Name);
        }

        [Fact]
        public async Task Projects_SortProjectsByName_Succeeds()
        {
            var sortParameters = new SortParameters
            {
                Property = SortParameters.PropertyOption.ProjectName,
                Direction = SortParameters.DirectionOption.ASC
            };

            var projectRequest = new ProjectsRequest(sortParameters);

            var sortedProjects = await GroupShareClient.Project.GetProject(projectRequest);
            var projects = await GroupShareClient.Project.GetAllProjects();

            Assert.Equal(sortedProjects.Items.Count, projects.Items.Count);

            var projectsNames = projects.Items.Select(p => p.Name).ToList();
            projectsNames.Sort();

            int i = 0;
            foreach (var proj in sortedProjects.Items)
            {
                Assert.Equal(0, string.Compare(proj.Name, projectsNames[i++], StringComparison.CurrentCultureIgnoreCase));
            }
        }

        [Fact]
        public async Task Projects_GetProjectFiles_Succeeds()
        {
            var projects = await GroupShareClient.Project.GetAllProjects();
            var project = projects.Items.FirstOrDefault();

            var projectFiles = await GroupShareClient.Project.GetProjectFiles(Guid.Parse(project.ProjectId));

            Assert.True(projectFiles.Count > 0);
        }

        [Fact]
        public async Task Projects_GetAllProjects_Succeeds()
        {
            var projects = await GroupShareClient.Project.GetAllProjects();
            Assert.True(projects.Count > 0);
        }

        [Fact]
        public async Task Projects_AnalysisReports_Succeeds()
        {
            var reports = await GroupShareClient.Project.GetAnalysisReports(_projectId, null);
            Assert.True(reports.Count > 0);
        }

        [Fact]
        public async Task Projects_AnalysisReportsAsHtml_Succeeds()
        {
            var reports = await GroupShareClient.Project.GetAnalysisReportsAsHtml(_projectId, null);
            Assert.NotNull(reports);
        }

        [Fact]
        public async Task Projects_AnalysisReportsAsXml_Succeeds()
        {
            var reports = await GroupShareClient.Project.GetAnalysisReportsAsXml(_projectId, null);
            Assert.NotNull(reports);
        }

        [Fact]
        public async Task Projects_GetMTQEAnalysisReportsV3_Succeeds()
        {
            var reports = await GroupShareClient.Project.GetMTQEAnalysisReportsV3(_projectId);
            Assert.NotNull(reports);

            var individualLanguageReports = await GroupShareClient.Project.GetMTQEAnalysisReportsV3(_projectId, "de-de");
            Assert.NotNull(individualLanguageReports);

            var individualLanguageReportsWithId = await GroupShareClient.Project.GetMTQEAnalysisReportsV3(_projectId, "de-de", 1);
            Assert.NotNull(individualLanguageReportsWithId);
        }

        [Fact]
        public async Task Projects_GetMTQEAnalysisReportsV3AsHtml_Succeeds()
        {
            var reports = await GroupShareClient.Project.GetMTQEAnalysisReportsV3AsHtml(_projectId);
            Assert.NotNull(reports);

            var individualLanguageReports = await GroupShareClient.Project.GetMTQEAnalysisReportsV3AsHtml(_projectId, "de-de");
            Assert.NotNull(individualLanguageReports);

            var individualLanguageReportsWithId = await GroupShareClient.Project.GetMTQEAnalysisReportsV3AsHtml(_projectId, "de-de", 1);
            Assert.NotNull(individualLanguageReportsWithId);
        }

        [Fact]
        public async Task Projects_GetMTQEAnalysisReportsV3AsXml_Succeeds()
        {
            var reports = await GroupShareClient.Project.GetMTQEAnalysisReportsV3AsXml(_projectId);
            Assert.NotNull(reports);

            var individualLanguageReports = await GroupShareClient.Project.GetMTQEAnalysisReportsV3AsXml(_projectId, "de-de");
            Assert.NotNull(individualLanguageReports);

            var individualLanguageReportsWithId = await GroupShareClient.Project.GetMTQEAnalysisReportsV3AsXml(_projectId, "de-de", 1);
            Assert.NotNull(individualLanguageReportsWithId);
        }

        [Fact]
        public async Task Projects_GetLanguageFileSettings_Succeeds()
        {
            var languageFileSettings = await GroupShareClient.Project.GetLanguageFileSettings(_projectId, _languageFileId);

            Assert.NotNull(languageFileSettings);
        }

        [Fact]
        public async Task Projects_GetProjectSettings_Succeeds()
        {
            var projectSettings = await GroupShareClient.Project.GetProjectSettings(_projectId);

            Assert.Equal(_projectId, projectSettings.GeneralSettings.ProjectId);
            Assert.Equal(3, projectSettings.GeneralSettings.LanguageDirection.Count);
            Assert.Empty(projectSettings.Termbases);
        }

        [Fact]
        public async Task Projects_GetProjectSettingsV4_Succeeds()
        {
            var projectSettings = await GroupShareClient.Project.GetProjectSettingsV4(_projectId);

            Assert.False(projectSettings.EnableSegmentLockTask);
            Assert.Empty(projectSettings.SegmentLock);
            Assert.Equal(_projectId, projectSettings.GeneralSettings.ProjectId);
            Assert.Equal(3, projectSettings.GeneralSettings.LanguageDirection.Count);
            Assert.Empty(projectSettings.Termbases);
        }

        [Fact]
        public async Task GetSegmentLockingConfig_Succeeds()
        {
            var segmentLockingConfig = await GroupShareClient.Project.GetGetSegmentLockingConfig();

            Assert.NotNull(segmentLockingConfig);
        }

        [Fact]
        public async Task Projects_IsUserAuthorizedToOpenTheFile_Succeeds()
        {
            var response = await GroupShareClient.Project.IsUserAuthorizedToOpenFile(_projectId, _languageFileId);

            Assert.True(string.IsNullOrEmpty(response));
        }

        [Fact]
        public async Task Projects_EditorProfile_Succeeds()
        {
            var editorProfile = await GroupShareClient.Project.EditorProfile(_projectId, _languageFileId);

            Assert.NotNull(editorProfile);
        }

        [Fact]
        public async Task Projects_IsCheckOutToSomeoneElseBasicOnlineEditorMode_Succeeds()
         {
            await GroupShareClient.Project.OnlineCheckout(_projectId, _languageFileId);

            var editorProfileMode = OnlineCheckout.EditorProfileMode.Basic.ToString();
            var isCheckedOutToSomeoneElse = await GroupShareClient.Project.IsCheckoutToSomeoneElse(_languageFileId, editorProfileMode);
            Assert.False(isCheckedOutToSomeoneElse);
        }

        [Fact]
        public async Task Projects_IsCheckOutToSomeoneElseAdvancedOnlineEditorMode_Succeeds()
        {
            await GroupShareClient.Project.OnlineCheckout(_projectId, _languageFileId);

            var editorProfileMode = OnlineCheckout.EditorProfileMode.Advanced.ToString();
            var isCheckedOutToSomeoneElse = await GroupShareClient.Project.IsCheckoutToSomeoneElse(_languageFileId, editorProfileMode);
            Assert.False(isCheckedOutToSomeoneElse);
        }

        [Fact]
        public async Task Projects_OnlineCheckIn_Succeeds()
        {
            var checkoutResponse = await GroupShareClient.Project.OnlineCheckout(_projectId, _languageFileId);
            var response = await GroupShareClient.Project.OnlineCheckin(_projectId, _languageFileId, checkoutResponse);
            Assert.NotNull(response);
        }

        [Fact]
        public async Task Projects_OnlineCheckOut_and_UndoCheckOut_Succeed()
        {
            var checkoutResponse = await GroupShareClient.Project.OnlineCheckout(_projectId, _languageFileId);
            Assert.NotNull(checkoutResponse);

            await GroupShareClient.Project.UndoCheckout(_projectId, _languageFileId);
        }

        [Fact]
        public async Task ExternalCheckOut_ExternalCheckIn_file()
        {
            var response = await GroupShareClient.Project.ExternalCheckout(_projectId, _languageFileId);
            Assert.NotNull(response);

            await GroupShareClient.Project.ExternalCheckin(_projectId, _languageFileId, "comment");
        }

        [Fact]
        public async Task ExternalCheckOut_ExternalCheckIn_files()
        {
            var filesIds = new List<Guid> { _translatableFileIds[0], _translatableFileIds[1] };

            await GroupShareClient.Project.ExternalCheckOutFiles(_projectId, filesIds);

            var externalCheckInData = new ExternalCheckInData
            {
                LanguageFileIds = new[] { _translatableFileIds[0].ToString(), _translatableFileIds[1].ToString() },
                Comment = "GroupShare Kit external check-in"
            };

            await GroupShareClient.Project.ExternalCheckInFiles(_projectId, externalCheckInData);
        }

        [Fact]
        public async Task ExternalCheckOut_UndoExternalCheckOut_files()
        {
            var filesIds = new List<Guid> { _translatableFileIds[0], _translatableFileIds[1] };

            await GroupShareClient.Project.ExternalCheckOutFiles(_projectId, filesIds);
            await GroupShareClient.Project.UndoExternalCheckOutForFiles(_projectId, filesIds);
        }

        [Fact]
        public async Task AuditTrail()
        {
            var auditTrail = await GroupShareClient.Project.AuditTrail(_projectId);

            Assert.True(auditTrail?.Count > 0);
        }

        [Fact]
        public async Task OnlineCheckoutHealthCheckBasicOnlineEditorMode()
        {
            var editorProfileMode = OnlineCheckout.EditorProfileMode.Basic.ToString();
            var response = await GroupShareClient.Project.OnlineCheckoutHealthCheck(editorProfileMode);
            Assert.NotNull(response);
        }

        [Fact]
        public async Task OnlineCheckoutHealthCheckAdvancedOnlineEditorMode()
        {
            var editorProfileMode = OnlineCheckout.EditorProfileMode.Advanced.ToString();
            var response = await GroupShareClient.Project.OnlineCheckoutHealthCheck(editorProfileMode);
            Assert.NotNull(response);
        }

        [Fact]
        public async Task GetProjectById()
        {
            var projects = await GroupShareClient.Project.GetAllProjects();
            var project = projects.Items.FirstOrDefault();

            if (project != null)
            {
                var actualProject = await GroupShareClient.Project.GetProject(Guid.Parse(project.ProjectId));

                Assert.Equal(actualProject.ProjectId, project.ProjectId);
            }
        }

        [Fact]
        public async Task GetProjectLanguageStatistics()
        {
            var languageStatistics = await GroupShareClient.Project.GetProjectLanguageStatistics(_projectId);
            var targetLanguageCodes = languageStatistics.Keys.ToList();

            Assert.Equal(3, languageStatistics.Count());
            Assert.Equal("de-DE", targetLanguageCodes[0]);
            Assert.Equal("fr-FR", targetLanguageCodes[1]);
            Assert.Equal("ja-JP", targetLanguageCodes[2]);
        }

        [Fact]
        public async Task GetProjectFileStatistics()
        {
            var projects = await GroupShareClient.Project.GetAllProjects();
            var project = projects.Items.FirstOrDefault();

            var response = await GroupShareClient.Project.GetAllProjectFileStatistics(Guid.Parse(project.ProjectId));

            Assert.True(response.Count > 0);
        }

        [Theory]
        [InlineData("SDL Community Developers")]
        public void GetProjectsForOrganization(string organizationName)
        {
            var projects = GroupShareClient.Project.GetProjectsForOrganization(organizationName);

            foreach (var project in projects)
            {
                Assert.Equal(project.OrganizationName, organizationName);
            }
        }

        [Fact]
        public async Task CreateProject()
        {
            var projectTemplateId = await CreateTestProjectTemplate();
            var projectId = await CreateTestProject(projectTemplateId);

            var project = await GroupShareClient.Project.GetProject(projectId);
            Assert.Equal(Helper.OrganizationId, project.OrganizationId);

            await DeleteTestProject(projectId);
            await DeleteTestProjectTemplate(projectTemplateId);
        }

        [Fact]
        public async Task Projects_AddTranslatableFileToExistingProjectUsingZip_Succeeds()
        {
            var projectTemplateId = await CreateTestProjectTemplate();
            var projectId = await CreateTestProject(projectTemplateId);
            var result = await GroupShareClient.Project.AddFiles(projectId, @"Resources\TwoFiles.zip");

            Assert.True(result.CreateBackgroundTask);
            Assert.Empty(result.ResponseText);

            await DeleteTestProject(projectId);
            await DeleteTestProjectTemplate(projectTemplateId);
        }

        [Fact]
        public async Task Projects_AddTranslatableFileToExistingProject_Succeeds()
        {
            var projectTemplateId = await CreateTestProjectTemplate();
            var projectId = await CreateTestProject(projectTemplateId);
            var result = await GroupShareClient.Project.AddFiles(projectId, @"Resources\test.docx");

            Assert.True(result.CreateBackgroundTask);
            Assert.Empty(result.ResponseText);

            await DeleteTestProject(projectId);
            await DeleteTestProjectTemplate(projectTemplateId);
        }

        [Fact]
        public async Task Projects_AddReferenceFileToExistingProjectUsingZip_Succeeds()
        {
            var projectTemplateId = await CreateTestProjectTemplate();
            var projectId = await CreateTestProject(projectTemplateId);
            var result = await GroupShareClient.Project.AddFiles(projectId, @"Resources\TwoFiles.zip", true);

            Assert.True(result.CreateBackgroundTask);
            Assert.Empty(result.ResponseText);

            await DeleteTestProject(projectId);
            await DeleteTestProjectTemplate(projectTemplateId);
        }

        [Fact]
        public async Task Projects_AddReferenceFileToExistingProject_Succeeds()
        {
            var projectTemplateId = await CreateTestProjectTemplate();
            var projectId = await CreateTestProject(projectTemplateId);
            var result = await GroupShareClient.Project.AddFiles(projectId, @"Resources\test.txt", true);

            Assert.True(result.CreateBackgroundTask);
            Assert.Empty(result.ResponseText);

            await DeleteTestProject(projectId);
            await DeleteTestProjectTemplate(projectTemplateId);
        }

        [Fact]
        public async Task Projects_AddSameReferenceFileAsExistingTranslatableFile_Fails()
        {
            var projects = await GroupShareClient.Project.GetAllProjects();
            var projectId = projects.Items.FirstOrDefault().ProjectId;

            var result = await GroupShareClient.Project.AddFiles(Guid.Parse(projectId), @"Resources\Grammar.zip", true);
            var expectedResponseText = "All specified files already exist in this project. If you want to create new versions for them, use the Update Files option instead.";

            Assert.False(result.CreateBackgroundTask);
            Assert.Equal(expectedResponseText, result.ResponseText);
        }

        [Fact]
        public async Task Projects_UpdateTranslatableFileWithoutSelection_Succeeds()
        {
            var projectTemplateId = await CreateTestProjectTemplate();
            var projectId = await CreateTestProject(projectTemplateId);

            var result = await GroupShareClient.Project.UpdateFiles(projectId, @"Resources\Grammar.zip");
            Assert.True(result.CreateBackgroundTask);
            Assert.Empty(result.ResponseText);

            await DeleteTestProject(projectId);
            await DeleteTestProjectTemplate(projectTemplateId);
        }

        [Fact]
        public async Task Projects_UpdateTranslatableFileBySelection_Succeeds()
        {
            var projectTemplateId = await CreateTestProjectTemplate();
            var projectId = await CreateTestProject(projectTemplateId, "TwoTranslatable_twoReference.zip");
            var projectFiles = await GroupShareClient.Project.GetProjectFiles(projectId);

            var translatableFileId = projectFiles.FirstOrDefault(f => f.FileRole == "Translatable").UniqueId;

            var fileIds = new MidProjectFileIdsModel
            {
                FileIds = new[] { translatableFileId }
            };

            var result = await GroupShareClient.Project.UpdateSelectedFiles(projectId, @"Resources\TwoTranslatable_twoReference.zip", fileIds);
            var expectedResponseText = "The following files will be skipped: FourWords.txt. These files are not part of this project or are not available for update. All other files will be uploaded.";

            Assert.True(result.CreateBackgroundTask);
            Assert.Equal(expectedResponseText, result.ResponseText);

            await DeleteTestProject(projectId);
            await DeleteTestProjectTemplate(projectTemplateId);
        }

        [Fact]
        public async Task Projects_UpdateReferenceFileBySelection_Succeeds()
        {
            var projectTemplateId = await CreateTestProjectTemplate();
            var projectId = await CreateTestProject(projectTemplateId, "TwoTranslatable_twoReference.zip");
            var projectFiles = await GroupShareClient.Project.GetProjectFiles(projectId);
            var referenceFileId = projectFiles.FirstOrDefault(f => f.FileRole == "Reference").UniqueId;

            var fileIds = new MidProjectFileIdsModel
            {
                FileIds = new[] { referenceFileId }
            };

            var result = await GroupShareClient.Project.UpdateSelectedFiles(projectId, @"Resources\TwoTranslatable_twoReference.zip", fileIds, true);
            var expectedResponseText = "The following files will be skipped: Second.txt. These files are not part of this project or are not available for update. All other files will be uploaded.";

            Assert.True(result.CreateBackgroundTask);
            Assert.Equal(expectedResponseText, result.ResponseText);

            await DeleteTestProject(projectId);
            await DeleteTestProjectTemplate(projectTemplateId);
        }

        [Fact]
        public async Task Projects_CancelTranslatableFile_Succeeds()
        {
            var projectTemplateId = await CreateTestProjectTemplate();
            var projectId = await CreateTestProject(projectTemplateId, "TwoTranslatable_twoReference.zip");
            var projectFiles = await GroupShareClient.Project.GetProjectFiles(projectId);
            var translatableFileId = projectFiles.FirstOrDefault(f => f.FileRole == "Translatable").UniqueId;

            var fileIds = new MidProjectFileIdsModel
            {
                FileIds = new[] { translatableFileId }
            };

            await GroupShareClient.Project.CancelProjectFiles(projectId, fileIds);

            projectFiles = await GroupShareClient.Project.GetProjectFiles(projectId);

            var translatableFiles = projectFiles.Where(f => f.FileRole.Equals("Translatable", StringComparison.OrdinalIgnoreCase));
            var referenceFiles = projectFiles.Where(f => f.FileRole.Equals("Reference", StringComparison.OrdinalIgnoreCase));

            Assert.True(translatableFiles.First().IsCanceled);
            Assert.False(translatableFiles.Last().IsCanceled);
            Assert.All(referenceFiles, f => Assert.False(f.IsCanceled));

            await DeleteTestProject(projectId);
            await DeleteTestProjectTemplate(projectTemplateId);
        }

        [Fact]
        public async Task Projects_CancelReferenceFiles_Succeeds()
        {
            var projectTemplateId = await CreateTestProjectTemplate();
            var projectId = await CreateTestProject(projectTemplateId, "TwoTranslatable_twoReference.zip");
            var projectFiles = await GroupShareClient.Project.GetProjectFiles(projectId);
            var referenceFilesIds = projectFiles.Where(f => f.FileRole == "Reference").Select(f => f.UniqueId).ToArray();

            var fileIds = new MidProjectFileIdsModel
            {
                FileIds = referenceFilesIds
            };

            await GroupShareClient.Project.CancelProjectFiles(projectId, fileIds);

            projectFiles = await GroupShareClient.Project.GetProjectFiles(projectId);
            var referenceFiles = projectFiles.Where(f => f.FileRole.Equals("Reference", StringComparison.OrdinalIgnoreCase));
            var translatableFiles = projectFiles.Where(f => f.FileRole.Equals("Translatable", StringComparison.OrdinalIgnoreCase));

            Assert.All(referenceFiles, f => Assert.True(f.IsCanceled));
            Assert.All(translatableFiles, f => Assert.False(f.IsCanceled));

            await DeleteTestProject(projectId);
            await DeleteTestProjectTemplate(projectTemplateId);
        }

        [Fact]
        public async Task Projects_GetAnalysisReportsForProjectCreation_Succeeds()
        {
            var projectTemplateId = await CreateTestProjectTemplate();
            var projectId = await CreateTestProject(projectTemplateId, "TwoTranslatable_twoReference.zip");
            var reports = await GroupShareClient.Project.GetAnalysisReportsV3(projectId);
            var projectCreationReport = reports.FirstOrDefault(r => r.TriggeredBy == "ProjectCreation");

            Assert.Single(reports);
            Assert.NotNull(projectCreationReport);

            await DeleteTestProject(projectId);
            await DeleteTestProjectTemplate(projectTemplateId);
        }

        [Fact]
        public async Task Projects_GetAnalysisReportsForProjectAddFile_Succeeds()
        {
            var projectTemplateId = await CreateTestProjectTemplate();
            var projectId = await CreateTestProject(projectTemplateId, "TwoTranslatable_twoReference.zip");

            await GroupShareClient.Project.AddFiles(projectId, @"Resources\test.docx");
            await WaitForUpdateProjectBackgroundTaskToFinish(projectId);

            var reports = await GroupShareClient.Project.GetAnalysisReportsV3(projectId);
            var projectCreationReport = reports.FirstOrDefault(r => r.TriggeredBy == "ProjectCreation");
            var addFileReport = reports.FirstOrDefault(r => r.TriggeredBy == "ProjectAddFile");

            Assert.Equal(3, reports.Count);
            Assert.NotNull(projectCreationReport);
            Assert.NotNull(addFileReport);

            await DeleteTestProject(projectId);
            await DeleteTestProjectTemplate(projectTemplateId);
        }

        [Fact]
        public async Task Projects_GetAnalysisReportsForProjectUpdateFile_Succeeds()
        {
            var projectTemplateId = await CreateTestProjectTemplate();
            var projectId = await CreateTestProject(projectTemplateId, "TwoTranslatable_twoReference.zip");

            await GroupShareClient.Project.UpdateFiles(projectId, @"Resources\FiveWords.txt");
            await WaitForUpdateProjectBackgroundTaskToFinish(projectId);

            var reports = await GroupShareClient.Project.GetAnalysisReportsV3(projectId);
            var projectCreationReport = reports.FirstOrDefault(r => r.TriggeredBy == "ProjectCreation");
            var updateFileReport = reports.FirstOrDefault(r => r.TriggeredBy == "ProjectUpdateFile");

            Assert.Equal(3, reports.Count);
            Assert.NotNull(projectCreationReport);
            Assert.NotNull(updateFileReport);

            await DeleteTestProject(projectId);
            await DeleteTestProjectTemplate(projectTemplateId);
        }

        [Fact]
        public async Task Projects_GetAnalysisReportsV3_Succeeds()
        {
            var reports = await GroupShareClient.Project.GetAnalysisReportsV3(_projectId, null);
            Assert.NotNull(reports);
        }

        [Fact]
        public async Task Projects_GetAnalysisReportsV3AsHtml_Succeeds()
        {
            var reports = await GroupShareClient.Project.GetAnalysisReportsV3AsHtml(_projectId, null);
            Assert.NotNull(reports);
        }

        [Fact]
        public async Task Projects_GetAnalysisReportsV3AsXml_Succeeds()
        {
            var reports = await GroupShareClient.Project.GetAnalysisReportsV3AsXml(_projectId, null);
            Assert.NotNull(reports);
        }

        [Fact]
        public async Task Projects_GetAnalysisReportsV3WithReportId_Succeeds()
        {
            var projectTemplateId = await CreateTestProjectTemplate("default_en-de_fr_it.sdltpl");
            var projectId = await CreateTestProject(projectTemplateId, "Grammar.zip");

            await GroupShareClient.Project.AddFiles(projectId, @"Resources\test.docx");
            await WaitForUpdateProjectBackgroundTaskToFinish(projectId);

            await GroupShareClient.Project.UpdateFiles(projectId, @"Resources\FiveWords.txt");
            await WaitForUpdateProjectBackgroundTaskToFinish(projectId);

            var reports = await GroupShareClient.Project.GetAnalysisReportsV3(projectId);
            var reportLanguageCode = reports.First().LanguageCode;
            var reportId = reports.First().ReportId;
            var individualReport = (await GroupShareClient.Project.GetAnalysisReportsV3(projectId, reportLanguageCode, reportId)).Single();

            Assert.Equal(reportLanguageCode, individualReport.LanguageCode);
            Assert.Equal(reportId, individualReport.ReportId);
        }

        [Fact]
        public async Task Projects_GetAnalysisReportsForEachLanguageAfterProjectAddAndUpdateFiles_Succeeds()
        {
            var projectTemplateId = await CreateTestProjectTemplate("default_en-de_fr_it.sdltpl");
            var projectId = await CreateTestProject(projectTemplateId, "TwoTranslatable_twoReference.zip");

            await GroupShareClient.Project.AddFiles(projectId, @"Resources\test.docx");
            await WaitForUpdateProjectBackgroundTaskToFinish(projectId);

            await GroupShareClient.Project.UpdateFiles(projectId, @"Resources\FiveWords.txt");
            await WaitForUpdateProjectBackgroundTaskToFinish(projectId);

            var reports = await GroupShareClient.Project.GetAnalysisReportsV3(projectId);
            var projectCreationReport = reports.FirstOrDefault(r => r.TriggeredBy == "ProjectCreation");
            var addFileReport = reports.FirstOrDefault(r => r.TriggeredBy == "ProjectAddFile");
            var updateFileReport = reports.FirstOrDefault(r => r.TriggeredBy == "ProjectUpdateFile");

            Assert.Equal(12, reports.Count);
            Assert.NotNull(projectCreationReport);
            Assert.NotNull(addFileReport);
            Assert.NotNull(updateFileReport);

            var individualLanguageReports = await GroupShareClient.Project.GetAnalysisReportsV3(projectId, "de-de");
            Assert.Equal(4, individualLanguageReports.Count);

            foreach (var r in individualLanguageReports)
            {
                Assert.Equal("de-de", r.LanguageCode);
            }

            individualLanguageReports = await GroupShareClient.Project.GetAnalysisReportsV3(projectId, "fr-fr");
            Assert.Equal(4, individualLanguageReports.Count);

            foreach (var r in individualLanguageReports)
            {
                Assert.Equal("fr-FR", r.LanguageCode);
            }

            individualLanguageReports = await GroupShareClient.Project.GetAnalysisReportsV3(projectId, "it-it");
            Assert.Equal(4, individualLanguageReports.Count);

            foreach (var r in individualLanguageReports)
            {
                Assert.Equal("it-IT", r.LanguageCode);
            }

            await DeleteTestProject(projectId);
            await DeleteTestProjectTemplate(projectTemplateId);
        }

        [Fact]
        public async Task PublishProjectPackage()
        {
            var rawData = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\ProjectPackage_1.sdlppx"));
            var createProjectRequest = new CreateProjectSkeletonRequest("ProjectForPublish", Helper.OrganizationId);

            var projectId = await GroupShareClient.Project.CreateProjectSkeleton(createProjectRequest);
            await GroupShareClient.Project.PublishPackage(projectId, rawData);

            var created = await WaitForProjectCreated(Guid.Parse(projectId));
            Assert.True(created);

            var project = await GroupShareClient.Project.GetProject(Guid.Parse(projectId));
            Assert.Equal("ProjectPackage_1", project.Name);
            Assert.Equal("en-US", project.SourceLanguage, StringComparer.OrdinalIgnoreCase);
            Assert.Equal("de-de,fr-FR", project.TargetLanguage, StringComparer.OrdinalIgnoreCase);

            await GroupShareClient.Project.DeleteProject(Guid.Parse(projectId));
        }

        [Fact]
        public async Task CancelPublishProjectPackage()
        {
            var rawData = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\ProjectPackage.sdlppx"));
            var createProjectRequest = new CreateProjectSkeletonRequest("ProjectForPublish", Helper.OrganizationId);

            var projectId = await GroupShareClient.Project.CreateProjectSkeleton(createProjectRequest);
            await GroupShareClient.Project.PublishPackage(projectId, rawData);
            await GroupShareClient.Project.CancelPublishPackage(projectId);

            var publishingStatus = await GroupShareClient.Project.GetPublishingStatus(Guid.Parse(projectId));
            Assert.Equal(PublishProjectStatus.Cancelled, publishingStatus.Status);
        }

        [Fact]
        public async Task GetProjectsAssignments()
        {
            var projects = await GroupShareClient.Project.GetUserAssignments();

            Assert.True(projects.Count > 0);
        }

        [Fact]
        public async Task GetProjectAssignmentsById()
        {
            var fileIds = new List<Guid> { _languageFileId };

            var assignments = await GroupShareClient.Project.GetProjectAssignmentById(_projectId, fileIds);

            Assert.True(assignments.Count > 0);
        }

        [Fact]
        public async Task ChangeProjectStatus()
        {
            var projectStatusRequest = new ChangeStatusRequest(_projectId.ToString(), ChangeStatusRequest.ProjectStatus.Completed);
            await GroupShareClient.Project.ChangeProjectStatus(projectStatusRequest);

            var project = await GroupShareClient.Project.GetProject(_projectId);
            Assert.Equal(4, project.Status);

            projectStatusRequest = new ChangeStatusRequest(_projectId.ToString(), ChangeStatusRequest.ProjectStatus.Started);
            await GroupShareClient.Project.ChangeProjectStatus(projectStatusRequest);

            project = await GroupShareClient.Project.GetProject(_projectId);
            Assert.Equal(2, project.Status);
        }

        [Fact]
        public async Task ChangeProjectStatusDetach()
        {
            var projectStatusRequest = new ChangeStatusRequest(_projectId.ToString(), ChangeStatusRequest.ProjectStatus.Completed);
            await GroupShareClient.Project.ChangeProjectStatusDetach(projectStatusRequest);

            var project = await GroupShareClient.Project.GetProject(_projectId);
            Assert.Equal(4, project.Status);

            projectStatusRequest = new ChangeStatusRequest(_projectId.ToString(), ChangeStatusRequest.ProjectStatus.Started);
            await GroupShareClient.Project.ChangeProjectStatus(projectStatusRequest);
        }

        [Fact]
        public async Task PerfectMatchWithZip()
        {
            var baseDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\PerfectMatch");
            var projectTemplateId = await CreateProjectTemplateForPerfectMatch(Path.Combine(baseDir, "project-template.sdltpl"));

            var basicProjectCreateRequest = CreateBasicCreateProjectRequest(projectTemplateId.ToString());
            var projectId = await GroupShareClient.Project.CreateProject(basicProjectCreateRequest, Path.Combine(baseDir, "PerfectMatch.zip"));
            var created = await WaitForProjectCreated(Guid.Parse(projectId));

            Assert.True(created);
            var analysisReports = await GroupShareClient.Project.GetAnalysisReports(Guid.Parse(projectId), "fr-fr");
            Assert.Equal(4, analysisReports[0].Report.Task.File.Count);
            Assert.Equal("3", analysisReports[0].Report.Task.File[0].Analyse.Total.Segments);
            Assert.Equal("0", analysisReports[0].Report.Task.File[0].Analyse.Perfect.Segments);
            Assert.Equal("1", analysisReports[0].Report.Task.File[1].Analyse.Perfect.Segments);
            Assert.Equal("2", analysisReports[0].Report.Task.File[2].Analyse.Perfect.Segments);
            Assert.Equal("3", analysisReports[0].Report.Task.File[3].Analyse.Perfect.Segments);

            await GroupShareClient.Project.DeleteProject(Guid.Parse(projectId));
            await GroupShareClient.Project.DeleteProjectTemplate(projectTemplateId);
        }

        [Fact]
        public async Task PerfectMatchWithFiles()
        {
            var baseDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\PerfectMatch");
            var projectTemplateId = await CreateProjectTemplateForPerfectMatch(Path.Combine(baseDir, "project-template.sdltpl"));

            var basicProjectCreateRequest = CreateBasicCreateProjectRequest(projectTemplateId.ToString());
            var projectId = await GroupShareClient.Project.CreateProject(
                basicProjectCreateRequest, Path.Combine(baseDir, "project-files"), null,
                new string[] { Path.Combine(baseDir, "previous-translations") });
            var created = await WaitForProjectCreated(Guid.Parse(projectId));
            Assert.True(created);

            var analysisReports = await GroupShareClient.Project.GetAnalysisReports(Guid.Parse(projectId), "fr-fr");
            Assert.Equal(4, analysisReports[0].Report.Task.File.Count);
            Assert.Equal("3", analysisReports[0].Report.Task.File[0].Analyse.Total.Segments);
            Assert.Equal("0", analysisReports[0].Report.Task.File[0].Analyse.Perfect.Segments);
            Assert.Equal("1", analysisReports[0].Report.Task.File[1].Analyse.Perfect.Segments);
            Assert.Equal("2", analysisReports[0].Report.Task.File[2].Analyse.Perfect.Segments);
            Assert.Equal("3", analysisReports[0].Report.Task.File[3].Analyse.Perfect.Segments);

            await GroupShareClient.Project.DeleteProject(Guid.Parse(projectId));
            await GroupShareClient.Project.DeleteProjectTemplate(projectTemplateId);
        }

        [Fact]
        public async Task IsProjectNameInUse()
        {
            var orgGuid = (await GroupShareClient.Organization.GetAll(new OrganizationRequest(true))).First().UniqueId;
            var isInUse = await GroupShareClient.Project.IsProjectNameInUse(new IsProjectNameInUseRequest(orgGuid, new Guid().ToString()));

            // Random Guid name will not exist
            Assert.False(isInUse);
        }

        [Fact]
        public async Task Projects_GetPublishingInformationForOneProject()
        {
            var projectTemplateId = await CreateTestProjectTemplate();
            var projectId = await CreateTestProject(projectTemplateId);

            var projectPublishingInformation = (await GroupShareClient.Project.GetProjectsPublishingInformation(projectId.ToString())).Single();
            var projectInformation = projectPublishingInformation.Project;

            Assert.Equal(ProjectPublishValidity.Published, projectPublishingInformation.Validity);
            Assert.Equal("en-US", projectInformation.SourceLanguageCode, ignoreCase: true);
            Assert.Equal("de-DE", projectInformation.TargetLanguageCodes.Single(), ignoreCase: true);
            Assert.Equal(ProjectStatus.Started, projectInformation.Status);
            Assert.NotNull(projectInformation.CreatedAt);
            Assert.Null(projectInformation.Customer);
            Assert.Null(projectInformation.CompletedAt);
            Assert.Null(projectPublishingInformation.PublishProjectInfo);

            await DeleteTestProject(projectId);
            await DeleteTestProjectTemplate(projectTemplateId);
        }

        [Fact]
        public async Task Projects_GetPublishingInformationForDifferentProjectStatuses()
        {
            var projectTemplateId = await CreateTestProjectTemplate();
            var projectId = await CreateTestProject(projectTemplateId);

            var projectStatusRequest = new ChangeStatusRequest(projectId, ChangeStatusRequest.ProjectStatus.Completed);
            await GroupShareClient.Project.ChangeProjectStatus(projectStatusRequest);

            var projectPublishingInformation = (await GroupShareClient.Project.GetProjectsPublishingInformation(projectId.ToString())).Single();
            Assert.Equal(ProjectPublishValidity.Published, projectPublishingInformation.Validity);
            Assert.Equal(ProjectStatus.Completed, projectPublishingInformation.Project.Status);
            Assert.NotNull(projectPublishingInformation.Project);

            projectStatusRequest = new ChangeStatusRequest(projectId, ChangeStatusRequest.ProjectStatus.Archived);
            await GroupShareClient.Project.ChangeProjectStatus(projectStatusRequest);
            projectPublishingInformation = (await GroupShareClient.Project.GetProjectsPublishingInformation(projectId.ToString())).Single();
            Assert.Equal(ProjectPublishValidity.Archived, projectPublishingInformation.Validity);
            Assert.Equal(ProjectStatus.Archived, projectPublishingInformation.Project.Status);
            Assert.NotNull(projectPublishingInformation.Project);

            await GroupShareClient.Project.DetachProject(projectId);
            projectPublishingInformation = (await GroupShareClient.Project.GetProjectsPublishingInformation(projectId.ToString())).Single();
            Assert.Equal(ProjectPublishValidity.Deleted, projectPublishingInformation.Validity);
            Assert.Null(projectPublishingInformation.Project);

            projectStatusRequest = new ChangeStatusRequest(projectId, ChangeStatusRequest.ProjectStatus.Completed);
            await GroupShareClient.Project.ChangeProjectStatus(projectStatusRequest);
            projectPublishingInformation = (await GroupShareClient.Project.GetProjectsPublishingInformation(projectId.ToString())).Single();
            Assert.Equal(ProjectPublishValidity.Published, projectPublishingInformation.Validity);
            Assert.Equal(ProjectStatus.Completed, projectPublishingInformation.Project.Status);
            Assert.NotNull(projectPublishingInformation.Project);

            await DeleteTestProject(projectId);
            await DeleteTestProjectTemplate(projectTemplateId);
        }

        [Fact]
        public async Task Projects_GetPublishingInformationForMultipleProjects()
        {
            var firstProjectTemplateId = await CreateTestProjectTemplate();
            var secondProjectTemplateId = await CreateTestProjectTemplate("default_en-de_fr_it.sdltpl");
            var firstProjectId = await CreateTestProject(firstProjectTemplateId);
            var secondProjectId = await CreateTestProject(secondProjectTemplateId, "FourWords.txt");

            var thirdProjectId = Guid.NewGuid();
            var projectIds = firstProjectId + "," + secondProjectId + "," + thirdProjectId;

            var projectPublishingInformation = await GroupShareClient.Project.GetProjectsPublishingInformation(projectIds);
            Assert.Equal(3, projectPublishingInformation.Count);

            var nonExistentProjectInformation = projectPublishingInformation.Single(p => p.ProjectId == thirdProjectId);
            Assert.Equal(ProjectPublishValidity.Deleted, nonExistentProjectInformation.Validity);
            Assert.Null(nonExistentProjectInformation.Project);
            Assert.Null(nonExistentProjectInformation.PublishProjectInfo);

            var firstProjectInformation = projectPublishingInformation.Single(p => p.ProjectId == firstProjectId);
            Assert.Null(firstProjectInformation.PublishProjectInfo);

            var secondProjectInformation = projectPublishingInformation.Single(p => p.ProjectId == secondProjectId);
            Assert.Null(secondProjectInformation.PublishProjectInfo);

            var expectedTargetLanguageCodes = new[] { "de-de", "fr-fr", "it-it" };
            Assert.True(expectedTargetLanguageCodes.SequenceEqual(secondProjectInformation.Project.TargetLanguageCodes, StringComparer.OrdinalIgnoreCase));
            Assert.Equal("en-us", secondProjectInformation.Project.SourceLanguageCode, ignoreCase: true);

            await DeleteTestProject(firstProjectId);
            await DeleteTestProject(secondProjectId);
            await DeleteTestProjectTemplate(firstProjectTemplateId);
            await DeleteTestProjectTemplate(secondProjectTemplateId);
        }

        private async Task<Guid> CreateProjectTemplateForPerfectMatch(string projectTemplateFilePath)
        {
            var projectTemplateData = File.ReadAllBytes(projectTemplateFilePath);
            var projectTemplateRequest = new ProjectTemplate
            {
                Name = "PerfectMatchProjectTemplate_" + Guid.NewGuid(),
                Description = "",
                OrganizationId = Guid.Parse(Helper.OrganizationId)
            };

            var projectTemplateId = await GroupShareClient.Project.CreateProjectTemplate(projectTemplateRequest, projectTemplateData);
            return projectTemplateId;
        }

        private static BasicCreateProjectRequest CreateBasicCreateProjectRequest(string projectTemplateId)
        {
            return new BasicCreateProjectRequest
            {
                Name = "Project - " + Guid.NewGuid(),
                Description = "",
                OrganizationId = Helper.OrganizationId,
                ProjectTemplateId = projectTemplateId,
                DueDate = null,
                ReferenceProjects = null,
                SuppressEmail = false,
                IsSecure = false
            };
        }

        private async Task<Guid> CreateTestProject(Guid projectTemplateId, string fileName = "")
        {
            var basicProjectCreateRequest = CreateBasicCreateProjectRequest(projectTemplateId.ToString());

            var filePath = fileName == ""
                ? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\Grammar.zip")
                : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\" + fileName);

            var projectId = await GroupShareClient.Project.CreateProject(basicProjectCreateRequest, filePath);

            var statusInfo = await WaitForProjectCreated(Guid.Parse(projectId));
            Assert.True(statusInfo);

            return Guid.Parse(projectId);
        }

        private async Task<Guid> CreateTestProjectTemplate(string fileName = "")
        {
            var rawData = fileName == "" ?
                File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\DefaultTemplate_en-de.sdltpl")) :
                File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\" + fileName));

            var templateRequest = new ProjectTemplate
            {
                Name = $"Project template - {Guid.NewGuid()}",
                OrganizationId = Guid.Parse(Helper.OrganizationId)
            };

            var templateId = await GroupShareClient.Project.CreateProjectTemplate(templateRequest, rawData);

            return templateId;
        }

        private async Task DeleteTestProject(Guid projectId)
        {
            await GroupShareClient.Project.DeleteProject(projectId);
        }

        private async Task DeleteTestProjectTemplate(Guid projectTemplateId)
        {
            await GroupShareClient.Project.DeleteProjectTemplate(projectTemplateId);
        }

        private async Task<bool> WaitForProjectCreated(Guid projectId, int retryInterval = 3, int maxTryCount = 15)
        {
            for (var i = 0; i < maxTryCount; i++)
            {
                var statusInfo = await GroupShareClient.Project.GetPublishingStatus(projectId);
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
        private async Task WaitForUpdateProjectBackgroundTaskToFinish(Guid projectId)
        {
            var filter = new BackgroundTasksRequestFilter { Type = new[] { 28 } }.SerializeFilter();

            var projectUpdateBackgroundTasks = (await GroupShareClient.Project.GetBackgroundTasks(filter)).Items;
            var backgroundTaskId = projectUpdateBackgroundTasks.First(task => task.ReferenceId == projectId).Id;

            BackgroundTask backgroundTask;
            do
            {
                projectUpdateBackgroundTasks = (await GroupShareClient.Project.GetBackgroundTasks(filter)).Items;
                backgroundTask = projectUpdateBackgroundTasks.Single(b => b.Id == backgroundTaskId);
            } while (backgroundTask.Status != (int)BackgroundTaskStatus.Done);
        }

        #endregion

        #region Project template tests

        [Fact]
        public async Task GetAllProjectsTemplates()
        {
            var templates = await GroupShareClient.Project.GetAllTemplates();

            Assert.True(templates.Count > 0);
        }

        [Fact]
        public async Task GetTemplateById()
        {
            var template = await GroupShareClient.Project.GetProjectTemplate(_projectTemplateId);

            Assert.True(template != string.Empty);
        }

        [Fact]
        public async Task GetProjectTemplateV3()
        {
            var template = await GroupShareClient.Project.GetProjectTemplateV3(_projectTemplateId);

            Assert.NotNull(template);
            Assert.True(template.SourceLanguageCode != string.Empty);
            Assert.True(template.TargetLanguageCodes.Count > 0);
        }

        [Fact]
        public async Task GetProjectTemplateV4()
        {
            var template = await GroupShareClient.Project.GetProjectTemplateV4(_projectTemplateId);

            Assert.NotNull(template);
            Assert.True(template.SourceLanguageCode != string.Empty);
            Assert.True(template.TargetLanguageCodes.Count > 0);
            Assert.False(template.EnableSegmentLockTask);
            Assert.False(template.EnableSdlXliffAnalysisReport);
        }

        [Fact]
        public async Task CreateTemplate()
        {
            var rawData = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\SampleTemplate.sdltpl"));

            var templateRequest = new ProjectTemplate
            {
                Name = $"Project template - {Guid.NewGuid()}",
                OrganizationId = Guid.Parse(Helper.OrganizationId)
            };

            var templateId = await GroupShareClient.Project.CreateProjectTemplate(templateRequest, rawData);
            var template = await GroupShareClient.Project.GetProjectTemplate(templateId);

            Assert.NotEqual(string.Empty, template);

            await GroupShareClient.Project.DeleteProjectTemplate(templateId);
        }

        [Fact]
        public async Task UpdateProjectTemplateV3_Succeeds()
        {
            var projectTemplateId = await CreateTestProjectTemplate();

            var templateRequest = new ProjectTemplateV3
            {
                Name = "Project template - " + projectTemplateId + " - edited",
                Description = "edited using GroupShare Kit",
                OrganizationId = Helper.OrganizationId,
                Settings = new ProjectTemplateSettingsV3
                {
                    SourceLanguageCode = "en-us",
                    TargetLanguageCodes = new[] { "fr-fr" },
                    Termbases = new List<TermbaseDetailsV3>(),
                    TranslationMemories = new List<TranslationMemoryDetailsV3>()
                }
            };

            await GroupShareClient.Project.UpdateProjectTemplateV3(projectTemplateId, templateRequest);
            var updatedProjectTemplate = await GroupShareClient.Project.GetProjectTemplateV3(projectTemplateId);

            Assert.Equal("en-us", updatedProjectTemplate.SourceLanguageCode);
            Assert.Equal("fr-fr", updatedProjectTemplate.TargetLanguageCodes.Single());
            Assert.Empty(updatedProjectTemplate.Termbases);
            Assert.Empty(updatedProjectTemplate.TranslationMemories);

            await GroupShareClient.Project.DeleteProjectTemplateV3(projectTemplateId);
        }

        [Fact]
        public async Task CreateProjectTemplateV4_default_SegmentLocking_settings()
        {
            var templateName = $"Project template - default Segment Locking settings - {Guid.NewGuid()}";
            var segmentLockingSettings = new List<SegmentLockingSettings>
            {
                new SegmentLockingSettings
                {
                    UseAndCondition = false,
                    TranslationStatuses = new List<string> { "ApprovedSignOff", "ApprovedTranslation", "Translated" },
                    TranslationOrigins = new List<string> { "TranslationMemory", "NeuralMachineTranslation" },
                    Score = 100,
                    MTQE = new List<string> { "Good" },
                    TargetLanguage = ""
                }
            };

            var templateSettings = new ProjectTemplateSettingsV4
            {
                EnableSegmentLockTask = true,
                SourceLanguageCode = "en-us",
                TargetLanguageCodes = new[] { "de-de" },
                Termbases = new List<TermbaseDetailsV3>(),
                SegmentLockingSettings = segmentLockingSettings,
                TranslationMemories = new List<TranslationMemoryDetailsV3>()
            };

            var templateRequest = new ProjectTemplateV4(templateName, description: "Segment Locking enabled", Guid.Parse(Helper.OrganizationId), templateSettings);
            var templateId = await GroupShareClient.Project.CreateProjectTemplateV4(templateRequest);

            Assert.NotEqual(Guid.Empty, templateId);

            await GroupShareClient.Project.DeleteProjectTemplateV4(templateId);
        }

        [Fact]
        public async Task UpdateProjectTemplateV4_SegmentLocking_settings()
        {
            var projectTemplateId = await CreateTestProjectTemplate();

            var segmentLockingSettings = new List<SegmentLockingSettings>
            {
                new SegmentLockingSettings
                {
                    UseAndCondition = true,
                    TranslationStatuses = new List<string> { "ApprovedSignOff", "Translated" },
                    TranslationOrigins = new List<string> { "DocumentMatch", "AutomatedAlignment", "AutoPropagated" },
                    Score = 99,
                    MTQE = new List<string> { "Good", "Adequate" },
                    TargetLanguage = ""
                }
            };

            var templateRequest = new ProjectTemplateV4
            {
                Name = "Project template - " + projectTemplateId + " - edited",
                Description = "edited using GroupShare Kit",
                OrganizationId = Guid.Parse(Helper.OrganizationId),
                Settings = new ProjectTemplateSettingsV4
                {
                    EnableSdlXliffAnalysisReport = true,
                    EnableSegmentLockTask = true,
                    SourceLanguageCode = "en-us",
                    TargetLanguageCodes = new[] { "fr-fr" },
                    Termbases = new List<TermbaseDetailsV3>(),
                    SegmentLockingSettings = segmentLockingSettings,
                    TranslationMemories = new List<TranslationMemoryDetailsV3>()
                }
            };

            await GroupShareClient.Project.UpdateProjectTemplateV4(projectTemplateId, templateRequest);
            var updatedProjectTemplate = await GroupShareClient.Project.GetProjectTemplateV4(projectTemplateId);

            Assert.Equal("en-us", updatedProjectTemplate.SourceLanguageCode);
            Assert.Equal("fr-fr", updatedProjectTemplate.TargetLanguageCodes.Single());
            Assert.Empty(updatedProjectTemplate.Termbases);
            Assert.Empty(updatedProjectTemplate.TranslationMemories);
            Assert.True(updatedProjectTemplate.EnableSdlXliffAnalysisReport);
            Assert.True(updatedProjectTemplate.EnableSegmentLockTask);
            Assert.True(updatedProjectTemplate.SegmentLockingSettings.Single().UseAndCondition);
            Assert.Equal(99, updatedProjectTemplate.SegmentLockingSettings.Single().Score);

            await GroupShareClient.Project.DeleteProjectTemplateV4(projectTemplateId);
        }

        #endregion

        #region File version tests
        [Fact]
        public async Task GetFileVersions()
        {
            var fileVersion = await GroupShareClient.Project.GetFileVersions(_languageFileId);

            Assert.True(fileVersion.Count > 0);
        }

        [Fact]
        public async Task DownloadFileVersion()
        {
            var downloadedFile = await GroupShareClient.Project.DownloadFileVersion(_projectId, _languageFileId, 2);

            Assert.True(downloadedFile.Length > 0);
        }
        #endregion

    }
}