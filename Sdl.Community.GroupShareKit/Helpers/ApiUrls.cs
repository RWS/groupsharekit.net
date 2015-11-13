using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Helpers
{
    public static partial class ApiUrls
    {
        static readonly Uri CurrentProjectServerUrl = new Uri("projectserver/api/1.0", UriKind.Relative);
        static readonly Uri CurrentManagementUrl = new Uri("management/api/1.0", UriKind.Relative);
        static readonly Uri CurrentAuthenticationUrl = new Uri("authentication/api/1.0", UriKind.Relative);

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
        /// Returns the <see cref="Uri"/> that returns all users
        /// </summary>
        /// <returns></returns>
        public static Uri Users()
        {
            return "{0}/users".
                FormatUri(CurrentManagementUrl);
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

        /// <summary>
        /// Returns the <see cref="Uri"/> that returns all projects associated with the specified organziation
        /// </summary>
        /// <returns></returns>
        public static Uri OrganizationProjects()
        {
            return "{0}/projects".
                FormatUri(CurrentProjectServerUrl);
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
            return "{0}/projects/{1}/filestatus/languagefiles".
                FormatUri(CurrentProjectServerUrl, projectId);
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
