using System;

namespace Sdl.Community.GroupShareKit.Helpers
{
    public static class ApiUrls
    {
        public static readonly Uri CurrentProjectServerUrl = new Uri("api/projectserver/v2", UriKind.Relative);
        public static readonly Uri CurrentManagementUrl = new Uri("api/management/v2", UriKind.Relative);
        public static readonly Uri CurrentAuthenticationUrl = new Uri("authentication/api/1.0", UriKind.Relative);


        /// <summary>
        /// Returns the <see cref="Uri"/> that returns a single user for the user name
        /// </summary>
        /// <returns></returns>
        public static Uri Login()
        {
            return "{0}/login".FormatUri(CurrentAuthenticationUrl);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that returns a single user for the user name
        /// </summary>
        /// <returns></returns>
        public static Uri User()
        {
            return "{0}/users".FormatUri(CurrentManagementUrl);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that returns a single user for the user id
        /// </summary>
        /// <returns></returns>
        public static Uri User(string userId)
        {
            return "{0}/users/{1}".
                FormatUri(CurrentManagementUrl,userId);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that find a user or users, by matching on the user's username or display name.
        /// </summary>
        /// <returns></returns>
        public static Uri Search(string searchText)
        {
            return "{0}/users?searchText={1}".
                FormatUri(CurrentManagementUrl, searchText);
        }

        /// <summary>
        ///  Returns the <see cref="Uri"/> that returns all roles
        /// </summary>
        /// <returns></returns>
        public static Uri Roles()
        {
            return "{0}/roles".
                FormatUri(CurrentManagementUrl);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that returns a single role
        /// </summary>
        /// <returns></returns>
        public static Uri Role(string roleId)
        {

            return "{0}/roles/{1}".
                FormatUri(CurrentManagementUrl, roleId);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that returns a membership
        /// </summary>
        /// <returns></returns>
        public static Uri RoleMembership()
        {
            return "{0}/roles/membership".FormatUri(CurrentManagementUrl);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that returns a single organization
        /// </summary>
        /// <returns></returns>
        public static Uri Organization(string organizationId)
        {
            return "{0}/organizations/{1}".
                FormatUri(CurrentManagementUrl, organizationId);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that a list of organizations
        /// </summary>
        /// <returns></returns>
        public static Uri Organizations()
        {
            return "{0}/organizations".
                FormatUri(CurrentManagementUrl);
        }
        public static Uri OrganizationsResources(string organizationId)
        {
            return "{0}/organizationresources/{1}".
                FormatUri(CurrentManagementUrl,organizationId);
        }
        public static Uri OrganizationsResources()
        {
            return "{0}/organizationresources".
                FormatUri(CurrentManagementUrl);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that returns all projects associated with the specified organziation
        /// </summary>
        /// <returns></returns>
        //public static Uri OrganizationProjects()
        //{
        //    return "{0}/projects".
        //        FormatUri(CurrentProjectServerUrl);
        //}

        public static Uri GetAllProjects()
        {
            return "{0}/projects".
                FormatUri(CurrentProjectServerUrl);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that returns all permissions
        /// </summary>
        /// <returns></returns>
        public static Uri Permission()
        {
            return "{0}/permissions".
                FormatUri(CurrentManagementUrl);
        }

        public static Uri PermissionName()
        {
            return "{0}/permissions/user".
                FormatUri(CurrentManagementUrl);
        }
        /// <summary>
        /// Returns the <see cref="Uri"/> that represents the project
        /// </summary>
        /// <returns></returns>
        public static Uri Project(string projectId)
        {
            return "{0}/projects/{1}".
                FormatUri(CurrentProjectServerUrl, projectId);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that represents publishing status of a server project.
        /// </summary>
        /// <returns></returns>
        public static Uri PublishingStatus(string projectId)
        {
            return "{0}/projects/{1}/publishingstatus".
                FormatUri(CurrentProjectServerUrl, projectId);
        }




        /// <summary>
        /// Returns the <see cref="Uri"/> that represents downloaded files with the specific languageCodeid and type
        /// </summary>
        /// <returns></returns>
        public static Uri DownloadFile()
        {
            return "{0}/FileDownload".
                FormatUri(CurrentProjectServerUrl);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that represents downloaded files with the specific languageCode ids
        /// </summary>
        /// <returns></returns>
        public static Uri DownloadFiles(string projectId,string languageFileIdsQuery)
        {
            return "{0}/projects/{1}/download/?{2}archive=true".
                FormatUri(CurrentProjectServerUrl, projectId,languageFileIdsQuery);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that  publish project package associated with the specified organziation
        /// </summary>
        /// <returns></returns>
        public static Uri PublishProjectPackage(string projectId)
        {
            return "{0}/projects/{1}/publishpackage".
                FormatUri(CurrentProjectServerUrl,projectId);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that returns all files associated with the specified project
        /// </summary>
        /// <param name="projectId">The project id</param>
        /// <returns></returns>
        public static Uri ProjectFiles(string projectId)
        {
            return "{0}/projects/{1}/files".
                FormatUri(CurrentProjectServerUrl, projectId);
        }

        public static Uri ProjectTemplates()
        {
            return "{0}/projects/templates".
                FormatUri(CurrentProjectServerUrl);
        }
        public static Uri ProjectTemplates(string templateId)
        {
            return "{0}/projects/templates/{1}".
                FormatUri(CurrentProjectServerUrl,templateId);
        }
        /// <summary>
        /// Returns the <see cref="Uri"/> that returns all phases associated with the specified project
        /// </summary>
        /// <param name="projectId">The project id</param>
        /// <returns></returns>
        public static Uri ProjectPhases(string projectId)
        {
            return "{0}/phases/{1}".
                FormatUri(CurrentProjectServerUrl, projectId);
        }

        public static Uri ProjectPhasesWithAssignees(string projectId,int phaseId)
        {
            return "{0}/projects/{1}/phaseswithassignees/{2}".
                FormatUri(CurrentProjectServerUrl, projectId,phaseId);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that change the project phases
        /// </summary>
        /// <param name="projectId">The project id</param>
        /// <returns></returns>
        public static Uri ChangePhases(string projectId)
        {
            return "{0}/projects/{1}/changephase".
               FormatUri(CurrentProjectServerUrl, projectId);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that change the project phases
        /// </summary>
        /// <param name="projectId">The project id</param>
        /// <returns></returns>
        public static Uri ChangeAssignments(string projectId)
        {
            return "{0}/projects/{1}/changeassignment".
               FormatUri(CurrentProjectServerUrl, projectId);
        }

    }
}
