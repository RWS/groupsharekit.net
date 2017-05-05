using System.Collections.Generic;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Exceptions;
using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Http;
using Sdl.Community.GroupShareKit.Models.Response;

namespace Sdl.Community.GroupShareKit.Clients
{
    /// <summary>
    /// A client for GroupShare's Management API.
    /// </summary>
    /// <remarks>
    /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">Management API documentation</a> for more details.
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
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
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
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
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

        /// <summary>
        /// Get <see cref="User"/>.
        /// </summary>
        /// <remarks>
        /// <param name="userId">string</param>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A <see cref="User"/>.</returns>
        public Task<User> GetUserById(string userId)
        {
            Ensure.ArgumentNotNull(userId, "userId");

            return ApiConnection.Get<User>(ApiUrls.User(userId), null);
        }

        /// <summary>
        /// Update <see cref="User"/>.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A <see cref="User"/>.</returns>
        public Task<string> Update(User user)
        {
            return ApiConnection.Put<string>(ApiUrls.User(), user);
        }


        /// <summary>
        /// Delete <see cref="User"/>.
        /// </summary>
        /// /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        public Task Delete(string userId)
        {
            Ensure.ArgumentNotNullOrEmptyString(userId,"userId");

            return ApiConnection.Delete(ApiUrls.User(userId));
        }
        /// <summary>
        /// Create <see cref="User"/>.
        /// </summary>
        /// /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <param name="user"><see cref="CreateUserRequest"/></param>
        /// <returns>Created user Id</returns>
        public async Task<string> Create(CreateUserRequest user)
        {
            Ensure.ArgumentNotNull(user,"user");

            return await ApiConnection.Post<string>(ApiUrls.User(), user, "application/json");
        }
    }
}