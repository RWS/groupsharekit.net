using System.Collections.Generic;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Exceptions;
using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Http;
using Sdl.Community.GroupShareKit.Models.Response;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class RoleClient : ApiClient ,IRoleClient
    {
        public RoleClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        /// <summary>
        /// Gets all <see cref="Role"/>'s.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
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
        /// Create <see cref="Role"/>'s.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="Role"/>s.</returns>
        public async Task<string> CreateRole(RoleRequest request)
        {
            Ensure.ArgumentNotNull(request, "request");

            return await ApiConnection.Post<string>(ApiUrls.Roles(), request, "application/json");
        }

        /// <summary>
        /// Update <see cref="Role"/>'s.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="Role"/>s.</returns>
        public Task<string> Update(RoleRequest role)
        {
            return ApiConnection.Put<string>(ApiUrls.Roles(),role);
        }

        /// <summary>
        /// Get <see cref="Role"/>'s.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="Role"/>s.</returns>
        public Task<RoleRequest> GetRole(string roleId)
        {
            Ensure.ArgumentNotNullOrEmptyString(roleId, "roleId");

            return ApiConnection.Get<RoleRequest>(ApiUrls.Role(roleId),null);
        }

        /// <summary>
        /// Delete <see cref="Role"/>'s.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="Role"/>s.</returns>
        public Task DeleteRole(string roleId)
        {
            Ensure.ArgumentNotNullOrEmptyString(roleId,"roleId");

            return ApiConnection.Delete(ApiUrls.Role(roleId));
        }

        /// <summary>
        /// Add a user to a role for a specific organization. <see cref="Role"/>'s.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
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
        /// Delete a user to a role for a specific organization.<see cref="Role"/>s.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="Role"/>s.</returns>
        public Task DeleteRoleMembership(List<Role> role)
        {
            return ApiConnection.Delete(ApiUrls.RoleMembership(),role, "application/json");
        }
    }
}
