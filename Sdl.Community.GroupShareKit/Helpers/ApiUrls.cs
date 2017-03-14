using System;
using Sdl.Community.GroupShareKit.Clients;

namespace Sdl.Community.GroupShareKit.Helpers
{
    public static class ApiUrls
    {
        public static readonly Uri CurrentProjectServerUrl = new Uri("api/projectserver/v2", UriKind.Relative);
        public static readonly Uri CurrentManagementUrl = new Uri("api/management/v2", UriKind.Relative);
        public static readonly Uri CurrentAuthenticationUrl = new Uri("authentication/api/1.0", UriKind.Relative);
        public static readonly Uri CurrentTranslationMemoriesUrl = new Uri("api/tmservice", UriKind.Relative);
        public static readonly Uri CurrentFieldServiceUrl = new Uri("api/fieldservice", UriKind.Relative);
        public static readonly Uri CurrentMultitermUrl = new Uri("multiterm/api/1.0", UriKind.Relative);


        public static Uri Modules()
        {
            return "{0}/modules".FormatUri(CurrentManagementUrl);
        }
        /// <summary>
        /// Returns the <see cref="Uri"/> that returns a single user for the user name
        /// </summary>
        public static Uri Login()
        {
            return "{0}/login".FormatUri(CurrentAuthenticationUrl);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that returns a single user for the user name
        /// </summary>
        public static Uri User()
        {
            return "{0}/users".FormatUri(CurrentManagementUrl);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that returns a single user for the user id
        /// </summary>
        public static Uri User(string userId)
        {
            return "{0}/users/{1}".
                FormatUri(CurrentManagementUrl,userId);
        }


        /// <summary>
        ///  Returns the <see cref="Uri"/> that returns all roles
        /// </summary>
        public static Uri Roles()
        {
            return "{0}/roles".
                FormatUri(CurrentManagementUrl);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that returns a single role
        /// </summary>
        public static Uri Role(string roleId)
        {

            return "{0}/roles/{1}".
                FormatUri(CurrentManagementUrl, roleId);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that returns a membership
        /// </summary>
        public static Uri RoleMembership()
        {
            return "{0}/roles/membership".FormatUri(CurrentManagementUrl);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that returns a single organization
        /// </summary>
        public static Uri Organization(string organizationId)
        {
            return "{0}/organizations/{1}".
                FormatUri(CurrentManagementUrl, organizationId);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that a list of organizations
        /// </summary>
        public static Uri Organizations()
        {
            return "{0}/organizations".
                FormatUri(CurrentManagementUrl);
        }
        /// <summary>
        ///  Returns the <see cref="Uri"/> that gets all organization resources
        /// </summary>
        /// <param name="organizationId">Organization Id</param>
        public static Uri OrganizationResources(string organizationId)
        {
            return "{0}/organizationresources/{1}".
                FormatUri(CurrentManagementUrl,organizationId);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that moves a resource to a organization
        /// </summary>
        public static Uri MoveOrganizationsResources()
        {
            return "{0}/organizationresources".
                FormatUri(CurrentManagementUrl);
        }

        /// <summary>
        /// Returs the <see cref="Uri" /> that gets all projects
        /// </summary>
        public static Uri GetAllProjects()
        {
            return "{0}/projects".
                FormatUri(CurrentProjectServerUrl);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that returns all permissions
        /// </summary>
        public static Uri Permissions()
        {
            return "{0}/permissions".
                FormatUri(CurrentManagementUrl);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that returns all permissions for users
        /// </summary>
        public static Uri PermissionUsers()
        {
            return "{0}/permissions/user".
                FormatUri(CurrentManagementUrl);
        }
        /// <summary>
        /// Returns the <see cref="Uri"/> that represents the project
        /// </summary>
        public static Uri Project(string projectId)
        {
            return "{0}/projects/{1}".
                FormatUri(CurrentProjectServerUrl, projectId);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that represents publishing status of a server project.
        /// </summary>
        public static Uri PublishingStatus(string projectId)
        {
            return "{0}/projects/{1}/publishingstatus".
                FormatUri(CurrentProjectServerUrl, projectId);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that represents downloaded files with the specific languageCodeid and type
        /// </summary>
        public static Uri DownloadFile(string projectId, string type)
        {
            return "{0}/projects/{1}/download/{2}".
                FormatUri(CurrentProjectServerUrl, projectId, type);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that represents downloaded files with the specific languageCode ids
        /// </summary>
        public static Uri DownloadFiles(string projectId,string languageFileIdsQuery)
        {
            return "{0}/projects/{1}/download/?{2}archive=true".
                FormatUri(CurrentProjectServerUrl, projectId,languageFileIdsQuery);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that  publish project package associated with the specified organziation
        /// </summary>
        public static Uri PublishProjectPackage(string projectId)
        {
            return "{0}/projects/{1}/publishpackage".
                FormatUri(CurrentProjectServerUrl,projectId);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that returns all files associated with the specified project
        /// </summary>
        /// <param name="projectId">The project id</param>
        public static Uri ProjectFiles(string projectId)
        {
            return "{0}/projects/{1}/files".
                FormatUri(CurrentProjectServerUrl, projectId);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that returns all project templates
        /// </summary>
        public static Uri ProjectTemplates()
        {
            return "{0}/projects/templates".
                FormatUri(CurrentProjectServerUrl);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that returns a template
        /// </summary>
        /// <param name="templateId">The template id</param>
        public static Uri ProjectTemplates(string templateId)
        {
            return "{0}/projects/templates/{1}".
                FormatUri(CurrentProjectServerUrl,templateId);
        }
        /// <summary>
        /// Returns the <see cref="Uri"/> that returns all phases associated with the specified project
        /// </summary>
        /// <param name="projectId">The project id</param>
        public static Uri ProjectPhases(string projectId)
        {
            return "{0}/phases/{1}".
                FormatUri(CurrentProjectServerUrl, projectId);
        }

        /// <summary>
        /// Returns the <see cref="Uri" />that gets a list of files for the requested project with all the project phases and theirs assignees
        /// </summary>
        /// <param name="projectId">Project id</param>
        /// <param name="phaseId">Phase id</param>
        public static Uri ProjectPhasesWithAssignees(string projectId,int phaseId)
        {
            return "{0}/projects/{1}/phaseswithassignees/{2}".
                FormatUri(CurrentProjectServerUrl, projectId,phaseId);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that change the project phases
        /// </summary>
        /// <param name="projectId">The project id</param>
          public static Uri ChangePhases(string projectId)
        {
            return "{0}/projects/{1}/changephase".
               FormatUri(CurrentProjectServerUrl, projectId);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that change the project phases
        /// </summary>
        /// <param name="projectId">The project id</param>
        public static Uri ChangeAssignments(string projectId)
        {
            return "{0}/projects/{1}/changeassignment".
               FormatUri(CurrentProjectServerUrl, projectId);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that gets  file versions informations
        /// </summary>
        /// <param name="languageFileId">Language file id</param>
        public static Uri GetFileVersion(string languageFileId)
        {
            return "{0}/projects/fileversions/{1}".
                FormatUri(CurrentProjectServerUrl, languageFileId);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> to download the file for a specified version 
        /// </summary>
        /// <param name="projectId">The project id</param>
        /// <param name="languageFileId"> Language file id</param>
        /// <param name="version"> File version</param>
        public static Uri DownloadFileForVersion(string projectId, string languageFileId, int version)
        {
            return "{0}/projects/{1}/fileversions/download/{2}/{3}".
                FormatUri(CurrentProjectServerUrl, projectId, languageFileId, version);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> for license informations
        /// </summary>
        public static Uri GetLicenseInformations()
        {
            return "{0}/license".FormatUri(CurrentManagementUrl);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that gets user assignments
        /// </summary>
        public static Uri GetProjectsAssignments()
        {
            return "{0}/projects/userassignments".FormatUri(CurrentProjectServerUrl);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> thet gets a list of assignements for a project
        /// </summary>
        /// <param name="projectId">Project Id</param>
        /// <param name="fileIdQuery"></param>
        public static Uri GetProjectAssignmentById(string projectId, string fileIdQuery)
        {
            return "{0}/projects/{1}/assignment?{2}"
                .FormatUri(CurrentProjectServerUrl, projectId, fileIdQuery);
        }
        /// <summary>
        /// Returns the <see cref="Uri"/> that adds the template
        /// </summary>
        /// <param name="templateId">Template id</param>
        public static Uri UploadProjectTemplate(string templateId)
        {
            return "{0}/projects/templates/{1}/upload".FormatUri(CurrentProjectServerUrl, templateId);
        }

        /// <summary>
        ///  Returns the <see cref="Uri"/> that adds files for project
        /// </summary>
        /// <param name="projectId">Project id</param>
        public static Uri UploadFilesForProject(string projectId)
        {
            return "{0}/projects/{1}/files/upload".FormatUri(CurrentProjectServerUrl, projectId);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that changes the project status
        /// </summary>
        /// <param name="projectId">Project id</param>
        /// <param name="status">Status</param>
        public static Uri ChangeProjectStatus(string projectId, string status)
        {
            return "{0}/projects/{1}/changestatus/{2}".FormatUri(CurrentProjectServerUrl,projectId, status);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that changes the project status
        /// </summary>
        /// <param name="statusRequest">Status request</param>
        public static Uri ChangeProjectStatus(ChangeStatusRequest statusRequest)
        {
            var status = Enum.GetName(typeof (ChangeStatusRequest.ProjectStatus), statusRequest.Status);
            return "{0}/projects/{1}/detach?status={2}".FormatUri(CurrentProjectServerUrl, statusRequest.ProjectId,status);
        }

        /// <summary>
        ///  Returns the <see cref="Uri"/> that deletes detach to a project status
        /// </summary>
        /// <param name="projectId">Project id</param>
        /// <param name="deleteTms">True/False if the tms should be deleted</param>
        public static Uri ProjectStatusDeleteDetach(string projectId, bool deleteTms)
        {
            return "{0}/projects/{1}/detach/{2}".FormatUri(CurrentProjectServerUrl, projectId, deleteTms);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that links resource to a organization
        /// </summary>
        public static Uri LinkResourceToOrganization()
        {
            return "{0}/resourcelink ".FormatUri(CurrentManagementUrl);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that gets a list of users in a certain role 
        /// </summary>
        /// <param name="roleId">The role id</param>
        public static Uri GetUsersForRole(string roleId)
        {
            return "{0}/roles/{1}/membership".FormatUri(CurrentManagementUrl, roleId);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that removes  users from a certain role 
        /// </summary>
        /// <param name="roleId">The role id</param>
        public static Uri DeleteUserFromRole(string roleId)
        {
            return "{0}/roles/{1}/users".FormatUri(CurrentManagementUrl, roleId);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that gives a list of tms
        /// </summary>
        public static Uri GetTms()
        {
            return "{0}/tms".FormatUri(CurrentTranslationMemoriesUrl);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that gives specified tm.
        /// </summary>
        public static Uri GetTmById(string tmId)
        {
            return "{0}/tms/{1}".FormatUri(CurrentTranslationMemoriesUrl,tmId);
        }
        /// <summary>
        /// Returns the <see cref="Uri"/> that gives the language direction information for a specified tm
        /// </summary>
        /// <param name="tmId"></param>
        /// <param name="languageDirectionId"></param>
        public static Uri GetLanguageDirectionForTm(string tmId, string languageDirectionId)
        {
            return "{0}/tms/{1}/language-directions/{2}".FormatUri(CurrentTranslationMemoriesUrl, tmId,languageDirectionId);
        }

        /// <summary>
        ///  Returns the <see cref="Uri"/> that gives the tms for resource language template id
        /// </summary>
        /// <param name="resourceTemplateId">resource te,plate id</param>
        public static Uri GetTmsNumberByLanguageResourceTemplateId(string resourceTemplateId)
        {
            return "{0}/tms/by-language-resource-template/{1}/count".FormatUri(CurrentTranslationMemoriesUrl, resourceTemplateId);
        }
        /// <summary>
        ///  Returns the <see cref="Uri"/> that gives the tms for field template id
        /// </summary>
        /// <param name="fieldTemplateId"> field template id</param>
        public static Uri GetTmsNumberByFieldTemplateId(string fieldTemplateId)
        {
            return "{0}/tms/by-field-template/{1}/count".FormatUri(CurrentTranslationMemoriesUrl, fieldTemplateId);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that gives a list of termbases
        /// </summary>
        public static Uri GetTermbases()
        {
            return "{0}/termbases".FormatUri(CurrentMultitermUrl);
        }
        /// <summary>
        /// Returns the <see cref="Uri"/> that gives specified tm
        /// </summary>
        public static Uri GetTermbaseById(string termbaseId)
        {
            return "{0}/termbases/{1}".FormatUri(CurrentMultitermUrl,termbaseId);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that returns field templates
        /// </summary>
        public static Uri FieldTemplate()
        {
            return "{0}/templates".FormatUri(CurrentFieldServiceUrl);
        }
        /// <summary>
        /// Returns the <see cref="Uri"/> that returns specific  field template
        /// </summary>
        public static Uri GetFieldTemplateById(string id)
        {
            return "{0}/templates/{1}".FormatUri(CurrentFieldServiceUrl,id);
        }
        /// <summary>
        /// Returns the <see cref="Uri"/> that returns the health status of tm service
        /// </summary>
        public static Uri Health()
        {
            return "{0}/health".FormatUri(CurrentTranslationMemoriesUrl);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that gets filters from the specified termbase
        /// </summary>
        public static Uri GetFilers(string termbaseId)
        {
            return "{0}/termbases/{1}/filters".FormatUri(CurrentMultitermUrl, termbaseId);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that search for terms in termbase
        /// </summary>
        public static Uri Search()
        {
            return "{0}/termbases/search".FormatUri(CurrentMultitermUrl);
        }
        /// <summary>
        /// Returns the <see cref="Uri"/> that gets a concept
        /// </summary>
        public static Uri GetConcepts(ConceptRequest request)
        {
            return "{0}/termbases/{1}/concepts?conceptId={2}".FormatUri(CurrentMultitermUrl,request.TermbaseId,request.ConceptId);
        }
        /// <summary>
        /// Returns the <see cref="Uri"/> that gets a concept
        /// </summary
        public static Uri GetConcepts(string termbaseId )
        {
            return "{0}/termbases/{1}/concepts".FormatUri(CurrentMultitermUrl, termbaseId);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that gets a concept
        /// </summary>
        public static Uri GetConcepts(string termbaseId, string conceptId)
        {
            return "{0}/termbases/{1}/concepts/{2}".FormatUri(CurrentMultitermUrl, termbaseId, conceptId);
        }
    }
}
