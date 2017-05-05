using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Exceptions;
using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Http;
using Sdl.Community.GroupShareKit.Models.Response;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class AuthenticateClient: ApiClient, IAuthenticateClient
    {
        public AuthenticateClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        /// <summary>
        /// Gets <see cref="Authorization"/> token required for all API requests.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="Authorization">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="ApiException"/>s.</returns>
        public async Task<Authorization> Post(IEnumerable<string> scopes)
        {
            var token = await ApiConnection.Post<string>(ApiUrls.Login(), scopes, "application/json");

            var authorization = new Authorization()
            {
                UserName = ApiConnection.Connection.Credentials.Login,
                ExpirationDate = DateTimeOffset.UtcNow.Add(new TimeSpan(11, 59, 59)),
                Scopes = scopes.ToArray(),
                Token = token
            };

            return authorization;
        }
    }
}
