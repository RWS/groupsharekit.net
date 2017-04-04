using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Exceptions;
using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Http;
using Sdl.Community.GroupShareKit.Models.Response.TranslationMemory;
using Sdl.TmService.Sdk;

namespace Sdl.Community.GroupShareKit.Clients.TranslationMemory
{
    public class TranslationMemoriesClient: ApiClient,ITranslationMemoriesClient
    {
        public TranslationMemoriesClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        #region Translation memory methods
        /// <summary>
        /// Gets all tms.
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
            return await ApiConnection.Get<Models.Response.TranslationMemory.TranslationMemory>(ApiUrls.GetTms(), null);
        }

        /// <summary>
        /// Gets specified tm.
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
        /// Gets specified language direction for tm
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
                    ApiConnection.Get<LanguageDirection>(ApiUrls.GetLanguageDirectionForTm(tmId, languageDirectionId), null);
        }

        /// <summary>
        /// Gets the  tms number.
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
        /// Gets the  tms number by field template id.
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
        /// Before you create a TM please make sure you HAVE CREATED A TEMPLATE FIELD and a LANGUAGE RESOURCE TEMPLATE
        /// USE thoes id in the create request 
        /// Creates a Translation Memory/>.
        /// </summary>
        /// <remarks>
        /// <param name="tm">translation memory request <see cref="CreateTmRequest"/> </param>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>  Translation memory Id</returns>
        public async Task<string> CreateTm(CreateTmRequest tm)
        {
            Ensure.ArgumentNotNull(tm, "Translation memory");
            return await ApiConnection.Post<string>(ApiUrls.GetTms(), tm, "application/json");
        }

        /// <summary>
        /// Deletes specified tm .
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        public async Task DeleteTm(string tmId)
        {
            Ensure.ArgumentNotNullOrEmptyString(tmId, "tmId");
            await ApiConnection.Delete(ApiUrls.GetTmById(tmId));
        }

        /// <summary>
        /// Updates specified tm .
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
            Ensure.ArgumentNotNullOrEmptyString(tmId, "tmId");
            Ensure.ArgumentNotNull(tm, "tm");
            await ApiConnection.Put<string>(ApiUrls.GetTmById(tmId), tm);
        }

        /// <summary>
        /// Gets the status  of tm service .
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

        /// <summary>
        /// Schedules a recompute statistics operation
        /// <param name="request"><see cref="FuzzyRequest"/></param>
        /// <param name="tmId">Translation memory id</param>
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns><see cref="FuzzyIndexResponse"/></returns>
        public async Task<FuzzyIndexResponse> RecomputeStatistics(string tmId, FuzzyRequest request)
        {
            Ensure.ArgumentNotNullOrEmptyString(tmId, "tmId");
            Ensure.ArgumentNotNull(request, "request");

            return await ApiConnection.Post<FuzzyIndexResponse>(ApiUrls.Fuzzy(tmId, "recomputestatistics"), request, "application/json");
        }

        /// <summary>
        /// Schedules a reindex operation
        /// <param name="request"><see cref="FuzzyRequest"/></param>
        /// <param name="tmId">Translation memory id</param>
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns><see cref="FuzzyIndexResponse"/></returns>
        public async Task<FuzzyIndexResponse> Reindex(string tmId, FuzzyRequest request)
        {
            Ensure.ArgumentNotNullOrEmptyString(tmId, "tmId");
            Ensure.ArgumentNotNull(request, "request");

            return await ApiConnection.Post<FuzzyIndexResponse>(ApiUrls.Fuzzy(tmId, "reindex"), request, "application/json");
        }

        /// <summary>
        /// Exports TUs from a Translation Memory
        /// <param name="request"><see cref="ExportRequest"/></param>
        /// <param name="tmId">Translation memory id</param>
        /// <param name="language"><see cref="LanguageParameters"/></param>
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns><see cref="ExportResponse"/></returns>
        public async Task<ExportResponse> ExportTm(string tmId, ExportRequest request, LanguageParameters language)
        {
            Ensure.ArgumentNotNullOrEmptyString(tmId, "tm is");
            Ensure.ArgumentNotNull(request, "request");
            Ensure.ArgumentNotNull(language, "language parameters");

            return
                await
                    ApiConnection.Post<ExportResponse>(ApiUrls.Export(tmId, language.Source, language.Target), request,
                        "application/json");
        }
        /// <summary>
        /// Imports TUs into a Translation Memory
        /// The file should be a TMX type.
        /// <param name="tmId">Translation memory id</param>
        /// <param name="language"><see cref="LanguageParameters"/></param>
        /// <param name="rawFile">byte[] which represents the file</param>
        /// <param name="fileName">file name</param>
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns><see cref="ImportResponse"/></returns>
        public async Task<ImportResponse> ImportTm(string tmId, LanguageParameters language, byte[] rawFile, string fileName)
        {
            Ensure.ArgumentNotNullOrEmptyString(tmId, "tm id");
            Ensure.ArgumentNotNull(language, "language parameters");
            Ensure.ArgumentNotNull(rawFile, "file");
            Ensure.ArgumentNotNullOrEmptyString(fileName, "file name");

            var byteContent = new ByteArrayContent(rawFile);
            byteContent.Headers.Add("Content-Type", "application/json");
            var multipartContent = new MultipartFormDataContent
            {
                {byteContent,"file",fileName}
            };

            return
                await
                    ApiConnection.Post<ImportResponse>(ApiUrls.Import(tmId, language.Source, language.Target),
                        multipartContent, "application/json");
        }
        #endregion

        #region Translation unit methods
        /// Confirmation levels possible values: Unspecified, Draft, Translated, RejectedTranslation
        /// ApprovedTranslation,RejectedSignOff,ApprovedSignOff
        public async Task<TranslationUnitResponse> AddCustomTranslationUnit(TranslationUnitRequest unitRequest, string tmId)
        {
            Ensure.ArgumentNotNull(unitRequest, "translation unit request");
            Ensure.ArgumentNotNullOrEmptyString(tmId, "translation memory id");
            return
                await
                    ApiConnection.Post<TranslationUnitResponse>(ApiUrls.TranslationUnits(tmId, "text"), unitRequest,
                        "application/json");
        }

        /// <summary>
        /// Updates a custom translation units to a specified TM .
        /// Please make sure the fields values you add corresponds  to the TM
        /// To find the right values look at "fieldTemplateId" corresponding to the TM -> "fields" (take the fieldName), 
        /// from "values", "name" values should be added to a list 
        /// Confirmation levels possible values: Unspecified, Draft, Translated, RejectedTranslation
        /// ApprovedTranslation,RejectedSignOff,ApprovedSignOff
        /// <param name="unitRequest"><see cref="TranslationUnitRequest"/></param>
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns><see cref="TranslationUnitResponse"/></returns>
        public async Task<TranslationUnitResponse> UpdateCustomTranslationUnit(TranslationUnitRequest unitRequest, string tmId)
        {
            Ensure.ArgumentNotNull(unitRequest, "translation unit request");
            Ensure.ArgumentNotNullOrEmptyString(tmId, "tmId");

            return await ApiConnection.Put<TranslationUnitResponse>(ApiUrls.TranslationUnits(tmId, "text"), unitRequest);
        }


        /// <summary>
        /// Add all  translation units from a field template to a specified TM .
        /// Confirmation levels possible values: Unspecified, Draft, Translated, RejectedTranslation
        /// ApprovedTranslation,RejectedSignOff,ApprovedSignOff
        /// <param name="unitRequest"><see cref="TranslationUnitRequest"/></param>
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns><see cref="TranslationUnitResponse"/></returns>
        public async Task<TranslationUnitResponse> AddAllTranslationUnits(TranslationUnitRequest unitRequest,
            string tmId, FieldTemplate fieldTemplate)
        {
            Ensure.ArgumentNotNull(unitRequest, "translation unit request");
            Ensure.ArgumentNotNullOrEmptyString(tmId, "translation memory id");
            Ensure.ArgumentNotNull(fieldTemplate, "field template");

            var fieldValues = new List<FieldValue>();
            foreach (var template in fieldTemplate.Fields)
            {
                var field = new FieldValue { FieldName = template.Name };
                var fieldValue = template.Values.Select(t => t.Name).ToList();
                if (fieldValue.Count > 0)
                {
                    field.Values = fieldValue;
                }
                fieldValues.Add(field);
            }
            unitRequest.Settings.FieldValues = fieldValues;

            return
                await
                    ApiConnection.Post<TranslationUnitResponse>(ApiUrls.TranslationUnits(tmId, "text"), unitRequest,
                        "application/json");
        }

        /// <summary>
        /// Gets specified translation unit for TM
        /// <param name="request"><see cref="TranslationUnitDetailsRequest"/></param>
        /// <param name="tmId">Translation memory id</param>
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns><see cref="TranslationUnitDetailsResponse"/></returns>
        public async Task<TranslationUnitDetailsResponse> GetTranslationUnitForTm(string tmId, TranslationUnitDetailsRequest request)
        {
            Ensure.ArgumentNotNull(request, "translation request params");
            Ensure.ArgumentNotNullOrEmptyString(tmId, "translation memory id");

            return
                await ApiConnection.Get<TranslationUnitDetailsResponse>(ApiUrls.Tus(tmId), request.ToParametersDictionary());
        }

        /// <summary>
        /// Gets the translation units number from the translation memory
        /// <param name="language"><see cref="LanguageParameters"/></param>
        /// <param name="tmId">Translation memory id</param>
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>int</returns>
        public async Task<int> GetNumberOfTus(string tmId, LanguageParameters language)
        {
            Ensure.ArgumentNotNullOrEmptyString(tmId, "translation memory id");
            Ensure.ArgumentNotNull(language, "language parameters request");

            return await ApiConnection.Get<int>(ApiUrls.TusCount(tmId), language.ToParametersDictionary());
        }

        /// <summary>
        /// Gets the postdated translation units count from the translation memory
        /// <param name="language"><see cref="LanguageParameters"/></param>
        /// <param name="tmId">Translation memory id</param>
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>int</returns>
        public async Task<int> GetNumberOfPostDatedTus(string tmId, LanguageParameters language)
        {
            Ensure.ArgumentNotNullOrEmptyString(tmId, "translation memory id");
            Ensure.ArgumentNotNull(language, "language parameters request");

            return await ApiConnection.Get<int>(ApiUrls.TusByType(tmId, "postdated"), language.ToParametersDictionary());
        }

        /// <summary>
        /// Gets the predated translation units count from the translation memory
        /// <param name="language"><see cref="LanguageParameters"/></param>
        /// <param name="tmId">Translation memory id</param>
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>int</returns>
        public async Task<int> GetNumberOfPreDatedTus(string tmId, LanguageParameters language)
        {
            Ensure.ArgumentNotNullOrEmptyString(tmId, "translation memory id");
            Ensure.ArgumentNotNull(language, "language parameters request");

            return await ApiConnection.Get<int>(ApiUrls.TusByType(tmId, "predated"), language.ToParametersDictionary());
        }

        /// <summary>
        /// Gets the unaligned translation units count from the translation memory
        /// <param name="language"><see cref="LanguageParameters"/></param>
        /// <param name="tmId">Translation memory id</param>
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>int</returns>
        public async Task<int> GetNumberOfUnalignedTus(string tmId, LanguageParameters language)
        {
            Ensure.ArgumentNotNullOrEmptyString(tmId, "translation memory id");
            Ensure.ArgumentNotNull(language, "language parameters request");

            return await ApiConnection.Get<int>(ApiUrls.TusByType(tmId, "unaligned"), language.ToParametersDictionary());
        }

        /// <summary>
        /// Retrieves the Duplicate Translation Units in a specific TM
        /// <param name="language"><see cref="LanguageParameters"/></param>
        /// <param name="tmId">Translation memory id</param>
        /// <param name="duplicatesRequest"><see cref="DuplicatesTusRequest"/></param>
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns><see cref="TranslationUnitDetailsResponse"/></returns>
        public async Task<TranslationUnitDetailsResponse> GetDuplicateTusForTm(string tmId, LanguageParameters language, DuplicatesTusRequest duplicatesRequest)
        {
            Ensure.ArgumentNotNullOrEmptyString(tmId, "translation memory id");
            Ensure.ArgumentNotNull(language, "language parameters request");
            Ensure.ArgumentNotNull(duplicatesRequest, "duplicates request");

            return
                await
                    ApiConnection.Post<TranslationUnitDetailsResponse>(ApiUrls.TranslationUnitsDuplicates(tmId, language.Source, language.Target),
                        duplicatesRequest);

        }
        #endregion

        #region Container methods
        private TmServiceRestClient _client;

        /// <summary>
        ///Returns a list of all available containers
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        ///<returns><see cref="ContainerResponse"/></returns>
        public async Task<ContainerResponse> GetContainers()
        {
            return await ApiConnection.Get<ContainerResponse>(ApiUrls.Containers(), null);
        }

        /// <summary>
        ///creates a new container
        /// </summary>
        /// <remarks>
        /// <param name="request"><see cref="ContainerRequest"/></param>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        ///<returns>Container's Id</returns>
        public async Task<string> CreateContainer(ContainerRequest request)
        {
            Ensure.ArgumentNotNull(request, "container request");

            return await ApiConnection.Post<string>(ApiUrls.Containers(), request, "application/json");
        }

        /// <summary>
        ///Returns a specified container
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        ///<returns><see cref="Container"/></returns>
        public async Task<Container> GetContainerById(string containerId)
        {
            Ensure.ArgumentNotNullOrEmptyString(containerId, "container id");
            //var test = ApiConnection.Connection.Credentials.
            ////var groupSharePassword = Environment.GetEnvironmentVariable("GROUPSHAREKIT_PASSWORD");
            //_client = new TmServiceRestClient();
            return await ApiConnection.Get<Container>(ApiUrls.Containers(containerId), null);
        }

        /// <summary>
        ///Deletes  specified container
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        public async Task DeleteContainer(string containerId)
        {
            Ensure.ArgumentNotNullOrEmptyString(containerId, "container id");
            await ApiConnection.Delete(ApiUrls.Containers(containerId));
        }

        /// <summary>
        ///Updates  specified container
        /// </summary>
        /// <remarks>
        /// <param name="request"><see cref="UpdateContainerRequest"/></param>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        public async Task UpdateContainer(string containerId, UpdateContainerRequest request)
        {
            Ensure.ArgumentNotNullOrEmptyString(containerId, "container id");
            Ensure.ArgumentNotNull(request, "request");

            await ApiConnection.Put<string>(ApiUrls.Containers(containerId), request);
        }
        #endregion

    }
}
