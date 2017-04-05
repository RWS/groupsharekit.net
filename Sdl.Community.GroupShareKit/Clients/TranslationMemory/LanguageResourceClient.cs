using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Exceptions;
using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Http;
using Sdl.Community.GroupShareKit.Models.Response;
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
        /// <returns>  A list of <see cref="Resource"/></returns>
        public async Task<IReadOnlyList<Resource>> GetLanguageResourcesForTemplate(string templateId)
        {
            Ensure.ArgumentNotNullOrEmptyString(templateId,"templateId");
            return await ApiConnection.GetAll<Resource>(ApiUrls.LanguageResource(templateId), null);
        }


        /// <summary>
        /// Creates a  language resources <see cref="Resource"/> for specified template.
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
        public async Task<string> CreateLanguageResourceForTemplate(string templateId, Resource request)
        {
            Ensure.ArgumentNotNullOrEmptyString(templateId,"templateId");
            Ensure.ArgumentNotNull(request,"request");
            var encodeData = Convert.ToBase64String(Encoding.UTF8.GetBytes(request.Data));
            request.Data = encodeData;
            var resourceUrl =
                await ApiConnection.Post<string>(ApiUrls.LanguageResource(templateId), request, "application/json");

            return resourceUrl.Split('/').Last();
        }

        /// <summary>
        /// Gets language resource service defaults type.
        /// </summary>
        /// <remarks>
        /// <param name="defaultsRequest"><see cref="ResourceServiceDefaultsRequest"/></param>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> Resource <see cref="ResourceServiceDefaultsRequest"/></returns>
        public async Task<Resource> GetDefaultsType(ResourceServiceDefaultsRequest defaultsRequest)
        {
            Ensure.ArgumentNotNull(defaultsRequest,"request");

            return
                await
                    ApiConnection.Get<Resource>(
                        ApiUrls.GetDefaults(
                            Enum.GetName(typeof (ResourceServiceDefaultsRequest.ResourceType), defaultsRequest.Type),
                            defaultsRequest.Language), null);
        }

        /// <summary>
        /// Gets   language resource <see cref="Resource"/> for specified template.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> <see cref="Resource"/></returns>
        public async Task<Resource> GetLanguageResourceForTemplate(string templateId, string languageResourceId)
        {
            Ensure.ArgumentNotNullOrEmptyString(templateId,"templateId");
            Ensure.ArgumentNotNullOrEmptyString(languageResourceId, "languageResourceId");

            return
                await
                    ApiConnection.Get<Resource>(ApiUrls.LanguageResourcesForTemplate(templateId, languageResourceId),
                        null);

        }
        /// <summary>
        /// Deletes   language resource <see cref="Resource"/> for specified template.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        public async Task DeleteLanguageResourceForTemplate(string templateId, string languageResourceId)
        {
            Ensure.ArgumentNotNullOrEmptyString(templateId, "templateId");
            Ensure.ArgumentNotNullOrEmptyString(languageResourceId, "languageResourceId");

            await ApiConnection.Delete(ApiUrls.LanguageResourcesForTemplate(templateId, languageResourceId));
        }

        /// <summary>
        /// Updates   language resource <see cref="Resource"/> for specified template.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        public async Task UpdateLanguageResourceForTemplate(string templateId, string languageResourceId, Resource resourceRequest)
        {
            Ensure.ArgumentNotNullOrEmptyString(templateId, "templateId");
            Ensure.ArgumentNotNullOrEmptyString(languageResourceId, "languageResourceId");
            Ensure.ArgumentNotNull(resourceRequest,"resourceRequest");

            var encodeData = Convert.ToBase64String(Encoding.UTF8.GetBytes(resourceRequest.Data));
            resourceRequest.Data = encodeData;
       
                await
                    ApiConnection.Put<string>(ApiUrls.LanguageResourcesForTemplate(templateId, languageResourceId),
                        resourceRequest);
        }

        /// <summary>
        ///Reset to default Culture values a specific Language Resource in a specific Language Resource Template
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        public async Task ResetToDefaultLanguageResource(string templateId, string languageResourceId)
        {
            Ensure.ArgumentNotNullOrEmptyString(templateId, "templateId");
            Ensure.ArgumentNotNullOrEmptyString(languageResourceId, "languageResourceId");

            await ApiConnection.Put<string>(ApiUrls.LanguageResourceActions(templateId, languageResourceId, "reset"), templateId);
        }

        /// <summary>
        /// Imports a file with data for a specific Language Resource Template 
        /// Document type be text (.txt)
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        public async Task ImportFileForLanguageResource(string templateId, string languageResourceId, byte[] file)
        {
            Ensure.ArgumentNotNullOrEmptyString(templateId, "templateId");
            Ensure.ArgumentNotNullOrEmptyString(languageResourceId, "languageResourceId");
            Ensure.ArgumentNotNull(file,"fileData");

            var byteContent = new ByteArrayContent(file);
            byteContent.Headers.Add("Content-Type", "application/json");
            var multipartContent = new MultipartFormDataContent
            {
                {byteContent,"file"}
            };

            await
                ApiConnection.Post<string>(ApiUrls.LanguageResourceActions(templateId, languageResourceId, "import"),
                    multipartContent);
        }
        /// <summary>
        /// Exports a file with data for a specific Language Resource Template 
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>byte[] that represents the document content</returns>
        public async Task<byte[]> ExportFileForLanguageResource(string templateId, string languageResourceId)
        {
            Ensure.ArgumentNotNullOrEmptyString(templateId, "templateId");
            Ensure.ArgumentNotNullOrEmptyString(languageResourceId, "languageResourceId");
            var document=
                await
                    ApiConnection.Get<string>(
                        ApiUrls.LanguageResourceActions(templateId, languageResourceId, "export"), null);
            return Encoding.UTF8.GetBytes(document);
        }
    }
}
