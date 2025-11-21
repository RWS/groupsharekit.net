using Sdl.Community.GroupShareKit.Exceptions;
using Sdl.Community.GroupShareKit.Models.Response;
using Sdl.Community.GroupShareKit.Models.Response.MultiTerm;
using System;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Clients
{
    public interface ITerminology
    {
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
        Task<Termbase> GetTermbases();

        /// <summary>
        /// Gets  <see cref="TermbaseDetails"/>s.
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> <see cref="TermbaseDetails"/></returns>
        Task<TermbaseResponse> GetTermbaseById(string termbaseId);

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
        /// <returns><see cref="Filter"/></returns>
        Task<FilterResponse> GetFilters(string termbaseId);


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
        /// <returns><see cref="SearchResponse"/></returns>
        Task<SearchResponse> SearchTerm(SearchTermRequest request);

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
        Task<ConceptDetails> GetConcept(ConceptResponse response);

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
        Task<ConceptDetails> GetConcept(string termbaseId, string conceptId);

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
        Task<ConceptDetails> EditConcept(string termbaseId, ConceptDetails concept);

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
        Task<ConceptDetails> CreateConcept(TermbaseResponse termbase, ConceptRequest conceptRequest);

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
        Task<ConceptDetails> CreateConceptWithCustomEntryClass(string entryId, string termbaseId, ConceptRequest conceptRequest);

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
        Task DeleteConcept(string termbaseId, string conceptId);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<TermbasesV2> GetTermbasesV2();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <returns></returns>
        Task<XmlObject> GetTermbaseDefinition(Guid termbaseId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <returns></returns>
        Task<TermbaseV2> GetTermbasePublicObjects(Guid termbaseId);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task DeleteTermbase(Guid termbaseId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termbaseName"></param>
        /// <returns></returns>
        Task<Guid> GetTermbaseGuidByName(TermbaseNameModel termbaseName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <param name="conceptId"></param>
        /// <returns></returns>
        Task<ConceptV2> GetConceptV2(Guid termbaseId, int conceptId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <param name="conceptId"></param>
        /// <returns></returns>
        Task<ConceptXmlObject> GetConceptXml(Guid termbaseId, int conceptId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <param name="concept"></param>
        /// <returns></returns>
        Task<int> CreateConcept(Guid termbaseId, ConceptV2 concept);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <param name="concept"></param>
        /// <returns></returns>
        Task UpdateConcept(Guid termbaseId, ConceptV2 concept);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <param name="conceptXml"></param>
        /// <returns></returns>
        Task<int> CreateConceptXml(Guid termbaseId, ConceptXmlObject conceptXml);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <param name="conceptXml"></param>
        /// <returns></returns>
        Task UpdateConceptXml(Guid termbaseId, ConceptXmlObject conceptXml);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ConceptXmlObject> SearchConcept(Guid termbaseId, SearchConceptRequest request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <param name="conceptId"></param>
        /// <returns></returns>
        Task LockConcept(Guid termbaseId, int conceptId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <param name="conceptId"></param>
        /// <param name="stealLock"></param>
        /// <returns></returns>
        Task LockConcept(Guid termbaseId, int conceptId, bool stealLock);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <param name="conceptId"></param>
        /// <returns></returns>
        Task UnlockConcept(Guid termbaseId, int conceptId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <param name="conceptId"></param>
        /// <returns></returns>
        Task DeleteConceptV2(Guid termbaseId, int conceptId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<TermbaseSearchResult> SearchTermbase(Guid termbaseId, string request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<TermbaseBrowseResult> BrowseExTermbase(Guid termbaseId, string request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <param name="catalogObjectId"></param>
        /// <returns></returns>
        Task<XmlObject> GetCatalogObject(Guid termbaseId, int catalogObjectId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <param name="catalogObjectId"></param>
        /// <returns></returns>
        Task DeleteCatalogObject(Guid termbaseId, int catalogObjectId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <param name="imageId"></param>
        /// <returns></returns>
        Task<byte[]> GetMultimediaV2(Guid termbaseId, int imageId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <param name=""></param>
        /// <returns></returns>
        Task<int> AddMultimediaV2(Guid termbaseId, MultimediaRequest request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <param name="conceptId"></param>
        /// <returns></returns>
        Task DeleteMultimediaV2(Guid termbaseId, int conceptId);

    }
}
