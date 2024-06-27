using Sdl.Community.GroupShareKit.Exceptions;
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

        /// <summary>
        /// Gets specified tm<see cref="TranslationMemoryDetails"/>.
        /// </summary>
        /// <remarks>
        /// <param name="tmId">translation memory id</param>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>  <see cref="TranslationMemoryDetails"/></returns>
        Task<TranslationMemoryDetails> GetTmById(string tmId);

        Task<TranslationMemoryDetails> GetTranslationMemoryById(Guid translationMemoryId);

        /// <summary>
        /// Before you create a TM please make sure you HAVE CREATED A TEMPLATE FIELD and a LANGUAGE RESOURCE TEMPLATE.
        /// USE these ids in the create request 
        /// Creates a Translation Memory/>.
        /// </summary>
        /// <remarks>
        /// <param name="tm">translation memory request <see cref="CreateTmRequest"/> </param>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>  Translation memory Id</returns>
        Task<string> CreateTm(CreateTmRequest tm);

        Task<Guid> CreateTranslationMemory(CreateTranslationMemoryRequest request);

        /// <summary>
        /// Deletes<see cref="Models.Response.TranslationMemory.TranslationMemory"/> .
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task DeleteTm(string tmId);

        Task DeleteTranslationMemory(Guid translationMemoryId);

        /// <summary>
        /// Updates<see cref="Models.Response.TranslationMemory.TranslationMemory"/> .
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task Update(string tmId, TranslationMemoryDetails tm);

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
        /// Schedules a recompute statistics operation
        /// <param name="request"><see cref="FuzzyRequest"/></param>
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
        /// <returns><see cref="FuzzyIndexResponse"/></returns>
        Task<FuzzyIndexResponse> RecomputeStatistics(string tmId, FuzzyRequest request);

        /// <summary>
        /// Schedules a reindex operation
        /// <param name="request"><see cref="FuzzyRequest"/></param>
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
        /// <returns><see cref="FuzzyIndexResponse"/></returns>
        Task<FuzzyIndexResponse> Reindex(string tmId, FuzzyRequest request);
        /// <summary>
        /// Gets <see cref="LanguageDirection"/> for tm
        /// </summary>
        /// <remarks>
        /// <param name="tmId">translation memory id</param>
        /// <param name="languageDirectionId">language direction id</param>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>  <see cref="LanguageDirection"/></returns>
        Task<LanguageDirection> GetLanguageDirectionForTm(string tmId, string languageDirectionId);

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
        Task<TranslationUnitResponse> AddAllTranslationUnits(TranslationUnitRequest unitRequest, string tmId,
            FieldTemplate fieldTemplate);

        /// <summary>
        /// Gets specified translation unit for TM
        /// <param name="request"><see cref="TranslationUnitDetailsRequest"/></param>
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
        /// <returns><see cref="TranslationUnitDetailsResponse"/></returns>
        Task<TranslationUnitDetailsResponse> GetTranslationUnitForTm(string tmId, TranslationUnitDetailsRequest request);

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
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
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
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
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
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
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
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        ///<returns><see cref="Containers"/></returns>
        Task<Containers> GetContainers();

        /// <summary>
        /// Creates a new container
        /// </summary>
        /// <remarks>
        /// <param name="request"><see cref="ContainerRequest"/></param>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>Container's Id</returns>
        Task<string> CreateContainer(ContainerRequest request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Guid> CreateContainer(CreateContainerRequest request);

        /// <summary>
        ///Returns specified container
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        ///<returns><see cref="Container"/></returns>
        Task<Container> GetContainerById(string containerId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="containerId"></param>
        /// <returns></returns>
        Task<Container> GetContainer(Guid containerId);

        /// <summary>
        /// Deletes a container
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task DeleteContainer(string containerId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="containerId"></param>
        /// <returns></returns>
        Task DeleteContainer(Guid containerId);

        /// <summary>
        /// Updates a container
        /// </summary>
        /// <remarks>
        /// <param name="request"><see cref="UpdateContainerRequest"/></param>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task UpdateContainer(string containerId, UpdateContainerRequest request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="containerId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task UpdateContainer(Guid containerId, UpdateContainerRequest request);

        #endregion

        #region Database server
        /// <summary>
        /// Returns a list of all available database servers
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns><see cref="DatabaseServerResponse"/></returns>
        Task<DatabaseServerResponse> GetDbServers();

        /// <summary>
        ///Returns specified database server
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// <param name="serverId">Server id</param>
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        ///<returns><see cref="DatabaseServer"/></returns>
        Task<DatabaseServer> GetDbServerById(string serverId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverId"></param>
        /// <returns></returns>
        Task<DatabaseServer> GetDbServer(Guid serverId);

        /// <summary>
        /// Creates a new database server
        /// </summary>
        /// <remarks>
        /// <param name="request"><see cref="DatabaseServerRequest"/></param>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>The id of db server</returns>
        Task<string> CreateDbServer(DatabaseServerRequest request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Guid> CreateDbServer(CreateDatabaseServerRequest request);

        /// <summary>
        /// Deletes a database server
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// <param name="serverId">Server id</param>
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task DeleteDbServer(string serverId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverId"></param>
        /// <returns></returns>
        Task DeleteDbServer(Guid serverId);

        /// <summary>
        /// Updates a database server
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// <param name="serverId">Server id</param>
        /// <param name="request"><see cref="RequestDbServer"/></param>
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task UpdateDbServer(string serverId, RequestDbServer request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task UpdateDbServer(Guid serverId, UpdateDatabaseServerRequest request);

        #endregion

        #region Field methods
        /// <summary>
        /// Creates <see cref="FieldTemplate"/>.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>Created field template id</returns>
        Task<string> CreateFieldTemplate(FieldTemplate template);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Guid> CreateFieldTemplate(CreateFieldTemplateRequest request);

        /// <summary>
        /// Gets <see cref="FieldTemplates"/>.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        ///<returns>Returns <see cref="FieldTemplates"/> which contains a list of <see cref="FieldTemplate"/></returns>
        Task<FieldTemplates> GetFieldTemplates();

        /// <summary>
        /// Gets <see cref="FieldTemplate"/> by id.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        ///<returns><see cref="FieldTemplate"/></returns>
        Task<FieldTemplate> GetFieldTemplateById(string id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldTemplateId"></param>
        /// <returns></returns>
        Task<FieldTemplate> GetFieldTemplate(Guid fieldTemplateId);

        /// <summary>
        /// Updates <see cref="FieldTemplate"/> 
        /// </summary>
        /// <remarks>
        /// <param name="templateRequest"><see cref="FieldTemplateRequest"/></param>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        ///<returns><see cref="FieldTemplate"/> id</returns>
        Task UpdateFieldTemplate(string templateId, FieldTemplateRequest templateRequest);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldTemplateId"></param>
        /// <param name="templateRequest"></param>
        /// <returns></returns>
        Task UpdateFieldTemplate(Guid fieldTemplateId, UpdateTemplateRequest templateRequest);

        /// <summary>
        /// Deletes <see cref="FieldTemplate"/> by id.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task DeleteFieldTemplate(string templateId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldTemplateId"></param>
        /// <returns></returns>
        Task DeleteFieldTemplate(Guid fieldTemplateId);

        /// <summary>
        /// Updates <see cref="FieldTemplate"/> 
        /// </summary>
        /// <remarks>
        /// <param name="request"><see cref="FieldTemplatePatchRequest"/></param>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task AddOperationsForFieldTemplate(string templateId, FieldTemplatePatchRequest request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldTemplateId"></param>
        /// <param name="operations"></param>
        /// <returns></returns>
        Task AddOperationsForFieldTemplate(Guid fieldTemplateId, List<Operation> operations);

        /// <summary>
        /// Gets a list of Fields for a specific Field Template ID
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
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
        /// <summary>
        /// Gets all language resources <see cref="Resource"/>.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>  A list of <see cref="Resource"/></returns>
        Task<IReadOnlyList<Resource>> GetLanguageResourcesForTemplate(string templateId);

        /// <summary>
        /// Creates a  language resources <see cref="Resource"/> for specified template.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> Resource id</returns>
        Task<string> CreateLanguageResourceForTemplate(string templateId, Resource request);

        /// <summary>
        /// Gets language resource service defaults type.
        /// </summary>
        /// <remarks>
        /// <param name="defaultsRequest"><see cref="ResourceServiceDefaultsRequest"/></param>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> Resource <see cref="ResourceServiceDefaultsRequest"/></returns>
        Task<Resource> GetDefaultsType(ResourceServiceDefaultsRequest defaultsRequest);

        /// <summary>
        /// Gets   language resource <see cref="Resource"/> for specified template.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> <see cref="Resource"/></returns>
        Task<Resource> GetLanguageResourceForTemplate(string templateId, string languageResourceId);

        /// <summary>
        /// Deletes   language resource <see cref="Resource"/> for specified template.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task DeleteLanguageResourceForTemplate(string templateId, string languageResourceId);

        /// <summary>
        /// Updates   language resource <see cref="Resource"/> for specified template.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task UpdateLanguageResourceForTemplate(string templateId, string languageResourceId,
            Resource resourceRequest);

        /// <summary>
        ///Reset to default Culture values a specific Language Resource in a specific Language Resource Template
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task ResetToDefaultLanguageResource(string templateId, string languageResourceId);

        /// <summary>
        /// Imports a file with data for a specific Language Resource Template 
        /// Document type be text (.txt)
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task ImportFileForLanguageResource(string templateId, string languageResourceId, byte[] file);

        /// <summary>
        /// Exports a file with data for a specific Language Resource Template 
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>byte[] that represents the document content</returns>
        Task<byte[]> ExportFileForLanguageResource(string templateId, string languageResourceId);
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

        /// <summary>
        /// Gets specified  language resource template .
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns><see cref="LanguageResourceTemplate"/> </returns>
        Task<LanguageResourceTemplate> GetTemplateById(string templateId);

        Task<LanguageResourceTemplate> GetLanguageResourceTemplate(Guid languageResourceTemplateId);

        /// <summary>
        /// Updates a language resource template
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// <param name="templateId">Template id</param>
        /// <param name="request"><see cref="FieldTemplateRequest"/>New values</param>
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task EditTemplate(string templateId, FieldTemplateRequest request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="languageResourceTemplateId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
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

        Task<Guid> CreateLanguageResourceTemplate(CreateLanguageResourceTemplateRequest request);

        /// <summary>
        ///Deletes a  language resource template  .
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41235/docs/ui/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task DeleteTemplate(string languageResourceTemplateId);

        Task DeleteLanguageResourceTemplate(Guid languageResourceTemplateId);
        #endregion

    }
}
