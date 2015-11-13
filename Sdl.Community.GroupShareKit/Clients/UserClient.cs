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
    /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">Management API documentation</a> for more details.
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
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="User"/>s.</returns>
        public Task<IReadOnlyList<User>> GetAllUsers()
        {
            return ApiConnection.GetAll<User>(ApiUrls.Users());
        }

        /// <summary>
        /// Get <see cref="User"/>.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
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
        /// Update <see cref="User"/>.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
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
    }
}