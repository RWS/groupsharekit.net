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

        [Obsolete("This method is obsolete. Call 'UpdateRole(RoleRequest)' instead.")]
        Task<string> Update(RoleRequest role);

        /// <summary>
        /// Updates a <see cref="Role"/>.
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

        [Obsolete("This method is obsolete. Call 'GetUsersForRole(Guid)' instead.")]
        Task<IReadOnlyList<User>> GetUsersForRole(string roleId);

        /// <summary>
        /// Gets all <see cref="User"/>s that have a specific role.
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

        [Obsolete("This method is obsolete. Call 'AddUserToRole(List<RoleMembership>)' instead.")]
        Task<string> RoleMembership(List<Role> role);

        [Obsolete("This method is obsolete. Call 'AddUserToRole(List<RoleMembership>)' instead.")]
        Task AddUserToRole(List<Role> roles);

        /// <summary>
        /// Adds users to roles in specific organizations.
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

        [Obsolete("This method is obsolete. Call 'RemoveUserFromRole(List<RoleMembership>)' instead.")]
        Task RemoveUserFromRole(List<Role> roles, string roleId);

        /// <summary>
        /// Removes users from roles in specific organizations.
        /// </summary>
        /// <param name="roles">An array of <see cref="RoleMembership"/> objects, each of them representing a combination of user, role and organization ids.</param>
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
