using Newtonsoft.Json;
using Sdl.Community.GroupShareKit.Exceptions;
using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Http;
using Sdl.Community.GroupShareKit.Models;
using Sdl.Community.GroupShareKit.Models.Response;
using Sdl.Community.GroupShareKit.Models.Response.ProjectPublishingInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Project = Sdl.Community.GroupShareKit.Models.Response.Project;

namespace Sdl.Community.GroupShareKit.Clients
{
    /// <summary>
    /// A client for GroupShare's ProjectServer API.
    /// </summary>
    /// <remarks>
    /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">ProjectServer API documentation</a> for more details.
    /// </remarks>
    public class ProjectClient : ApiClient, IProjectClient
    {
        public ProjectClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

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
        public Task<Project> GetProject(ProjectsRequest request)
        {
            Ensure.ArgumentNotNull(request, "request");

            return ApiConnection.Get<Project>(ApiUrls.GetAllProjects(), request.ToParametersDictionary());
        }

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
        public Task<Project> GetAllProjects()
        {
            return ApiConnection.Get<Project>(ApiUrls.GetAllProjects(), null);
        }

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
        public List<ProjectDetails> GetProjectsForOrganization(string organizationName)
        {
            var allProjects = ApiConnection.Get<Project>(ApiUrls.GetAllProjects(), null);
            return allProjects.Result.Items.Where(o => o.OrganizationName == organizationName).ToList();
        }

        [Obsolete("This method is obsolete. Call 'GetProjectFiles(Guid)' instead.")]
        public Task<IReadOnlyList<File>> GetAllFilesForProject(string projectId)
        {
            Ensure.ArgumentNotNullOrEmptyString(projectId, "projectId");

            return ApiConnection.GetAll<File>(ApiUrls.ProjectFiles(projectId));
        }

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
        public Task<IReadOnlyList<File>> GetProjectFiles(Guid projectId)
        {
            Ensure.ArgumentNotNull(projectId, "projectId");

            return ApiConnection.GetAll<File>(ApiUrls.ProjectFiles(projectId));
        }

        [Obsolete("This method is obsolete. Call 'GetProjectPhases(Guid)' instead.")]
        public Task<IReadOnlyList<Phase>> GetAllPhasesForProject(string projectId)
        {
            Ensure.ArgumentNotNullOrEmptyString(projectId, "projectId");
            return ApiConnection.GetAll<Phase>(ApiUrls.ProjectPhases(projectId));
        }

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
        public Task<IReadOnlyList<Phase>> GetProjectPhases(Guid projectId)
        {
            Ensure.ArgumentNotNull(projectId, "projectId");
            return ApiConnection.GetAll<Phase>(ApiUrls.ProjectPhases(projectId));
        }

        [Obsolete("This method is obsolete. Call 'GetPhasesWithAssignees(Guid, int)' instead.")]
        public Task<IReadOnlyList<PhasesWithAssignees>> GetPhasesWithAssignees(string projectId, int phaseId)
        {
            Ensure.ArgumentNotNullOrEmptyString(projectId, "projectId");
            Ensure.ArgumentNotNullOrEmptyString(phaseId.ToString(), "phaseId");
            return ApiConnection.GetAll<PhasesWithAssignees>(ApiUrls.ProjectPhasesWithAssignees(projectId, phaseId));
        }

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
        public Task<IReadOnlyList<PhasesWithAssignees>> GetPhasesWithAssignees(Guid projectId, int phaseId)
        {
            Ensure.ArgumentNotNull(projectId, "projectId");
            Ensure.ArgumentNotNull(phaseId, "phaseId");

            return ApiConnection.GetAll<PhasesWithAssignees>(ApiUrls.ProjectPhasesWithAssignees(projectId, phaseId));
        }

        [Obsolete("This method is obsolete. Call 'ChangePhase(ChangePhaseRequest)' instead.")]
        public Task ChangePhases(string projectId, ChangePhaseRequest request)
        {
            Ensure.ArgumentNotNullOrEmptyString(projectId, "projectId");
            Ensure.ArgumentNotNull(request, "request");

            return ApiConnection.Post<string>(ApiUrls.ChangePhases(projectId), request, "application/json");
        }

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
        public Task ChangePhase(Guid projectId, ChangePhaseRequest request)
        {
            Ensure.ArgumentNotNull(projectId, "projectId");
            Ensure.ArgumentNotNull(request, "request");

            return ApiConnection.Post<Guid>(ApiUrls.ChangePhase(projectId), request, "application/json");
        }

        [Obsolete("This method is obsolete. Call 'ChangeAssignment(Guid, ChangeAssignmentRequest)' instead.")]
        public Task ChangeAssignments(string projectId, ChangeAssignmentRequest request)
        {
            Ensure.ArgumentNotNullOrEmptyString(projectId, "projectId");
            Ensure.ArgumentNotNull(request, "request");

            return ApiConnection.Post<string>(ApiUrls.ChangeAssignments(projectId), request, "application/json");
        }

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
        public Task ChangeAssignment(Guid projectId, ChangeAssignmentRequest request)
        {
            Ensure.ArgumentNotNull(projectId, "projectId");
            Ensure.ArgumentNotNull(request, "request");

            return ApiConnection.Post<string>(ApiUrls.ChangeAssignment(projectId), request, "application/json");
        }

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
        public async Task<string> CreateProject(CreateProjectRequest request)
        {
            Ensure.ArgumentNotNull(request, "request");

            var projectUri = await ApiConnection.Post<string>(ApiUrls.GetAllProjects(), request, "application/json");
            var projectId = projectUri.Split('/').Last();

            await UploadFilesForProject(projectId, request.RawData, request.Name);
            return projectId;
        }

        /// <summary>
        /// Creates an empty project.
        /// </summary>
        /// <returns>The project id</returns>
        public async Task<string> CreateProjectSkeleton(CreateProjectSkeletonRequest request)
        {
            Ensure.ArgumentNotNull(request, "request");

            var projectUri = await ApiConnection.Post<string>(ApiUrls.GetAllProjects(), request, "application/json");
            var projectId = projectUri.Split('/').Last();

            return projectId;
        }

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
        public async Task<string> CreateProject(BasicCreateProjectRequest request,
            string filesPath, string referenceFilesPath = null, string[] perfectMatchFilesPaths = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(filesPath, "filesPath");

            // register the project creation
            var projectCreateResponse = await ApiConnection.Post<string>(ApiUrls.GetAllProjects(), request, "application/json");
            var projectId = projectCreateResponse.Split('/').Last();

            var started = await UploadFilesForProject(projectId, filesPath);
            if (started)
            {
                return projectId;
            }

            if (!string.IsNullOrEmpty(referenceFilesPath))
            {
                await UploadReferenceFilesForProject(projectId, referenceFilesPath);
            }

            if (perfectMatchFilesPaths != null && perfectMatchFilesPaths.Length > 0)
            {
                for (var i = 0; i < perfectMatchFilesPaths.Length; i++)
                {
                    var uri = ApiUrls.GetPerfectMatchFiles(projectId, i);
                    await UploadPerfectMatchFilesForProject(uri.ToString(), perfectMatchFilesPaths[i]);
                }
            }

            await ApiConnection.Post<string>(ApiUrls.StartProjectCreationUri(projectId));
            return projectId;
        }

        private async Task<bool> UploadFilesForProject(string projectId, string filesPath)
        {
            if (System.IO.File.Exists(filesPath))
            {
                if (filesPath.EndsWith(".zip", StringComparison.InvariantCultureIgnoreCase))
                {
                    var uri = ApiUrls.UploadFilesForProject(projectId, false, true);
                    await UploadFilesForProject(uri, new[] { filesPath });
                    return true;
                }
                else
                {
                    var uri = ApiUrls.UploadFilesForProject(projectId, false, false);
                    System.Diagnostics.Debug.WriteLine($"Upload files: {filesPath}");
                    await UploadFilesForProject(uri, new[] { filesPath });
                    return false;
                }
            }
            else
            {
                var uri = ApiUrls.UploadFilesForProject(projectId, false, false);
                System.Diagnostics.Debug.WriteLine($"Upload folder: {filesPath}");
                await UploadDirectoryForProject(uri, filesPath);
                return false;
            }
        }

        private async Task UploadReferenceFilesForProject(string projectId, string referenceFilesPath)
        {
            var uri = ApiUrls.UploadFilesForProject(projectId, true, false);
            if (System.IO.File.Exists(referenceFilesPath))
            {
                await UploadFilesForProject(uri, new[] { referenceFilesPath });
            }
            else
            {
                await UploadDirectoryForProject(uri, referenceFilesPath);
            }
        }

        private async Task UploadPerfectMatchFilesForProject(string uri, string directory)
        {
            // first level are language folders
            foreach (var languageDir in new System.IO.DirectoryInfo(directory).GetDirectories())
            {
                //var languageCode = languageDir.Name;
                await UploadDirectoryForProject(uri, languageDir.FullName);
            }
        }

        private async Task UploadDirectoryForProject(string uri, string directory)
        {
            var files = System.IO.Directory.GetFiles(directory);
            if (files.Length > 0)
            {
                System.Diagnostics.Debug.WriteLine("Upload files: " + string.Join(Environment.NewLine, files));
                await UploadFilesForProject(uri, files);
            }

            foreach (var subDir in new System.IO.DirectoryInfo(directory).GetDirectories())
            {
                var name = subDir.Name;
                var folderUri = uri + name + "\\";
                System.Diagnostics.Debug.WriteLine(folderUri);
                System.Diagnostics.Debug.WriteLine($"Upload folder: {subDir.FullName}");
                await UploadDirectoryForProject(folderUri, subDir.FullName);
            }
        }

        private async Task UploadFilesForProject(string uri, string[] filesPaths)
        {
            using (var content = new MultipartFormDataContent())
            {
                foreach (var file in filesPaths)
                {
                    var stream = new System.IO.FileStream(file, System.IO.FileMode.Open);
                    var streamContent = new StreamContent(stream);
                    streamContent.Headers.Add("Content-Type", "application/octet-stream");
                    content.Add(streamContent, "file", System.IO.Path.GetFileName(file));
                }

                await ApiConnection.Post<string>(uri, content, null);
            }
        }

        [Obsolete("This method is obsolete. Call 'AddFiles(Guid, string, bool)' instead.")]
        public async Task<MidProjectUpdateResponse> AddFiles(string projectId, string filesPath, bool reference)
        {
            var uri = ApiUrls.AddProjectFiles(projectId, reference);

            using (var content = new MultipartFormDataContent())
            {
                var stream = new System.IO.FileStream(filesPath, System.IO.FileMode.Open);
                var streamContent = new StreamContent(stream);
                streamContent.Headers.Add("Content-Type", "application/octet-stream");
                content.Add(streamContent, "file", System.IO.Path.GetFileName(filesPath));

                return await ApiConnection.Post<MidProjectUpdateResponse>(uri, content, null);
            }
        }

        public async Task<MidProjectUpdateResponse> AddFiles(Guid projectId, string filesPath, bool reference)
        {
            var uri = ApiUrls.AddProjectFiles(projectId, reference);

            using (var content = new MultipartFormDataContent())
            {
                var stream = new System.IO.FileStream(filesPath, System.IO.FileMode.Open);
                var streamContent = new StreamContent(stream);
                streamContent.Headers.Add("Content-Type", "application/octet-stream");
                content.Add(streamContent, "file", System.IO.Path.GetFileName(filesPath));

                return await ApiConnection.Post<MidProjectUpdateResponse>(uri, content, null);
            }
        }

        [Obsolete("This method is obsolete. Call 'AddFiles(Guid, string[], bool)' instead.")]
        public async Task<MidProjectUpdateResponse> AddFiles(string projectId, string[] filesPaths, bool reference)
        {
            var uri = ApiUrls.AddProjectFiles(projectId, reference);

            using (var content = new MultipartFormDataContent())
            {
                foreach (var file in filesPaths)
                {
                    var stream = new System.IO.FileStream(file, System.IO.FileMode.Open);
                    var streamContent = new StreamContent(stream);
                    streamContent.Headers.Add("Content-Type", "application/octet-stream");
                    content.Add(streamContent, "file", System.IO.Path.GetFileName(file));
                }

                return await ApiConnection.Post<MidProjectUpdateResponse>(uri, content, null);
            }
        }

        public async Task<MidProjectUpdateResponse> AddFiles(Guid projectId, string[] filesPaths, bool reference)
        {
            var uri = ApiUrls.AddProjectFiles(projectId, reference);

            using (var content = new MultipartFormDataContent())
            {
                foreach (var file in filesPaths)
                {
                    var stream = new System.IO.FileStream(file, System.IO.FileMode.Open);
                    var streamContent = new StreamContent(stream);
                    streamContent.Headers.Add("Content-Type", "application/octet-stream");
                    content.Add(streamContent, "file", System.IO.Path.GetFileName(file));
                }

                return await ApiConnection.Post<MidProjectUpdateResponse>(uri, content, null);
            }
        }

        [Obsolete("This method is obsolete. Call 'UpdateFiles(Guid, string, bool)' instead.")]
        public async Task<MidProjectUpdateResponse> UpdateFiles(string projectId, string filesPath, bool reference)
        {
            var uri = ApiUrls.UpdateProjectFiles(projectId, reference);

            using (var content = new MultipartFormDataContent())
            {
                var stream = new System.IO.FileStream(filesPath, System.IO.FileMode.Open);
                var streamContent = new StreamContent(stream);
                streamContent.Headers.Add("Content-Type", "application/octet-stream");
                content.Add(streamContent, "file", System.IO.Path.GetFileName(filesPath));

                return await ApiConnection.Put<MidProjectUpdateResponse>(uri, content);
            }
        }

        public async Task<MidProjectUpdateResponse> UpdateFiles(Guid projectId, string filesPath, bool reference)
        {
            var uri = ApiUrls.UpdateProjectFiles(projectId, reference);

            using (var content = new MultipartFormDataContent())
            {
                var stream = new System.IO.FileStream(filesPath, System.IO.FileMode.Open);
                var streamContent = new StreamContent(stream);
                streamContent.Headers.Add("Content-Type", "application/octet-stream");
                content.Add(streamContent, "file", System.IO.Path.GetFileName(filesPath));

                return await ApiConnection.Put<MidProjectUpdateResponse>(uri, content);
            }
        }

        [Obsolete("This method is obsolete. Call 'UpdateFiles(Guid, string[], bool)' instead.")]
        public async Task<MidProjectUpdateResponse> UpdateFiles(string projectId, string[] filesPaths, bool reference)
        {
            var uri = ApiUrls.UpdateProjectFiles(projectId, reference);

            using (var content = new MultipartFormDataContent())
            {
                foreach (var file in filesPaths)
                {
                    var stream = new System.IO.FileStream(file, System.IO.FileMode.Open);
                    var streamContent = new StreamContent(stream);
                    streamContent.Headers.Add("Content-Type", "application/octet-stream");
                    content.Add(streamContent, "file", System.IO.Path.GetFileName(file));
                }

                return await ApiConnection.Put<MidProjectUpdateResponse>(uri, content);
            }
        }

        public async Task<MidProjectUpdateResponse> UpdateFiles(Guid projectId, string[] filesPaths, bool reference)
        {
            var uri = ApiUrls.UpdateProjectFiles(projectId, reference);

            using (var content = new MultipartFormDataContent())
            {
                foreach (var file in filesPaths)
                {
                    var stream = new System.IO.FileStream(file, System.IO.FileMode.Open);
                    var streamContent = new StreamContent(stream);
                    streamContent.Headers.Add("Content-Type", "application/octet-stream");
                    content.Add(streamContent, "file", System.IO.Path.GetFileName(file));
                }

                return await ApiConnection.Put<MidProjectUpdateResponse>(uri, content);
            }
        }

        [Obsolete("This method is obsolete. Call 'UpdateSelectedFiles(Guid, string, MidProjectFileIdsModel, bool)' instead.")]
        public async Task<MidProjectUpdateResponse> UpdateSelectedFiles(string projectId, string filesPath, MidProjectFileIdsModel fileIds, bool reference)
        {
            var uri = ApiUrls.UpdateProjectFiles(projectId, reference);

            using (var content = new MultipartFormDataContent())
            {
                var stream = new System.IO.FileStream(filesPath, System.IO.FileMode.Open);
                var streamContent = new StreamContent(stream);
                streamContent.Headers.Add("Content-Type", "application/octet-stream");
                content.Add(streamContent, "file", System.IO.Path.GetFileName(filesPath));

                var fileIdsString = new SimpleJsonSerializer().Serialize(fileIds);
                content.Add(new StringContent(fileIdsString), "FileIds");

                return await ApiConnection.Put<MidProjectUpdateResponse>(uri, content);
            }
        }

        public async Task<MidProjectUpdateResponse> UpdateSelectedFiles(Guid projectId, string filesPath, MidProjectFileIdsModel fileIds, bool reference)
        {
            var uri = ApiUrls.UpdateProjectFiles(projectId, reference);

            using (var content = new MultipartFormDataContent())
            {
                var stream = new System.IO.FileStream(filesPath, System.IO.FileMode.Open);
                var streamContent = new StreamContent(stream);
                streamContent.Headers.Add("Content-Type", "application/octet-stream");
                content.Add(streamContent, "file", System.IO.Path.GetFileName(filesPath));

                var fileIdsString = new SimpleJsonSerializer().Serialize(fileIds);
                content.Add(new StringContent(fileIdsString), "FileIds");

                return await ApiConnection.Put<MidProjectUpdateResponse>(uri, content);
            }
        }

        [Obsolete("This method is obsolete. Call 'UpdateSelectedFiles(Guid, string, MidProjectFileIdsModel, bool)' instead.")]
        public async Task<MidProjectUpdateResponse> UpdateSelectedFiles(string projectId, string[] filesPaths, MidProjectFileIdsModel fileIds, bool reference)
        {
            var uri = ApiUrls.UpdateProjectFiles(projectId, reference);

            using (var content = new MultipartFormDataContent())
            {
                foreach (var file in filesPaths)
                {
                    var stream = new System.IO.FileStream(file, System.IO.FileMode.Open);
                    var streamContent = new StreamContent(stream);
                    streamContent.Headers.Add("Content-Type", "application/octet-stream");
                    content.Add(streamContent, "file", System.IO.Path.GetFileName(file));
                }

                var fileIdsString = new SimpleJsonSerializer().Serialize(fileIds);
                content.Add(new StringContent(fileIdsString), "FileIds");

                return await ApiConnection.Put<MidProjectUpdateResponse>(uri, content);
            }
        }

        public async Task<MidProjectUpdateResponse> UpdateSelectedFiles(Guid projectId, string[] filesPaths, MidProjectFileIdsModel fileIds, bool reference)
        {
            var uri = ApiUrls.UpdateProjectFiles(projectId, reference);

            using (var content = new MultipartFormDataContent())
            {
                foreach (var file in filesPaths)
                {
                    var stream = new System.IO.FileStream(file, System.IO.FileMode.Open);
                    var streamContent = new StreamContent(stream);
                    streamContent.Headers.Add("Content-Type", "application/octet-stream");
                    content.Add(streamContent, "file", System.IO.Path.GetFileName(file));
                }

                var fileIdsString = new SimpleJsonSerializer().Serialize(fileIds);
                content.Add(new StringContent(fileIdsString), "FileIds");

                return await ApiConnection.Put<MidProjectUpdateResponse>(uri, content);
            }
        }

        [Obsolete("This method is obsolete. Call 'CancelProjectFiles(Guid, MidProjectFileIdsModel)' instead.")]
        public async Task<string> CancelProjectFiles(string projectId, MidProjectFileIdsModel fileIds)
        {
            var uri = ApiUrls.CancelProjectFiles(projectId);
            var fileIdsString = new SimpleJsonSerializer().Serialize(fileIds);

            return await ApiConnection.Put<string>(uri, fileIdsString);
        }

        public async Task<string> CancelProjectFiles(Guid projectId, MidProjectFileIdsModel fileIds)
        {
            var uri = ApiUrls.CancelProjectFiles(projectId);
            var fileIdsString = new SimpleJsonSerializer().Serialize(fileIds);

            return await ApiConnection.Put<string>(uri, fileIdsString);
        }

        /// <summary>
        /// Get background tasks list with filter and default sort options
        /// </summary>
        public async Task<JsonCollection<BackgroundTask>> GetBackgroundTasks(string filter, int limit = 50)
        {
            var sort = new SortOptions
            {
                Property = "CreatedAt",
                Direction = "DESC"
            };

            var serializedSortOptions = JsonConvert.SerializeObject(sort);

            return await ApiConnection.Get<JsonCollection<BackgroundTask>>(ApiUrls.GetBackgroundTasks(serializedSortOptions, filter), null);
        }

        [Obsolete("This method is obsolete. Call 'DeleteProject(Guid)' instead.")]
        public Task DeleteProject(string projectId)
        {
            Ensure.ArgumentNotNullOrEmptyString(projectId, "projectId");

            return ApiConnection.Delete(ApiUrls.Project(projectId));
        }

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
        public Task DeleteProject(Guid projectId)
        {
            Ensure.ArgumentNotNull(projectId, "projectId");

            return ApiConnection.Delete(ApiUrls.Project(projectId));
        }

        [Obsolete("This method is obsolete. Call 'GetProject(Guid)' instead.")]
        public Task<ProjectDetails> Get(string projectId)
        {
            Ensure.ArgumentNotNullOrEmptyString(projectId, "projectId");

            return ApiConnection.Get<ProjectDetails>(ApiUrls.Project(projectId), null);
        }

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
        public Task<ProjectDetails> GetProject(Guid projectId)
        {
            Ensure.ArgumentNotNull(projectId, "projectId");

            return ApiConnection.Get<ProjectDetails>(ApiUrls.Project(projectId), null);
        }

        [Obsolete("This method is obsolete. Call 'PublishingStatus(Guid)' instead.")]
        public async Task<PublishingStatus> PublishingStatus(string projectId)
        {
            Ensure.ArgumentNotNullOrEmptyString(projectId, "projectId");
            return await ApiConnection.Get<PublishingStatus>(ApiUrls.PublishingStatus(projectId), null);
        }

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
        public async Task<PublishingStatus> GetPublishingStatus(Guid projectId)
        {
            Ensure.ArgumentNotNull(projectId, "projectId");
            return await ApiConnection.Get<PublishingStatus>(ApiUrls.PublishingStatus(projectId), null);
        }

        /// <summary>
        /// Gets publishing information for one or multiple projects.
        /// </summary>
        /// <param name="projectIds">IDs of projects to get publishing information for, separated by comma.</param>
        /// <returns><see cref="ProjectPublishingInformation"/></returns>
        public async Task<List<ProjectPublishingInformation>> GetProjectsPublishingInformation(string projectIds)
        {
            Ensure.ArgumentNotNullOrEmptyString(projectIds, "projectIds");
            return await ApiConnection.Get<List<ProjectPublishingInformation>>(ApiUrls.PublishingInformation(projectIds), null);
        }

        [Obsolete("This method is obsolete. Call 'DownloadFiles(Guid, List<Guid>)' instead.")]
        public async Task<byte[]> DownloadFiles(string projectId, List<string> languageFileIds)
        {
            Ensure.ArgumentNotEmpty(languageFileIds, "languageFileIds");

            return await ApiConnection.Get<byte[]>(ApiUrls.DownloadFiles(projectId, LanguageIdQuery(languageFileIds)), null);
        }

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
        public async Task<byte[]> DownloadFiles(Guid projectId, List<Guid> languageFileIds)
        {
            Ensure.ArgumentNotNull(languageFileIds, "languageFileIds");

            return await ApiConnection.Get<byte[]>(ApiUrls.DownloadFiles(projectId, LanguageIdQuery(languageFileIds)), null);
        }

        [Obsolete("This method is obsolete. Call 'DownloadNative(Guid)' instead.")]
        public async Task<byte[]> DownloadNative(string projectId)
        {
            return await ApiConnection.Get<byte[]>(ApiUrls.DownloadNative(projectId), null);
        }

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
        public async Task<byte[]> DownloadNative(Guid projectId)
        {
            return await ApiConnection.Get<byte[]>(ApiUrls.DownloadNative(projectId), null);
        }

        [Obsolete("This method is obsolete. Call 'Finalize(Guid, List<Guid>)' instead.")]
        public async Task<byte[]> Finalize(string projectId, List<string> languageFileIds)
        {
            Ensure.ArgumentNotEmpty(languageFileIds, "languageFileIds");

            return await ApiConnection.Post<byte[]>(ApiUrls.Finalize(projectId, LanguageIdQuery(languageFileIds)));
        }

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
        public async Task<byte[]> Finalize(Guid projectId, List<Guid> languageFileIds)
        {
            Ensure.ArgumentNotNull(projectId, "languageFileIds");
            Ensure.ArgumentNotNull(languageFileIds, "languageFileIds");

            return await ApiConnection.Post<byte[]>(ApiUrls.Finalize(projectId, LanguageIdQuery(languageFileIds)));
        }

        /// <summary>
        /// Helper method to create  query.
        /// </summary>
        /// <param name="languageFileIds"></param>
        /// <returns></returns>
        public string LanguageIdQuery(List<string> languageFileIds)
        {
            var query = string.Empty;

            if (languageFileIds.Count == 1)
            {
                return "languageFileIds=" + languageFileIds.FirstOrDefault();
            }

            foreach (var id in languageFileIds)
            {
                query = query + "languageFileIds=" + id + "&";
            }

            return query;
        }

        public string LanguageIdQuery(List<Guid> languageFileIds)
        {
            var query = string.Empty;

            if (languageFileIds.Count == 1)
            {
                return "languageFileIds=" + languageFileIds.FirstOrDefault();
            }

            foreach (var id in languageFileIds)
            {
                query = query + "languageFileIds=" + id + "&";
            }

            return query;
        }

        /// <summary>
        /// Helper method to create query
        /// </summary>
        /// <param name="languageFileIds"></param>
        /// <returns></returns>
        public string FileIdQuery(List<string> languageFileIds)
        {
            var query = string.Empty;
            foreach (var id in languageFileIds)
            {
                query = query + "fileId=" + id + "&";
            }

            return query;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="languageFileIds"></param>
        /// <returns></returns>
        public string FileIdQuery(List<Guid> languageFileIds)
        {
            var query = string.Empty;
            foreach (var id in languageFileIds)
            {
                query = query + "fileId=" + id + "&";
            }

            return query;
        }

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
        public async Task<byte[]> DownloadFile(FileDownloadRequest downloadRequest)
        {
            if (downloadRequest.Type != null)
            {
                return
                 await
                     ApiConnection.Get<byte[]>(
                         ApiUrls.DownloadFile(downloadRequest.ProjectId, Enum.GetName(typeof(FileDownloadRequest.Types), downloadRequest.Type)),
                         null);
            }

            return await ApiConnection.Get<byte[]>(ApiUrls.DownloadFile(downloadRequest.ProjectId, "all"), null);
        }

        /// <summary>
        /// Gets a list of user assignments
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
        public async Task<IReadOnlyList<UserAssignments>> GetUserAssignments()
        {
            return await ApiConnection.GetAll<UserAssignments>(ApiUrls.GetProjectsAssignments(), null);
        }

        [Obsolete("This method is obsolete. Call 'GetProjectAssignmentById(Guid, List<Guid>)' instead.")]
        public async Task<IReadOnlyList<ProjectAssignment>> GetProjectAssignmentById(string projectId, List<string> fileIdsList)
        {
            Ensure.ArgumentNotNullOrEmptyString(projectId, "projectId");
            Ensure.ArgumentNotNull(fileIdsList, "fileIdsList");

            return await ApiConnection.GetAll<ProjectAssignment>(ApiUrls.GetProjectAssignmentById(projectId, FileIdQuery(fileIdsList)), null);
        }

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
        public async Task<IReadOnlyList<ProjectAssignment>> GetProjectAssignmentById(Guid projectId, List<Guid> fileIdsList)
        {
            Ensure.ArgumentNotNull(projectId, "projectId");
            Ensure.ArgumentNotNull(fileIdsList, "fileIdsList");

            return await ApiConnection.GetAll<ProjectAssignment>(ApiUrls.GetProjectAssignmentById(projectId, FileIdQuery(fileIdsList)), null);
        }

        /// <summary>
        /// Uploads file for a specific project
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        public async Task<string> UploadFilesForProject(string projectId, byte[] rawData, string projectName)
        {
            Ensure.ArgumentNotNullOrEmptyString(projectId, "projectId");
            var byteContent = new ByteArrayContent(rawData);
            byteContent.Headers.Add("Content-Type", "application/zip");

            var multipartContent = new MultipartFormDataContent
            {
                { byteContent, "file", projectName + ".zip" }
            };

            return await ApiConnection.Post<string>(ApiUrls.UploadFilesForProject(projectId), multipartContent, "application/zip");
        }

        /// <summary>
        /// Change project status
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
        public async Task<string> ChangeProjectStatus(ChangeStatusRequest statusRequest)
        {
            return await ApiConnection.Put<string>(ApiUrls.ChangeProjectStatus(statusRequest.ProjectId, Enum.GetName(typeof(ChangeStatusRequest.ProjectStatus), statusRequest.Status)), statusRequest);
        }

        [Obsolete("This method is obsolete. Call 'DetachProject(Guid, bool)' instead.")]
        public async Task DetachProject(string projectId, bool deleteProjectTMs = false)
        {
            await ApiConnection.Delete(ApiUrls.DetachProject(projectId, deleteProjectTMs));
        }

        /// <summary>
        /// Detaches a project, with the possibility to delete project TMs.
        /// </summary>
        /// <param name="projectId">The project's Guid.</param>
        /// <param name="deleteProjectTMs">If true, project TMs will be deleted after the project is detached.</param>
        public async Task DetachProject(Guid projectId, bool deleteProjectTMs = false)
        {
            await ApiConnection.Delete(ApiUrls.DetachProject(projectId, deleteProjectTMs));
        }

        /// <summary>
        /// Change project status detach
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
        public async Task<string> ChangeProjectStatusDetach(ChangeStatusRequest statusRequest)
        {
            return await ApiConnection.Put<string>(ApiUrls.ChangeProjectStatus(statusRequest), statusRequest);
        }

        /// <summary>
        /// Deletes detach to a project status
        /// <param name="projectId deleteTms">></param>
        /// <param name="deleteTms"></param>
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// 
        public async Task ChangeProjectStatusDeleteDetach(string projectId, bool deleteTms)
        {
            await ApiConnection.Delete(ApiUrls.ProjectStatusDeleteDetach(projectId, deleteTms));
        }

        /// <summary>
        /// Publishes a project package (.sdlppx)
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        public async Task PublishPackage(string projectId, byte[] rawData)
        {
            var byteContent = new ByteArrayContent(rawData);
            byteContent.Headers.Add("Content-Type", "application/json");

            var projectName = "Project";

            var multipartContent = new MultipartFormDataContent
            {
                { byteContent, projectName, projectName }
            };

            await ApiConnection.Post<string>(ApiUrls.PublishProjectPackage(projectId), multipartContent, "application/json");
        }

        /// <summary>
        /// Initiates a cancel for project package publishing
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        public async Task CancelPublishPackage(string projectId)
        {
            await ApiConnection.Post(ApiUrls.CancelPublishProjectPackage(projectId));
        }

        [Obsolete("This method is obsolete. Call 'GetAllProjectFileStatistics(Guid)' instead.")]
        public Task<IReadOnlyList<ProjectFileStatistics>> GetAllProjectFileStatistics(string projectId)
        {
            Ensure.ArgumentNotNullOrEmptyString(projectId, "projectId");

            return ApiConnection.GetAll<ProjectFileStatistics>(ApiUrls.ProjectFileStatistics(projectId), null);
        }

        public Task<IReadOnlyList<ProjectFileStatistics>> GetAllProjectFileStatistics(Guid projectId)
        {
            Ensure.ArgumentNotNull(projectId, "projectId");

            return ApiConnection.GetAll<ProjectFileStatistics>(ApiUrls.ProjectFileStatistics(projectId), null);
        }

        [Obsolete("This method is obsolete. Call 'GetProjectLanguageStatistics(Guid)' instead.")]
        public Task<Dictionary<string, ProjectStatistics>> GetProjectLanguageStatistics(string projectId)
        {
            Ensure.ArgumentNotNullOrEmptyString(projectId, "projectId");

            return ApiConnection.Get<Dictionary<string, ProjectStatistics>>(ApiUrls.ProjectLanguageStatistics(projectId), null);
        }

        public Task<Dictionary<string, ProjectStatistics>> GetProjectLanguageStatistics(Guid projectId)
        {
            Ensure.ArgumentNotNull(projectId, "projectId");

            return ApiConnection.Get<Dictionary<string, ProjectStatistics>>(ApiUrls.ProjectLanguageStatistics(projectId), null);
        }

        public async Task<bool> IsProjectNameInUse(IsProjectNameInUseRequest request)
        {
            Ensure.ArgumentNotNull(request, nameof(request));

            return await ApiConnection.Get<bool>(ApiUrls.IsProjectNameInUse(), request.ToParametersDictionary()).ConfigureAwait(false);
        }
        #endregion


        #region Project template methods
        /// <summary>
        /// Gets all templates
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
        public async Task<IReadOnlyList<ProjectTemplates>> GetAllTemplates()
        {
            return await ApiConnection.GetAll<ProjectTemplates>(ApiUrls.ProjectTemplates(), null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyList<ProjectTemplate>> GetProjectTemplates()
        {
            return await ApiConnection.GetAll<ProjectTemplate>(ApiUrls.ProjectTemplates(), null);
        }

        /// <summary>
        /// Creates a template
        /// </summary>
        /// <param name="templateRequest"><see cref="ProjectTemplates"/></param>
        /// <param name="rawData">The project template file as a byte array.</param>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>Id of created template/></returns>
        public async Task<string> CreateTemplate(ProjectTemplates templateRequest, byte[] rawData)
        {
            var templateId = await ApiConnection.Post<string>(ApiUrls.ProjectTemplates(), templateRequest, "application/json");
            await UploadProjectTemplate(templateId, rawData, templateRequest.Name);
            return templateId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectTemplateRequest"></param>
        /// <param name="rawData"></param>
        /// <returns></returns>
        public async Task<Guid> CreateProjectTemplate(ProjectTemplate projectTemplateRequest, byte[] rawData)
        {
            var templateId = await ApiConnection.Post<Guid>(ApiUrls.ProjectTemplates(), projectTemplateRequest, "application/json");
            await UploadProjectTemplate(templateId, rawData, projectTemplateRequest.Name);
            return templateId;
        }

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
        public async Task<Guid> CreateProjectTemplateV4(ProjectTemplateV4 templateRequest)
        {
            var templateId = await ApiConnection.Post<Guid>(ApiUrls.ProjectTemplatesV4(), templateRequest, "application/json");
            return templateId;
        }

        /// <summary>
        /// Creates a template
        /// </summary>
        /// <param name="templateRequest"><see cref="ProjectTemplateV3"/></param>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>Id of created template/></returns>
        public async Task<string> CreateTemplateV3(ProjectTemplateV3 templateRequest)
        {
            var templateId = await ApiConnection.Post<string>(ApiUrls.ProjectTemplatesV3(), templateRequest, "application/json");
            return templateId;
        }

        /// <summary>
        /// Updates a project template
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
        /// <returns>The GUID of the project template/></returns>
        public async Task<Guid> UpdateProjectTemplateV3(Guid templateId, ProjectTemplateV3 templateRequest)
        {
            return await ApiConnection.Put<Guid>(ApiUrls.ProjectTemplatesV3(templateId), templateRequest);
        }

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
        public async Task<Guid> CreateTemplateV4(ProjectTemplateV4 templateRequest)
        {
            var templateId = await ApiConnection.Post<Guid>(ApiUrls.ProjectTemplatesV4(), templateRequest);
            return templateId;
        }

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
        public async Task<Guid> UpdateProjectTemplateV4(Guid templateId, ProjectTemplateV4 templateRequest)
        {
            return await ApiConnection.Put<Guid>(ApiUrls.ProjectTemplatesV4(templateId), templateRequest);
        }

        [Obsolete("This method is obsolete. Call 'GetProjectTemplate(Guid)' instead.")]
        public async Task<string> GetTemplateById(string templateId)
        {
            Ensure.ArgumentNotNullOrEmptyString(templateId, "templateId");
            return await ApiConnection.Get<string>(ApiUrls.ProjectTemplates(templateId), null);
        }

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
        public async Task<string> GetProjectTemplate(Guid templateId)
        {
            Ensure.ArgumentNotNull(templateId, "templateId");
            return await ApiConnection.Get<string>(ApiUrls.ProjectTemplates(templateId), null);
        }

        /// <summary>
        /// Gets a project template by id
        /// </summary>
        /// <param name="templateId">Project template GUID</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>The project template data</returns>
        public async Task<ProjectTemplateSettingsV3> GetProjectTemplateV3(Guid templateId)
        {
            Ensure.ArgumentNotNull(templateId, "templateId");
            return await ApiConnection.GetWithContent<ProjectTemplateSettingsV3>(ApiUrls.ProjectTemplatesV3(templateId), "application/json");
        }

        /// <summary>
        /// Gets a project template by id
        /// </summary>
        /// <param name="templateId">Project template GUID</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>The project template data</returns>
        public async Task<ProjectTemplateSettingsV4> GetProjectTemplateV4(Guid templateId)
        {
            Ensure.ArgumentNotNull(templateId, "templateId");
            return await ApiConnection.GetWithContent<ProjectTemplateSettingsV4>(ApiUrls.ProjectTemplatesV4(templateId), "application/json");
        }

        [Obsolete("This method is obsolete. Call 'DeleteProjectTemplate(Guid)' instead.")]
        public async Task DeleteProjectTemplate(string templateId)
        {
            Ensure.ArgumentNotNullOrEmptyString(templateId, "templateId");
            await ApiConnection.Delete(ApiUrls.ProjectTemplates(templateId));
        }

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
        public async Task DeleteProjectTemplate(Guid templateId)
        {
            Ensure.ArgumentNotNull(templateId, "templateId");
            await ApiConnection.Delete(ApiUrls.ProjectTemplates(templateId));
        }

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
        public async Task DeleteProjectTemplateV3(Guid templateId)
        {
            Ensure.ArgumentNotNull(templateId, "templateId");
            await ApiConnection.Delete(ApiUrls.ProjectTemplatesV3(templateId));
        }

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
        public async Task DeleteProjectTemplateV4(Guid templateId)
        {
            Ensure.ArgumentNotNull(templateId, "templateId");
            await ApiConnection.Delete(ApiUrls.ProjectTemplatesV4(templateId));
        }

        [Obsolete("This method is obsolete. Call 'UploadProjectTemplate(Guid, byte[], string)' instead.")]
        public async Task<string> UploadProjectTemplate(string templateId, byte[] projectTemplate, string templateName)
        {
            Ensure.ArgumentNotNullOrEmptyString(templateId, "templateId");
            var templateByteArray = new ByteArrayContent(projectTemplate);
            var multipartContent = new MultipartFormDataContent
            {
                { templateByteArray, "file", templateName }
            };

            return await ApiConnection.Post<string>(ApiUrls.UploadProjectTemplate(templateId), multipartContent, "application/json");
        }

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
        public async Task<Guid> UploadProjectTemplate(Guid templateId, byte[] projectTemplate, string templateName)
        {
            Ensure.ArgumentNotNull(templateId, "templateId");
            var templateByteArray = new ByteArrayContent(projectTemplate);
            var multipartContent = new MultipartFormDataContent
            {
                { templateByteArray, "file", templateName }
            };

            return await ApiConnection.Post<Guid>(ApiUrls.UploadProjectTemplate(templateId), multipartContent, "application/json");
        }
        #endregion

        #region File version methods

        [Obsolete("This method is obsolete. Call 'GetFileVersions(Guid)' instead.")]
        public async Task<IReadOnlyList<FileVersion>> GetFileVersions(string languageFileId)
        {
            Ensure.ArgumentNotNullOrEmptyString(languageFileId, "languageFileId");
            return await ApiConnection.GetAll<FileVersion>(ApiUrls.GetFileVersion(languageFileId), null);
        }

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
        public async Task<IReadOnlyList<FileVersion>> GetFileVersions(Guid languageFileId)
        {
            Ensure.ArgumentNotNull(languageFileId, "languageFileId");
            return await ApiConnection.GetAll<FileVersion>(ApiUrls.GetFileVersions(languageFileId), null);
        }

        [Obsolete("This method is obsolete. Call 'DownloadFileVersion(Guid, Guid, int)' instead.")]
        public async Task<byte[]> DownloadFileVersion(string projectId, string languageFileId, int version)
        {
            Ensure.ArgumentNotNullOrEmptyString(languageFileId, "languageFileId");
            Ensure.ArgumentNotNullOrEmptyString(projectId, "projectId");
            Ensure.ArgumentNotNull(version, "version");

            var fileContent = await ApiConnection.Get<byte[]>(ApiUrls.DownloadFileForVersion(projectId, languageFileId, version), null);

            return fileContent;
        }

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
        public async Task<byte[]> DownloadFileVersion(Guid projectId, Guid languageFileId, int version)
        {
            Ensure.ArgumentNotNull(languageFileId, "languageFileId");
            Ensure.ArgumentNotNull(projectId, "projectId");
            Ensure.ArgumentNotNull(version, "version");

            var fileContent = await ApiConnection.Get<byte[]>(ApiUrls.DownloadFileVersion(projectId, languageFileId, version), null);

            return fileContent;
        }

        [Obsolete("This method is obsolete. Call 'GetAnalysisReports(Guid, string)' instead.")]
        public async Task<IReadOnlyList<AnalysisReports>> GetAnalysisReports(string projectId, string languageCode)
        {
            Ensure.ArgumentNotNullOrEmptyString(projectId, "projectId");

            var reportResult = await ApiConnection.GetAll<AnalysisReports>(ApiUrls.AnalysisReports(projectId, languageCode), null);
            return reportResult;
        }

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
        public async Task<IReadOnlyList<AnalysisReports>> GetAnalysisReports(Guid projectId, string languageCode)
        {
            Ensure.ArgumentNotNull(projectId, "projectId");

            var reportResult = await ApiConnection.GetAll<AnalysisReports>(ApiUrls.AnalysisReports(projectId, languageCode), null);
            return reportResult;
        }

        [Obsolete("This method is obsolete. Call 'GetAnalysisReportsAsHtml(Guid, string)' instead.")]
        public async Task<IReadOnlyList<AnalysisReportWithMimeType>> GetAnalysisReportsAsHtml(string projectId, string languageCode)
        {
            Ensure.ArgumentNotNullOrEmptyString(projectId, "projectId");

            var reportResult = await ApiConnection.GetWithContent<IReadOnlyList<AnalysisReportWithMimeType>>(ApiUrls.AnalysisReports(projectId, languageCode), "text/html");
            return reportResult;
        }

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
        public async Task<IReadOnlyList<AnalysisReportWithMimeType>> GetAnalysisReportsAsHtml(Guid projectId, string languageCode)
        {
            Ensure.ArgumentNotNull(projectId, "projectId");

            var reportResult = await ApiConnection.GetWithContent<IReadOnlyList<AnalysisReportWithMimeType>>(ApiUrls.AnalysisReports(projectId, languageCode), "text/html");
            return reportResult;
        }

        [Obsolete("This method is obsolete. Call 'GetAnalysisReportsAsXml(Guid, string)' instead.")]
        public async Task<IReadOnlyList<AnalysisReportWithMimeType>> GetAnalysisReportsAsXml(string projectId, string languageCode)
        {
            Ensure.ArgumentNotNullOrEmptyString(projectId, "projectId");

            var reportResult = await ApiConnection.GetWithContent<IReadOnlyList<AnalysisReportWithMimeType>>(ApiUrls.AnalysisReports(projectId, languageCode), "text/xml");
            return reportResult;
        }

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
        public async Task<IReadOnlyList<AnalysisReportWithMimeType>> GetAnalysisReportsAsXml(Guid projectId, string languageCode)
        {
            Ensure.ArgumentNotNull(projectId, "projectId");

            var reportResult = await ApiConnection.GetWithContent<IReadOnlyList<AnalysisReportWithMimeType>>(ApiUrls.AnalysisReports(projectId, languageCode), "text/xml");
            return reportResult;
        }

        [Obsolete("This method is obsolete. Call 'GetAnalysisReportsV3(Guid, string, int)' instead.")]
        public async Task<IReadOnlyList<AnalysisReports>> GetAnalysisReportsV3(string projectId, string languageCode = null, int? reportId = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(projectId, "projectId");

            var reportResult = await ApiConnection.GetAll<AnalysisReports>(ApiUrls.AnalysisReportsV3(projectId, languageCode, reportId));
            return reportResult;
        }

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
        public async Task<IReadOnlyList<AnalysisReports>> GetAnalysisReportsV3(Guid projectId, string languageCode = null, int? reportId = null)
        {
            Ensure.ArgumentNotNull(projectId, "projectId");

            var reportResult = await ApiConnection.GetAll<AnalysisReports>(ApiUrls.AnalysisReportsV3(projectId, languageCode, reportId));
            return reportResult;
        }

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
        public async Task<IReadOnlyList<AnalysisReports>> GetMTQEAnalysisReportsV3(Guid projectId, string languageCode = null, int? reportId = null)
        {
            Ensure.ArgumentNotNull(projectId, "projectId");

            var reportResult = await ApiConnection.GetAll<AnalysisReports>(ApiUrls.MTQEAnalysisReportsV3(projectId, languageCode, reportId));
            return reportResult;
        }

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
        public async Task<IReadOnlyList<AnalysisReportWithMimeTypeV3>> GetMTQEAnalysisReportsV3AsHtml(Guid projectId, string languageCode = null, int? reportId = null)
        {
            Ensure.ArgumentNotNull(projectId, "projectId");

            var reportResult = await ApiConnection.GetWithContent<IReadOnlyList<AnalysisReportWithMimeTypeV3>>(ApiUrls.MTQEAnalysisReportsV3(projectId, languageCode, reportId), "text/html");
            return reportResult;
        }

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
        public async Task<IReadOnlyList<AnalysisReportWithMimeTypeV3>> GetMTQEAnalysisReportsV3AsXml(Guid projectId, string languageCode = null, int? reportId = null)
        {
            Ensure.ArgumentNotNull(projectId, "projectId");

            var reportResult = await ApiConnection.GetWithContent<IReadOnlyList<AnalysisReportWithMimeTypeV3>>(ApiUrls.MTQEAnalysisReportsV3(projectId, languageCode, reportId), "text/xml");

            return reportResult;
        }

        [Obsolete("This method is obsolete. Call 'GetAnalysisReportsV3AsHtml(Guid, string, int)' instead.")]
        public async Task<IReadOnlyList<AnalysisReportWithMimeTypeV3>> GetAnalysisReportsV3AsHtml(string projectId, string languageCode = null, int? reportId = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(projectId, "projectId");

            var reportResult = await ApiConnection.GetWithContent<IReadOnlyList<AnalysisReportWithMimeTypeV3>>(ApiUrls.AnalysisReportsV3(projectId, languageCode, reportId), "text/html");
            return reportResult;
        }

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
        public async Task<IReadOnlyList<AnalysisReportWithMimeTypeV3>> GetAnalysisReportsV3AsHtml(Guid projectId, string languageCode = null, int? reportId = null)
        {
            Ensure.ArgumentNotNull(projectId, "projectId");

            var reportResult = await ApiConnection.GetWithContent<IReadOnlyList<AnalysisReportWithMimeTypeV3>>(ApiUrls.AnalysisReportsV3(projectId, languageCode, reportId), "text/html");
            return reportResult;
        }

        [Obsolete("This method is obsolete. Call 'GetAnalysisReportsV3AsXml(Guid, string, int)' instead.")]
        public async Task<IReadOnlyList<AnalysisReportWithMimeTypeV3>> GetAnalysisReportsV3AsXml(string projectId, string languageCode = null, int? reportId = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(projectId, "projectId");

            var reportResult = await ApiConnection.GetWithContent<IReadOnlyList<AnalysisReportWithMimeTypeV3>>(ApiUrls.AnalysisReportsV3(projectId, languageCode, reportId), "text/xml");
            return reportResult;
        }

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
        public async Task<IReadOnlyList<AnalysisReportWithMimeTypeV3>> GetAnalysisReportsV3AsXml(Guid projectId, string languageCode = null, int? reportId = null)
        {
            Ensure.ArgumentNotNull(projectId, "projectId");

            var reportResult = await ApiConnection.GetWithContent<IReadOnlyList<AnalysisReportWithMimeTypeV3>>(ApiUrls.AnalysisReportsV3(projectId, languageCode, reportId), "text/xml");
            return reportResult;
        }

        [Obsolete("This method is obsolete. Call 'GetLanguageFileSettings(Guid, Guid)' instead.")]
        public async Task<ProjectSettings> GetProjectSettings(string projectId, string languageFileId)
        {
            Ensure.ArgumentNotNullOrEmptyString(projectId, "projectId");
            Ensure.ArgumentNotNullOrEmptyString(projectId, "languageFileId");

            var projectSettings = await ApiConnection.Get<ProjectSettings>(ApiUrls.GetProjectSettings(projectId, languageFileId), null);
            return projectSettings;
        }

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
        public async Task<LanguageFileSettings> GetLanguageFileSettings(Guid projectId, Guid languageFileId)
        {
            Ensure.ArgumentNotNull(projectId, "projectId");
            Ensure.ArgumentNotNull(languageFileId, "languageFileId");

            var languageFileSettings = await ApiConnection.Get<LanguageFileSettings>(ApiUrls.GetLanguageFileSettings(projectId, languageFileId), null);
            return languageFileSettings;
        }

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
        public async Task<ProjectSettingsV2> GetProjectSettings(Guid projectId)
        {
            Ensure.ArgumentNotNull(projectId, "projectId");

            var projectSettings = await ApiConnection.Get<ProjectSettingsV2>(ApiUrls.GetProjectSettings(projectId), null);
            return projectSettings;
        }

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
        public async Task<ProjectSettingsV4> GetProjectSettingsV4(Guid projectId)
        {
            Ensure.ArgumentNotNull(projectId, "projectId");

            var projectSettings = await ApiConnection.Get<ProjectSettingsV4>(ApiUrls.GetProjectSettingsV4(projectId), null);
            return projectSettings;
        }

        /// <summary>
        /// Retrieves the Segment Locking configuration
        /// </summary>
        public async Task<dynamic> GetGetSegmentLockingConfig()
        {
            var segmentLockingConfig = await ApiConnection.Get<dynamic>(ApiUrls.GetSegmentLockingConfig(), null);
            return segmentLockingConfig;
        }

        [Obsolete("This method is obsolete. Call 'IsUserAuthorizedToOpenFile(Guid, Guid)' instead.")]
        public async Task<string> IsUserAuthorizedToOpenFile(string projectId, string languageFileId)
        {
            Ensure.ArgumentNotNullOrEmptyString(projectId, "projectId");
            Ensure.ArgumentNotNullOrEmptyString(projectId, "languageFileId");
            var response = await ApiConnection.Get<string>(ApiUrls.IsAuthorizedToOpenInEditor(projectId, languageFileId), null);

            return response;
        }

        /// <summary>
        /// Validates that the user can open the file in Universal Editor.
        /// </summary>
        /// <param name="projectId">The project's Guid</param>
        /// <param name="languageFileId">The language file's Guid</param>
        /// <returns></returns>
        public async Task<string> IsUserAuthorizedToOpenFile(Guid projectId, Guid languageFileId)
        {
            Ensure.ArgumentNotNull(projectId, "projectId");
            Ensure.ArgumentNotNull(languageFileId, "languageFileId");

            return await ApiConnection.Get<string>(ApiUrls.IsAuthorizedToOpenInEditor(projectId, languageFileId), null);
        }

        [Obsolete("This method is obsolete. Call 'EditorProfile(Guid, Guid)' instead.")]
        public async Task<EditorProfile> EditorProfile(string projectId, string languageFileId)
        {
            Ensure.ArgumentNotNullOrEmptyString(projectId, "projectId");
            Ensure.ArgumentNotNullOrEmptyString(projectId, "languageFileId");
            var editorProfile = await ApiConnection.Get<EditorProfile>(ApiUrls.EditorProfile(projectId, languageFileId), null);

            return editorProfile;
        }

        /// <summary>
        /// Gets the features associated to basic or advanced editor profile mode.
        /// </summary>
        /// <param name="projectId">The project's Guid</param>
        /// <param name="languageFileId">The language file's Guid</param>
        /// <returns><see cref="EditorProfile"/></returns>
        public async Task<EditorProfile> EditorProfile(Guid projectId, Guid languageFileId)
        {
            Ensure.ArgumentNotNull(projectId, "projectId");
            Ensure.ArgumentNotNull(projectId, "languageFileId");
            var editorProfile = await ApiConnection.Get<EditorProfile>(ApiUrls.EditorProfile(projectId, languageFileId), null);

            return editorProfile;
        }

        [Obsolete("This method is obsolete. Call 'OnlineCheckin(Guid, Guid, OnlineCheckInRequest)' instead.")]
        public async Task<OnlineCheckInRequest> OnlineCheckin(string projectId, string languageFileId, OnlineCheckInRequest checkoutResponse)
        {
            Ensure.ArgumentNotNullOrEmptyString(projectId, "projectId");
            Ensure.ArgumentNotNullOrEmptyString(languageFileId, "LanguageFileId");

            return await ApiConnection.Post<OnlineCheckInRequest>(ApiUrls.OnlineCheckIn(projectId, languageFileId), checkoutResponse, "application/json");
        }

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
        public async Task<OnlineCheckInRequest> OnlineCheckin(Guid projectId, Guid languageFileId, OnlineCheckInRequest checkoutResponse)
        {
            Ensure.ArgumentNotNull(projectId, "projectId");
            Ensure.ArgumentNotNull(languageFileId, "languageFileId");

            return await ApiConnection.Post<OnlineCheckInRequest>(ApiUrls.OnlineCheckIn(projectId, languageFileId), checkoutResponse, "application/json");
        }

        [Obsolete("This method is obsolete. Call 'OnlineCheckout(Guid, Guid)' instead.")]
        public async Task<OnlineCheckInRequest> OnlineCheckout(string projectId, string languageFileId)
        {
            Ensure.ArgumentNotNullOrEmptyString(projectId, "projectId");
            Ensure.ArgumentNotNullOrEmptyString(languageFileId, "LanguageFileId");
            return await ApiConnection.Post<OnlineCheckInRequest>(ApiUrls.OnlineCheckout(projectId, languageFileId), "application/json");
        }

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
        public async Task<OnlineCheckInRequest> OnlineCheckout(Guid projectId, Guid languageFileId)
        {
            Ensure.ArgumentNotNull(projectId, "projectId");
            Ensure.ArgumentNotNull(languageFileId, "languageFileId");
            return await ApiConnection.Post<OnlineCheckInRequest>(ApiUrls.OnlineCheckout(projectId, languageFileId), "application/json");
        }

        [Obsolete("This method is obsolete. Call 'UndoCheckout(Guid, Guid)' instead.")]
        public async Task UndoCheckout(string projectId, string languageFileId)
        {
            Ensure.ArgumentNotNullOrEmptyString(projectId, "projectId");
            Ensure.ArgumentNotNullOrEmptyString(languageFileId, "LanguageFileId");

            await ApiConnection.Delete(ApiUrls.UndoCheckout(projectId, languageFileId));
        }

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
        public async Task UndoCheckout(Guid projectId, Guid languageFileId)
        {
            Ensure.ArgumentNotNull(projectId, "projectId");
            Ensure.ArgumentNotNull(languageFileId, "languageFileId");

            await ApiConnection.Delete(ApiUrls.UndoCheckout(projectId, languageFileId));
        }

        /// <summary>
        /// Health check call used to keep the OE license seat taken
        /// </summary>
        /// This method requires authentication.
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        public async Task<string> OnlineCheckoutHealthCheck(string editorProfileMode)
        {
            var response = await ApiConnection.Get<string>(ApiUrls.OnlineCheckoutHealthCheck(editorProfileMode), null);
            return response;
        }

        [Obsolete("This method is obsolete. Call 'IsCheckoutToSomeoneElse(Guid, string)' instead.")]
        public async Task<bool> IsCheckoutToSomeoneElse(string languageFileId, string editorProfileMode)
        {
            Ensure.ArgumentNotNullOrEmptyString(languageFileId, "LanguageFileId");
            return await ApiConnection.Get<bool>(ApiUrls.IsCheckoutToSomeoneElse(languageFileId, editorProfileMode), null);
        }

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
        public async Task<bool> IsCheckoutToSomeoneElse(Guid languageFileId, string editorProfileMode)
        {
            Ensure.ArgumentNotNull(languageFileId, "LanguageFileId");
            return await ApiConnection.Get<bool>(ApiUrls.IsCheckoutToSomeoneElse(languageFileId, editorProfileMode), null);
        }

        [Obsolete("This method is obsolete. Call 'ExternalCheckin(Guid, Guid, string)' instead.")]
        public async Task<string> ExternalCheckin(string projectId, string languageFileId, string comment)
        {
            Ensure.ArgumentNotNullOrEmptyString(projectId, "projectId");
            Ensure.ArgumentNotNullOrEmptyString(languageFileId, "LanguageFileId");

            return await ApiConnection.Post<string>(ApiUrls.ExternalCheckin(projectId, languageFileId), comment, "application/json");
        }

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
        public async Task<string> ExternalCheckin(Guid projectId, Guid languageFileId, string comment)
        {
            Ensure.ArgumentNotNull(projectId, "projectId");
            Ensure.ArgumentNotNull(languageFileId, "LanguageFileId");

            return await ApiConnection.Post<string>(ApiUrls.ExternalCheckin(projectId, languageFileId), comment, "application/json");
        }

        [Obsolete("This method is obsolete. Call 'ExternalCheckout(Guid, Guid)' instead.")]
        public async Task<string> ExternalCheckout(string projectId, string languageFileId)
        {
            Ensure.ArgumentNotNullOrEmptyString(projectId, "projectId");
            Ensure.ArgumentNotNullOrEmptyString(languageFileId, "LanguageFileId");

            return await ApiConnection.Post<string>(ApiUrls.ExternalCheckout(projectId, languageFileId), "application/json");
        }

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
        public async Task<string> ExternalCheckout(Guid projectId, Guid languageFileId)
        {
            Ensure.ArgumentNotNull(projectId, "projectId");
            Ensure.ArgumentNotNull(languageFileId, "LanguageFileId");

            return await ApiConnection.Post<string>(ApiUrls.ExternalCheckout(projectId, languageFileId), "application/json");
        }

        [Obsolete("This method is obsolete. Call 'ExternalCheckOutFiles(Guid, List<Guid>)' instead.")]
        public async Task ExternalCheckOutFiles(string projectId, List<string> filesIdsList)
        {
            Ensure.ArgumentNotNullOrEmptyString(projectId, "projectId");
            Ensure.ArgumentNotEmpty(filesIdsList, "filesIds");

            var filesIds = "[\"" + string.Join("\",\"", filesIdsList) + "\"]";
            var content = new StringContent(filesIds, Encoding.UTF8, "application/json");

            await ApiConnection.Post<string>(ApiUrls.ExternalCheckOutFiles(projectId), content);
        }

        /// <summary>
        /// Checks-out multiple files for editing.
        /// </summary>
        /// <param name="projectId">The project's Guid</param>
        /// <param name="filesIds">Language file Ids to check-out</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        public async Task ExternalCheckOutFiles(Guid projectId, List<Guid> filesIdsList)
        {
            Ensure.ArgumentNotNull(projectId, "projectId");
            Ensure.ArgumentNotNull(filesIdsList, "filesIds");

            var filesIds = "[\"" + string.Join("\",\"", filesIdsList) + "\"]";
            var content = new StringContent(filesIds, Encoding.UTF8, "application/json");

            await ApiConnection.Post<Guid>(ApiUrls.ExternalCheckOutFiles(projectId), content);
        }

        [Obsolete("This method is obsolete. Call 'ExternalCheckInFiles(Guid, ExternalCheckInData)' instead.")]
        public async Task ExternalCheckInFiles(string projectId, ExternalCheckInData externalCheckInData)
        {
            Ensure.ArgumentNotNullOrEmptyString(projectId, "projectId");
            Ensure.ArgumentNotNull(externalCheckInData, "externalCheckInData");

            var serialized = new SimpleJsonSerializer().Serialize(externalCheckInData);
            var content = new StringContent(serialized, Encoding.UTF8, "application/json");

            await ApiConnection.Post<string>(ApiUrls.ExternalCheckInFiles(projectId), content);
        }

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
        public async Task ExternalCheckInFiles(Guid projectId, ExternalCheckInData externalCheckInData)
        {
            Ensure.ArgumentNotNull(projectId, "projectId");
            Ensure.ArgumentNotNull(externalCheckInData, "externalCheckInData");

            var serialized = new SimpleJsonSerializer().Serialize(externalCheckInData);
            var content = new StringContent(serialized, Encoding.UTF8, "application/json");

            await ApiConnection.Post<string>(ApiUrls.ExternalCheckInFiles(projectId), content);
        }

        [Obsolete("This method is obsolete. Call 'UndoExternalCheckOutForFiles(Guid, List<Guid>)' instead.")]
        public async Task UndoExternalCheckOutForFiles(string projectId, List<string> filesIdsList)
        {
            Ensure.ArgumentNotNullOrEmptyString(projectId, "projectId");
            Ensure.ArgumentNotEmpty(filesIdsList, "filesIds");

            var filesIds = "[\"" + string.Join("\",\"", filesIdsList) + "\"]";
            var content = new StringContent(filesIds, Encoding.UTF8, "application/json");

            await ApiConnection.Post<string>(ApiUrls.UndoExternalCheckOutForFiles(projectId), content);
        }

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
        public async Task UndoExternalCheckOutForFiles(Guid projectId, List<Guid> filesIdsList)
        {
            Ensure.ArgumentNotNull(projectId, "projectId");
            Ensure.ArgumentNotNull(filesIdsList, "filesIds");

            var filesIds = "[\"" + string.Join("\",\"", filesIdsList) + "\"]";
            var content = new StringContent(filesIds, Encoding.UTF8, "application/json");

            await ApiConnection.Post<string>(ApiUrls.UndoExternalCheckOutForFiles(projectId), content);
        }

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
        public Task<IReadOnlyList<AuditTrail>> AuditTrail(Guid projectId)
        {
            Ensure.ArgumentNotNull(projectId, "projectId");
            return ApiConnection.GetAll<AuditTrail>(ApiUrls.AuditTrail(projectId), null);
        }

        [Obsolete("This method is obsolete. Call 'AuditTrail(Guid)' instead.")]
        public Task<IReadOnlyList<AuditTrail>> AuditTrail(string projectId)
        {
            Ensure.ArgumentNotNullOrEmptyString(projectId, "projectId");
            return ApiConnection.GetAll<AuditTrail>(ApiUrls.AuditTrail(projectId), null);
        }

        [Obsolete("This method is obsolete. Call 'AuditTrail(Guid)' instead.")]
        public Task<IReadOnlyList<AuditTrial>> AuditTrial(string projectId)
        {
            Ensure.ArgumentNotNullOrEmptyString(projectId, "projectId");
            return ApiConnection.GetAll<AuditTrial>(ApiUrls.AuditTrial(projectId), null);
        }

        #endregion

    }
}