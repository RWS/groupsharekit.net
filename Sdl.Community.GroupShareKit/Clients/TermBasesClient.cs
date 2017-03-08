using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Exceptions;
using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Http;
using Sdl.Community.GroupShareKit.Models.Response;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class TermBasesClient : ApiClient, ITermBases
    {
        public TermBasesClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        /// <summary>
        /// Gets  <see cref="Termbase"/>s.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> <see cref="Termbase"/></returns>
        public async Task<Termbase> GetTermbases()
        {
            return await ApiConnection.Get<Termbase>(ApiUrls.GetTermbases(), null);
        }
    }
}
