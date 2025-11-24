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
        /// Gets  <see cref="Termbase"/>s.
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
        /// Gets  <see cref="TermbaseDetails"/>s.
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
        /// Gets  <see cref="Filter"/>s.
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
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<TermbasesV2> GetTermbasesV2()
        {
            return await ApiConnection.Get<TermbasesV2>(ApiUrls.GetTermbasesV2(), null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <returns></returns>
        public async Task<XmlObject> GetTermbaseDefinition(Guid termbaseId)
        {
            Ensure.ArgumentNotNull(termbaseId, "termbaseId");

            return await ApiConnection.Get<XmlObject>(ApiUrls.GetTermbaseDefinition(termbaseId), null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <returns></returns>
        public async Task<TermbaseV2> GetTermbasePublicObjects(Guid termbaseId)
        {
            Ensure.ArgumentNotNull(termbaseId, "termbaseId");

            return await ApiConnection.Get<TermbaseV2>(ApiUrls.GetTermbasePublicObjects(termbaseId), null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <returns></returns>
        public async Task DeleteTermbase(Guid termbaseId)
        {
            Ensure.ArgumentNotNull(termbaseId, "termbaseId");

            await ApiConnection.Delete(ApiUrls.GetTermbaseDefinition(termbaseId));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termbaseName"></param>
        /// <returns></returns>
        public async Task<Guid> GetTermbaseGuidByName(TermbaseNameModel termbaseName)
        {
            Ensure.ArgumentNotNull(termbaseName, "termbaseName");

            return await ApiConnection.Post<Guid>(ApiUrls.GetTermbaseGuidByName(), termbaseName, "application/json");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <param name="conceptId"></param>
        /// <returns></returns>
        public async Task<ConceptV2> GetConceptV2(Guid termbaseId, int conceptId)
        {
            Ensure.ArgumentNotNull(termbaseId, "termbaseId");
            Ensure.ArgumentNotNull(conceptId, "conceptId");

            return await ApiConnection.Get<ConceptV2>(ApiUrls.ConceptV2(termbaseId, conceptId), null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <param name="conceptId"></param>
        /// <returns></returns>
        public async Task<ConceptXmlObject> GetConceptXml(Guid termbaseId, int conceptId)
        {
            Ensure.ArgumentNotNull(termbaseId, "termbaseId");
            Ensure.ArgumentNotNull(conceptId, "conceptId");

            return await ApiConnection.Get<ConceptXmlObject>(ApiUrls.ConceptXml(termbaseId, conceptId), null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <param name="concept"></param>
        /// <returns></returns>
        public async Task<int> CreateConcept(Guid termbaseId, ConceptV2 concept)
        {
            Ensure.ArgumentNotNull(termbaseId, "termbaseId");
            Ensure.ArgumentNotNull(concept, "concept");

            return await ApiConnection.Post<int>(ApiUrls.ConceptsV2(termbaseId), concept, "application/json");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <param name="concept"></param>
        /// <returns></returns>
        public async Task UpdateConcept(Guid termbaseId, ConceptV2 concept)
        {
            Ensure.ArgumentNotNull(termbaseId, "termbaseId");
            Ensure.ArgumentNotNull(concept, "concept");

            await ApiConnection.Put<string>(ApiUrls.ConceptsV2(termbaseId), concept);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <param name="conceptXml"></param>
        /// <returns></returns>
        public async Task<int> CreateConceptXml(Guid termbaseId, ConceptXmlObject conceptXml)
        {
            Ensure.ArgumentNotNull(termbaseId, "termbaseId");
            Ensure.ArgumentNotNull(conceptXml, "conceptXml");

            return await ApiConnection.Post<int>(ApiUrls.ConceptXmls(termbaseId), conceptXml, "application/json");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <param name="conceptXml"></param>
        /// <returns></returns>
        public async Task UpdateConceptXml(Guid termbaseId, ConceptXmlObject conceptXml)
        {
            Ensure.ArgumentNotNull(termbaseId, "termbaseId");
            Ensure.ArgumentNotNull(conceptXml, "conceptXml");

            await ApiConnection.Put<string>(ApiUrls.ConceptXmls(termbaseId), conceptXml);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ConceptXmlObject> SearchConcept(Guid termbaseId, SearchConceptRequest request)
        {
            Ensure.ArgumentNotNull(termbaseId, "termbaseId");
            Ensure.ArgumentNotNull(request, "request");

            return await ApiConnection.Post<ConceptXmlObject>(ApiUrls.SearchConcept(termbaseId), request, "application/json");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <param name="conceptId"></param>
        /// <returns></returns>
        public async Task LockConcept(Guid termbaseId, int conceptId)
        {
            Ensure.ArgumentNotNull(termbaseId, "termbaseId");
            Ensure.ArgumentNotNull(conceptId, "conceptId");

            await ApiConnection.Post(ApiUrls.LockConcept(termbaseId, conceptId));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <param name="conceptId"></param>
        /// <param name="stealLock"></param>
        /// <returns></returns>
        public async Task LockConcept(Guid termbaseId, int conceptId, bool stealLock)
        {
            Ensure.ArgumentNotNull(termbaseId, "termbaseId");
            Ensure.ArgumentNotNull(conceptId, "conceptId");
            Ensure.ArgumentNotNull(stealLock, "stealLock");

            await ApiConnection.Post(ApiUrls.LockConcept(termbaseId, conceptId, stealLock));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <param name="conceptId"></param>
        /// <returns></returns>
        public async Task UnlockConcept(Guid termbaseId, int conceptId)
        {
            Ensure.ArgumentNotNull(termbaseId, "termbaseId");
            Ensure.ArgumentNotNull(conceptId, "conceptId");

            await ApiConnection.Post(ApiUrls.UnlockConcept(termbaseId, conceptId));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <param name="conceptId"></param>
        /// <returns></returns>
        public async Task DeleteConceptV2(Guid termbaseId, int conceptId)
        {
            Ensure.ArgumentNotNull(termbaseId, "termbaseId");
            Ensure.ArgumentNotNull(conceptId, "conceptId");

            await ApiConnection.Delete(ApiUrls.ConceptV2(termbaseId, conceptId));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<TermbaseSearchResult> SearchTermbase(Guid termbaseId, string request)
        {
            Ensure.ArgumentNotNull(termbaseId, "termbaseId");
            Ensure.ArgumentNotNullOrEmptyString(request, "request");

            return await ApiConnection.Post<TermbaseSearchResult>(ApiUrls.SearchTermbase(termbaseId), request, "application/json");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<TermbaseBrowseResult> BrowseExTermbase(Guid termbaseId, string request)
        {
            Ensure.ArgumentNotNull(termbaseId, "termbaseId");
            Ensure.ArgumentNotNullOrEmptyString(request, "request");

            return await ApiConnection.Post<TermbaseBrowseResult>(ApiUrls.BrowseExTermbase(termbaseId), request, "application/json");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <param name="catalogObjectId"></param>
        /// <returns></returns>
        public async Task<XmlObject> GetCatalogObject(Guid termbaseId, int catalogObjectId)
        {
            Ensure.ArgumentNotNull(termbaseId, "termbaseId");
            Ensure.ArgumentNotNull(catalogObjectId, "catalogObjectId");

            return await ApiConnection.Get<XmlObject>(ApiUrls.CatalogObject(termbaseId, catalogObjectId), null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <param name="catalogObjectId"></param>
        /// <returns></returns>
        public async Task DeleteCatalogObject(Guid termbaseId, int catalogObjectId)
        {
            Ensure.ArgumentNotNull(termbaseId, "termbaseId");
            Ensure.ArgumentNotNull(catalogObjectId, "catalogObjectId");

            await ApiConnection.Delete(ApiUrls.CatalogObject(termbaseId, catalogObjectId));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <param name="imageId"></param>
        /// <returns></returns>
        public async Task<byte[]> GetMultimediaV2(Guid termbaseId, int imageId)
        {
            Ensure.ArgumentNotNull(termbaseId, "termbaseId");
            Ensure.ArgumentNotNull(imageId, "imageId");

            return await ApiConnection.Get<byte[]>(ApiUrls.TermbaseMultimediaV2(termbaseId, imageId), null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<int> AddMultimediaV2(Guid termbaseId, MultimediaRequest request)
        {
            Ensure.ArgumentNotNull(termbaseId, "termbaseId");
            Ensure.ArgumentNotNull(request, "request");

            return await ApiConnection.Post<int>(ApiUrls.AddTermbaseMultimediaV2(termbaseId), request, "application/json");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <param name="conceptId"></param>
        /// <returns></returns>
        public async Task DeleteMultimediaV2(Guid termbaseId, int conceptId)
        {
            Ensure.ArgumentNotNull(termbaseId, "termbaseId");
            Ensure.ArgumentNotNull(conceptId, "conceptId");

            await ApiConnection.Delete(ApiUrls.TermbaseMultimediaV2(termbaseId, conceptId));
        }




    }
}
