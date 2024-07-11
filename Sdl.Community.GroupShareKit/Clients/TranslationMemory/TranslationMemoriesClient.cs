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
using Sdl.TmService.Sdk;
using Sdl.TmService.Sdk.Model;
using FilterResponse = Sdl.Community.GroupShareKit.Models.Response.TranslationMemory.FilterResponse;
using Sdl.TmService.Sdk.Model.Search.Settings;
using Sdl.TmService.Sdk.Model.Search;
using Newtonsoft.Json;
using BackgroundTask = Sdl.Community.GroupShareKit.Models.Response.TranslationMemory.BackgroundTask;

namespace Sdl.Community.GroupShareKit.Clients.TranslationMemory
{
    public class TranslationMemoriesClient : ApiClient, ITranslationMemoriesClient
    {
        private readonly TmServiceRestClient _client;
        public TranslationMemoriesClient(IApiConnection apiConnection) : base(apiConnection)
        {
            var userName = ApiConnection.Connection.Credentials.Login;
            var password = ApiConnection.Connection.Credentials.Password;
            _client = new TmServiceRestClient(ApiConnection.Connection.BaseAddress, userName, password, ServiceLocation.OnPremise);
        }

        #region Translation memory methods
        /// <summary>
        /// Gets all tms.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
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

        [Obsolete("This method is obsolete. Call 'GetTranslationMemory(Guid)' instead.")]
        public async Task<TranslationMemoryDetails> GetTmById(string tmId)
        {
            Ensure.ArgumentNotNullOrEmptyString(tmId, "tmId");
            return await ApiConnection.Get<TranslationMemoryDetails>(ApiUrls.GetTmById(tmId), null);
        }

        /// <summary>
        /// Gets a <see cref="Models.Response.TranslationMemory.TranslationMemory"/> by Guid.
        /// </summary>
        /// <param name="translationMemoryId">Translation memory Guid</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A <see cref="Models.Response.TranslationMemory.TranslationMemory"/>.</returns>
        public async Task<TranslationMemoryDetails> GetTranslationMemory(Guid translationMemoryId)
        {
            Ensure.ArgumentNotNull(translationMemoryId, "translationMemoryId");
            return await ApiConnection.Get<TranslationMemoryDetails>(ApiUrls.GetTranslationMemory(translationMemoryId), null);
        }

        [Obsolete("This method is obsolete. Call 'GetTmLanguageDirection(Guid, Guid)' instead.")]
        public async Task<LanguageDirection> GetLanguageDirectionForTm(string tmId, string languageDirectionId)
        {
            Ensure.ArgumentNotNullOrEmptyString(tmId, "tmId");
            Ensure.ArgumentNotNullOrEmptyString(languageDirectionId, "languageDirectionId");

            return await ApiConnection.Get<LanguageDirection>(ApiUrls.GetLanguageDirectionForTm(tmId, languageDirectionId), null);
        }

        /// <summary>
        /// Gets TM <see cref="LanguageDirection"/> by Guid.
        /// </summary>
        /// <param name="tmId">Translation memory Guid</param>
        /// <param name="languageDirectionId">Language direction Guid</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A <see cref="LanguageDirection"/>.</returns>
        public async Task<LanguageDirection> GetTmLanguageDirection(Guid tmId, Guid languageDirectionId)
        {
            Ensure.ArgumentNotNull(tmId, "tmId");
            Ensure.ArgumentNotNull(languageDirectionId, "languageDirectionId");

            return await ApiConnection.Get<LanguageDirection>(ApiUrls.GetTmLanguageDirection(tmId, languageDirectionId), null);
        }

        [Obsolete("This method is obsolete. Call 'GetTmsNumberByLanguageResourceTemplateId(Guid)' instead.")]
        public async Task<int> GetTmsNumberByLanguageResourceTemplateId(string resourceTemplateId)
        {
            Ensure.ArgumentNotNullOrEmptyString(resourceTemplateId, "resourceTemplateId");
            return await ApiConnection.Get<int>(ApiUrls.GetTmsNumberByLanguageResourceTemplateId(resourceTemplateId), null);
        }

        /// <summary>
        /// Gets the translation memories number by language resource template Id.
        /// </summary>
        /// <param name="languageResourceTemplateId">Language resource template Guid</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>Translation memories number.</returns>
        public async Task<int> GetTmsNumberByLanguageResourceTemplateId(Guid languageResourceTemplateId)
        {
            Ensure.ArgumentNotNull(languageResourceTemplateId, "languageResourceTemplateId");
            return await ApiConnection.Get<int>(ApiUrls.GetTmsNumberByLanguageResourceTemplateId(languageResourceTemplateId), null);
        }

        [Obsolete("This method is obsolete. Call 'GetTmsNumberByFieldTemplateId(Guid)' instead.")]
        public async Task<int> GetTmsNumberByFieldTemplateId(string fieldTemplateId)
        {
            Ensure.ArgumentNotNullOrEmptyString(fieldTemplateId, "fieldTemplateId");
            return await ApiConnection.Get<int>(ApiUrls.GetTmsNumberByFieldTemplateId(fieldTemplateId), null);
        }

        /// <summary>
        /// Gets the translation memories number by field template Id.
        /// </summary>
        /// <param name="fieldTemplateId">Field template Guid</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>Translation memories number.</returns>
        public async Task<int> GetTmsNumberByFieldTemplateId(Guid fieldTemplateId)
        {
            Ensure.ArgumentNotNull(fieldTemplateId, "fieldTemplateId");
            return await ApiConnection.Get<int>(ApiUrls.GetTmsNumberByFieldTemplateId(fieldTemplateId), null);
        }

        [Obsolete("This method is obsolete. Call 'CreateTranslationMemory(CreateTranslationMemoryRequest)' instead.")]
        public async Task<string> CreateTm(CreateTmRequest tm)
        {
            Ensure.ArgumentNotNull(tm, "Translation memory");
            return await ApiConnection.Post<string>(ApiUrls.GetTms(), tm, "application/json").ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a <see cref="Models.Response.TranslationMemory.TranslationMemory"/>.
        /// </summary>
        /// <param name="request">Translation memory details</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>The translation memory Guid.</returns>
        public async Task<Guid> CreateTranslationMemory(CreateTranslationMemoryRequest request)
        {
            Ensure.ArgumentNotNull(request, "request");
            return await ApiConnection.Post<Guid>(ApiUrls.GetTms(), request, "application/json");
        }

        [Obsolete("This method is obsolete. Call 'DeleteTranslationMemory(Guid)' instead.")]
        public async Task DeleteTm(string tmId)
        {
            Ensure.ArgumentNotNullOrEmptyString(tmId, "tmId");
            await ApiConnection.Delete(ApiUrls.GetTmById(tmId));
        }

        /// <summary>
        /// Deletes a <see cref="Models.Response.TranslationMemory.TranslationMemory"/>.
        /// </summary>
        /// <param name="translationMemoryId">Translation memory Guid.</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        public async Task DeleteTranslationMemory(Guid translationMemoryId)
        {
            Ensure.ArgumentNotNull(translationMemoryId, "translationMemoryId");
            await ApiConnection.Delete(ApiUrls.GetTranslationMemory(translationMemoryId));
        }

        [Obsolete("This method is obsolete. Call 'Update(Guid, TranslationMemoryDetails)' instead.")]
        public async Task Update(string tmId, TranslationMemoryDetails tm)
        {
            Ensure.ArgumentNotNullOrEmptyString(tmId, "tmId");
            Ensure.ArgumentNotNull(tm, "tm");
            await ApiConnection.Put<string>(ApiUrls.GetTmById(tmId), tm);
        }

        /// <summary>
        /// Updates a <see cref="Models.Response.TranslationMemory.TranslationMemory"/>.
        /// </summary>
        /// <param name="tmId">Translation memory Guid</param>
        /// <param name="tmDetails">Translation memory details</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        public async Task UpdateTranslationMemory(Guid tmId, TranslationMemoryDetails tmDetails)
        {
            Ensure.ArgumentNotNull(tmId, "tmId");
            Ensure.ArgumentNotNull(tmDetails, "tmDetails");
            await ApiConnection.Put<string>(ApiUrls.GetTranslationMemory(tmId), tmDetails);
        }

        /// <summary>
        /// Gets the status of TM Service
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
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

        [Obsolete("This method is obsolete. Call 'RecomputeStatistics(Guid, FuzzyRequest)' instead.")]
        public async Task<FuzzyIndexResponse> RecomputeStatistics(string tmId, FuzzyRequest request)
        {
            Ensure.ArgumentNotNullOrEmptyString(tmId, "tmId");
            Ensure.ArgumentNotNull(request, "request");

            return await ApiConnection.Post<FuzzyIndexResponse>(ApiUrls.Fuzzy(tmId, "recomputestatistics"), request, "application/json");
        }

        /// <summary>
        /// Schedules a recompute statistics operation.
        /// </summary>
        /// <param name="tmId">Translation memory Guid</param>
        /// <param name="request"><see cref="FuzzyRequest"/></param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns><see cref="FuzzyIndexResponse"/></returns>
        public async Task<FuzzyIndexResponse> RecomputeStatistics(Guid tmId, FuzzyRequest request)
        {
            Ensure.ArgumentNotNull(tmId, "tmId");
            Ensure.ArgumentNotNull(request, "request");

            return await ApiConnection.Post<FuzzyIndexResponse>(ApiUrls.Fuzzy(tmId, "recomputestatistics"), request, "application/json");
        }

        [Obsolete("This method is obsolete. Call 'Reindex(Guid, FuzzyRequest)' instead.")]
        public async Task<FuzzyIndexResponse> Reindex(string tmId, FuzzyRequest request)
        {
            Ensure.ArgumentNotNullOrEmptyString(tmId, "tmId");
            Ensure.ArgumentNotNull(request, "request");

            return await ApiConnection.Post<FuzzyIndexResponse>(ApiUrls.Fuzzy(tmId, "reindex"), request, "application/json");
        }

        /// <summary>
        /// Schedules a reindex operation.
        /// </summary>
        /// <param name="tmId">Translation memory Guid</param>
        /// <param name="request"><see cref="FuzzyRequest"/></param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns><see cref="FuzzyIndexResponse"/></returns>
        public async Task<FuzzyIndexResponse> Reindex(Guid tmId, FuzzyRequest request)
        {
            Ensure.ArgumentNotNull(tmId, "tmId");
            Ensure.ArgumentNotNull(request, "request");

            return await ApiConnection.Post<FuzzyIndexResponse>(ApiUrls.Fuzzy(tmId, "reindex"), request, "application/json");
        }

        [Obsolete("This method is obsolete. Call 'ExportTm(Guid, ExportRequest, LanguageParameters)' instead.")]
        public async Task<byte[]> ExportTm(string tmId, ExportRequest request, LanguageParameters language)
        {
            Ensure.ArgumentNotNullOrEmptyString(tmId, "tmId");
            Ensure.ArgumentNotNull(request, "request");
            Ensure.ArgumentNotNull(language, "language parameters");

            var response = await ApiConnection.Post<ExportResponse>(ApiUrls.Export(tmId, language.Source, language.Target), request, "application/json");

            BackgroundTask backgroundTask;
            do
            {
                backgroundTask = await ApiConnection.Get<BackgroundTask>(ApiUrls.GetTaskById(response.Id), null);
            } while (backgroundTask.Status != "Done");

            var fileContent = await ApiConnection.Get<byte[]>(ApiUrls.TaskOutput(backgroundTask.Id), null);

            return fileContent;
        }

        /// <summary>
        /// Exports a translation memory as byte[]
        /// The encoding file format is a zip with the .gz extension
        /// To save the Tm on disk the array should be decompressed using GZipStream()
        /// <param name="request"><see cref="ExportRequest"/></param>
        /// <param name="tmId">Translation memory id</param>
        /// <param name="language"><see cref="LanguageParameters"/></param>
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>Selected tm as byte[]</returns>
        public async Task<byte[]> ExportTm(Guid tmId, ExportRequest request, LanguageParameters language)
        {
            Ensure.ArgumentNotNull(tmId, "tmId");
            Ensure.ArgumentNotNull(request, "request");
            Ensure.ArgumentNotNull(language, "language parameters");

            var response = await ApiConnection.Post<ExportResponse>(ApiUrls.Export(tmId, language.Source, language.Target), request, "application/json");

            BackgroundTask backgroundTask;
            do
            {
                backgroundTask = await ApiConnection.Get<BackgroundTask>(ApiUrls.GetTaskById(response.Id), null);
            } while (backgroundTask.Status != "Done");

            var fileContent = await ApiConnection.Get<byte[]>(ApiUrls.TaskOutput(backgroundTask.Id), null);

            return fileContent;
        }

        [Obsolete("This method is obsolete. Call 'GetBackgroundTask(Guid)' instead.")]
        public async Task<BackgroundTask> GetBackgroundTask(string taskId)
        {
            var backgroundTask = await ApiConnection.Get<BackgroundTask>(ApiUrls.GetTaskById(taskId), null);
            return backgroundTask;
        }

        /// <summary>
        /// Gets the status of a background task operation.
        /// </summary>
        /// <param name="backgroundTaskId">The background task's Guid</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns><see cref="BackgroundTask"/></returns>
        public async Task<BackgroundTask> GetBackgroundTask(Guid taskId)
        {
            var backgroundTask = await ApiConnection.Get<BackgroundTask>(ApiUrls.GetTaskById(taskId), null);
            return backgroundTask;
        }

        [Obsolete("This method is obsolete. Call 'ImportTm(Guid, LanguageParameters, byte[], string)' instead.")]
        public async Task<ImportResponse> ImportTm(string tmId, LanguageParameters language, byte[] rawFile, string fileName)
        {
            Ensure.ArgumentNotNullOrEmptyString(tmId, "tmId");
            Ensure.ArgumentNotNull(language, "language parameters");
            Ensure.ArgumentNotNull(rawFile, "file");
            Ensure.ArgumentNotNullOrEmptyString(fileName, "file name");

            var byteContent = new ByteArrayContent(rawFile);
            byteContent.Headers.Add("Content-Type", "application/json");
            var multipartContent = new MultipartFormDataContent
            {
                { byteContent, "file", fileName }
            };

            return await ApiConnection.Post<ImportResponse>(ApiUrls.Import(tmId, language.Source, language.Target), multipartContent, "application/json");
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
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns><see cref="ImportResponse"/></returns>
        public async Task<ImportResponse> ImportTm(Guid tmId, LanguageParameters language, byte[] rawFile, string fileName)
        {
            Ensure.ArgumentNotNull(tmId, "tmId");
            Ensure.ArgumentNotNull(language, "language parameters");
            Ensure.ArgumentNotNull(rawFile, "file");
            Ensure.ArgumentNotNullOrEmptyString(fileName, "file name");

            var byteContent = new ByteArrayContent(rawFile);
            byteContent.Headers.Add("Content-Type", "application/json");
            var multipartContent = new MultipartFormDataContent
            {
                { byteContent, "file", fileName }
            };

            return await ApiConnection.Post<ImportResponse>(ApiUrls.Import(tmId, language.Source, language.Target), multipartContent, "application/json");
        }

        [Obsolete("This method is obsolete. Call 'ImportTmWithSettings(Guid, LanguageParameters, string, ImportSettings)' instead.")]
        public async Task<ImportResponse> ImportTmWithSettings(string tmId, LanguageParameters language, string filePath, ImportSettings settings)
        {
            Ensure.ArgumentNotNullOrEmptyString(tmId, "tmId");
            Ensure.ArgumentNotNull(language, "language parameters");
            Ensure.ArgumentNotNullOrEmptyString(filePath, "file path");

            using (var content = new MultipartFormDataContent())
            {
                var stream = new System.IO.FileStream(filePath, System.IO.FileMode.Open);
                var streamContent = new StreamContent(stream);
                content.Add(streamContent, "File", System.IO.Path.GetFileName(filePath));

                var importSettings = new SimpleJsonSerializer().Serialize(settings);
                content.Add(new StringContent(importSettings), "Settings");

                return await ApiConnection.Post<ImportResponse>(ApiUrls.Import(tmId, language.Source, language.Target), content);
            }
        }

        /// <summary>
        /// Imports translation units into a translation memory
        /// </summary>
        /// <param name="tmId">Translation memory GUID</param>
        /// <param name="language"><see cref="LanguageParameters"/></param>
        /// <param name="filePath">Local file path</param>
        /// <param name="settings">Import settings</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns><see cref="ImportResponse"/></returns>
        public async Task<ImportResponse> ImportTmWithSettings(Guid tmId, LanguageParameters language, string filePath, ImportSettings settings)
        {
            Ensure.ArgumentNotNull(tmId, "tmId");
            Ensure.ArgumentNotNull(language, "language parameters");
            Ensure.ArgumentNotNullOrEmptyString(filePath, "file path");

            using (var content = new MultipartFormDataContent())
            {
                var stream = new System.IO.FileStream(filePath, System.IO.FileMode.Open);
                var streamContent = new StreamContent(stream);
                content.Add(streamContent, "File", System.IO.Path.GetFileName(filePath));

                var importSettings = new SimpleJsonSerializer().Serialize(settings);
                content.Add(new StringContent(importSettings), "Settings");

                return await ApiConnection.Post<ImportResponse>(ApiUrls.Import(tmId, language.Source, language.Target), content);
            }
        }

        [Obsolete("This method is obsolete. Call 'ImportTmWithSettings(Guid, LanguageParameters, byte[], string, ImportSettings)' instead.")]
        public async Task<ImportResponse> ImportTmWithSettings(string tmId, LanguageParameters language, byte[] rawFile, string fileName, ImportSettings settings)
        {
            Ensure.ArgumentNotNullOrEmptyString(tmId, "tm id");
            Ensure.ArgumentNotNull(language, "language parameters");
            Ensure.ArgumentNotNull(rawFile, "file");
            Ensure.ArgumentNotNullOrEmptyString(fileName, "file name");

            var byteContent = new ByteArrayContent(rawFile);
            byteContent.Headers.Add("Content-Type", "application/json");

            var json = JsonConvert.SerializeObject(settings);

            var multipartContent = new MultipartFormDataContent
            {
                { byteContent, "file", fileName },
                { new StringContent(json), "settings" }
            };

            return await ApiConnection.Post<ImportResponse>(ApiUrls.Import(tmId, language.Source, language.Target), multipartContent, "application/json");
        }

        /// <summary>
        /// Imports TUs into a Translation Memory
        /// The file should be a TMX type.
        /// <param name="tmId">Translation memory id</param>
        /// <param name="language"><see cref="LanguageParameters"/></param>
        /// <param name="rawFile">byte[] which represents the file</param>
        /// <param name="fileName">file name</param>
        /// <param name="settings">import settings</param>
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns><see cref="ImportResponse"/></returns>
        public async Task<ImportResponse> ImportTmWithSettings(Guid tmId, LanguageParameters language, byte[] rawFile, string fileName, ImportSettings settings)
        {
            Ensure.ArgumentNotNull(tmId, "tmId");
            Ensure.ArgumentNotNull(language, "language parameters");
            Ensure.ArgumentNotNull(rawFile, "file");
            Ensure.ArgumentNotNullOrEmptyString(fileName, "file name");

            var byteContent = new ByteArrayContent(rawFile);
            byteContent.Headers.Add("Content-Type", "application/json");

            var json = JsonConvert.SerializeObject(settings);

            var multipartContent = new MultipartFormDataContent
            {
                { byteContent, "file", fileName },
                { new StringContent(json), "settings" }
            };

            return await ApiConnection.Post<ImportResponse>(ApiUrls.Import(tmId, language.Source, language.Target), multipartContent, "application/json");
        }

        #endregion

        #region Translation unit methods
        /// Confirmation levels possible values: Unspecified, Draft, Translated, RejectedTranslation
        /// ApprovedTranslation,RejectedSignOff,ApprovedSignOff
        public async Task<TranslationUnitResponse> AddCustomTranslationUnit(TranslationUnitRequest unitRequest, string tmId)
        {
            Ensure.ArgumentNotNull(unitRequest, "translation unit request");
            Ensure.ArgumentNotNullOrEmptyString(tmId, "translation memory id");

            return await ApiConnection.Post<TranslationUnitResponse>(ApiUrls.TranslationUnits(tmId, "text"), unitRequest, "application/json");
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

            return await ApiConnection.Post<TranslationUnitResponse>(ApiUrls.TranslationUnits(tmId, "text"), unitRequest, "application/json");
        }

        [Obsolete("This method is obsolete. Call 'GetTranslationUnitsForTm(Guid, TranslationUnitDetailsRequest)' instead.")]
        public async Task<TranslationUnitDetailsResponse> GetTranslationUnitForTm(string tmId, TranslationUnitDetailsRequest request)
        {
            Ensure.ArgumentNotNull(request, "translation request params");
            Ensure.ArgumentNotNullOrEmptyString(tmId, "translation memory id");

            return await ApiConnection.Get<TranslationUnitDetailsResponse>(ApiUrls.Tus(tmId), request.ToParametersDictionary());
        }

        /// <summary>
        /// Gets the translation units from the translation memory.
        /// </summary>
        /// <param name="tmId">Translation memory Guid.</param>
        /// <param name="request"><see cref="TranslationUnitDetailsRequest"/></param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns><see cref="TranslationUnitDetailsResponse"/></returns>
        public async Task<TranslationUnitDetailsResponse> GetTranslationUnitsForTm(Guid tmId, TranslationUnitDetailsRequest request)
        {
            Ensure.ArgumentNotNull(request, "request");
            Ensure.ArgumentNotNull(tmId, "translation memory id");

            return await ApiConnection.Get<TranslationUnitDetailsResponse>(ApiUrls.Tus(tmId), request.ToParametersDictionary());
        }

        [Obsolete("This method is obsolete. Call 'GetTranslationUnitsCount(Guid, LanguageParameters)' instead.")]
        public async Task<int> GetNumberOfTus(string tmId, LanguageParameters language)
        {
            Ensure.ArgumentNotNullOrEmptyString(tmId, "translation memory id");
            Ensure.ArgumentNotNull(language, "language parameters request");

            return await ApiConnection.Get<int>(ApiUrls.TusCount(tmId), language.ToParametersDictionary());
        }

        /// <summary>
        /// Gets the translation units number from the translation memory.
        /// <param name="language"><see cref="LanguageParameters"/></param>
        /// <param name="tmId">Translation memory id</param>
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>Translation units count.</returns>
        public async Task<int> GetTranslationUnitsCount(Guid tmId, LanguageParameters language)
        {
            Ensure.ArgumentNotNull(tmId, "translation memory id");
            Ensure.ArgumentNotNull(language, "language parameters request");

            return await ApiConnection.Get<int>(ApiUrls.TusCount(tmId), language.ToParametersDictionary());
        }

        [Obsolete("This method is obsolete. Call 'GetPostdatedTranslationUnitsCount(Guid, LanguageParameters)' instead.")]
        public async Task<int> GetNumberOfPostDatedTus(string tmId, LanguageParameters language)
        {
            Ensure.ArgumentNotNullOrEmptyString(tmId, "translation memory id");
            Ensure.ArgumentNotNull(language, "language parameters request");

            return await ApiConnection.Get<int>(ApiUrls.TusByType(tmId, "postdated"), language.ToParametersDictionary());
        }

        /// <summary>
        /// Gets the postdated translation units count from the translation memory
        /// <param name="language"><see cref="LanguageParameters"/></param>
        /// <param name="tmId">Translation memory id</param>
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>Postdated translation units count.</returns>
        public async Task<int> GetPostdatedTranslationUnitsCount(Guid tmId, LanguageParameters language)
        {
            Ensure.ArgumentNotNull(tmId, "translation memory id");
            Ensure.ArgumentNotNull(language, "language parameters request");

            return await ApiConnection.Get<int>(ApiUrls.TusByType(tmId, "postdated"), language.ToParametersDictionary());
        }

        [Obsolete("This method is obsolete. Call 'GetPredatedTranslationUnitsCount(Guid, LanguageParameters)' instead.")]
        public async Task<int> GetNumberOfPreDatedTus(string tmId, LanguageParameters language)
        {
            Ensure.ArgumentNotNullOrEmptyString(tmId, "translation memory id");
            Ensure.ArgumentNotNull(language, "language parameters request");

            return await ApiConnection.Get<int>(ApiUrls.TusByType(tmId, "predated"), language.ToParametersDictionary());
        }

        /// <summary>
        /// Gets the predated translation units count from the translation memory
        /// <param name="language"><see cref="LanguageParameters"/></param>
        /// <param name="tmId">Translation memory id</param>
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>Predated translation units count.</returns>
        public async Task<int> GetPredatedTranslationUnitsCount(Guid tmId, LanguageParameters language)
        {
            Ensure.ArgumentNotNull(tmId, "translation memory id");
            Ensure.ArgumentNotNull(language, "language parameters request");

            return await ApiConnection.Get<int>(ApiUrls.TusByType(tmId, "predated"), language.ToParametersDictionary());
        }

        [Obsolete("This method is obsolete. Call 'GetUnalignedTranslationUnitsCount(Guid, LanguageParameters)' instead.")]
        public async Task<int> GetNumberOfUnalignedTus(string tmId, LanguageParameters language)
        {
            Ensure.ArgumentNotNullOrEmptyString(tmId, "translation memory id");
            Ensure.ArgumentNotNull(language, "language parameters request");

            return await ApiConnection.Get<int>(ApiUrls.TusByType(tmId, "unaligned"), language.ToParametersDictionary());
        }

        /// <summary>
        /// Gets the unaligned translation units count from the translation memory.
        /// <param name="language"><see cref="LanguageParameters"/></param>
        /// <param name="tmId">Translation memory id</param>
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>Unaligned translation units count.</returns>
        public async Task<int> GetUnalignedTranslationUnitsCount(Guid tmId, LanguageParameters language)
        {
            Ensure.ArgumentNotNull(tmId, "translation memory id");
            Ensure.ArgumentNotNull(language, "language parameters request");

            return await ApiConnection.Get<int>(ApiUrls.TusByType(tmId, "unaligned"), language.ToParametersDictionary());
        }

        [Obsolete("This method is obsolete. Call 'GetDuplicateTranslationUnits(Guid, LanguageParameters, DuplicatesTusRequest)' instead.")]
        public async Task<TranslationUnitDetailsResponse> GetDuplicateTusForTm(string tmId, LanguageParameters language, DuplicatesTusRequest duplicatesRequest)
        {
            Ensure.ArgumentNotNullOrEmptyString(tmId, "translation memory id");
            Ensure.ArgumentNotNull(language, "language parameters request");
            Ensure.ArgumentNotNull(duplicatesRequest, "duplicates request");

            return await ApiConnection.Post<TranslationUnitDetailsResponse>(ApiUrls.TranslationUnitsDuplicates(tmId, language.Source, language.Target), duplicatesRequest);
        }

        /// <summary>
        /// Retrieves the Duplicate Translation Units in a specific TM
        /// <param name="language"><see cref="LanguageParameters"/></param>
        /// <param name="tmId">Translation memory id</param>
        /// <param name="duplicatesRequest"><see cref="DuplicatesTusRequest"/></param>
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns><see cref="TranslationUnitDetailsResponse"/></returns>
        public async Task<TranslationUnitDetailsResponse> GetDuplicateTranslationUnits(Guid tmId, LanguageParameters language, DuplicatesTusRequest duplicatesRequest)
        {
            Ensure.ArgumentNotNull(tmId, "tmId");
            Ensure.ArgumentNotNull(language, "language parameters request");
            Ensure.ArgumentNotNull(duplicatesRequest, "duplicates request");

            return await ApiConnection.Post<TranslationUnitDetailsResponse>(ApiUrls.TranslationUnitsDuplicates(tmId, language.Source, language.Target), duplicatesRequest);
        }

        /// <summary>
        /// Filters translation units, retrieves a string matching the expression
        /// <param name="languageRequest"><see cref="LanguageDetailsRequest"/></param>
        /// <param name="tmRequest"><see cref="TranslationMemoryDetailsRequest"/></param>
        /// <param name="allowWildCards"></param>
        /// <param name="caseSensitive"></param>
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="FilterResponse"/> which represent filter data</returns>
        public async Task<IReadOnlyList<FilterResponse>> FilterAsPlainText(
            LanguageDetailsRequest languageRequest, TranslationMemoryDetailsRequest tmRequest, bool caseSensitive,
            bool allowWildCards)
        {
            Ensure.ArgumentNotNull(languageRequest, "languageRequest");
            Ensure.ArgumentNotNull(tmRequest, "translation memory request");

            //language validation
            Ensure.ArgumentNotNull(languageRequest.SourceLanguageCode, "source language code");
            Ensure.ArgumentNotNull(languageRequest.TargetLanguageCode, "target language code");

            Ensure.ArgumentNotNull(tmRequest.TmId, "translation memory id");

            RestFilterExpression restFilterExpression = null;
            var expression = FilterExpression.CreateFilter(languageRequest, caseSensitive, allowWildCards);

            if (expression != "")
            {
                restFilterExpression = FilterExpression.GetRestFilterExpression(expression, languageRequest);
            }

            var document = await _client.GetTranslationUnitsAsync(tmRequest.TmId, languageRequest.SourceLanguageCode, languageRequest.TargetLanguageCode, tmRequest.StartTuId, tmRequest.Count, restFilterExpression);
            var searchResult = FilterResults.GetFilterResultForDocument(document, null);

            return searchResult;
        }

        /// <summary>
        /// Performs a text search, retrieves a string matching the expression
        /// Source and target language language code is required
        /// For example : German (Germany) - de-de , English (United States) - en-us
        /// For a custom search Settings property should be set. If is not set the search will have the default values as follows:
        /// It will perform a search in source . 
        /// MinScore default value is 70
        /// MaxResult default value is set to 30
        /// Example of custom filter expression:   "\"Andrea\" = (\"AndreaField\")", "TestFilterName") 
        /// For more examples see https://github.com/sdl/groupsharekit.net/blob/master/Sdl.Community.GroupShareKit.Tests.Integration/Clients/TranslationMemoriesClientTest.cs
        /// <param name="searchRequest"><see cref="SearchRequest"/></param>
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        public async Task<IReadOnlyList<FilterResponse>> SearchText(SearchRequest searchRequest)
        {
            Ensure.ArgumentNotNull(searchRequest, "Search request null");
            var searchResults = new List<FilterResponse>();
            var restTextSearch = new RestTextSearch
            {
                SearchText = searchRequest.SearchText,
                Settings = new RestSearchSettings()
            };

            if (searchRequest.Settings != null)
            {
                restTextSearch.Settings = CreateRestTextSearchSettings(searchRequest.Settings);
                restTextSearch.SearchText = searchRequest.SearchText;
            }

            var restSearchResult = await _client.TextSearchAsync(searchRequest.TmId, searchRequest.SourceLanguageCode, searchRequest.TargetLanguageCode, restTextSearch);

            foreach (var result in restSearchResult.Results)
            {
                var searchResult = FilterResults.GetFilterResultForDocument(result.MemoryTranslationUnit, null);

                searchResults.AddRange(searchResult);
            }

            return searchResults;
        }

        /// <summary>
        /// Performs a concordance search, retrieves a string matching the expression
        /// Source and target language language code is required
        /// For example : German (Germany) - de-de , English (United States) - en-us
        /// For a custom search Settings property should be set. If is not set the search will have the default values as follows:
        /// It will perform a search in source . 
        /// MinScore default value is 70
        /// MaxResult default value is set to 30
        /// Example of custom filter expression:   "\"Andrea\" = (\"AndreaField\")", "TestFilterName") 
        /// For more examples see https://github.com/sdl/groupsharekit.net/blob/master/Sdl.Community.GroupShareKit.Tests.Integration/Clients/TranslationMemoriesClientTest.cs
        /// <param name="searchRequest"><see cref="ConcordanceSearchRequest"/></param>
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        public async Task<IReadOnlyList<FilterResponse>> ConcordanceSearchAsPlainText(ConcordanceSearchRequest concordanceSearchRequest)
        {
            Ensure.ArgumentNotNull(concordanceSearchRequest, "Search request null");

            var restConcordanceSearch = new RestConcordanceSearch
            {
                Settings = new RestConcordanceSearchSettings(),
                SearchText = concordanceSearchRequest.SearchText
            };

            var searchResults = new List<FilterResponse>();

            if (concordanceSearchRequest.Settings != null)
            {
                restConcordanceSearch = CreateRestConcordanceSearch(concordanceSearchRequest.Settings);
                restConcordanceSearch.SearchText = concordanceSearchRequest.SearchText;
            }

            var concordanceSearchResult = await _client.ConcordanceSearchAsync(concordanceSearchRequest.TmId, concordanceSearchRequest.SourceLanguageCode, concordanceSearchRequest.TargetLanguageCode, restConcordanceSearch);

            foreach (var result in concordanceSearchResult.Results)
            {
                var searchResult = FilterResults.GetFilterResultForDocument(result.MemoryTranslationUnit, result.ScoringResult);

                searchResults.AddRange(searchResult);
            }

            return searchResults;
        }

        private static RestSearchSettings CreateRestTextSearchSettings(SearchTextSettings searchSettings)
        {
            var restSearchSettings = new RestSearchSettings();

            if (searchSettings.MinScore >= 30 && searchSettings.MinScore <= 100)
            {
                restSearchSettings.MinScore = searchSettings.MinScore;
            }

            if (searchSettings.MaxResults >= 1 && searchSettings.MinScore <= 99)
            {
                restSearchSettings.MaxResults = searchSettings.MaxResults;
            }

            if (searchSettings.Filters != null && searchSettings.Filters.Count > 0)
            {
                restSearchSettings.Filters = CreateSearchTextRestFilter(searchSettings);
            }

            if (searchSettings.Penalties != null && searchSettings.Penalties.Count > 0)
            {
                restSearchSettings.Penalties = CreateSearchTextPenaltiesRestFilter(searchSettings.Penalties);
            }

            return restSearchSettings;
        }

        private static List<RestPenalty> CreateSearchTextPenaltiesRestFilter(List<Penalty> penalties)
        {
            var penaltyRest = new List<RestPenalty>();

            foreach (var penalty in penalties)
            {
                var restPenalty = new RestPenalty
                {
                    Malus = penalty.Malus,
                    PenaltyType = penalty.PenaltyType.ToString()
                };

                penaltyRest.Add(restPenalty);
            }

            return penaltyRest;
        }

        private static List<RestFilter> CreateSearchTextRestFilter(SearchTextSettings searchSettings)
        {
            var restFilterList = new List<RestFilter>();
            var restFilterFields = new List<RequestField>();

            foreach (var filter in searchSettings.Filters)
            {
                foreach (var filterField in filter.Expression.Fields)
                {
                    var restField = new RequestField
                    {
                        Name = filterField.Name,
                        Values = filterField.Values,
                        Type = filterField.Type.ToString()
                    };

                    restFilterFields.Add(restField);
                }

                var restFilter = new RestFilter
                {
                    Name = filter.Name,
                    Penalty = filter.Penalty,
                    Expression = new RestFilterExpression
                    {
                        Expression = filter.Expression.Expression,
                        Fields = restFilterFields
                    }
                };

                restFilterList.Add(restFilter);
            }

            return restFilterList;
        }

        private static RestConcordanceSearch CreateRestConcordanceSearch(ConcordanceSearchSettings searchSettings)
        {
            var restSearch = new RestConcordanceSearch
            {
                Settings = new RestConcordanceSearchSettings(),
            };

            //By default is 70
            if (searchSettings.MinScore >= 30 && searchSettings.MinScore <= 100)
            {
                restSearch.Settings.MinScore = searchSettings.MinScore;
            }
            //by default is 30
            if (searchSettings.MaxResults >= 1 && searchSettings.MinScore <= 99)
            {
                restSearch.Settings.MaxResults = searchSettings.MaxResults;
            }

            if (searchSettings.Filters != null && searchSettings.Filters.Count > 0)
            {
                restSearch.Settings.Filters = CreateRestFilterList(searchSettings.Filters);
            }

            if (searchSettings.Penalties != null && searchSettings.Penalties.Count > 0)
            {
                restSearch.Settings.Penalties = CreatePenaltiesFilterList(searchSettings.Penalties);
            }

            return restSearch;
        }

        private static List<RestPenalty> CreatePenaltiesFilterList(List<Penalty> penalties)
        {
            var restPenaltyTypes = new List<RestPenalty>();

            foreach (var penalty in penalties)
            {
                var restPenalty = new RestPenalty
                {
                    Malus = penalty.Malus,
                    PenaltyType = penalty.PenaltyType.ToString()
                };

                restPenaltyTypes.Add(restPenalty);
            }

            return restPenaltyTypes;
        }

        private static List<RestFilter> CreateRestFilterList(List<ConcordanceSearchFilter> searchSettings)
        {
            var serviceFilters = new List<RestFilter>();
            foreach (var filter in searchSettings)
            {

                var restFilterFields = new List<RequestField>();

                foreach (var field in filter.Expression.Fields)
                {
                    var restField = new RequestField
                    {
                        Name = field.Name,
                        Type = field.Type.ToString(),
                        Values = field.Values
                    };
                    restFilterFields.Add(restField);
                }

                var restFilter = new RestFilter
                {
                    Expression = new RestFilterExpression
                    {
                        Expression = filter.Expression.Expression,
                        Fields = restFilterFields
                    },
                    Name = filter.Name,
                    Penalty = filter.Penalty,
                };

                serviceFilters.Add(restFilter);
            }

            return serviceFilters;
        }

        /// <summary>
        /// Filters translation units, retrieves a string matching the expression
        /// For source and target language language code is required
        /// For example : German (Germany) - de-de , English (United States) - en-us
        /// <param name="request"><see cref="RawFilterRequest"/></param>
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="FilterResponse"/> which represent filter data</returns>
        public async Task<IReadOnlyList<FilterResponse>> RawFilter(RawFilterRequest request)
        {
            Ensure.ArgumentNotNull(request, "filter request");
            Ensure.ArgumentNotNull(request.TmId, "tm id");
            Ensure.ArgumentNotNullOrEmptyString(request.SourceLanguageCode, "source language code");
            Ensure.ArgumentNotNullOrEmptyString(request.TargetLanguageCode, "target language code");
            Ensure.ArgumentNotNullOrEmptyString(request.Filter.Expression, "filter expression");
            Ensure.ArgumentNotNull(request.Filter.Fields, "filter fields");

            var customFilterExpressionRequest = FilterExpression.GetCustomRestFilterExpression(request.Filter);

            var document = await _client.GetTranslationUnitsAsync(request.TmId, request.SourceLanguageCode, request.TargetLanguageCode, request.StartTuId, request.Count, customFilterExpressionRequest);

            var searchResult = FilterResults.GetFilterResultForDocument(document, null);

            return searchResult;
        }

        #endregion

        #region Container methods


        /// <summary>
        /// Returns a list of all available containers
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        ///<returns><see cref="Containers"/></returns>
        public async Task<Containers> GetContainers()
        {
            return await ApiConnection.Get<Containers>(ApiUrls.Containers(), null);
        }

        [Obsolete("This method is obsolete. Call 'CreateContainer(CreateContainerRequest)' instead.")]
        public async Task<string> CreateContainer(ContainerRequest request)
        {
            Ensure.ArgumentNotNull(request, "container request");
            return await ApiConnection.Post<string>(ApiUrls.Containers(), request, "application/json");
        }

        /// <summary>
        /// Creates a <see cref="ContainerRequest"/>.
        /// </summary>
        /// <param name="request">The container's details.</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>The container's Guid.</returns>
        public async Task<Guid> CreateContainer(CreateContainerRequest request)
        {
            Ensure.ArgumentNotNull(request, "request");
            return await ApiConnection.Post<Guid>(ApiUrls.Containers(), request, "application/json");
        }

        [Obsolete("This method is obsolete. Call 'GetContainer(Guid)' instead.")]
        public async Task<Container> GetContainerById(string containerId)
        {
            Ensure.ArgumentNotNullOrEmptyString(containerId, "container id");
            return await ApiConnection.Get<Container>(ApiUrls.Containers(containerId), null);
        }

        /// <summary>
        /// Gets a <see cref="Container"/> with the specified Id.
        /// </summary>
        /// <param name="containerId">Container Guid</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns><see cref="ContainerRequest"/></returns>
        public async Task<Container> GetContainer(Guid containerId)
        {
            Ensure.ArgumentNotNull(containerId, "containerId");
            return await ApiConnection.Get<Container>(ApiUrls.Containers(containerId), null);
        }

        [Obsolete("This method is obsolete. Call 'DeleteContainer(Guid)' instead.")]
        public async Task DeleteContainer(string containerId)
        {
            Ensure.ArgumentNotNullOrEmptyString(containerId, "container id");
            await ApiConnection.Delete(ApiUrls.Containers(containerId));
        }

        /// <summary>
        /// Deletes a <see cref="Container"/>.
        /// </summary>
        /// <param name="containerId">Container Guid</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        public async Task DeleteContainer(Guid containerId)
        {
            Ensure.ArgumentNotNull(containerId, "containerId");
            await ApiConnection.Delete(ApiUrls.Containers(containerId));
        }

        [Obsolete("This method is obsolete. Call 'UpdateContainer(Guid)' instead.")]
        public async Task UpdateContainer(string containerId, UpdateContainerRequest request)
        {
            Ensure.ArgumentNotNullOrEmptyString(containerId, "container id");
            Ensure.ArgumentNotNull(request, "request");

            await ApiConnection.Put<string>(ApiUrls.Containers(containerId), request);
        }

        /// <summary>
        /// Updates a <see cref="Container"/>.
        /// </summary>
        /// <param name="containerId">The container Guid.</param>
        /// <param name="request"><see cref="UpdateContainerRequest"/></param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        public async Task UpdateContainer(Guid containerId, UpdateContainerRequest request)
        {
            Ensure.ArgumentNotNull(containerId, "container id");
            Ensure.ArgumentNotNull(request, "request");

            await ApiConnection.Put<Guid>(ApiUrls.Containers(containerId), request);
        }

        #endregion

        #region Database server
        /// <summary>
        /// Returns a list of all available database servers
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns><see cref="DatabaseServerResponse"/> id</returns>
        public async Task<DatabaseServerResponse> GetDbServers()
        {
            return await ApiConnection.Get<DatabaseServerResponse>(ApiUrls.DbServers(), null);
        }

        [Obsolete("This method is obsolete. Call 'GetDbServer(Guid)' instead.")]
        public async Task<DatabaseServer> GetDbServerById(string serverId)
        {
            Ensure.ArgumentNotNullOrEmptyString(serverId, "serverId");
            return await ApiConnection.Get<DatabaseServer>(ApiUrls.DbServers(serverId), null);
        }

        /// <summary>
        /// Gets a <see cref="DatabaseServer"/> with the specified Id.
        /// </summary>
        /// <param name="serverId">The database server Guid.</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns><see cref="DatabaseServer"/></returns>
        public async Task<DatabaseServer> GetDbServer(Guid serverId)
        {
            Ensure.ArgumentNotNull(serverId, "serverId");
            return await ApiConnection.Get<DatabaseServer>(ApiUrls.DbServers(serverId), null);
        }

        [Obsolete("This method is obsolete. Call 'CreateDbServer(CreateDatabaseServerRequest)' instead.")]
        public async Task<string> CreateDbServer(DatabaseServerRequest request)
        {
            Ensure.ArgumentNotNull(request, "request");
            return await ApiConnection.Post<string>(ApiUrls.DbServers(), request, "application/json");
        }

        /// <summary>
        /// Creates a <see cref="DatabaseServer"/>.
        /// </summary>
        /// <param name="request">The database server's details.</param>
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>The database server Guid.</returns>
        public async Task<Guid> CreateDbServer(CreateDatabaseServerRequest request)
        {
            Ensure.ArgumentNotNull(request, "request");
            return await ApiConnection.Post<Guid>(ApiUrls.DbServers(), request, "application/json");
        }

        [Obsolete("This method is obsolete. Call 'DeleteDbServer(Guid)' instead.")]
        public async Task DeleteDbServer(string serverId)
        {
            Ensure.ArgumentNotNullOrEmptyString(serverId, "server id");
            await ApiConnection.Delete(ApiUrls.DbServers(serverId));
        }

        /// <summary>
        /// Deletes a <see cref="DatabaseServer"/>.
        /// </summary>
        /// <param name="serverId">The database server Guid.</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        public async Task DeleteDbServer(Guid serverId)
        {
            Ensure.ArgumentNotNull(serverId, "serverId");
            await ApiConnection.Delete(ApiUrls.DbServers(serverId));
        }

        [Obsolete("This method is obsolete. Call 'UpdateDbServer(Guid)' instead.")]
        public async Task UpdateDbServer(string serverId, RequestDbServer request)
        {
            Ensure.ArgumentNotNullOrEmptyString(serverId, "server id");
            Ensure.ArgumentNotNull(request, "server request");

            await ApiConnection.Put<string>(ApiUrls.DbServers(serverId), request);
        }

        /// <summary>
        /// Updates a <see cref="DatabaseServer"/>.
        /// </summary>
        /// <param name="serverId">The database server Guid.</param>
        /// <param name="request"><see cref="UpdateDatabaseServerRequest"/></param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        public async Task UpdateDbServer(Guid serverId, UpdateDatabaseServerRequest request)
        {
            Ensure.ArgumentNotNull(serverId, "serverId");
            await ApiConnection.Put<Guid>(ApiUrls.DbServers(serverId), request);
        }
        #endregion

        #region Fields methods
        [Obsolete("This method is obsolete. Call 'CreateFieldTemplate(CreateFieldTemplateRequest)' instead.")]
        public async Task<string> CreateFieldTemplate(FieldTemplate template)
        {
            Ensure.ArgumentNotNull(template, "FieldTemplate");
            var templateLocation = await ApiConnection.Post<string>(ApiUrls.FieldTemplate(), template, "application/json");
            var templateId = templateLocation.Split('/').Last();
            return templateId;
        }

        /// <summary>
        /// Creates a <see cref="FieldTemplate"/>.
        /// </summary>
        /// <param name="request"><see cref="CreateFieldTemplateRequest"/></param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>The field template's Guid.</returns>
        public async Task<Guid> CreateFieldTemplate(CreateFieldTemplateRequest request)
        {
            Ensure.ArgumentNotNull(request, "request");

            var fieldTemplateId = await ApiConnection.Post<Guid>(ApiUrls.FieldTemplate(), request, "application/json");
            return fieldTemplateId;
        }

        /// <summary>
        /// Gets <see cref="FieldTemplates"/>.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>Returns <see cref="FieldTemplates"/> which contains a list of <see cref="FieldTemplate"/></returns>
        public async Task<FieldTemplates> GetFieldTemplates()
        {
            return await ApiConnection.Get<FieldTemplates>(ApiUrls.FieldTemplate(), null);
        }

        [Obsolete("This method is obsolete. Call 'GetFieldTemplate(Guid)' instead.")]
        public async Task<FieldTemplate> GetFieldTemplateById(string id)
        {
            return await ApiConnection.Get<FieldTemplate>(ApiUrls.GetFieldTemplateById(id), null);
        }

        /// <summary>
        /// Gets a <see cref="FieldTemplate"/> by Id.
        /// </summary>
        /// <param name="fieldTemplateId">The field template Guid.</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A <see cref="FieldTemplate"/>.</returns>
        public async Task<FieldTemplate> GetFieldTemplate(Guid fieldTemplateId)
        {
            return await ApiConnection.Get<FieldTemplate>(ApiUrls.GetFieldTemplate(fieldTemplateId), null);
        }

        [Obsolete("This method is obsolete. Call 'UpdateFieldTemplate(Guid)' instead.")]
        public async Task UpdateFieldTemplate(string templateId, FieldTemplateRequest templateRequest)
        {
            Ensure.ArgumentNotNullOrEmptyString(templateId, "templateId");
            Ensure.ArgumentNotNull(templateRequest, "templateRequest");

            await ApiConnection.Put<string>(ApiUrls.GetFieldTemplateById(templateId), templateRequest);
        }

        /// <summary>
        /// Updates a <see cref="FieldTemplate"/>.
        /// </summary>
        /// <param name="fieldTemplateId">The field template's Guid.</param>
        /// <param name="fieldTemplateRequest"><see cref="UpdateTemplateRequest"/></param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        public async Task UpdateFieldTemplate(Guid fieldTemplateId, UpdateTemplateRequest templateRequest)
        {
            Ensure.ArgumentNotNull(fieldTemplateId, "fieldTemplateId");
            Ensure.ArgumentNotNull(templateRequest, "templateRequest");

            await ApiConnection.Put<Guid>(ApiUrls.GetFieldTemplate(fieldTemplateId), templateRequest);
        }

        [Obsolete("This method is obsolete. Call 'DeleteFieldTemplate(Guid)' instead.")]
        public async Task DeleteFieldTemplate(string templateId)
        {
            Ensure.ArgumentNotNullOrEmptyString(templateId, "templateId");
            await ApiConnection.Delete(ApiUrls.GetFieldTemplateById(templateId));
        }

        /// <summary>
        /// Deletes a <see cref="FieldTemplate"/> by Id.
        /// </summary>
        /// <param name="fieldTemplateId">The field template's Guid.</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        public async Task DeleteFieldTemplate(Guid fieldTemplateId)
        {
            Ensure.ArgumentNotNull(fieldTemplateId, "fieldTemplateId");
            await ApiConnection.Delete(ApiUrls.GetFieldTemplate(fieldTemplateId));
        }

        [Obsolete("This method is obsolete. Call 'AddOperationsForFieldTemplate(Guid, List<Operation>)' instead.")]
        public async Task AddOperationsForFieldTemplate(string templateId, FieldTemplatePatchRequest request)
        {
            Ensure.ArgumentNotNullOrEmptyString(templateId, "templateId");
            Ensure.ArgumentNotNull(request, "request");

            await ApiConnection.Patch(ApiUrls.GetFieldTemplateById(templateId), request, "application/json");
        }

        /// <summary>
        /// Executes a partial update for a <see cref="FieldTemplate"/>.
        /// </summary>
        /// <param name="fieldTemplateId">The field template's Guid.</param>
        /// <param name="operations"><see cref="Operation"/></param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        public async Task AddOperationsForFieldTemplate(Guid fieldTemplateId, List<Operation> operations)
        {
            Ensure.ArgumentNotNull(fieldTemplateId, "fieldTemplateId");

            await ApiConnection.Patch(ApiUrls.GetFieldTemplate(fieldTemplateId), operations, "application/json");
        }

        [Obsolete("This method is obsolete. Call 'GetFieldForTemplate(Guid, Guid)' instead.")]
        public async Task<IReadOnlyList<Field>> GetFieldsForTemplate(string fieldTemplateId)
        {
            Ensure.ArgumentNotNullOrEmptyString(fieldTemplateId, "fieldTemplateId");
            return await ApiConnection.GetAll<Field>(ApiUrls.GetFields(fieldTemplateId), null);
        }

        /// <summary>
        /// Gets a list of Fields for a specific field Template ID
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="Field"/>s</returns>
        public async Task<IReadOnlyList<Field>> GetFieldsForTemplate(Guid fieldTemplateId)
        {
            Ensure.ArgumentNotNull(fieldTemplateId, "fieldTemplateId");
            return await ApiConnection.GetAll<Field>(ApiUrls.GetFields(fieldTemplateId), null);
        }

        [Obsolete("This method is obsolete. Call 'GetFieldForTemplate(Guid, Guid)' instead.")]
        public async Task<Field> GetFieldForTemplate(string fieldTemplateId, string fieldId)
        {
            Ensure.ArgumentNotNullOrEmptyString(fieldTemplateId, "fieldTemplateId");
            Ensure.ArgumentNotNullOrEmptyString(fieldId, "fieldId");
            return await ApiConnection.Get<Field>(ApiUrls.GetField(fieldTemplateId, fieldId), null);
        }

        /// <summary>
        /// Gets a specified Field for a specific Field Template ID
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> <see cref="Field"/></returns>
        public async Task<Field> GetFieldForTemplate(Guid fieldTemplateId, Guid fieldId)
        {
            Ensure.ArgumentNotNull(fieldTemplateId, "fieldTemplateId");
            Ensure.ArgumentNotNull(fieldId, "fieldId");
            return await ApiConnection.Get<Field>(ApiUrls.GetField(fieldTemplateId, fieldId), null);
        }

        [Obsolete("This method is obsolete. Call 'CreateFieldForTemplate(Guid, FieldRequest)' instead.")]
        public async Task<string> CreateFieldForTemplate(string fieldTemplateId, FieldRequest fieldRequest)
        {
            Ensure.ArgumentNotNullOrEmptyString(fieldTemplateId, "fieldTemplateId");
            Ensure.ArgumentNotNull(fieldRequest, "field request");
            var fieldType = Enum.GetName(typeof(FieldRequest.TypeEnum), fieldRequest.Type);

            // in case the type is SinglePicklist or MultiplePicklist the values will be a list of strings.

            var field = new Field
            {
                Type = fieldType,
                Name = fieldRequest.Name,
                FieldId = fieldRequest.FieldId,
                Values = GetValues(fieldRequest.Values)
            };

            var fieldLocation = await ApiConnection.Post<string>(ApiUrls.GetFields(fieldTemplateId), field, "application/json");
            var fieldId = fieldLocation.Split('/').Last();
            return fieldId;
        }

        /// <summary>
        /// Creates a Field for a specific Field Template Guid.
        /// If selected type is SinglePicklist or MultiplePicklist , "values " property should be filled out.
        ///  For each value the id should be a new Guid, and the "name" property should be the value you want to add.
        /// </summary>
        /// <remarks>
        /// <param name="field"><see cref="FieldRequest"/></param>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>The field's Guid.</returns>
        public async Task<Guid> CreateFieldForTemplate(Guid fieldTemplateId, FieldRequest fieldRequest)
        {
            Ensure.ArgumentNotNull(fieldTemplateId, "fieldTemplateId");
            Ensure.ArgumentNotNull(fieldRequest, "field request");
            var fieldType = Enum.GetName(typeof(FieldRequest.TypeEnum), fieldRequest.Type);

            // in case the type is SinglePicklist or MultiplePicklist the values will be a list of strings.

            var field = new Field
            {
                Type = fieldType,
                Name = fieldRequest.Name,
                FieldId = fieldRequest.FieldId,
                Values = GetValues(fieldRequest.Values)
            };

            var fieldId = await ApiConnection.Post<Guid>(ApiUrls.GetFields(fieldTemplateId), field, "application/json");
            return fieldId;
        }

        /// <summary>
        /// Helper method in case of SinglePicklist or MultiplePicklist type
        /// </summary>
        /// <param name="valuesList"></param>
        /// <returns>A list of <see cref="Value"/>'s</returns>
        private static List<Value> GetValues(List<string> valuesList)
        {
            var multipleValuesList = new List<Value>();

            foreach (var value in valuesList)
            {
                var item = new Value
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = value
                };

                multipleValuesList.Add(item);
            }

            return multipleValuesList;
        }

        [Obsolete("This method is obsolete. Call 'UpdateFieldForTemplate(Guid, Guid, Field)' instead.")]
        public async Task UpdateFieldForTemplate(string fieldTemplateId, string fieldId, Field field)
        {
            Ensure.ArgumentNotNullOrEmptyString(fieldId, "fieldId");
            Ensure.ArgumentNotNullOrEmptyString(fieldTemplateId, "fieldTemplateId");
            Ensure.ArgumentNotNull(field, "field request");
            await ApiConnection.Put<string>(ApiUrls.GetField(fieldTemplateId, fieldId), field);
        }

        /// <summary>
        /// Updates a Field for a specific Field Template ID
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        public async Task UpdateFieldForTemplate(Guid fieldTemplateId, Guid fieldId, Field field)
        {
            Ensure.ArgumentNotNull(fieldId, "fieldId");
            Ensure.ArgumentNotNull(fieldTemplateId, "fieldTemplateId");
            Ensure.ArgumentNotNull(field, "field request");
            await ApiConnection.Put<string>(ApiUrls.GetField(fieldTemplateId, fieldId), field);
        }

        [Obsolete("This method is obsolete. Call 'DeleteFieldForTemplate(Guid, Guid)' instead.")]
        public async Task DeleteFieldForTemplate(string fieldTemplateId, string fieldId)
        {
            Ensure.ArgumentNotNullOrEmptyString(fieldTemplateId, "fieldTemplateId");
            Ensure.ArgumentNotNullOrEmptyString(fieldId, "fieldId");

            await ApiConnection.Delete(ApiUrls.GetField(fieldTemplateId, fieldId));
        }

        /// <summary>
        /// Deletes a specified Field for a specific Field Template ID.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        public async Task DeleteFieldForTemplate(Guid fieldTemplateId, Guid fieldId)
        {
            Ensure.ArgumentNotNull(fieldTemplateId, "fieldTemplateId");
            Ensure.ArgumentNotNull(fieldId, "fieldId");

            await ApiConnection.Delete(ApiUrls.GetField(fieldTemplateId, fieldId));
        }

        #endregion

        #region Language resource methods

        [Obsolete("This method is obsolete. Call 'GetLanguageResources(Guid)' instead.")]
        public async Task<IReadOnlyList<Resource>> GetLanguageResourcesForTemplate(string templateId)
        {
            Ensure.ArgumentNotNullOrEmptyString(templateId, "templateId");
            return await ApiConnection.GetAll<Resource>(ApiUrls.LanguageResource(templateId), null);
        }

        /// <summary>
        /// Gets the <see cref="LanguageResource"/>s of a <see cref="LanguageResourceTemplate"/>.
        /// </summary>
        /// <param name="languageResourceTemplateId">The language resource template's Guid.</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="LanguageResource"/>.</returns>
        public async Task<IReadOnlyList<LanguageResource>> GetLanguageResources(Guid languageResourceTemplateId)
        {
            Ensure.ArgumentNotNull(languageResourceTemplateId, "languageResourceTemplateId");
            return await ApiConnection.GetAll<LanguageResource>(ApiUrls.LanguageResources(languageResourceTemplateId), null);
        }

        [Obsolete("This method is obsolete. Call 'CreateLanguageResourceForTemplate(Guid)' instead.")]
        public async Task<string> CreateLanguageResourceForTemplate(string templateId, Resource request)
        {
            Ensure.ArgumentNotNullOrEmptyString(templateId, "templateId");
            Ensure.ArgumentNotNull(request, "request");
            var encodeData = Convert.ToBase64String(Encoding.UTF8.GetBytes(request.Data));
            request.Data = encodeData;
            var resourceUrl = await ApiConnection.Post<string>(ApiUrls.LanguageResource(templateId), request, "application/json");

            return resourceUrl.Split('/').Last();
        }

        /// <summary>
        /// Creates a <see cref="LanguageResource"/>s for a <see cref="LanguageResourceTemplate"/>.
        /// </summary>
        /// <param name="languageResourceTemplateId">The language resource template's Guid.</param>
        /// <param name="request">Language resource details.</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>The language resource Guid.</returns>
        public async Task<Guid> CreateLanguageResourceForTemplate(Guid languageResourceTemplateId, LanguageResource request)
        {
            Ensure.ArgumentNotNull(languageResourceTemplateId, "languageResourceTemplateId");
            Ensure.ArgumentNotNull(request, "request");

            var encodeData = Convert.ToBase64String(Encoding.UTF8.GetBytes(request.Data));
            request.Data = encodeData;

            return await ApiConnection.Post<Guid>(ApiUrls.LanguageResources(languageResourceTemplateId), request, "application/json");
        }

        [Obsolete("This method is obsolete. Call 'GetLanguageResourceServiceDefaults(LanguageResourceServiceDefaultsRequest)' instead.")]
        public async Task<Resource> GetDefaultsType(ResourceServiceDefaultsRequest defaultsRequest)
        {
            Ensure.ArgumentNotNull(defaultsRequest, "request");

            return await ApiConnection.Get<Resource>(ApiUrls.GetDefaults(Enum.GetName(typeof(ResourceServiceDefaultsRequest.ResourceType), defaultsRequest.Type), defaultsRequest.Language), null);
        }

        /// <summary>
        /// Gets language resource service defaults.
        /// </summary>
        /// <param name="request"><see cref="LanguageResourceServiceDefaultsRequest"/></param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns><see cref="LanguageResourceServiceDefaultsRequest"/></returns>
        public async Task<LanguageResource> GetLanguageResourceServiceDefaults(LanguageResourceServiceDefaultsRequest request)
        {
            Ensure.ArgumentNotNull(request, "request");

            return await ApiConnection.Get<LanguageResource>(ApiUrls.GetDefaults(Enum.GetName(typeof(LanguageResourceType), request.Type), request.Language), null);
        }

        [Obsolete("This method is obsolete. Call 'GetLanguageResourceForTemplate(Guid, Guid)' instead.")]
        public async Task<Resource> GetLanguageResourceForTemplate(string templateId, string languageResourceId)
        {
            Ensure.ArgumentNotNullOrEmptyString(templateId, "templateId");
            Ensure.ArgumentNotNullOrEmptyString(languageResourceId, "languageResourceId");

            return await ApiConnection.Get<Resource>(ApiUrls.LanguageResourcesForTemplate(templateId, languageResourceId), null);
        }

        /// <summary>
        /// Gets a <see cref="LanguageResource"/>s of a <see cref="LanguageResourceTemplate"/>.
        /// </summary>
        /// <param name="templateId">The language resource template's Guid.</param>
        /// <param name="languageResourceId">The language resource's Guid.</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A <see cref="LanguageResource"/>.</returns>
        public async Task<LanguageResource> GetLanguageResourceForTemplate(Guid templateId, Guid languageResourceId)
        {
            Ensure.ArgumentNotNull(templateId, "templateId");
            Ensure.ArgumentNotNull(languageResourceId, "languageResourceId");

            return await ApiConnection.Get<LanguageResource>(ApiUrls.LanguageResourcesForTemplate(templateId, languageResourceId), null);
        }

        [Obsolete("This method is obsolete. Call 'DeleteLanguageResourceForTemplate(Guid, Guid)' instead.")]
        public async Task DeleteLanguageResourceForTemplate(string templateId, string languageResourceId)
        {
            Ensure.ArgumentNotNullOrEmptyString(templateId, "templateId");
            Ensure.ArgumentNotNullOrEmptyString(languageResourceId, "languageResourceId");

            await ApiConnection.Delete(ApiUrls.LanguageResourcesForTemplate(templateId, languageResourceId));
        }

        /// <summary>
        /// Deletes a <see cref="LanguageResource"/>s of a <see cref="LanguageResourceTemplate"/>.
        /// </summary>
        /// <param name="languageResourceTemplateId">The language resource template's Guid.</param>
        /// <param name="languageResourceId">The language resource's Guid.</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        public async Task DeleteLanguageResourceForTemplate(Guid languageResourceTemplateId, Guid languageResourceId)
        {
            Ensure.ArgumentNotNull(languageResourceTemplateId, "languageResourceTemplateId");
            Ensure.ArgumentNotNull(languageResourceId, "languageResourceId");

            await ApiConnection.Delete(ApiUrls.LanguageResourcesForTemplate(languageResourceTemplateId, languageResourceId));
        }

        [Obsolete("This method is obsolete. Call 'UpdateLanguageResourceForTemplate(Guid, Guid, LanguageResource)' instead.")]
        public async Task UpdateLanguageResourceForTemplate(string templateId, string languageResourceId, Resource resourceRequest)
        {
            Ensure.ArgumentNotNullOrEmptyString(templateId, "templateId");
            Ensure.ArgumentNotNullOrEmptyString(languageResourceId, "languageResourceId");
            Ensure.ArgumentNotNull(resourceRequest, "resourceRequest");

            var encodeData = Convert.ToBase64String(Encoding.UTF8.GetBytes(resourceRequest.Data));
            resourceRequest.Data = encodeData;

            await ApiConnection.Put<string>(ApiUrls.LanguageResourcesForTemplate(templateId, languageResourceId), resourceRequest);
        }

        /// <summary>
        /// Updates a <see cref="LanguageResource"/>s of a <see cref="LanguageResourceTemplate"/>.
        /// </summary>
        /// <param name="languageResourceTemplateId">The language resource template's Guid.</param>
        /// <param name="languageResourceId">The language resource's Guid.</param>
        /// <param name="request">Language resource details</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        public async Task UpdateLanguageResourceForTemplate(Guid languageResourceTemplateId, Guid languageResourceId, LanguageResource resourceRequest)
        {
            Ensure.ArgumentNotNull(languageResourceTemplateId, "languageResourceTemplateId");
            Ensure.ArgumentNotNull(languageResourceId, "languageResourceId");
            Ensure.ArgumentNotNull(resourceRequest, "request");

            var encodeData = Convert.ToBase64String(Encoding.UTF8.GetBytes(resourceRequest.Data));
            resourceRequest.Data = encodeData;

            await ApiConnection.Put<string>(ApiUrls.LanguageResourcesForTemplate(languageResourceTemplateId, languageResourceId), resourceRequest);
        }

        [Obsolete("This method is obsolete. Call 'ResetLanguageResourceToDefault(Guid, Guid)' instead.")]
        public async Task ResetToDefaultLanguageResource(string templateId, string languageResourceId)
        {
            Ensure.ArgumentNotNullOrEmptyString(templateId, "templateId");
            Ensure.ArgumentNotNullOrEmptyString(languageResourceId, "languageResourceId");

            await ApiConnection.Put<string>(ApiUrls.LanguageResourceActions(templateId, languageResourceId, "reset"), templateId);
        }

        /// <summary>
        /// Reset to default Culture values a specific Language Resource in a specific Language Resource Template
        /// </summary>
        /// <param name="languageResourceTemplateId">The language resource template's Guid.</param>
        /// <param name="languageResourceId">The language resource's Guid.</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        public async Task ResetLanguageResourceToDefault(Guid languageResourceTemplateId, Guid languageResourceId)
        {
            Ensure.ArgumentNotNull(languageResourceTemplateId, "languageResourceTemplateId");
            Ensure.ArgumentNotNull(languageResourceId, "languageResourceId");

            await ApiConnection.Put<string>(ApiUrls.LanguageResourceActions(languageResourceTemplateId, languageResourceId, "reset"), languageResourceTemplateId);
        }

        [Obsolete("This method is obsolete. Call 'ImportFileForLanguageResource(Guid, Guid, byte[])' instead.")]
        public async Task ImportFileForLanguageResource(string templateId, string languageResourceId, byte[] file)
        {
            Ensure.ArgumentNotNullOrEmptyString(templateId, "templateId");
            Ensure.ArgumentNotNullOrEmptyString(languageResourceId, "languageResourceId");
            Ensure.ArgumentNotNull(file, "fileData");

            var byteContent = new ByteArrayContent(file);
            byteContent.Headers.Add("Content-Type", "application/json");
            var multipartContent = new MultipartFormDataContent
            {
                { byteContent, "file" }
            };

            await ApiConnection.Post<string>(ApiUrls.LanguageResourceActions(templateId, languageResourceId, "import"), multipartContent);
        }

        /// <summary>
        /// Imports a file with data for a specific <see cref="LanguageResourceTemplate"/>.
        /// </summary>
        /// <param name="languageResourceTemplateId">The language resource template's Guid.</param>
        /// <param name="languageResourceId">The language resource's Guid.</param>
        /// <param name="file">Import file.</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        public async Task ImportFileForLanguageResource(Guid languageResourceTemplateId, Guid languageResourceId, byte[] file)
        {
            Ensure.ArgumentNotNull(languageResourceTemplateId, "languageResourceTemplateId");
            Ensure.ArgumentNotNull(languageResourceId, "languageResourceId");
            Ensure.ArgumentNotNull(file, "fileData");

            var byteContent = new ByteArrayContent(file);
            byteContent.Headers.Add("Content-Type", "application/json");

            var multipartContent = new MultipartFormDataContent
            {
                { byteContent, "file", "File" }
            };

            await ApiConnection.Post<string>(ApiUrls.LanguageResourceActions(languageResourceTemplateId, languageResourceId, "import"), multipartContent, "application/json");
        }

        [Obsolete("This method is obsolete. Call 'ExportFileForLanguageResource(Guid, Guid)' instead.")]
        public async Task<byte[]> ExportFileForLanguageResource(string templateId, string languageResourceId)
        {
            Ensure.ArgumentNotNullOrEmptyString(templateId, "templateId");
            Ensure.ArgumentNotNullOrEmptyString(languageResourceId, "languageResourceId");

            var document = await ApiConnection.Get<string>(ApiUrls.LanguageResourceActions(templateId, languageResourceId, "export"), null);
            return Encoding.UTF8.GetBytes(document);
        }

        /// <summary>
        /// Exports a file with data for a specific <see cref="LanguageResourceTemplate"/>.
        /// </summary>
        /// <param name="languageResourceTemplateId">The language resource template's Guid.</param>
        /// <param name="languageResourceId">The language resource's Guid.</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>Exported document content.</returns>
        public async Task<byte[]> ExportFileForLanguageResource(Guid languageResourceTemplateId, Guid languageResourceId)
        {
            Ensure.ArgumentNotNull(languageResourceTemplateId, "languageResourceTemplateId");
            Ensure.ArgumentNotNull(languageResourceId, "languageResourceId");

            var document = await ApiConnection.Get<string>(ApiUrls.LanguageResourceActions(languageResourceTemplateId, languageResourceId, "export"), null);
            return Encoding.UTF8.GetBytes(document);
        }

        #endregion

        #region Language resource template clients
        /// <summary>
        /// Gets all language resource templates  .
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns><see cref="LanguageResourceTemplates"/> which contains a list of language resource templates </returns>
        public async Task<LanguageResourceTemplates> GetAllLanguageResourceTemplates()
        {
            return await ApiConnection.Get<LanguageResourceTemplates>(ApiUrls.LanguageResourceServiceTemplates(), null);
        }

        [Obsolete("This method is obsolete. Call 'GetLanguageResourceTemplate(Guid)' instead.")]
        public async Task<LanguageResourceTemplate> GetTemplateById(string templateId)
        {
            Ensure.ArgumentNotNullOrEmptyString(templateId, "templateId");
            return await ApiConnection.Get<LanguageResourceTemplate>(ApiUrls.GetLanguageResourceTemplateById(templateId), null);
        }

        /// <summary>
        /// Gets a <see cref="LanguageResourceTemplate"/> with the specified Id.
        /// </summary>
        /// <param name="languageResourceTemplateId">The language resource template Guid.</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A <see cref="LanguageResourceTemplate"/>.</returns>
        public async Task<LanguageResourceTemplate> GetLanguageResourceTemplate(Guid languageResourceTemplateId)
        {
            Ensure.ArgumentNotNull(languageResourceTemplateId, "languageResourceTemplateId");
            return await ApiConnection.Get<LanguageResourceTemplate>(ApiUrls.GetLanguageResourceTemplate(languageResourceTemplateId), null);
        }

        [Obsolete("This method is obsolete. Call 'UpdateLanguageResourceTemplate(Guid, UpdateTemplateRequest)' instead.")]
        public async Task EditTemplate(string templateId, FieldTemplateRequest request)
        {
            Ensure.ArgumentNotNullOrEmptyString(templateId, "templateId");
            Ensure.ArgumentNotNull(request, "request");
            await ApiConnection.Put<string>(ApiUrls.GetLanguageResourceTemplateById(templateId), request);
        }

        /// <summary>
        /// Updates a <see cref="LanguageResourceTemplate"/>.
        /// </summary>
        /// <param name="languageResourceTemplateId">The language resource template Guid.</param>
        /// <param name="request">Language resource template details.</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        public async Task UpdateLanguageResourceTemplate(Guid languageResourceTemplateId, UpdateTemplateRequest request)
        {
            Ensure.ArgumentNotNull(languageResourceTemplateId, "languageResourceTemplateId");
            Ensure.ArgumentNotNull(request, "request");
            await ApiConnection.Put<Guid>(ApiUrls.GetLanguageResourceTemplate(languageResourceTemplateId), request);
        }

        [Obsolete("This method is obsolete. Call 'CreateLanguageResourceTemplate(CreateLanguageResourceTemplateRequest)' instead.")]
        public async Task<string> CreateTemplate(LanguageResourceTemplate templateRequest)
        {
            Ensure.ArgumentNotNull(templateRequest, "templateRequest");
            foreach (var resource in templateRequest.LanguageResources)
            {
                var encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(resource.Data));
                resource.Data = encoded;
            }

            var responseUrl = await ApiConnection
                .Post<string>(ApiUrls.LanguageResourceServiceTemplates(), templateRequest, "application/json")
                .ConfigureAwait(false);

            var id = responseUrl.Split('/').Last();
            return id;
        }

        /// <summary>
        /// Creates a <see cref="LanguageResourceTemplate"/>.
        /// </summary>
        /// <param name="request"><see cref="CreateLanguageResourceTemplateRequest"/></param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>The language resource template's Guid.</returns>
        public async Task<Guid> CreateLanguageResourceTemplate(CreateLanguageResourceTemplateRequest request)
        {
            Ensure.ArgumentNotNull(request, "request");

            var languageResourceTemplateId = await ApiConnection.Post<Guid>(ApiUrls.LanguageResourceServiceTemplates(), request, "application/json");
            return languageResourceTemplateId;
        }

        [Obsolete("This method is obsolete. Call 'DeleteLanguageResourceTemplate(Guid)' instead.")]
        public async Task DeleteTemplate(string languageResourceTemplateId)
        {
            Ensure.ArgumentNotNullOrEmptyString(languageResourceTemplateId, "languageResourceTemplateId");
            await ApiConnection.Delete(ApiUrls.GetLanguageResourceTemplateById(languageResourceTemplateId));
        }

        /// <summary>
        /// Deletes a <see cref="LanguageResourceTemplate"/> by Id.
        /// </summary>
        /// <param name="languageResourceTemplateId">The language resource template's Guid.</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        public async Task DeleteLanguageResourceTemplate(Guid languageResourceTemplateId)
        {
            Ensure.ArgumentNotNull(languageResourceTemplateId, "languageResourceTemplateId");
            await ApiConnection.Delete(ApiUrls.LanguageResourceTemplates(languageResourceTemplateId));
        }

        /// <summary>
        /// Gets<see cref="TmServiceDetails"/> of tm service .
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>Returns the status of tm service and the dependencies</returns>
        public async Task<TmServiceDetails> TmServiceInfo()
        {
            return await ApiConnection.Get<TmServiceDetails>(ApiUrls.GetTmServiceInfo(), null);
        }

        #endregion

    }
}
