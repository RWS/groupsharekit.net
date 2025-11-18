using Sdl.Community.GroupShareKit.Exceptions;
using Sdl.Community.GroupShareKit.Models;
using Sdl.Community.GroupShareKit.Models.Response;
using Sdl.Community.GroupShareKit.Models.Response.ProjectPublishingInformation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project = Sdl.Community.GroupShareKit.Models.Response.Project;

namespace Sdl.Community.GroupShareKit.Clients
{
    /// <summary>
    /// A client for GroupShare's Project API.
    /// </summary>
    /// <remarks>
    /// </remarks>
    public interface IProjectClient
    {
        #region Project management methods

        /// <summary>
        /// Gets a <see cref="Project"/>.
        /// </summary>
        /// <remarks>
        /// <param name="request"><see cref="ProjectsRequest"/></param>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns><see cref="Project"/></returns>
        Task<Project> GetProject(ProjectsRequest request);

        /// <summary>
        /// Gets all <see cref="Project"/>s.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="Project"/>s.</returns>
        Task<Project> GetAllProjects();

        /// <summary>
        /// Gets all <see cref="Project"/>s for the organization.
        /// </summary>
        /// <remarks>
        /// <param name="organizationName">string</param>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="ProjectDetails"/>s.</returns>
        List<ProjectDetails> GetProjectsForOrganization(string organizationName);

        /// <summary>
        /// Gets all <see cref="File"/>s of a project.
        /// </summary>
        /// <param name="projectId">The project's Guid.</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="File"/>s.</returns>
        Task<IReadOnlyList<File>> GetProjectFiles(Guid projectId);

        /// <summary>
        /// Gets all <see cref="Phase"/>s for a project.
        /// </summary>
        /// <param name="projectId">The project's Guid.</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="Phase"/>s.</returns>
        Task<IReadOnlyList<Phase>> GetProjectPhases(Guid projectId);

        /// <summary>
        /// Gets a list of files with all phases with assignee information.
        /// </summary>
        /// <param name="projectId">The project's Guid</param>
        /// <param name="phaseId">The Id of the project phase used for filtering. This parameter is optional.</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="PhasesWithAssignees"/>.</returns>
        Task<IReadOnlyList<PhasesWithAssignees>> GetPhasesWithAssignees(Guid projectId, int phaseId);

        /// <summary>
        /// Changes the phases for a list of files of a specific project.
        /// </summary>
        /// <param name="projectId">The project's Guid.</param>
        /// <param name="request"><see cref="ChangePhaseRequest"/></param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task ChangePhase(Guid projectId, ChangePhaseRequest request);

        /// <summary>
        /// Changes user assignment for a specific project files list for a specific phase.
        /// </summary>
        /// <param name="projectId">The project's Guid.</param>
        /// <param name="request"><see cref="ChangeAssignmentRequest"/></param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task ChangeAssignment(Guid projectId, ChangeAssignmentRequest request);

        /// <summary>
        /// Create project
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task<string> CreateProject(CreateProjectRequest request);

        /// <summary>
        /// Creates an empty project.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>The project id</returns>
        Task<string> CreateProjectSkeleton(CreateProjectSkeletonRequest request);

        /// <summary>
        /// Create project
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <param name="request">The basic project parameters</param>
        /// <param name="filesPath">The path pointing to the files for the project. The path can be a zip file, a single file, or a directory. 
        /// If it is a zip file path, the zip should have a folder SourceFiles, an optional folder ReferenceFiles, and an optional folder PerfectMatchFiles.
        /// If it is a file, the project will be created as a single file project. If it is a directory, all the files under the directory will be the project files. 
        /// </param>
        /// <param name="referenceFilesPath">If filesPath parameter is not a zip file, this optional parameter points to a reference file or a directory containing reference files.</param>
        /// <param name="perfectMatchFilesPaths">If filesPath parameter is not a zip file, this optional parameter points to a directories containing the perfect match files.
        /// </param>
        /// <returns>The project Id</returns>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task<string> CreateProject(BasicCreateProjectRequest request, string filesPath, string referenceFilesPath = null, string[] perfectMatchFilesPaths = null);

        /// <summary>
        /// Deletes a project.
        /// </summary>
        /// <param name="projectId">The project's Guid.</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task DeleteProject(Guid projectId);

        /// <summary>
        /// Gets a project by Id.
        /// </summary>
        /// <param name="projectId">The project's Guid.</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns><see cref="ProjectDetails"/></returns>
        Task<ProjectDetails> GetProject(Guid projectId);

        /// <summary>
        /// Gets the publishing status of a project.
        /// </summary>
        /// <param name="projectId">The project's Guid.</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns><see cref="PublishingStatus"/></returns>
        Task<PublishingStatus> GetPublishingStatus(Guid projectId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectIds"></param>
        /// <returns></returns>
        Task<List<ProjectPublishingInformation>> GetProjectsPublishingInformation(string projectIds);

        /// <summary>
        /// Downloads files with specific language file Ids.
        /// </summary>
        /// <param name="projectId">The project's Guid.</param>
        /// <param name="languageFileIds">Language file Guids.</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>Downloaded files content.</returns>
        Task<byte[]> DownloadFiles(Guid projectId, List<Guid> languageFileIds);

        /// <summary>
        ///Downloads the files with the specific type and language code.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of byte[] which represents downloaded files.</returns>
        Task<byte[]> DownloadFile(FileDownloadRequest downloadRequest);

        /// <summary>
        /// Downloads the native files of a project.
        /// </summary>
        /// <param name="projectId">The project's Guid.</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>Downloaded files content.</returns>
        Task<byte[]> DownloadNative(Guid projectId);

        /// <summary>
        /// Finalizes files of a project.
        /// </summary>
        /// <param name="projectId">The project's Guid</param>
        /// <param name="languageFileIds">Language files Guids</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>Downloaded file content.</returns>
        Task<byte[]> Finalize(Guid projectId, List<Guid> languageFileIds);

        /// <summary>
        /// Gets a list of user assignments.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="UserAssignments"/>.</returns>
        Task<IReadOnlyList<UserAssignments>> GetUserAssignments();

        /// <summary>
        /// Gets a list of assignments for a project.
        /// </summary>
        /// <param name="projectId">The project's Guid</param>
        /// <param name="fileIdsList">Language file Ids</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="ProjectAssignment"/>s.</returns>
        Task<IReadOnlyList<ProjectAssignment>> GetProjectAssignmentById(Guid projectId, List<Guid> fileIdsList);

        /// <summary>
        /// Uploads file for a specific project.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task<string> UploadFilesForProject(string projectId, byte[] rawData, string projectName);

        /// <summary>
        /// Add new files to an existing project.
        /// </summary>
        /// <param name="projectId">The project's Guid</param>
        /// <param name="filesPath"></param>
        /// <param name="reference">Indicates if the files to be added are reference files or not.</param>
        /// <returns><see cref="MidProjectUpdateResponse"/></returns>
        Task<MidProjectUpdateResponse> AddFiles(Guid projectId, string filesPath, bool reference = false);

        /// <summary>
        /// Updates files of an existing project without any file selection.
        /// </summary>
        /// <param name="projectId">The project's Guid</param>
        /// <param name="filesPath"></param>
        /// <param name="reference">Indicates if the files to be updated are reference files or not.</param>
        /// <returns></returns>
        Task<MidProjectUpdateResponse> UpdateFiles(Guid projectId, string filesPath, bool reference = false);

        /// <summary>
        /// Updates the selected files of an existing project.
        /// </summary>
        /// <param name="projectId">The project's Guid</param>
        /// <param name="filesPath"></param>
        /// <param name="fileIds">The files Guids</param>
        /// <param name="reference">Indicates if the files to be updated are reference files or not.</param>
        /// <returns></returns>
        Task<MidProjectUpdateResponse> UpdateSelectedFiles(Guid projectId, string filesPath, MidProjectFileIdsModel fileIds, bool reference = false);

        /// <summary>
        /// Cancels the selected files of an existing project.
        /// </summary>
        /// <param name="projectId">The project's Guid</param>
        /// <param name="fileIds">The files Guids.</param>
        /// <returns></returns>
        Task<string> CancelProjectFiles(Guid projectId, MidProjectFileIdsModel fileIds);

        /// <summary>
        ///Change project status
        /// <param name="statusRequest"><see cref="ChangeStatusRequest"/></param>
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task<string> ChangeProjectStatus(ChangeStatusRequest statusRequest);

        /// <summary>
        /// Detaches a project, with the possibility to delete project TMs.
        /// </summary>
        /// <param name="projectId">The project's Guid.</param>
        /// <param name="deleteProjectTMs">If true, project TMs will be deleted after the project is detached.</param>
        Task DetachProject(Guid projectId, bool deleteProjectTMs = false);

        /// <summary>
        /// Change project status detach
        /// <param name="statusRequest"><see cref="ChangeStatusRequest"/></param>
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task<string> ChangeProjectStatusDetach(ChangeStatusRequest statusRequest);

        /// <summary>
        /// Deletes detach to a project status
        /// <param name="projectId deleteTms">></param>
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task ChangeProjectStatusDeleteDetach(string projectId, bool deleteTms);

        /// <summary>
        /// Publishes a project package (.sdlppx)
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        Task PublishPackage(string projectId, byte[] rawData);

        /// <summary>
        /// Initiates a cancel for project package publishing
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        Task CancelPublishPackage(string projectId);

        /// <summary>
        /// Gets a list of file statistics for a project.
        /// </summary>
        /// <param name="projectId">The project's Guid.</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="ProjectFileStatistics"/>s.</returns>
        Task<IReadOnlyList<ProjectFileStatistics>> GetAllProjectFileStatistics(Guid projectId);

        /// <summary>
        /// Gets the project language statistics.
        /// </summary>
        /// <param name="projectId"></param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A dictionary with the key representing the language code and the value as project statistics.</returns>
        Task<Dictionary<string, ProjectStatistics>> GetProjectLanguageStatistics(Guid projectId);

        Task<bool> IsProjectNameInUse(IsProjectNameInUseRequest request);

        #endregion

        #region Project template client

        /// <summary>
        ///Gets all templates
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A List of <see cref="ProjectTemplates"/></returns>
        Task<IReadOnlyList<ProjectTemplates>> GetAllTemplates();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyList<ProjectTemplate>> GetProjectTemplates();

        /// <summary>
        /// Creates a project template.
        /// </summary>
        /// <param name="projectTemplateRequest"><see cref="ProjectTemplates"/></param>
        /// <param name="rawData"></param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>The project template's Guid.</returns>
        Task<Guid> CreateProjectTemplate(ProjectTemplate projectTemplateRequest, byte[] rawData);

        /// <summary>
        /// Gets a project template by Id.
        /// </summary>
        /// <param name="templateId">The project template's Guid.</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>The content of the project template as a string.</returns>
        Task<string> GetProjectTemplate(Guid templateId);

        /// <summary>
        /// Gets a project template by Id.
        /// </summary>
        /// <param name="templateId">Project template GUID</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>The project template data.</returns>
        Task<ProjectTemplateSettingsV3> GetProjectTemplateV3(Guid templateId);

        /// <summary>
        /// Updates a project template.
        /// </summary>
        /// <param name="templateId">Project template GUID</param>
        /// <param name="templateRequest"><see cref="ProjectTemplateV3"/></param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>The GUID of the project template.</returns>
        Task<Guid> UpdateProjectTemplateV3(Guid templateId, ProjectTemplateV3 templateRequest);

        /// <summary>
        /// Gets a project template by id.
        /// </summary>
        /// <param name="templateId">Project template GUID</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>The project template data.</returns>
        Task<ProjectTemplateSettingsV4> GetProjectTemplateV4(Guid templateId);

        /// <summary>
        /// Creates a project template
        /// </summary>
        /// <param name="templateRequest"><see cref="ProjectTemplateV4"/></param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>The GUID of the created project template</returns>
        Task<Guid> CreateProjectTemplateV4(ProjectTemplateV4 templateRequest);

        /// <summary>
        /// Updates a project template
        /// </summary>
        /// <param name="templateId">Project template GUID</param>
        /// <param name="templateRequest"><see cref="ProjectTemplateV4"/></param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>The GUID of the project template</returns>
        Task<Guid> UpdateProjectTemplateV4(Guid templateId, ProjectTemplateV4 templateRequest);

        /// <summary>
        /// Deletes a project template.
        /// </summary>
        /// <param name="templateId">The project template's Guid.</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task DeleteProjectTemplate(Guid templateId);

        /// <summary>
        /// Deletes a project template
        /// </summary>
        /// <param name="templateId">Project template GUID</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task DeleteProjectTemplateV3(Guid templateId);

        /// <summary>
        /// Deletes a project template
        /// </summary>
        /// <param name="templateId">Project template GUID</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task DeleteProjectTemplateV4(Guid templateId);

        /// <summary>
        /// Uploads a project template.
        /// </summary>
        /// <param name="templateId">The project template Guid.</param>
        /// <param name="projectTemplate"></param>
        /// <param name="templateName"></param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>The project template's Guid.</returns>
        Task<Guid> UploadProjectTemplate(Guid templateId, byte[] projectTemplate, string templateName);

        #endregion

        #region file version methods

        /// <summary>
        /// Gets file versions information.
        /// </summary>
        /// <param name="languageFileId">The language file Guid</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="FileVersion"/>.</returns>
        Task<IReadOnlyList<FileVersion>> GetFileVersions(Guid languageFileId);

        /// <summary>
        /// Downloads a language file version.
        /// </summary>
        /// <param name="projectId">The project's Guid</param>
        /// <param name="languageFileId">The language file Guid</param>
        /// <param name="version">File version</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>Downloaded file content.</returns>
        Task<byte[]> DownloadFileVersion(Guid projectId, Guid languageFileId, int version);

        #endregion

        /// <summary>
        /// Gets the analysis reports for a specific project.
        /// </summary>
        /// <param name="projectId">The project's Guid.</param>
        /// <param name="languageCode"></param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="AnalysisReports"/>.</returns>
        Task<IReadOnlyList<AnalysisReports>> GetAnalysisReports(Guid projectId, string languageCode);

        /// <summary>
        /// Get the project analysis report for a given project in HTML format (the format only refers to the Report property).
        /// The project must be created in GroupShare, not in Studio and published in GroupShare.
        /// </summary>
        /// <param name="projectId">The project's Guid</param>
        /// <param name="languageCode"></param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="AnalysisReportWithMimeType"/>.</returns>
        Task<IReadOnlyList<AnalysisReportWithMimeType>> GetAnalysisReportsAsHtml(Guid projectId, string languageCode);

        /// <summary>
        /// Get the project analysis report for a given project in XML format (the format only refers to the Report property).
        /// The project must be created in GroupShare, not in Studio and published in GroupShare.
        /// </summary>
        /// <param name="projectId">The project's Guid.</param>
        /// <param name="languageCode"></param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="AnalysisReportWithMimeType"/>.</returns>
        Task<IReadOnlyList<AnalysisReportWithMimeType>> GetAnalysisReportsAsXml(Guid projectId, string languageCode);

        /// <summary>
        /// Get the project analysis reports v3 for a given project.
        /// The project must be created or updated via Mid Project Update in GroupShare in order to have reports on GroupShare.
        /// </summary>
        /// <param name="projectId">The project's Guid</param>
        /// <param name="languageCode">Optional language code. Eg: en-US</param>
        /// <param name="reportId">Optional report id</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="AnalysisReports"/>.</returns>
        Task<IReadOnlyList<AnalysisReports>> GetAnalysisReportsV3(Guid projectId, string languageCode = null, int? reportId = null);

        /// <summary>
        /// Get the MTQE analysis reports for a project
        /// The project must be created or updated via Mid Project Update in GroupShare in order to have reports on GroupShare
        /// </summary>
        /// <param name="projectId">The project GUID</param>
        /// <param name="languageCode">Optional language code. Eg: en-US</param>
        /// <param name="reportId">Optional report id</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>List <see cref="AnalysisReports"/>s.</returns>
        Task<IReadOnlyList<AnalysisReports>> GetMTQEAnalysisReportsV3(Guid projectId, string languageCode = null, int? reportId = null);

        /// <summary>
        /// Get the MTQE analysis reports for a project in HTML format (the format only refers to the Report property)
        /// The project must be created or updated via Mid Project Update in GroupShare in order to have reports on GroupShare 
        /// </summary>
        /// <param name="projectId">The project GUID</param>
        /// <param name="languageCode">Optional language code. Eg: en-US</param>
        /// <param name="reportId">Optional report id</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>List <see cref="AnalysisReportWithMimeTypeV3"/>s.</returns>
        Task<IReadOnlyList<AnalysisReportWithMimeTypeV3>> GetMTQEAnalysisReportsV3AsHtml(Guid projectId, string languageCode = null, int? reportId = null);

        /// <summary>
        /// Get the MTQE analysis reports for a project in XML format (the format only refers to the Report property)
        /// The project must be created or updated via Mid Project Update in GroupShare in order to have reports on GroupShare 
        /// </summary>
        /// <param name="projectId">The project GUID</param>
        /// <param name="languageCode">Optional language code. Eg: en-US</param>
        /// <param name="reportId">Optional report id</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>List <see cref="AnalysisReportWithMimeTypeV3"/>s.</returns>
        Task<IReadOnlyList<AnalysisReportWithMimeTypeV3>> GetMTQEAnalysisReportsV3AsXml(Guid projectId, string languageCode = null, int? reportId = null);

        /// <summary>
        /// Get the project analysis report v3 for a given project in HTML format (the format only refers to the Report property)
        /// The project must be created or updated via Mid Project Update in GroupShare in order to have reports on GroupShare. 
        /// </summary>
        /// <param name="projectId">The project Guid</param>
        /// <param name="languageCode">Optional language code. Eg: en-US</param>
        /// <param name="reportId">Optional report id</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="AnalysisReportWithMimeTypeV3"/>.</returns>
        Task<IReadOnlyList<AnalysisReportWithMimeTypeV3>> GetAnalysisReportsV3AsHtml(Guid projectId, string languageCode = null, int? reportId = null);

        /// <summary>
        /// Get the project analysis report v3 for a given project in XML format (the format only refers to the Report property)
        /// The project must be created or updated via Mid Project Update in GroupShare in order to have reports on GroupShare
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="AnalysisReportWithMimeTypeV3"/>.</returns>
        Task<IReadOnlyList<AnalysisReportWithMimeTypeV3>> GetAnalysisReportsV3AsXml(Guid projectId, string languageCode = null, int? reportId = null);

        /// <summary>
        /// Gets project settings for a given language file.
        /// </summary>
        /// <param name="projectId">The project GUID</param>
        /// <param name="languageFileId">The language file GUID</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns><see cref="LanguageFileSettings"/></returns>
        Task<LanguageFileSettings> GetLanguageFileSettings(Guid projectId, Guid languageFileId);

        /// <summary>
        /// Get project general settings
        /// </summary>
        /// <param name="projectId">The project GUID</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns><see cref="ProjectSettingsV2"/></returns>
        Task<ProjectSettingsV2> GetProjectSettings(Guid projectId);

        /// <summary>
        /// Get project general settings
        /// </summary>
        /// <param name="projectId">The project GUID</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns><see cref="ProjectSettingsV4"/></returns>
        Task<ProjectSettingsV4> GetProjectSettingsV4(Guid projectId);

        /// <summary>
        /// Retrieves the Segment Locking configuration
        /// </summary>
        Task<dynamic> GetGetSegmentLockingConfig();

        /// <summary>
        /// Validates that the user can open the file in Universal Editor.
        /// </summary>
        /// <param name="projectId">The project's Guid</param>
        /// <param name="languageFileId">The language file's Guid</param>
        /// <returns></returns>
        Task<string> IsUserAuthorizedToOpenFile(Guid projectId, Guid languageFileId);

        /// <summary>
        /// Gets the features associated to basic or advanced editor profile mode.
        /// </summary>
        /// <param name="projectId">The project's Guid</param>
        /// <param name="languageFileId">The language file's Guid</param>
        /// <returns><see cref="EditorProfile"/></returns>
        Task<EditorProfile> EditorProfile(Guid projectId, Guid languageFileId);

        /// <summary>
        /// Checks in a file.
        /// </summary>
        /// <param name="projectId">The project's Guid</param>
        /// <param name="languageFileId">The language file's Guid</param>
        /// <param name="onlineCheckInRequest"></param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns></returns>
        Task<OnlineCheckInRequest> OnlineCheckin(Guid projectId, Guid languageFileId, OnlineCheckInRequest onlineCheckInRequest);

        /// <summary>
        /// Checks out a file for editing in the Universal Editor.
        /// </summary>
        /// <param name="projectId">The project's Guid</param>
        /// <param name="languageFileId">The language file's Guid</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns></returns>
        Task<OnlineCheckInRequest> OnlineCheckout(Guid projectId, Guid languageFileId);

        /// <summary>
        /// Undoes an online checkout, note that you will lose all the changes done inside the OnlineEditor. To make a proper checkin use the OnlineCheckOutController.
        /// </summary>
        /// <param name="projectId">The project's Guid</param>
        /// <param name="languageFileId">The language file's Guid</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task UndoCheckout(Guid projectId, Guid languageFileId);

        /// <summary>
        /// Health check call used to keep the OE license advanced/basic seat taken.
        /// By default, if no parameter advanced/basic is passed in api route, advanced mode is checkout.
        /// </summary>
        /// This method requires authentication.
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task<string> OnlineCheckoutHealthCheck(string editorProfileMode);

        /// <summary>
        /// Checks if the given language file is check-out to someone other than the user making this call.
        /// </summary>
        /// <param name="languageFileId">The language file's Guid</param>
        /// <param name="editorProfileMode">Editor profile mode</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns></returns>
        Task<bool> IsCheckoutToSomeoneElse(Guid languageFileId, string editorProfileMode);

        /// <summary>
        /// Checks in a file.
        /// </summary>
        /// <param name="projectId">The project's Guid.</param>
        /// <param name="languageFileId">The language file's Guid.</param>
        /// <param name="comment">Optional comment.</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns></returns>
        Task<string> ExternalCheckin(Guid projectId, Guid languageFileId, string comment);

        /// <summary>
        /// Checks out a file for editing.
        /// </summary>
        /// <param name="projectId">The project's Guid</param>
        /// <param name="languageFileId">The language file's Guid</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task<string> ExternalCheckout(Guid projectId, Guid languageFileId);

        /// <summary>
        /// Checks-out multiple files for editing.
        /// </summary>
        /// <param name="projectId">The project's Guid</param>
        /// <param name="filesIds">Language file Ids to check-out</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        Task ExternalCheckOutFiles(Guid projectId, List<Guid> filesIds);

        /// <summary>
        /// Checks-in files.
        /// </summary>
        /// <param name="projectId">The project's Guid</param>
        /// <param name="externalCheckInData">Array of language file Ids to check-in and optional comment</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task ExternalCheckInFiles(Guid projectId, ExternalCheckInData externalCheckInData);

        /// <summary>
        /// Performs undo external check-out for multiple files.
        /// </summary>
        /// <param name="projectId">The project's Guid</param>
        /// <param name="filesIds">Language files ids to undo external check-out for</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task UndoExternalCheckOutForFiles(Guid projectId, List<Guid> filesIds);

        /// <summary>
        /// Gets the audit trail for all the language files of a project.
        /// </summary>
        /// <param name="projectId">The project's Guid</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="AuditTrail"/>.</returns>
        Task<IReadOnlyList<AuditTrail>> AuditTrail(Guid projectId);

        /// <summary>
        /// Get background tasks list
        /// </summary>
        /// <returns></returns>
        Task<JsonCollection<BackgroundTask>> GetBackgroundTasks(string filter = null, int limit = 50);
    }
}