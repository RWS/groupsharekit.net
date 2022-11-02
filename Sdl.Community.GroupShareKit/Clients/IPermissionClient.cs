using System.Collections.Generic;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Exceptions;
using Sdl.Community.GroupShareKit.Models.Response;

namespace Sdl.Community.GroupShareKit.Clients
{
    public interface IPermissionClient
    {
        /// <summary>
        /// Gets all <see cref="Permission"/>s.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="Permission"/>s.</returns>
        Task<IReadOnlyList<Permission>> GetAll();

        /// <summary>
        /// Gets all permissions names for users <see cref="PermissionsName"/>s.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="PermissionsName"/>s.</returns>
        Task<IReadOnlyList<PermissionsName>> GetUsersPermissions();

        /// <summary>
        /// Gets all the permissions granted per resource groups, hierarchically.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <returns>An array of <see cref="OrganizationPermissions"/>s.</returns>
        Task<IReadOnlyList<OrganizationPermissions>> GetUserPermissions(string username, bool hideImplicitLibs = false);
    }
}
