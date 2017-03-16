using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Exceptions;
using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Http;
using Sdl.Community.GroupShareKit.Models.Response.TranslationMemory;

namespace Sdl.Community.GroupShareKit.Clients.TranslationMemory
{
    public class LanguageResourceClient:ApiClient, ILanguageResource
    {
        public LanguageResourceClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        /// <summary>
        /// Gets all language resources  <see cref="Models.Response.TranslationMemory.Resource"/> for a template.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>  A list of <see cref="Models.Response.TranslationMemory.Resource"/></returns>
        public async Task<IReadOnlyList<Models.Response.TranslationMemory.Resource>> GetLanguageResourcesForTemplate(string templateId)
        {
            Ensure.ArgumentNotNullOrEmptyString(templateId,"templateId");
            return await ApiConnection.GetAll<Models.Response.TranslationMemory.Resource>(ApiUrls.LanguageResource(templateId), null);
        }

        //public Task<string> CreateLanguageResourceForTemplate(string templateId, Resource request)
        //{
        //    throw new NotImplementedException();
        //}

        /// <summary>
        /// Creates a  language resources <see cref="Models.Response.TranslationMemory.Resource"/> for specified template.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> Resource id</returns>
        public async Task<string> CreateLanguageResourceForTemplate(string templateId, Test request)
        {
            Ensure.ArgumentNotNullOrEmptyString(templateId,"templateId");
            Ensure.ArgumentNotNull(request,"test");

            var resourceUrl =
                await ApiConnection.Post<string>(ApiUrls.LanguageResource(templateId), request, "application/json");

            return resourceUrl.Split('/').Last();
        }
    }
}
