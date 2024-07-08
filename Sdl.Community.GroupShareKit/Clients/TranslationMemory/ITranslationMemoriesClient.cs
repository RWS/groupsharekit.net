﻿using Sdl.Community.GroupShareKit.Exceptions;
using Sdl.Community.GroupShareKit.Models.Response;
using Sdl.Community.GroupShareKit.Models.Response.TranslationMemory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackgroundTask = Sdl.Community.GroupShareKit.Models.Response.TranslationMemory.BackgroundTask;

namespace Sdl.Community.GroupShareKit.Clients.TranslationMemory
{
    public interface ITranslationMemoriesClient
    {
        #region Translation memory methods
        /// <summary>
        /// Gets all tms<see cref="Models.Response.TranslationMemory.TranslationMemory"/>.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>  <see cref="Models.Response.TranslationMemory.TranslationMemory"/></returns>
        Task<Models.Response.TranslationMemory.TranslationMemory> GetTms();

        [Obsolete("This method is obsolete. Call 'GetTranslationMemory(Guid)' instead.")]
        Task<TranslationMemoryDetails> GetTmById(string tmId);

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
        Task<TranslationMemoryDetails> GetTranslationMemory(Guid translationMemoryId);

        [Obsolete("This method is obsolete. Call 'CreateTranslationMemory(CreateTranslationMemoryRequest)' instead.")]
        Task<string> CreateTm(CreateTmRequest tm);

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
        Task<Guid> CreateTranslationMemory(CreateTranslationMemoryRequest request);

        [Obsolete("This method is obsolete. Call 'DeleteTranslationMemory(Guid)' instead.")]
        Task DeleteTm(string tmId);

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
        Task DeleteTranslationMemory(Guid translationMemoryId);

        [Obsolete("This method is obsolete. Call 'Update(Guid, TranslationMemoryDetails)' instead.")]
        Task Update(string tmId, TranslationMemoryDetails tm);

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
        Task UpdateTranslationMemory(Guid tmId, TranslationMemoryDetails tmDetails);

        /// <summary>
        /// Gets<see cref="Health"/> of tm service .
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>Returns the status of tm service</returns>
        Task<Health> Health();

        /// <summary>
        /// Gets<see cref="TmServiceDetails"/> of tm service .
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>Returns the status of tm service and the dependencies</returns>
        Task<TmServiceDetails> TmServiceInfo();

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
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>Selected tm as byte[]</returns>
        Task<byte[]> ExportTm(string tmId, ExportRequest request, LanguageParameters language);

        Task<BackgroundTask> GetBackgroundTask(string taskId);

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
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns><see cref="ImportResponse"/></returns>
        Task<ImportResponse> ImportTm(string tmId, LanguageParameters language, byte[] rawFile, string fileName);

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
        Task<ImportResponse> ImportTmWithSettings(string tmId, LanguageParameters language, string filePath, ImportSettings settings);

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
        Task<ImportResponse> ImportTmWithSettings(string tmId, LanguageParameters language, byte[] rawFile, string fileName, ImportSettings settings);

        /// <summary>
        /// Gets the  tms number by language resource template.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>  Tm number</returns>
        Task<int> GetTmsNumberByLanguageResourceTemplateId(string resourceTemplateId);

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
        Task<int> GetTmsNumberByLanguageResourceTemplateId(Guid languageResourceTemplateId);

        /// <summary>
        /// Gets the  tms number by field template id number.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>  Tm number</returns>
        Task<int> GetTmsNumberByFieldTemplateId(string fieldTemplateId);

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
        Task<int> GetTmsNumberByFieldTemplateId(Guid fieldTemplateId);

        [Obsolete("This method is obsolete. Call 'RecomputeStatistics(Guid, FuzzyRequest)' instead.")]
        Task<FuzzyIndexResponse> RecomputeStatistics(string tmId, FuzzyRequest request);

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
        Task<FuzzyIndexResponse> RecomputeStatistics(Guid tmId, FuzzyRequest request);

        [Obsolete("This method is obsolete. Call 'Reindex(Guid, FuzzyRequest)' instead.")]
        Task<FuzzyIndexResponse> Reindex(string tmId, FuzzyRequest request);

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
        Task<FuzzyIndexResponse> Reindex(Guid tmId, FuzzyRequest request);

        [Obsolete("This method is obsolete. Call '(Guid)' instead.")]
        Task<LanguageDirection> GetLanguageDirectionForTm(string tmId, string languageDirectionId);

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
        Task<LanguageDirection> GetTmLanguageDirection(Guid tmId, Guid languageDirectionId);
        #endregion

        #region Translation unit methods
        /// <summary>
        /// Add a custom translation units to a specified TM .
        /// Please make sure the fields values you add corresponds  to the TM
        /// To find the right values look at "fieldTemplateId" corresponding to the TM -> "fields" (take the fieldName), 
        /// from "values", "name" values should be added to a list 
        /// Confirmation levels possible values: Unspecified, Draft, Translated, RejectedTranslation
        /// ApprovedTranslation,RejectedSignOff,ApprovedSignOff
        /// <param name="unitRequest"><see cref="TranslationUnitRequest"/></param>
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns><see cref="TranslationUnitResponse"/></returns>
        Task<TranslationUnitResponse> AddCustomTranslationUnit(TranslationUnitRequest unitRequest, string tmId);

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
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns><see cref="TranslationUnitResponse"/></returns>
        Task<TranslationUnitResponse> UpdateCustomTranslationUnit(TranslationUnitRequest unitRequest, string tmId);

        /// <summary>
        /// Add all  translation units from a field template to a specified TM .
        /// Confirmation levels possible values: Unspecified, Draft, Translated, RejectedTranslation
        /// ApprovedTranslation,RejectedSignOff,ApprovedSignOff
        /// <param name="unitRequest"><see cref="TranslationUnitRequest"/></param>
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns><see cref="TranslationUnitResponse"/></returns>
        Task<TranslationUnitResponse> AddAllTranslationUnits(TranslationUnitRequest unitRequest, string tmId, FieldTemplate fieldTemplate);

        [Obsolete("This method is obsolete. Call '(Guid)' instead.")]
        Task<TranslationUnitDetailsResponse> GetTranslationUnitForTm(string tmId, TranslationUnitDetailsRequest request);

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
        Task<TranslationUnitDetailsResponse> GetTranslationUnitsForTm(Guid tmId, TranslationUnitDetailsRequest request);

        /// <summary>
        /// Gets the translation units number from the translation memory
        /// <param name="language"><see cref="LanguageParameters"/></param>
        /// <param name="tmId">Translation memory id</param>
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>int</returns>
        Task<int> GetNumberOfTus(string tmId, LanguageParameters language);

        /// <summary>
        /// Gets the postdated translation units count from the translation memory
        /// <param name="language"><see cref="LanguageParameters"/></param>
        /// <param name="tmId">Translation memory id</param>
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>int</returns>
        Task<int> GetNumberOfPostDatedTus(string tmId, LanguageParameters language);

        /// <summary>
        /// Gets the predated translation units count from the translation memory
        /// <param name="language"><see cref="LanguageParameters"/></param>
        /// <param name="tmId">Translation memory id</param>
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>int</returns>
        Task<int> GetNumberOfPreDatedTus(string tmId, LanguageParameters language);

        /// <summary>
        /// Gets the unaligned translation units count from the translation memory
        /// <param name="language"><see cref="LanguageParameters"/></param>
        /// <param name="tmId">Translation memory id</param>
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>int</returns>
        Task<int> GetNumberOfUnalignedTus(string tmId, LanguageParameters language);

        /// <summary>
        /// Retrieves the Duplicate Translation Units in a specific TM
        /// <param name="language"><see cref="LanguageParameters"/></param>
        /// <param name="tmId">Translation memory id</param>
        /// <param name="duplicatesRequest"><see cref="DuplicatesTusRequest"/></param>
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns><see cref="TranslationUnitDetailsResponse"/></returns>
        Task<TranslationUnitDetailsResponse> GetDuplicateTusForTm(string tmId, LanguageParameters language, DuplicatesTusRequest duplicatesRequest);

        /// <summary>
        /// Filters translation units, retrieves a string matching the expression
        /// <param name="languageRequest"><see cref="LanguageDetailsRequest"/></param>
        /// <param name="tmRequest"><see cref="TranslationMemoryDetailsRequest"/></param>
        /// <param name="allowWildCards"></param>
        /// <param name="caseSensitive"></param>
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="Models.Response.TranslationMemory.FilterResponse"/> which represent filter data</returns>
        Task<IReadOnlyList<Models.Response.TranslationMemory.FilterResponse>> FilterAsPlainText(LanguageDetailsRequest languageRequest, TranslationMemoryDetailsRequest tmRequest, bool caseSensitive, bool allowWildCards);

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
        /// <param name="concordanceSearchRequest"><see cref="SearchRequest"/></param>
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task<IReadOnlyList<Models.Response.TranslationMemory.FilterResponse>> SearchText(SearchRequest searchRequest);

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
        /// <param name="concordanceSearchRequest"><see cref="ConcordanceSearchRequest"/></param>
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task<IReadOnlyList<Models.Response.TranslationMemory.FilterResponse>> ConcordanceSearchAsPlainText(ConcordanceSearchRequest concordanceSearchRequest);

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
        /// <returns>A list of <see cref="Models.Response.TranslationMemory.FilterResponse"/> which represent filter data</returns>
        Task<IReadOnlyList<Models.Response.TranslationMemory.FilterResponse>> RawFilter(RawFilterRequest request);

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
        Task<Containers> GetContainers();

        [Obsolete("This method is obsolete. Call '(Guid)' instead.")]
        Task<string> CreateContainer(ContainerRequest request);

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
        Task<Guid> CreateContainer(CreateContainerRequest request);

        [Obsolete("This method is obsolete. Call 'GetContainer(Guid)' instead.")]
        Task<Container> GetContainerById(string containerId);

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
        Task<Container> GetContainer(Guid containerId);

        [Obsolete("This method is obsolete. Call 'DeleteContainer(Guid)' instead.")]
        Task DeleteContainer(string containerId);

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
        Task DeleteContainer(Guid containerId);

        [Obsolete("This method is obsolete. Call 'UpdateContainer(Guid, UpdateContainerRequest)' instead.")]
        Task UpdateContainer(string containerId, UpdateContainerRequest request);

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
        Task UpdateContainer(Guid containerId, UpdateContainerRequest request);

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
        /// <returns><see cref="DatabaseServerResponse"/></returns>
        Task<DatabaseServerResponse> GetDbServers();

        [Obsolete("This method is obsolete. Call 'GetDbServer(Guid)' instead.")]
        Task<DatabaseServer> GetDbServerById(string serverId);

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
        Task<DatabaseServer> GetDbServer(Guid serverId);

        [Obsolete("This method is obsolete. Call 'CreateDbServer(CreateDatabaseServerRequest)' instead.")]
        Task<string> CreateDbServer(DatabaseServerRequest request);

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
        Task<Guid> CreateDbServer(CreateDatabaseServerRequest request);

        [Obsolete("This method is obsolete. Call 'DeleteDbServer(Guid)' instead.")]
        Task DeleteDbServer(string serverId);

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
        Task DeleteDbServer(Guid serverId);

        [Obsolete("This method is obsolete. Call 'UpdateDbServer(Guid)' instead.")]
        Task UpdateDbServer(string serverId, RequestDbServer request);

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
        Task UpdateDbServer(Guid serverId, UpdateDatabaseServerRequest request);

        #endregion

        #region Field methods
        
        [Obsolete("This method is obsolete. Call 'CreateFieldTemplate(Guid)' instead.")]
        Task<string> CreateFieldTemplate(FieldTemplate template);

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
        Task<Guid> CreateFieldTemplate(CreateFieldTemplateRequest request);

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
        ///<returns>Returns <see cref="FieldTemplates"/> which contains a list of <see cref="FieldTemplate"/></returns>
        Task<FieldTemplates> GetFieldTemplates();

        [Obsolete("This method is obsolete. Call 'GetFieldTemplate(Guid)' instead.")]
        Task<FieldTemplate> GetFieldTemplateById(string id);

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
        Task<FieldTemplate> GetFieldTemplate(Guid fieldTemplateId);

        [Obsolete("This method is obsolete. Call 'UpdateFieldTemplate(Guid, UpdateTemplateRequest)' instead.")]
        Task UpdateFieldTemplate(string templateId, FieldTemplateRequest templateRequest);

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
        Task UpdateFieldTemplate(Guid fieldTemplateId, UpdateTemplateRequest templateRequest);

        [Obsolete("This method is obsolete. Call 'DeleteFieldTemplate(Guid)' instead.")]
        Task DeleteFieldTemplate(string templateId);

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
        Task DeleteFieldTemplate(Guid fieldTemplateId);

        [Obsolete("This method is obsolete. Call 'AddOperationsForFieldTemplate(Guid, List<Operation>)' instead.")]
        Task AddOperationsForFieldTemplate(string templateId, FieldTemplatePatchRequest request);

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
        Task AddOperationsForFieldTemplate(Guid fieldTemplateId, List<Operation> operations);

        /// <summary>
        /// Gets a list of Fields for a specific Field Template ID
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="Field"/>'s</returns>
        Task<IReadOnlyList<Field>> GetFieldsForTemplate(string fieldTemplateId);

        /// <summary>
        /// Gets a specified Field for a specific Field Template ID
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> <see cref="Field"/></returns>
        Task<Field> GetFieldForTemplate(string fieldTemplateId, string fieldId);

        /// <summary>
        /// Creates a Field for a specific Field Template ID
        /// If selected type is SinglePicklist or MultiplePicklist , "values " property should be filled out.
        ///  For each value the id should be a new Guid, and the "name" property should be the value you want to add.
        /// </summary>
        /// <remarks>
        /// <param name="field"><see cref="FieldRequest"/></param>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> Field Id</returns>
        Task<string> CreateFieldForTemplate(string fieldTemplateId, FieldRequest field);

        /// <summary>
        /// Updates a Field for a specific Field Template ID
        /// Accepted values for type: SingleString, MultipleString, Integer, DateTime, SinglePicklist, MultiplePicklist
        ///  If selected type is SinglePicklist or MultiplePicklist , "values " property should be filled out.
        ///  For each value the id should be a new Guid, and the "name" property should be the value you want to add.
        /// </summary>
        /// <remarks>
        /// <param name="field"><see cref="Field"/></param>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task UpdateFieldForTemplate(string fieldTemplateId, string fieldId, Field field);

        /// <summary>
        /// Deletes a specified Field for a specific Field Template ID
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task DeleteFieldForTemplate(string fieldTemplateId, string fieldId);
        #endregion

        #region Language resource

        [Obsolete("This method is obsolete. Call 'GetLanguageResources(Guid)' instead.")]
        Task<IReadOnlyList<Resource>> GetLanguageResourcesForTemplate(string templateId);

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
        Task<IReadOnlyList<LanguageResource>> GetLanguageResources(Guid languageResourceTemplateId);

        [Obsolete("This method is obsolete. Call 'CreateLanguageResourceForTemplate(Guid, LanguageResource)' instead.")]
        Task<string> CreateLanguageResourceForTemplate(string templateId, Resource request);

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
        Task<Guid> CreateLanguageResourceForTemplate(Guid languageResourceTemplateId, LanguageResource request);

        [Obsolete("This method is obsolete. Call 'GetLanguageResourceServiceDefaults(LanguageResourceServiceDefaultsRequest)' instead.")]
        Task<Resource> GetDefaultsType(ResourceServiceDefaultsRequest defaultsRequest);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="defaultsRequest"></param>
        /// <returns></returns>
        Task<LanguageResource> GetLanguageResourceServiceDefaults(LanguageResourceServiceDefaultsRequest request);

        [Obsolete("This method is obsolete. Call 'GetLanguageResourceForTemplate(Guid, Guid)' instead.")]
        Task<Resource> GetLanguageResourceForTemplate(string templateId, string languageResourceId);

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
        Task<LanguageResource> GetLanguageResourceForTemplate(Guid templateId, Guid languageResourceId);

        [Obsolete("This method is obsolete. Call 'DeleteLanguageResourceForTemplate(Guid, Guid)' instead.")]
        Task DeleteLanguageResourceForTemplate(string templateId, string languageResourceId);

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
        Task DeleteLanguageResourceForTemplate(Guid languageResourceTemplateId, Guid languageResourceId);

        [Obsolete("This method is obsolete. Call 'UpdateLanguageResourceForTemplate(Guid, Guid, LanguageResource)' instead.")]
        Task UpdateLanguageResourceForTemplate(string templateId, string languageResourceId, Resource resourceRequest);

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
        Task UpdateLanguageResourceForTemplate(Guid languageResourceTemplateId, Guid languageResourceId, LanguageResource resourceRequest);

        [Obsolete("This method is obsolete. Call 'ResetLanguageResourceToDefault(Guid, Guid)' instead.")]
        Task ResetToDefaultLanguageResource(string templateId, string languageResourceId);

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
        Task ResetLanguageResourceToDefault(Guid languageResourceTemplateId, Guid languageResourceId);

        [Obsolete("This method is obsolete. Call 'ImportFileForLanguageResource(Guid, Guid, byte[])' instead.")]
        Task ImportFileForLanguageResource(string templateId, string languageResourceId, byte[] file);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="templateId"></param>
        /// <param name="languageResourceId"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        Task ImportFileForLanguageResource(Guid languageResourceTemplateId, Guid languageResourceId, byte[] file);

        [Obsolete("This method is obsolete. Call 'ExportFileForLanguageResource(Guid, Guid)' instead.")]
        Task<byte[]> ExportFileForLanguageResource(string templateId, string languageResourceId);

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
        Task<byte[]> ExportFileForLanguageResource(Guid languageResourceTemplateId, Guid languageResourceId);
        #endregion

        #region Language resource template methods
        /// <summary>
        /// Gets all language resource templates .
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns><see cref="LanguageResourceTemplates"/> which contains a list of language resource templates </returns>
        Task<LanguageResourceTemplates> GetAllLanguageResourceTemplates();

        [Obsolete("This method is obsolete. Call 'GetLanguageResourceTemplate(Guid)' instead.")]
        Task<LanguageResourceTemplate> GetTemplateById(string templateId);

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
        Task<LanguageResourceTemplate> GetLanguageResourceTemplate(Guid languageResourceTemplateId);

        [Obsolete("This method is obsolete. Call 'UpdateLanguageResourceTemplate(Guid, UpdateTemplateRequest)' instead.")]
        Task EditTemplate(string templateId, FieldTemplateRequest request);

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
        Task UpdateLanguageResourceTemplate(Guid languageResourceTemplateId, UpdateTemplateRequest request);

        /// <summary>
        ///Creates a  language resource template  .
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> Created template id</returns>
        Task<string> CreateTemplate(LanguageResourceTemplate templateRequest);

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
        Task<Guid> CreateLanguageResourceTemplate(CreateLanguageResourceTemplateRequest request);

        [Obsolete("This method is obsolete. Call 'DeleteLanguageResourceTemplate(Guid)' instead.")]
        Task DeleteTemplate(string languageResourceTemplateId);

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
        Task DeleteLanguageResourceTemplate(Guid languageResourceTemplateId);
        #endregion

    }
}
