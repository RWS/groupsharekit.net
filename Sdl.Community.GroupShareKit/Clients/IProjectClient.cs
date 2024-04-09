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
    /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">Project API documentation</a> for more details.
    /// </remarks>
    public interface IProjectClient
    {
        #region Project management methods

        /// <summary>
        /// Gets a <see cref="Project"/>s
        /// </summary>
        /// <remarks>
        /// <param name="request"><see cref="ProjectsRequest"/></param>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns><see cref="Project"/></returns>
        Task<Project> GetProject(ProjectsRequest request);

        /// <summary>
        /// Gets all <see cref="Project"/>s
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
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
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="ProjectDetails"/>s.</returns>
        List<ProjectDetails> GetProjectsForOrganization(string organizationName);

        /// <summary>
        /// Gets all <see cref="File"/>s for  project.
        /// </summary>
        /// <param name="projectId">string</param>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="File"/>s.</returns>
        Task<IReadOnlyList<File>> GetAllFilesForProject(string projectId);

        /// <summary>
        /// Gets all <see cref="Phase"/>s for the project.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="Phase"/>s.</returns>
        Task<IReadOnlyList<Phase>> GetAllPhasesForProject(string projectId);

        /// <summary>
        /// Gets the list of files for the requested project with all the project phases and theirs assignees <see cref="PhasesWithAssignees"/>
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="PhasesWithAssignees"/>s.</returns>
        Task<IReadOnlyList<PhasesWithAssignees>> GetPhasesWithAssignees(string projectId, int phaseId);

        /// <summary>
        /// Changes the phases for files from a server project
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="Phase"/>s.</returns>
        Task ChangePhases(string projectId, ChangePhaseRequest request);

        /// <summary>
        /// Changes the assignment for a specific phase for files from a server project,
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="Phase"/>s.</returns>
        Task ChangeAssignments(string projectId, ChangeAssignmentRequest request);

        /// <summary>
        /// Create project
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
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
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
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
        Task<string> CreateProject(BasicCreateProjectRequest request,
            string filesPath, string referenceFilesPath = null, string[] perfectMatchFilesPaths = null);

        /// <summary>
        /// Delete project
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task DeleteProject(string projectId);

        /// <summary>
        /// Get project
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> <see cref="ProjectDetails"/></returns>
        Task<ProjectDetails> Get(string projectId);

        /// <summary>
        /// Get the publishing status of a server project.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> <see cref="PublishingStatus"/></returns>
        Task<PublishingStatus> PublishingStatus(string projectId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectIds"></param>
        /// <returns></returns>
        Task<List<ProjectPublishingInformation>> GetProjectsPublishingInformation(string projectIds);

        /// <summary>
        ///Downloads the files with the specific language ids.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of byte[] which represents downloaded files.</returns>
        Task<byte[]> DownloadFiles(string projectId, List<string> languageFileIds);

        /// <summary>
        ///Downloads the files with the specific type and language code.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
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
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of byte[] which represents downloaded files.</returns>>
        Task<byte[]> DownloadNative(string projectId);

        /// <summary>
		/// Finalizes the files of a project.
		/// </summary>
		/// <remarks>
		/// This method requires authentication.
		/// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
		/// </remarks>
		/// <exception cref="AuthorizationException">
		/// Thrown when the current user does not have permission to make the request.
		/// </exception>
		/// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
		/// <returns>A list of byte[] which represents downloaded files.</returns>
        Task<byte[]> Finalize(string projectId, List<string> languageFileIds);

        /// <summary>
        ///Gets a list of user assignments
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="UserAssignments"/>s.</returns>
        Task<IReadOnlyList<UserAssignments>> GetUserAssignments();

        /// <summary>
        ///Gets a list of assignments for a project
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="ProjectAssignment"/>s.</returns>
        Task<IReadOnlyList<ProjectAssignment>> GetProjectAssignmentById(string projectId, List<string> fileIdsList);

        /// <summary>
        ///Uploads file for a specific project
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task<string> UploadFilesForProject(string projectId, byte[] rawData, string projectName);

        /// <summary>
        /// Adds files to an existing project
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="filesPath"></param>
        /// <param name="reference"></param>
        /// <returns></returns>
        Task<MidProjectUpdateResponse> AddFiles(string projectId, string filesPath, bool reference = false);

        /// <summary>
        /// Updates files of an existing project without any file selection
        /// </summary>
        Task<MidProjectUpdateResponse> UpdateFiles(string projectId, string filesPath, bool reference = false);

        /// <summary>
        /// Updates selected files of an existing project
        /// </summary>
        Task<MidProjectUpdateResponse> UpdateSelectedFiles(string projectId, string filesPath, MidProjectFileIdsModel fileIds, bool reference = false);

        /// <summary>
        /// Cancels selected files of an existing project
        /// </summary>
        Task<string> CancelProjectFiles(string projectId, MidProjectFileIdsModel fileIds);

        /// <summary>
        ///Change project status
        /// <param name="statusRequest"><see cref="ChangeStatusRequest"/></param>
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task<string> ChangeProjectStatus(ChangeStatusRequest statusRequest);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="deleteProjectTMs"></param>
        /// <returns></returns>
        Task DetachProject(string projectId, bool deleteProjectTMs = false);

        /// <summary>
        ///Change project status detach
        /// <param name="statusRequest"><see cref="ChangeStatusRequest"/></param>
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task<string> ChangeProjectStatusDetach(ChangeStatusRequest statusRequest);

        /// <summary>
        ///Deletes detach to a project status
        /// <param name="projectId deleteTms">></param>
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task ChangeProjectStatusDeleteDetach(string projectId, bool deleteTms);

        /// <summary>
        ///Publish  project
        /// <param name="projectRequest"><see cref="CreateProjectRequest"/></param>
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>

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
        ///Gets a list of file statistics for a project
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="GetAllProjectFileStatistics"/>s.</returns>
        Task<IReadOnlyList<ProjectFileStatistics>> GetAllProjectFileStatistics(string projectId);

        /// <summary>
        /// Get the project language statistics.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A dictionary with the key representing the language code and the value as project statistics </returns>
        Task<Dictionary<string, ProjectStatistics>> GetProjectLanguageStatistics(string projectId);

        Task<bool> IsProjectNameInUse(IsProjectNameInUseRequest request);

        #endregion

        #region Project template client

        /// <summary>
        ///Gets all templates
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A List of <see cref="ProjectTemplates"/></returns>
        Task<IReadOnlyList<ProjectTemplates>> GetAllTemplates();

        /// <summary>
        ///Creates a template
        /// </summary>
        /// <param name="projectRequest"><see cref="ProjectTemplates"/></param>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>Id of created template/></returns>
        Task<string> CreateTemplate(ProjectTemplates projectRequest, byte[] rawData);

        /// <summary>
        ///Get a template by id
        /// </summary>
        /// <param name="templateId">string</param>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>Te contend of template in a string/></returns>
        Task<string> GetTemplateById(string templateId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="templateId"></param>
        /// <returns></returns>
        Task<ProjectTemplateSettingsV4> GetProjectTemplateV4(Guid templateId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="templateRequest"></param>
        /// <returns></returns>
        Task<Guid> CreateProjectTemplateV4(ProjectTemplateV4 templateRequest);

        /// <summary>
        ///Deletes a template 
        /// </summary>
        /// <param name="id">string</param>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task DeleteProjectTemplate(string id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteProjectTemplateV3(Guid id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteProjectTemplateV4(Guid id);

        /// <summary>
        ///Uploads a template to a newly created project 
        /// This method should be called after you create a project in order to add the template
        /// </summary>
        /// <param name="templateId">string</param>
        /// <param name="projectTemplate">byte[]</param>
        /// <param name="templateName">string</param>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task<string> UploadProjectTemplate(string templateId, byte[] projectTemplate, string templateName);

        #endregion

        #region file version methods

        /// <summary>
        /// Gets file versions information<see cref="FileVersion"/>.
        /// </summary>
        ///  <param name="languageFileId">Language file id></param>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> List <see cref="FileVersion"/>s.</returns>
        Task<IReadOnlyList<FileVersion>> GetFileVersions(string languageFileId);

        /// <summary>
        /// Downloads the file/>.
        /// </summary>
        /// <param name="projectId">The project id</param>
        /// <param name="languageFileId"> Language file id</param>
        /// <param name="version"> File version</param>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> Downloaded file in bytes[].</returns>
        Task<byte[]> DownloadFileVersion(string projectId, string languageFileId, int version);

        #endregion

        /// <summary>
        /// Get the project analysis report for a given project.
        /// The project must be created in GroupShare, not in Studio and published in GS
        /// </summary>
        /// <param name="projectId">The project id</param>
        /// <param name="languageCode"> language code. Eg: en-US</param>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> List <see cref="AnalysisReports"/>s.</returns>
        Task<IReadOnlyList<AnalysisReports>> GetAnalysisReports(string projectId, string languageCode);

        /// <summary>
        /// Get the project analysis report for a given project, in html format.
        /// The project must be created in GroupShare, not in Studio and published in GS
        /// </summary>
        /// <param name="projectId">The project id</param>
        /// <param name="languageCode"> language code. Eg: en-US</param>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> List <see cref="AnalysisReportWithMimeType"/>s.</returns>
        Task<IReadOnlyList<AnalysisReportWithMimeType>> GetAnalysisReportsAsHtml(string projectId, string languageCode);

        /// <summary>
        /// Get the project analysis report for a given project, in xml format.
        /// The project must be created in GroupShare, not in Studio and published in GS
        /// </summary>
        /// <param name="projectId">The project id</param>
        /// <param name="languageCode"> language code. Eg: en-US</param>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> List <see cref="AnalysisReportWithMimeType"/>s.</returns>
        Task<IReadOnlyList<AnalysisReportWithMimeType>> GetAnalysisReportsAsXml(string projectId, string languageCode);

        /// <summary>
        /// Get the project analysis report v3 for a given project
        /// The project must be created or updated via Mid Project Update in GroupShare in order to have reports on GroupShare
        /// </summary>
        /// <param name="projectId">The project id</param>
        /// <param name="languageCode"> Optional language code. Eg: en-US</param>
        /// <param name="reportId"> Optional report id</param>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> List <see cref="AnalysisReports"/>s.</returns>
        Task<IReadOnlyList<AnalysisReports>> GetAnalysisReportsV3(string projectId, string languageCode = null, int? reportId = null);

        /// <summary>
        /// Get the project analysis report v3 for a given project, in html format.
        /// The project must be created or updated via Mid Project Update in GroupShare in order to have reports on GroupShare
        /// </summary>
        /// <param name="projectId">The project id</param>
        /// <param name="languageCode"> Optional language code. Eg: en-US</param>
        /// <param name="reportId"> Optional report id</param>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> List <see cref="AnalysisReportWithMimeTypeV3"/>s.</returns>
        Task<IReadOnlyList<AnalysisReportWithMimeTypeV3>> GetAnalysisReportsV3AsHtml(string projectId, string languageCode = null, int? reportId = null);

        /// <summary>
        /// Get the project analysis report v3 for a given project, in json format.
        /// The project must be created or updated via Mid Project Update in GroupShare in order to have reports on GroupShare
        /// </summary>
        /// <param name="projectId">The project id</param>
        /// <param name="languageCode"> Optional language code. Eg: en-US</param>
        /// <param name="reportId"> Optional report id</param>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> List <see cref="AnalysisReportWithMimeTypeV3"/>s.</returns>
        Task<IReadOnlyList<AnalysisReportWithMimeTypeV3>> GetAnalysisReportsV3AsJson(string projectId, string languageCode = null, int? reportId = null);

        /// <summary>
        /// Get the project analysis report v3 for a given project, in xml format.
        /// The project must be created or updated via Mid Project Update in GroupShare in order to have reports on GroupShare
        /// </summary>
        /// <param name="projectId">The project id</param>
        /// <param name="languageCode"> Optional language code. Eg: en-US</param>
        /// <param name="reportId"> Optional report id</param>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> List <see cref="AnalysisReportWithMimeTypeV3"/>s.</returns>
        Task<IReadOnlyList<AnalysisReportWithMimeTypeV3>> GetAnalysisReportsV3AsXml(string projectId, string languageCode = null, int? reportId = null);

        /// <summary>
        ///  Get project settings for a language file
        /// </summary>
        /// <param name="projectId">The id of the project</param>
        /// <param name="languageFileId">The if of the language file</param>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns><see cref="ProjectSettings"/></returns>
        Task<ProjectSettings> GetProjectSettings(string projectId, string languageFileId);

        /// <summary>
        /// Validates that the user can open the file in universal editor
        /// </summary>
        /// <param name="projectId">The id of the project</param>
        /// <param name="languageFileId">The if of the language file</param>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task<string> IsUserAuthorizedToOpenFile(string projectId, string languageFileId);

        /// <summary>
        ///Returns user permissions in editor
        /// </summary>
        /// <param name="projectId">The id of the project</param>
        /// <param name="languageFileId">The if of the language file</param>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns><see cref="EditorProfile"/></returns>
        Task<EditorProfile> EditorProfile(string projectId, string languageFileId);

        ///  <summary>
        /// Checks in a file edited in the Universal Editor
        ///  </summary>
        /// <param name="projectId">The id of the project</param>
        /// <param name="languageFileId">The if of the language file</param>
        /// <remarks>
        ///  This method requires authentication.
        ///  See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        ///  </remarks>
        ///  <exception cref="AuthorizationException">
        ///  Thrown when the current user does not have permission to make the request.
        ///  </exception>
        ///  <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task<OnlineCheckInRequest> OnlineCheckin(string projectId, string languageFileId, OnlineCheckInRequest onlineCheckInRequest);

        ///  <summary>
        /// Checks out a file for editing in the Universal Editor
        ///  </summary>
        /// <param name="projectId">The id of the project</param>
        /// <param name="languageFileId">The if of the language file</param>
        /// <remarks>
        ///  This method requires authentication.
        ///  See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        ///  </remarks>
        ///  <exception cref="AuthorizationException">
        ///  Thrown when the current user does not have permission to make the request.
        ///  </exception>
        ///  <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task<OnlineCheckInRequest> OnlineCheckout(string projectId, string languageFileId);

        ///  <summary>
        /// Undoes an online checkout, note that you will loose all the changes done inside the OnlineEditor. To make a proper checkin use the OnlineCheckOutController.
        ///  </summary>
        /// <param name="projectId">The id of the project</param>
        /// <param name="languageFileId">The if of the language file</param>
        /// <remarks>
        ///  This method requires authentication.
        ///  See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        ///  </remarks>
        ///  <exception cref="AuthorizationException">
        ///  Thrown when the current user does not have permission to make the request.
        ///  </exception>
        ///  <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task UndoCheckout(string projectId, string languageFileId);

        ///  <summary>
        /// Health check call used to keep the OE license advanced/basic seat taken
        /// By default, if no parameter advanced/basic is passed in api route, advanced mode is checkout.
        ///  </summary>
        ///  This method requires authentication.
        ///  See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        ///  <exception cref="AuthorizationException">
        ///  Thrown when the current user does not have permission to make the request.
        ///  </exception>
        ///  <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task<string> OnlineCheckoutHealthCheck(string editorProfileMode);

        ///  <summary>
        /// Checks if the given language file is check-out to someone other than the user making this call
        ///  </summary>
        /// <param name="languageFileId">The if of the language file</param>
        /// <remarks>
        ///  This method requires authentication.
        ///  See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        ///  </remarks>
        ///  <exception cref="AuthorizationException">
        ///  Thrown when the current user does not have permission to make the request.
        ///  </exception>
        ///  <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task<bool> IsCheckoutToSomeoneElse(string languageFileId, string editorProfileMode);

        ///  <summary>
        /// Checks in a file for editing
        ///  </summary>
        /// <param name="projectId">The id of the project</param>
        /// <param name="languageFileId">The if of the language file</param>
        /// <param name="comment">Comment</param>	 
        /// <remarks>
        ///  This method requires authentication.
        ///  See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        ///  </remarks>
        ///  <exception cref="AuthorizationException">
        ///  Thrown when the current user does not have permission to make the request.
        ///  </exception>
        ///  <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task<string> ExternalCheckin(string projectId, string languageFileId, string comment);

        ///  <summary>
        /// Checks out a file for editing
        ///  </summary>
        /// <param name="projectId">The id of the project</param>
        /// <param name="languageFileId">The if of the language file</param>
        /// <remarks>
        ///  This method requires authentication.
        ///  See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        ///  </remarks>
        ///  <exception cref="AuthorizationException">
        ///  Thrown when the current user does not have permission to make the request.
        ///  </exception>
        ///  <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task<string> ExternalCheckout(string projectId, string languageFileId);

        /// <summary>
        /// Checks-out multiple files for editing
        /// </summary>
        /// <param name="projectId">The id of the project</param>
        /// <param name="filesIds">Language files ids to check-out</param>
        /// <remarks>
        ///  This method requires authentication.
        /// </remarks>
        Task ExternalCheckOutFiles(string projectId, List<string> filesIds);

        /// <summary>
        /// Checks-in files previously checked-out
        /// </summary>
        /// <param name="projectId">The id of the project</param>
        /// <param name="externalCheckInData">Array of language files ids to check-in and optional comment</param>
        /// <remarks>
        ///  This method requires authentication.
        /// </remarks>
        Task ExternalCheckInFiles(string projectId, ExternalCheckInData externalCheckInData);

        /// <summary>
        /// Performs undo external check-out for multiple files
        /// </summary>
        /// <param name="projectId">The id of the project</param>
        /// <param name="filesIds">Language files ids to undo external check-out for</param>
        /// <remarks>
        ///  This method requires authentication.
        /// </remarks>
        Task UndoExternalCheckOutForFiles(string projectId, List<string> filesIds);

        ///  <summary>
        /// Gets the dashboard data
        ///  </summary>
        ///  This method requires authentication.
        ///  See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        ///  <exception cref="AuthorizationException">
        ///  Thrown when the current user does not have permission to make the request.
        ///  </exception>
        ///  <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task<Dashboard> Dashboard();

        /// <summary>
        /// Gets the dashboard projects per month data
        /// </summary>
        /// <remarks>
		///  This method requires authentication.
		///  See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
		///  </remarks>
		///  <exception cref="AuthorizationException">
		///  Thrown when the current user does not have permission to make the request.
		///  </exception>
		///  <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task<IReadOnlyList<DashboardCount>> DashboardProjectsPerMonth();

        /// <summary>
        /// Gets the dashboard top language pairs
        /// </summary>
        /// <param name="noOfTopLanguagePairs"></param>
        /// <returns></returns>
        /// <remarks>
        ///  This method requires authentication.
        ///  See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        ///  </remarks>
        ///  <exception cref="AuthorizationException">
        ///  Thrown when the current user does not have permission to make the request.
        ///  </exception>
        ///  <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task<IReadOnlyList<LanguagePairsInProject>> DashboardTopLanguagePairs(int? noOfTopLanguagePairs);

        /// <summary>
        /// Gets the dashboard words per month
        /// </summary>
        /// <remarks>
        ///  This method requires authentication.
        ///  See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        ///  </remarks>
        ///  <exception cref="AuthorizationException">
        ///  Thrown when the current user does not have permission to make the request.
        ///  </exception>
        ///  <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task<IReadOnlyList<DashboardCount>> DashboardWordsPerMonth();

        /// <summary>
        /// Gets the dashboard words per organization
        /// </summary>
        /// <remarks>
		///  This method requires authentication.
		///  See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
		///  </remarks>
		///  <exception cref="AuthorizationException">
		///  Thrown when the current user does not have permission to make the request.
		///  </exception>
		///  <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task<IReadOnlyList<WordsInOrganization>> DashboardWordsPerOrganization();

        /// <summary>
        /// Gets the dashboard statistics data
        /// </summary>
        /// <remarks>
        ///  This method requires authentication.
        ///  See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        ///  </remarks>
        ///  <exception cref="AuthorizationException">
        ///  Thrown when the current user does not have permission to make the request.
        ///  </exception>
        ///  <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task<DashboardStatistics> DashboardStatistics();

        ///  <summary>
        /// Retries the audit trail for all the language files in the given project
        ///  </summary>
        ///  This method requires authentication.
        /// <param name="projectId">The id of the project</param>
        ///  This method requires authentication.
        ///  See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        ///  <exception cref="AuthorizationException">
        ///  Thrown when the current user does not have permission to make the request.
        ///  </exception>
        ///  <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task<IReadOnlyList<AuditTrail>> AuditTrail(string projectId);

        [Obsolete("AuditTrial is deprecated, please use AuditTrail instead.")]
        Task<IReadOnlyList<AuditTrial>> AuditTrial(string projectId);

        /// <summary>
        /// Returns the projects report data
        /// </summary>
        /// <param name="options"></param>
        /// <remarks>
		///  This method requires authentication.
		///  See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
		///  </remarks>
		///  <exception cref="AuthorizationException">
		///  Thrown when the current user does not have permission to make the request.
		///  </exception>
		///  <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task<IReadOnlyList<ProjectReport>> ReportingProjectPredefinedReportData(ReportingOptions options);

        /// <summary>
        /// Returns the tasks Report report data
        /// </summary>
        /// <param name="options"></param>
        /// <remarks>
		///  This method requires authentication.
		///  See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
		///  </remarks>
		///  <exception cref="AuthorizationException">
		///  Thrown when the current user does not have permission to make the request.
		///  </exception>
		///  <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task<IReadOnlyList<TasksReport>> ReportingTasksReportData(ReportingOptions options);

        /// <summary>
        /// Returns the TM Leverage report data
        /// </summary>
        /// <param name="options"></param>
        /// <remarks>
		///  This method requires authentication.
		///  See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
		///  </remarks>
		///  <exception cref="AuthorizationException">
		///  Thrown when the current user does not have permission to make the request.
		///  </exception>
		///  <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task<TmLeverageReport> ReportingTmLeverageData(ReportingOptions options);

        /// <summary>
        /// Get background tasks list
        /// </summary>
        /// <returns></returns>
        Task<JsonCollection<BackgroundTask>> GetBackgroundTasks(string filter = null, int limit = 50);
    }
}