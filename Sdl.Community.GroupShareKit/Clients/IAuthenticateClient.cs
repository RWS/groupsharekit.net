using System.Collections.Generic;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Exceptions;
using Sdl.Community.GroupShareKit.Models.Response;

namespace Sdl.Community.GroupShareKit.Clients
{
    public interface IAuthenticateClient
    {
        /// <summary>
        /// Gets <see cref="Authorization"/> token required for all API requests.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="Authorization">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="ApiException"/>s.</returns>
        Task<Authorization> Post(IEnumerable<string> scopes);
    }
}