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
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="Role"/>s.</returns>
        Task<IReadOnlyList<Role>> GetRoles();

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
        Task<Guid> UpdateRole(RoleRequest role);

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
        /// Delete user membership <see cref="Role"/>s.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task DeleteRoleMembership(List<Role> role);

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
        Task<IReadOnlyList<User>> GetUsersForRole(Guid roleId);

        /// <summary>
        /// Adds users to a specific role.
        /// </summary>
        /// <param name="roles">An array of <see cref="RoleMembership"/> objects, each of them representing a combination of user, role and organization ids.</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task AddUserToRole(List<RoleMembership> roles);

        /// <summary>
        /// Removes users from a specific role.
        /// </summary>
        /// <param name="roles">An array of <see cref="RoleMembership"/> objects, each of them representing a combination of user, role and organization ids.</param>
        /// <remarks>
        /// <param name="roles"><see cref="RoleMembership"/></param>
        /// This method requires authentication.
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task RemoveUserFromRole(List<RoleMembership> roles);
    }
}
