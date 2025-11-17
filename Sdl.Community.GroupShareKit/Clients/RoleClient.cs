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
        public Task<IReadOnlyList<Role>> GetRoles()
        {
            return ApiConnection.GetAll<Role>(ApiUrls.Roles());
        }

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
        public async Task<Guid> CreateRole(Role role)
        {
            Ensure.ArgumentNotNull(role, "role");

            return await ApiConnection.Post<Guid>(ApiUrls.Roles(), role, "application/json");
        }

        /// <summary>
        /// Updates a role.
        /// </summary>
        /// <param name="role">Role details</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>The role's Guid.</returns>
        public Task<Guid> UpdateRole(RoleRequest role)
        {
            return ApiConnection.Put<Guid>(ApiUrls.Roles(), role);
        }

        /// <summary>
        /// Gets a <see cref="Role"/>.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A <see cref="Role"/>.</returns>
        public Task<Role> GetRole(Guid roleId)
        {
            Ensure.ArgumentNotNull(roleId, "roleId");

            return ApiConnection.Get<Role>(ApiUrls.Role(roleId), null);
        }

        /// <summary>
        /// Deletes a <see cref="Role"/>.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        public Task DeleteRole(Guid roleId)
        {
            Ensure.ArgumentNotNull(roleId, "roleId");

            return ApiConnection.Delete(ApiUrls.Role(roleId));
        }

        /// <summary>
        /// Delete a user to a role membership <see cref="Role"/>s.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
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
        /// Gets users for a specific <see cref="Role"/>.
        /// </summary>
        /// <param name="roleId">The role's Id</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="User"/>s.</returns>
        public Task<IReadOnlyList<User>> GetUsersForRole(Guid roleId)
        {
            return ApiConnection.GetAll<User>(ApiUrls.GetUsersForRole(roleId));
        }

        /// <summary>
        /// Adds users for a specific role<see cref="Role"/>s.
        /// </summary>
        /// <param name="roles">An array of <see cref="RoleMembership"/> objects, each of them representing a combination of user, role and organization ids.</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        public async Task AddUserToRole(List<RoleMembership> roles)
        {
            await ApiConnection.Put<Guid>(ApiUrls.RoleMembership(), roles);
        }

        /// <param name="roles"><see cref="RoleMembership"/></param>
        /// This method requires authentication.
        /// <remarks>
        /// Removes users for a specific role<see cref="Role"/>s.
        /// </summary>
        /// <param name="roles">An array of <see cref="RoleMembership"/> objects, each of them representing a combination of user, role and organization ids.</param>
        /// <remarks>
        /// <param name="roles"><see cref="Role"/></param>
        /// <param name="roleId">string</param>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        public async Task RemoveUserFromRole(List<RoleMembership> roles)
        {
            await ApiConnection.Delete(ApiUrls.RoleMembership(), roles, "application/json");
        }

    }
}
