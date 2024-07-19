using Sdl.Community.GroupShareKit.Exceptions;
using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Http;
using Sdl.Community.GroupShareKit.Models.Response;
using System;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Clients
{
    /// <summary>
    /// A client for GroupShare's Management API.
    /// </summary>
    /// <remarks>
    /// </remarks>
    public class UserClient : ApiClient, IUserClient
    {
        public UserClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

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
        public Task<UserResponse> GetAllUsers(UsersRequest usersRequest)
        {
            return ApiConnection.Get<UserResponse>(ApiUrls.User(), usersRequest.ToParametersDictionary());
        }

        /// <summary>
        /// Get <see cref="User"/>.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A <see cref="User"/>.</returns>
        public Task<User> Get(UserRequest request)
        {
            Ensure.ArgumentNotNull(request, "request");

            return ApiConnection.Get<User>(ApiUrls.User(), request.ToParametersDictionary());
        }

        [Obsolete("This method is obsolete. Call 'GetUser(Guid)' instead.")]
        public Task<User> GetUserById(string userId)
        {
            Ensure.ArgumentNotNull(userId, "userId");

            return ApiConnection.Get<User>(ApiUrls.User(userId), null);
        }

        /// <summary>
        /// Gets a <see cref="User"/> by Id.
        /// </summary>
        /// <remarks>
        /// <param name="userId">string</param>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A <see cref="User"/>.</returns>
        public Task<User> GetUser(Guid userId)
        {
            Ensure.ArgumentNotNull(userId, "userId");

            return ApiConnection.Get<User>(ApiUrls.User(userId), null);
        }

        [Obsolete("This method is obsolete. Call 'UpdateUser(User)' instead.")]
        public Task<string> Update(User user)
        {
            return ApiConnection.Put<string>(ApiUrls.User(), user);
        }

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
        /// <returns>The user's Guid.</returns>
        public Task<Guid> UpdateUser(User user)
        {
            return ApiConnection.Put<Guid>(ApiUrls.User(), user);
        }

        [Obsolete("This method is obsolete. Call 'DeleteUser(Guid)' instead.")]
        public Task Delete(string userId)
        {
            Ensure.ArgumentNotNullOrEmptyString(userId, "userId");

            return ApiConnection.Delete(ApiUrls.User(userId));
        }

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
        public Task DeleteUser(Guid userId)
        {
            Ensure.ArgumentNotNull(userId, "userId");

            return ApiConnection.Delete(ApiUrls.User(userId));
        }

        [Obsolete("This method is obsolete. Call 'CreateUser(CreateUserRequest)' instead.")]
        public async Task<string> Create(CreateUserRequest user)
        {
            Ensure.ArgumentNotNull(user, "user");

            return await ApiConnection.Post<string>(ApiUrls.User(), user, "application/json");
        }

        //// <summary>
        /// Creates a <see cref="User"/>.
        /// </summary>
        /// /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <param name="user"><see cref="CreateUserRequest"/></param>
        /// <returns>Created user Id</returns>
        public async Task<Guid> CreateUser(CreateUserRequest user)
        {
            Ensure.ArgumentNotNull(user, "user");

            return await ApiConnection.Post<Guid>(ApiUrls.User(), user, "application/json");
        }
    }
}