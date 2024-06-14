using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Exceptions;
using Sdl.Community.GroupShareKit.Models.Response;

namespace Sdl.Community.GroupShareKit.Clients
{
    public interface IRoleClient
    {
        /// <summary>
        /// Gets all <see cref="Role"/>s.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="Role"/>s.</returns>
        [Obsolete("GetAllRoles is deprecated, please use GetRoles instead.")]
        Task<IReadOnlyList<RoleRequest>> GetAllRoles();

        /// <summary>
        /// Gets all <see cref="Role"/>s.
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyList<Role>> GetRoles();

        /// <summary>
        /// Create <see cref="Role"/>s.
        /// </summary>
        /// <remarks>
        /// <param name="request"><see cref="RoleRequest"/></param>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>Role id.</returns>
        [Obsolete]
        Task<string> CreateRole(RoleRequest request);

        Task<Guid> CreateRole(Role role);

        /// <summary>
        /// Update role <see cref="RoleRequest"/>s.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>Role id</returns>
        Task<string> Update(RoleRequest role);

        /// <summary>
        /// Get <see cref="RoleRequest"/>s.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> <see cref="RoleRequest"/>s.</returns>
        [Obsolete("GetRole is deprecated, please use GetRoles instead.")]
        Task<RoleRequest> GetRole(string roleId);

        /// <summary>
        /// Get <see cref="Role"/>s.
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Task<Role> GetRole(Guid roleId);

        /// <summary>
        /// Delete role.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task DeleteRole(string roleId);

        /// <summary>
        /// Add a user to a role for a specific organization.<see cref="Role"/>s.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="Role"/>s.</returns>
        Task<string> RoleMembership(List<Role> role);

        /// <summary>
        /// Delete user membership <see cref="Role"/>s.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task DeleteRoleMembership(List<Role> role);

        /// <summary>
        /// Gets users for a specific role<see cref="Role"/>s.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="User"/>'s</returns>
        Task<IReadOnlyList<User>> GetUsersForRole(string roleId);

        /// <summary>
        /// Adds users for a specific role<see cref="Role"/>s.
        /// </summary>
        /// <remarks>
        /// <param name="roles"><see cref="Role"/></param>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        [Obsolete]
        Task AddUserToRole(List<Role> roles);

        Task AddUserToRole(List<RoleMembership> roles);

        /// <summary>
        /// Removes users for a specific role<see cref="Role"/>s.
        /// </summary>
        /// <remarks>
        /// <param name="roles"><see cref="Role"/></param>
        /// <param name="roleId">string</param>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        [Obsolete]
        Task RemoveUserFromRole(List<Role> roles, string roleId);

        Task RemoveUserFromRole(List<RoleMembership> roles/*, Guid roleId*/);
    }
}
