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
    public class LanguageResourceTemplateClient:ApiClient, ILanguageResourceTemplate
    {
        public LanguageResourceTemplateClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        /// <summary>
        /// Gets all language resource templates <see cref="LanguageResourceTemplate"/> .
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns><see cref="LanguageResourceTemplates"/> which contains a list of language resource templates </returns>
        public async Task<LanguageResourceTemplates> GetAllLanguageResourceTemplates()
        {
            return
                await
                    ApiConnection.Get<LanguageResourceTemplates>(ApiUrls.LanguageResourceServiceTemplates(), null);
        }

        /// <summary>
        /// Gets specified  language resource template <see cref="LanguageResourceTemplate"/> .
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns><see cref="LanguageResourceTemplate"/> </returns>
        public async Task<LanguageResourceTemplate> GetTemplateById(string templateId)
        {
            Ensure.ArgumentNotNullOrEmptyString(templateId,"templateId");
            return
                await
                    ApiConnection.Get<LanguageResourceTemplate>(ApiUrls.GetLanguageResourceTemplateById(templateId),
                        null);
        }
        /// <summary>
        /// Updates  language resource template <see cref="LanguageResourceTemplate"/> .
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// <param name="templateId">Template id</param>
        /// <param name="request"><see cref="FieldTemplateRequest"/>New values</param>
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns><see cref="LanguageResourceTemplate"/> </returns>
        public async Task EditTemplate(string templateId, FieldTemplateRequest request)
        {
            Ensure.ArgumentNotNullOrEmptyString(templateId,"templateId");
            Ensure.ArgumentNotNull(request,"request");
                await
                    ApiConnection.Put<string>(ApiUrls.GetLanguageResourceTemplateById(templateId),
                        request);
        }

        /// <summary>
        ///Creates a  language resource template <see cref="LanguageResourceTemplate"/> .
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> Created template id</returns>
        public async Task<string> CreateTemplate(LanguageResourceTemplate templateRequest)
        {
            Ensure.ArgumentNotNull(templateRequest,"templateRequest");
            foreach (var resource in templateRequest.LanguageResources)
            {
                var encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(resource.Data));
                resource.Data = encoded;
            }
           
            var responseUrl =
                await
                    ApiConnection.Post<string>(ApiUrls.LanguageResourceServiceTemplates(), templateRequest, "application/json");

            var id = responseUrl.Split('/').Last();
            return id;
        }

        /// <summary>
        ///Deletes a  language resource template <see cref="LanguageResourceTemplate"/> .
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        public async Task DeleteTemplate(string languageResourceTemplateId)
        {
            Ensure.ArgumentNotNullOrEmptyString(languageResourceTemplateId,"languageResourceTemplateId");
            await ApiConnection.Delete(ApiUrls.GetLanguageResourceTemplateById(languageResourceTemplateId));
        }
    }
}
