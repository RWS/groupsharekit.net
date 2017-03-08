using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Exceptions;
using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Http;

namespace Sdl.Community.GroupShareKit.Clients.TranslationMemory
{
    public class TranslationMemoriesClient: ApiClient,ITranslationMemoriesClient
    {
        public TranslationMemoriesClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }
        /// <summary>
        /// Gets all tms<see cref="Models.Response.TranslationMemory.TranslationMemory"/>.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>  <see cref="Models.Response.TranslationMemory.TranslationMemory"/></returns>
        public async Task<Models.Response.TranslationMemory.TranslationMemory> GetTms()
        {
            return await ApiConnection.Get<Models.Response.TranslationMemory.TranslationMemory>(ApiUrls.GetTms(),null);
        }

       
    }
}
