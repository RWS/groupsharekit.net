using Sdl.Community.GroupShareKit.Exceptions;
using Sdl.Community.GroupShareKit.Models.Response;
using System;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Clients
{
    /// <summary>
    /// A client for GroupShare's User API.
    /// </summary>
    /// <remarks>
    /// </remarks>
    public interface IUserClient
    {
        /// <summary>
        /// Gets all <see cref="User"/>s.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="User"/>s.</returns>
        Task<UserResponse> GetAllUsers(UsersRequest usersRequest);

        /// <summary>
        /// Gets a <see cref="User"/>.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A <see cref="User"/>.</returns>
        Task<User> Get(UserRequest request);

        /// <summary>
        /// Gets a <see cref="User"/> by Guid.
        /// </summary>
        /// <param name="userId">User Guid</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A <see cref="User"/>.</returns>
        Task<User> GetUser(Guid userId);

        /// <summary>
        /// Updates a <see cref="User"/>.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <param name="user"><see cref="User"/></param>
        /// <returns>The user's Guid.</returns>
        Task<Guid> UpdateUser(User user);

        /// <summary>
        /// Deletes a <see cref="User"/>.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <param name="userId">User Guid</param>
        Task DeleteUser(Guid userId);

        /// <summary>
        /// Creates a <see cref="User"/>.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <param name="user">User details</param>
        /// <returns>The user's Guid.</returns>
        Task<Guid> CreateUser(CreateUserRequest user);
    }
}