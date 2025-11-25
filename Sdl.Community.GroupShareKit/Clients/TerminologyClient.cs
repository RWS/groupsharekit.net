using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Sdl.Community.GroupShareKit.Exceptions;
using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Http;
using Sdl.Community.GroupShareKit.Models.Response;
using Sdl.Community.GroupShareKit.Models.Response.MultiTerm;
using Sdl.Community.GroupShareKit.Models.Response.MultiTerm.Browse;
using Sdl.Community.GroupShareKit.Models.Response.MultiTerm.Concepts;
using Sdl.Community.GroupShareKit.Models.Response.MultiTerm.Images;
using Sdl.Community.GroupShareKit.Models.Response.MultiTerm.Search;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class TerminologyClient : ApiClient, ITerminology
    {
        public TerminologyClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        /// <summary>
        /// Gets <see cref="Termbase"/>s.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
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

        /// <summary>
        /// Gets <see cref="TermbaseDetails"/>s.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> <see cref="TermbaseDetails"/></returns>
        public async Task<TermbaseResponse> GetTermbaseById(string termbaseId)
        {
            Ensure.ArgumentNotNullOrEmptyString(termbaseId, "termbaseId");
            return await ApiConnection.Get<TermbaseResponse>(ApiUrls.GetTermbaseById(termbaseId), null);
        }

        /// <summary>
        /// Gets <see cref="Filter"/>s.
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> <see cref="Filter"/></returns>
        public async Task<FilterResponse> GetFilters(string termbaseId)
        {
            Ensure.ArgumentNotNullOrEmptyString(termbaseId, "termbaseId");
            return await ApiConnection.Get<FilterResponse>(ApiUrls.GetFilers(termbaseId), null);
        }

        /// <summary>
        /// Search for a term in a termbase  
        /// </summary>
        /// <param name="request"><see cref="SearchTermRequest"/></param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> <see cref="SearchResponse"/></returns>
        public async Task<SearchResponse> SearchTerm(SearchTermRequest request)
        {
            Ensure.ArgumentNotNull(request, "request");
            return await ApiConnection.Get<SearchResponse>(ApiUrls.Search(), request.ToParametersDictionary());
        }

        /// <summary>
        /// Gets <see cref="ConceptDetails"/> 
        /// </summary>
        /// <param name="response"><see cref="ConceptResponse"/></param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> <see cref="ConceptDetails"/></returns>
        public async Task<ConceptDetails> GetConcept(ConceptResponse response)
        {
            Ensure.ArgumentNotNull(response, "request");
            return await ApiConnection.Get<ConceptDetails>(ApiUrls.GetConcepts(response), null);
        }

        /// <summary>
        /// Gets <see cref="ConceptDetails"/> 
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> <see cref="ConceptDetails"/></returns>
        public async Task<ConceptDetails> GetConcept(string termbaseId, string conceptId)
        {
            Ensure.ArgumentNotNullOrEmptyString(termbaseId, "termbaseId");
            Ensure.ArgumentNotNullOrEmptyString(conceptId, "conceptId");
            return await ApiConnection.Get<ConceptDetails>(ApiUrls.GetConcepts(termbaseId, conceptId), null);
        }

        /// <summary>
        /// Updates a entry in termbase<see cref="ConceptDetails"/> 
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> Updated<see cref="ConceptDetails"/> </returns>
        public async Task<ConceptDetails> EditConcept(string termbaseId, ConceptDetails concept)
        {
            Ensure.ArgumentNotNullOrEmptyString(termbaseId, "termbaseId");
            Ensure.ArgumentNotNull(concept, "concept");

            return await ApiConnection.Put<ConceptDetails>(ApiUrls.GetConcepts(termbaseId), concept);
        }

        /// <summary>
        /// Creates termbase concept <see cref="Concept"/> with the default entry class Id
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>Created concept <see cref="ConceptDetails"/></returns>
        public async Task<ConceptDetails> CreateConcept(TermbaseResponse termbase, ConceptRequest conceptRequest)
        {
            Ensure.ArgumentNotNull(termbase, "termbase");
            Ensure.ArgumentNotNull(conceptRequest, "conceptRequest");

            var defaultEntryClass = termbase.Termbase.EntryClasses.FirstOrDefault(d => d.IsDefault);
            var concept = new ConceptDetails
            {
                Concept = new Concept
                {
                    EntryClass = new Entry
                    {
                        Id = defaultEntryClass?.Id
                    },
                    Attributes = conceptRequest.Attributes,
                    Languages = conceptRequest.Languages,
                    Transactions = conceptRequest.Transactions
                }
            };

            return await ApiConnection.Post<ConceptDetails>(ApiUrls.GetConcepts(termbase.Termbase.Id), concept, "application/json");
        }

        /// <summary>
        /// Creates termbase concept <see cref="Concept"/> with custom entry class Id
        /// </summary>
        /// <remarks>
        /// <param name="entryId">Entry class id</param>
        /// <param name="conceptRequest">Concept request <see cref="ConceptRequest"/></param>
        /// <param name="termbaseId">Termbase id</param>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>Created concept <see cref="ConceptDetails"/></returns>
        public async Task<ConceptDetails> CreateConceptWithCustomEntryClass(string entryId, string termbaseId, ConceptRequest conceptRequest)
        {
            Ensure.ArgumentNotNull(conceptRequest, "conceptRequest");
            Ensure.ArgumentNotNullOrEmptyString(entryId, "Entry class id");

            var concept = new ConceptDetails
            {
                Concept = new Concept
                {
                    EntryClass = new Entry
                    {
                        Id = entryId
                    },
                    Attributes = conceptRequest.Attributes,
                    Languages = conceptRequest.Languages,
                    Transactions = conceptRequest.Transactions
                }
            };

            return await ApiConnection.Post<ConceptDetails>(ApiUrls.GetConcepts(termbaseId), concept, "application/json");
        }

        /// <summary>
        /// Deletes termbase concept <see cref="Concept"/> 
        /// </summary>
        /// <param name="termbaseId">Termbase id</param>
        /// <param name="conceptId">Concept id</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        public async Task DeleteConcept(string termbaseId, string conceptId)
        {
            Ensure.ArgumentNotNullOrEmptyString(termbaseId, "termbaseId");
            Ensure.ArgumentNotNullOrEmptyString(conceptId, "conceptId");

            await ApiConnection.Delete(ApiUrls.GetConcepts(termbaseId, conceptId));
        }

        /// <summary>
        /// Retrieves all termbases from the v2 API.
        /// </summary>
        public async Task<TermbasesV2> GetTermbasesV2()
        {
            return await ApiConnection.Get<TermbasesV2>(ApiUrls.GetTermbasesV2(), null);
        }

        /// <summary>
        /// Retrieves termbases from the v2 API using pagination.
        /// </summary>
        /// <param name="page">The page number to retrieve.</param>
        /// <param name="limit">The maximum number of items per page.</param>
        public async Task<TermbasesV2> GetTermbasesV2(int page, int limit)
        {
            return await ApiConnection.Get<TermbasesV2>(ApiUrls.GetTermbasesV2(page, limit), null);
        }

        /// <summary>
        /// Retrieves the termbase definition.
        /// </summary>
        public async Task<XmlObject> GetTermbaseDefinitionV2(Guid termbaseId)
        {
            Ensure.ArgumentNotNull(termbaseId, "termbaseId");

            return await ApiConnection.Get<XmlObject>(ApiUrls.GetTermbaseDefinitionV2(termbaseId), null);
        }

        /// <summary>
        /// Retrieves the termbase public objects.
        /// </summary>
        public async Task<TermbaseV2> GetTermbasePublicObjectsV2(Guid termbaseId)
        {
            Ensure.ArgumentNotNull(termbaseId, "termbaseId");

            return await ApiConnection.Get<TermbaseV2>(ApiUrls.GetTermbasePublicObjectsV2(termbaseId), null);
        }

        /// <summary>
        /// Deletes a termbase.
        /// </summary>
        public async Task DeleteTermbaseV2(Guid termbaseId)
        {
            Ensure.ArgumentNotNull(termbaseId, "termbaseId");

            await ApiConnection.Delete(ApiUrls.GetTermbaseDefinitionV2(termbaseId));
        }

        /// <summary>
        /// Retrieves a termbase GUID by its friendly name.
        /// </summary>
        public async Task<Guid> GetTermbaseGuidByNameV2(TermbaseNameModel termbaseName)
        {
            Ensure.ArgumentNotNull(termbaseName, "termbaseName");

            return await ApiConnection.Post<Guid>(ApiUrls.GetTermbaseGuidByNameV2(), termbaseName, "application/json");
        }

        /// <summary>
        /// Retrieves a termbase concept from the v2 API.
        /// </summary>
        public async Task<ConceptV2> GetConceptV2(Guid termbaseId, int conceptId)
        {
            Ensure.ArgumentNotNull(termbaseId, "termbaseId");
            Ensure.ArgumentNotNull(conceptId, "conceptId");

            return await ApiConnection.Get<ConceptV2>(ApiUrls.ConceptV2(termbaseId, conceptId), null);
        }

        /// <summary>
        /// Retrieves a termbase concept XML from the v2 API.
        /// </summary>
        public async Task<ConceptXmlObject> GetConceptXmlV2(Guid termbaseId, int conceptId)
        {
            Ensure.ArgumentNotNull(termbaseId, "termbaseId");
            Ensure.ArgumentNotNull(conceptId, "conceptId");

            return await ApiConnection.Get<ConceptXmlObject>(ApiUrls.ConceptXml(termbaseId, conceptId), null);
        }

        /// <summary>
        /// Creates a new concept in the specified termbase using the v2 API.
        /// </summary>
        /// <param name="termbaseId">The identifier of the termbase where the concept will be created.</param>
        /// <param name="concept">The concept details associated with the concept.</param>
        public async Task<int> CreateConceptV2(Guid termbaseId, ConceptV2 concept)
        {
            Ensure.ArgumentNotNull(termbaseId, "termbaseId");
            Ensure.ArgumentNotNull(concept, "concept");

            return await ApiConnection.Post<int>(ApiUrls.ConceptsV2(termbaseId), concept, "application/json");
        }

        /// <summary>
        /// Updates an existing concept in the specified termbase using the v2 API.
        /// </summary>
        /// <param name="termbaseId">The identifier of the termbase where the concept exists.</param>
        /// <param name="concept">The updated concept details associated with the concept.</param>
        public async Task UpdateConceptV2(Guid termbaseId, ConceptV2 concept)
        {
            Ensure.ArgumentNotNull(termbaseId, "termbaseId");
            Ensure.ArgumentNotNull(concept, "concept");

            await ApiConnection.Put<string>(ApiUrls.ConceptsV2(termbaseId), concept);
        }

        /// <summary>
        /// Creates a new concept in the specified termbase using the v2 API.
        /// </summary>
        /// <param name="termbaseId">The identifier of the termbase where the concept will be created.</param>
        /// <param name="conceptXml">The concept details associated with the concept.</param>
        public async Task<int> CreateConceptXmlV2(Guid termbaseId, ConceptXmlObject conceptXml)
        {
            Ensure.ArgumentNotNull(termbaseId, "termbaseId");
            Ensure.ArgumentNotNull(conceptXml, "conceptXml");

            return await ApiConnection.Post<int>(ApiUrls.ConceptXmlsV2(termbaseId), conceptXml, "application/json");
        }

        /// <summary>
        /// Updates an existing concept in the specified termbase using the v2 API.
        /// </summary>
        /// <param name="termbaseId">The identifier of the termbase where the concept exists.</param>
        /// <param name="conceptXml">The updated concept details associated with the concept.</param>
        public async Task UpdateConceptXmlV2(Guid termbaseId, ConceptXmlObject conceptXml)
        {
            Ensure.ArgumentNotNull(termbaseId, "termbaseId");
            Ensure.ArgumentNotNull(conceptXml, "conceptXml");

            await ApiConnection.Put<string>(ApiUrls.ConceptXmlsV2(termbaseId), conceptXml);
        }

        /// <summary>
        /// Locks a concept from a termbase.
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <param name="conceptId"></param>
        public async Task LockConceptV2(Guid termbaseId, int conceptId)
        {
            Ensure.ArgumentNotNull(termbaseId, "termbaseId");
            Ensure.ArgumentNotNull(conceptId, "conceptId");

            await ApiConnection.Post(ApiUrls.LockConcept(termbaseId, conceptId));
        }

        /// <summary>
        /// Locks a concept from a termbase.
        /// </summary>
        /// <param name="termbaseId">The identifier of the termbase.</param>
        /// <param name="conceptId">The identifier of the concept.</param>
        /// <param name="stealLock">If set to true, steals the lock previously acquired by the same user.</param>
        /// <returns></returns>
        public async Task LockConceptV2(Guid termbaseId, int conceptId, bool stealLock)
        {
            Ensure.ArgumentNotNull(termbaseId, "termbaseId");
            Ensure.ArgumentNotNull(conceptId, "conceptId");
            Ensure.ArgumentNotNull(stealLock, "stealLock");

            await ApiConnection.Post(ApiUrls.LockConcept(termbaseId, conceptId, stealLock));
        }

        /// <summary>
        /// Unlocks a concept from a termbase.
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <param name="conceptId"></param>
        /// <returns></returns>
        public async Task UnlockConceptV2(Guid termbaseId, int conceptId)
        {
            Ensure.ArgumentNotNull(termbaseId, "termbaseId");
            Ensure.ArgumentNotNull(conceptId, "conceptId");

            await ApiConnection.Post(ApiUrls.UnlockConcept(termbaseId, conceptId));
        }

        /// <summary>
        /// Deletes a concept from a termbase using the v2 API.
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <param name="conceptId"></param>
        public async Task DeleteConceptV2(Guid termbaseId, int conceptId)
        {
            Ensure.ArgumentNotNull(termbaseId, "termbaseId");
            Ensure.ArgumentNotNull(conceptId, "conceptId");

            await ApiConnection.Delete(ApiUrls.ConceptV2(termbaseId, conceptId));
        }

        /// <summary>
        /// Searches terms in a termbase using the v2 API.
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <param name="request"></param>
        public async Task<TermbaseSearchResult> SearchTermbaseV2(Guid termbaseId, TermbaseSearchRequest request)
        {
            Ensure.ArgumentNotNull(termbaseId, "termbaseId");
            Ensure.ArgumentNotNull(request, "request");

            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Converters = { new StringEnumConverter() }
            };

            return await ApiConnection.Post<TermbaseSearchResult>(ApiUrls.SearchTermbase(termbaseId), JsonConvert.SerializeObject(request, settings), "application/json");
        }

        /// <summary>
        /// Searches for a concept in a termbase using the v2 API.
        /// </summary>
        public async Task<ConceptXmlObject> SearchConceptV2(Guid termbaseId, SearchConceptRequest request)
        {
            Ensure.ArgumentNotNull(termbaseId, "termbaseId");
            Ensure.ArgumentNotNull(request, "request");

            return await ApiConnection.Post<ConceptXmlObject>(ApiUrls.SearchConceptsV2(termbaseId), request, "application/json");
        }

        /// <summary>
        /// Browses entries in a termbase using the v2 API.
        /// </summary>
        public async Task<TermbaseBrowseResult> BrowseExTermbaseV2(Guid termbaseId, TermbaseBrowseRequest request)
        {
            Ensure.ArgumentNotNull(termbaseId, "termbaseId");
            Ensure.ArgumentNotNull(request, "request");

            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Converters = { new StringEnumConverter() }
            };

            return await ApiConnection.Post<TermbaseBrowseResult>(ApiUrls.BrowseExTermbase(termbaseId), JsonConvert.SerializeObject(request, settings), "application/json");
        }

        /// <summary>
        /// Retrieves a catalog object from a termbase using the v2 API.
        /// </summary>
        public async Task<XmlObject> GetCatalogObjectV2(Guid termbaseId, int catalogObjectId)
        {
            Ensure.ArgumentNotNull(termbaseId, "termbaseId");
            Ensure.ArgumentNotNull(catalogObjectId, "catalogObjectId");

            return await ApiConnection.Get<XmlObject>(ApiUrls.CatalogObjectV2(termbaseId, catalogObjectId), null);
        }

        /// <summary>
        /// Deletes a catalog object from a termbase using the v2 API.
        /// </summary>
        public async Task DeleteCatalogObjectV2(Guid termbaseId, int catalogObjectId)
        {
            Ensure.ArgumentNotNull(termbaseId, "termbaseId");
            Ensure.ArgumentNotNull(catalogObjectId, "catalogObjectId");

            await ApiConnection.Delete(ApiUrls.CatalogObjectV2(termbaseId, catalogObjectId));
        }

        /// <summary>
        /// Retrieves a multimedia (image) file from a termbase using the v2 API.
        /// </summary>
        public async Task<byte[]> GetMultimediaV2(Guid termbaseId, int imageId)
        {
            Ensure.ArgumentNotNull(termbaseId, "termbaseId");
            Ensure.ArgumentNotNull(imageId, "imageId");

            return await ApiConnection.Get<byte[]>(ApiUrls.TermbaseMultimediaV2(termbaseId, imageId), null);
        }

        /// <summary>
        /// Creates a multimedia (image) file in a termbase using the v2 API.
        /// </summary>
        public async Task<int> AddMultimediaV2(Guid termbaseId, MultimediaRequest request)
        {
            Ensure.ArgumentNotNull(termbaseId, "termbaseId");
            Ensure.ArgumentNotNull(request, "request");

            return await ApiConnection.Post<int>(ApiUrls.AddTermbaseMultimediaV2(termbaseId), request, "application/json");
        }

        /// <summary>
        /// Deletes a multimedia (image) file from a termbase using the v2 API.
        /// </summary>
        public async Task DeleteMultimediaV2(Guid termbaseId, int conceptId)
        {
            Ensure.ArgumentNotNull(termbaseId, "termbaseId");
            Ensure.ArgumentNotNull(conceptId, "conceptId");

            await ApiConnection.Delete(ApiUrls.TermbaseMultimediaV2(termbaseId, conceptId));
        }

    }
}
