using System.Collections.Generic;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Exceptions;
using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Http;
using Sdl.Community.GroupShareKit.Models.Response;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class PermissionClient : ApiClient, IPermissionClient
    {
        public PermissionClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        /// <summary>
        /// Gets all <see cref="Permission"/>s.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="Permission"/>s.</returns>
        public Task<IReadOnlyList<Permission>> GetAll()
        {
            return ApiConnection.GetAll<Permission>(ApiUrls.Permissions());
        }

        /// <summary>
        /// Gets all permissions names for users <see cref="PermissionsName"/>s.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="PermissionsName"/>s.</returns>
        public Task<IReadOnlyList<PermissionsName>> GetUsersPermissions()
        {
            return ApiConnection.GetAll<PermissionsName>(ApiUrls.PermissionUsers());
        }

        /// <summary>
        /// Gets all the permissions granted per resource groups, hierarchically.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <returns>An array of <see cref="OrganizationPermissions"/>s.</returns>
        public Task<IReadOnlyList<OrganizationPermissions>> GetUserPermissions(string username, bool hideImplicitLibs = false)
        {
            return ApiConnection.GetAll<OrganizationPermissions>(ApiUrls.GetUserPermissions(username, hideImplicitLibs));
        }
    }
}
