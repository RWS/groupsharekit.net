using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Exceptions;
using Sdl.Community.GroupShareKit.Models.Response;

namespace Sdl.Community.GroupShareKit.Clients
{
    public interface IRoleClient
    {
        [Obsolete("This method is obsolete. Call 'GetRoles()' instead.")]
        Task<IReadOnlyList<RoleRequest>> GetAllRoles();

        /// <summary>
        /// Gets all <see cref="Role"/>s.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="Role"/>s.</returns>
        Task<IReadOnlyList<Role>> GetRoles();

        [Obsolete("This method is obsolete. Call 'CreateRole(Role)' instead.")]
        Task<string> CreateRole(RoleRequest request);

        /// <summary>
        /// Creates a <see cref="Role"/>.
        /// </summary>
        /// <remarks>
        /// <param name="role"><see cref="Role"/></param>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>The role's Guid.</returns>
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

        [Obsolete("This method is obsolete. Call 'GetRole(Guid)' instead.")]
        Task<RoleRequest> GetRole(string roleId);

        /// <summary>
        /// Gets a <see cref="Role"/>.
        /// </summary>
        /// <param name="roleId">Role Guid</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A <see cref="Role"/>.</returns>
        Task<Role> GetRole(Guid roleId);

        [Obsolete("This method is obsolete. Call 'DeleteRole(Guid)' instead.")]
        Task DeleteRole(string roleId);

        /// <summary>
        /// Deletes a <see cref="Role"/>.
        /// </summary>
        /// <param name="roleId">Role Guid</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task DeleteRole(Guid roleId);

        /// <summary>
        /// Add a user to a role for a specific organization.<see cref="Role"/>s.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
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
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Task<IReadOnlyList<User>> GetUsersForRole(Guid roleId);

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
        [Obsolete("This method is obsolete. Call 'AddUserToRole(List<RoleMembership>)' instead.")]
        Task AddUserToRole(List<Role> roles);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
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
        [Obsolete("This method is obsolete. Call 'RemoveUserFromRole(List<RoleMembership>)' instead.")]
        Task RemoveUserFromRole(List<Role> roles, string roleId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        Task RemoveUserFromRole(List<RoleMembership> roles);
    }
}
