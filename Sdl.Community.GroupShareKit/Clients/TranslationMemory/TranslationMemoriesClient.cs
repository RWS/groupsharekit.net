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

        /// <summary>
        /// Gets specified tm<see cref="Models.Response.TranslationMemory.TranslationMemory"/>.
        /// </summary>
        /// <remarks>
        /// <param name="tmId">translation memory id</param>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>  <see cref="Models.Response.TranslationMemory.TranslationMemory"/></returns>
        public async Task<TranslationMemoryDetails> GetTmById(string tmId)
        {
            Ensure.ArgumentNotNullOrEmptyString(tmId, "tmId");
            return
                await
                    ApiConnection.Get<TranslationMemoryDetails>(ApiUrls.GetTmById(tmId), null);
        }
        /// <summary>
        /// Gets <see cref="LanguageDirection"/> for tm
        /// </summary>
        /// <remarks>
        /// <param name="tmId">translation memory id</param>
        /// <param name="languageDirectionId">language direction id</param>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>  <see cref="LanguageDirection"/></returns>
        public async Task<LanguageDirection> GetLanguageDirectionForTm(string tmId, string languageDirectionId)
        {
            Ensure.ArgumentNotNullOrEmptyString(tmId, "tmId");
            Ensure.ArgumentNotNullOrEmptyString(languageDirectionId, "languageDirectionId");
            return
                await
                    ApiConnection.Get<LanguageDirection>(ApiUrls.GetLanguageDirectionForTm(tmId,languageDirectionId), null);
        }

        /// <summary>
        /// Gets the  tms<see cref="Models.Response.TranslationMemory.TranslationMemory"/> number.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>  <see cref="Models.Response.TranslationMemory.TranslationMemory"/> number</returns>
        public async Task<int> GetTmsNumberByLanguageResourceTemplateId(string resourceTemplateId)
        {
            Ensure.ArgumentNotNullOrEmptyString(resourceTemplateId, "resourceTemplateId");
            return
                await
                    ApiConnection.Get<int>(ApiUrls.GetTmsNumberByLanguageResourceTemplateId(resourceTemplateId), null);
        }

        /// <summary>
        /// Gets the  tms<see cref="Models.Response.TranslationMemory.TranslationMemory"/> number.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>  <see cref="Models.Response.TranslationMemory.TranslationMemory"/> number</returns>
        public async Task<int> GetTmsNumberByFieldTemplateId(string fieldTemplateId)
        {
            Ensure.ArgumentNotNullOrEmptyString(fieldTemplateId, "fieldTemplateId");
            return
               await
                   ApiConnection.Get<int>(ApiUrls.GetTmsNumberByFieldTemplateId(fieldTemplateId), null);
        }

        /// <summary>
        /// Gets specified tm<see cref="TranslationMemoryDetails"/>.
        /// </summary>
        /// <remarks>
        /// <param name="tm">translation memory </param>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>  <see cref="TranslationMemoryDetails"/></returns>
        public async Task<string> Create(CreateTmRequest tm)
        {
            Ensure.ArgumentNotNull(tm,"Translation memory");
            return await ApiConnection.Post<string>(ApiUrls.GetTms(), tm, "application/json");
        }

        /// <summary>
        /// Deletes<see cref="Models.Response.TranslationMemory.TranslationMemory"/> .
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        public async Task Delete(string tmId)
        {
            Ensure.ArgumentNotNullOrEmptyString(tmId, "tmId");
            await ApiConnection.Delete(ApiUrls.GetTmById(tmId));
        }

        /// <summary>
        /// Updates<see cref="Models.Response.TranslationMemory.TranslationMemory"/> .
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        public async Task Update(string tmId, TranslationMemoryDetails tm)
        {
            Ensure.ArgumentNotNullOrEmptyString(tmId,"tmId");
            Ensure.ArgumentNotNull(tm,"tm");
            await ApiConnection.Put<string>(ApiUrls.GetTmById(tmId), tm);
        }

        /// <summary>
        /// Gets<see cref="Health"/> of tm service .
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>Returns the status of tm service</returns>
        public async Task<Health> Health()
        {
            return await ApiConnection.Get<Health>(ApiUrls.Health(), null);
        }
    }
}
