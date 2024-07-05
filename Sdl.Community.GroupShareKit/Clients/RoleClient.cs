using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Exceptions;
using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Http;
using Sdl.Community.GroupShareKit.Models.Response;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class RoleClient : ApiClient, IRoleClient
    {
        public RoleClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        /// <summary>
        /// Gets all <see cref="Role"/>'s.
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
        public Task<IReadOnlyList<RoleRequest>> GetAllRoles()
        {
            return ApiConnection.GetAll<RoleRequest>(ApiUrls.Roles());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<IReadOnlyList<Role>> GetRoles()
        {
            return ApiConnection.GetAll<Role>(ApiUrls.Roles());
        }

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
        [Obsolete("This method is obsolete. Call 'CreateRole(Role)' instead.")]
        public async Task<string> CreateRole(RoleRequest request)
        {
            Ensure.ArgumentNotNull(request, "request");

            return await ApiConnection.Post<string>(ApiUrls.Roles(), request, "application/json");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public async Task<Guid> CreateRole(Role role)
        {
            Ensure.ArgumentNotNull(role, "role");

            return await ApiConnection.Post<Guid>(ApiUrls.Roles(), role, "application/json");
        }

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
        public Task<string> Update(RoleRequest role)
        {
            return ApiConnection.Put<string>(ApiUrls.Roles(), role);
        }

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
        [Obsolete("This method is obsolete. Call 'GetRole(Guid)' instead.")]
        public Task<RoleRequest> GetRole(string roleId)
        {
            Ensure.ArgumentNotNullOrEmptyString(roleId, "roleId");

            return ApiConnection.Get<RoleRequest>(ApiUrls.Role(roleId), null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public Task<Role> GetRole(Guid roleId)
        {
            Ensure.ArgumentNotNull(roleId, "roleId");

            return ApiConnection.Get<Role>(ApiUrls.Role(roleId), null);
        }

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
        [Obsolete("This method is obsolete. Call 'DeleteRole(Guid)' instead.")]
        public Task DeleteRole(string roleId)
        {
            Ensure.ArgumentNotNullOrEmptyString(roleId, "roleId");

            return ApiConnection.Delete(ApiUrls.Role(roleId));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public Task DeleteRole(Guid roleId)
        {
            Ensure.ArgumentNotNull(roleId, "roleId");

            return ApiConnection.Delete(ApiUrls.Role(roleId));
        }

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
        public Task<string> RoleMembership(List<Role> role)
        {
            return ApiConnection.Put<string>(ApiUrls.RoleMembership(), role);
        }

        /// <summary>
        /// Delete a user to a role membership <see cref="Role"/>s.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        public Task DeleteRoleMembership(List<Role> role)
        {
            return ApiConnection.Delete(ApiUrls.RoleMembership(), role, "application/json");
        }

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
        [Obsolete("This method is obsolete. Call 'GetUsersForRole(Guid)' instead.")]
        public Task<IReadOnlyList<User>> GetUsersForRole(string roleId)
        {
            Ensure.ArgumentNotNullOrEmptyString(roleId, "roleId");
            return ApiConnection.GetAll<User>(ApiUrls.GetUsersForRole(roleId));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public Task<IReadOnlyList<User>> GetUsersForRole(Guid roleId)
        {
            Ensure.ArgumentNotNull(roleId, "roleId");
            return ApiConnection.GetAll<User>(ApiUrls.GetUsersForRole(roleId));
        }

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
        public async Task AddUserToRole(List<Role> roles)
        {
            await ApiConnection.Put<string>(ApiUrls.RoleMembership(), roles);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        public async Task AddUserToRole(List<RoleMembership> roles)
        {
            await ApiConnection.Put<Guid>(ApiUrls.RoleMembership(), roles);
        }

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
        public async Task RemoveUserFromRole(List<Role> roles, string roleId)
        {
            await ApiConnection.Delete(ApiUrls.DeleteUserFromRole(roleId), roles, "application/json");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        public async Task RemoveUserFromRole(List<RoleMembership> roles)
        {
            await ApiConnection.Delete(ApiUrls.RoleMembership(), roles, "application/json");
        }

    }
}
