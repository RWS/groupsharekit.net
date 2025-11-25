using Sdl.Community.GroupShareKit.Exceptions;
using Sdl.Community.GroupShareKit.Models.Response;
using Sdl.Community.GroupShareKit.Models.Response.MultiTerm;
using Sdl.Community.GroupShareKit.Models.Response.MultiTerm.Browse;
using Sdl.Community.GroupShareKit.Models.Response.MultiTerm.Concepts;
using Sdl.Community.GroupShareKit.Models.Response.MultiTerm.Images;
using Sdl.Community.GroupShareKit.Models.Response.MultiTerm.Search;
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
        /// Retrieves all termbases from the v2 API.
        /// </summary>
        Task<TermbasesV2> GetTermbasesV2();

        /// <summary>
        /// Retrieves termbases from the v2 API using pagination.
        /// </summary>
        /// <param name="page">The page number to retrieve.</param>
        /// <param name="limit">The maximum number of items per page.</param>
        Task<TermbasesV2> GetTermbasesV2(int page, int limit);

        /// <summary>
        /// Retrieves the termbase definition.
        /// </summary>
        Task<XmlObject> GetTermbaseDefinitionV2(Guid termbaseId);

        /// <summary>
        /// Retrieves the termbase public objects.
        /// </summary>
        Task<TermbaseV2> GetTermbasePublicObjectsV2(Guid termbaseId);

        /// <summary>
        /// Deletes a termbase.
        /// </summary>
        Task DeleteTermbaseV2(Guid termbaseId);

        /// <summary>
        /// Retrieves a termbase GUID by its friendly name.
        /// </summary>
        Task<Guid> GetTermbaseGuidByNameV2(TermbaseNameModel termbaseName);

        /// <summary>
        /// Retrieves a termbase concept from the v2 API.
        /// </summary>
        Task<ConceptV2> GetConceptV2(Guid termbaseId, int conceptId);

        /// <summary>
        /// Retrieves a termbase concept XML from the v2 API.
        /// </summary>
        Task<ConceptXmlObject> GetConceptXmlV2(Guid termbaseId, int conceptId);

        /// <summary>
        /// Creates a new concept in the specified termbase using the v2 API.
        /// </summary>
        /// <param name="termbaseId">The identifier of the termbase where the concept will be created.</param>
        /// <param name="concept">The concept details associated with the concept.</param>
        Task<int> CreateConceptV2(Guid termbaseId, ConceptV2 concept);

        /// <summary>
        /// Updates an existing concept in the specified termbase using the v2 API.
        /// </summary>
        /// <param name="termbaseId">The identifier of the termbase where the concept exists.</param>
        /// <param name="concept">The updated concept details associated with the concept.</param>
        Task UpdateConceptV2(Guid termbaseId, ConceptV2 concept);

        /// <summary>
        /// Creates a new concept in the specified termbase using the v2 API.
        /// </summary>
        /// <param name="termbaseId">The identifier of the termbase where the concept will be created.</param>
        /// <param name="conceptXml">The concept details associated with the concept.</param>
        Task<int> CreateConceptXmlV2(Guid termbaseId, ConceptXmlObject conceptXml);

        /// <summary>
        /// Updates an existing concept in the specified termbase using the v2 API.
        /// </summary>
        /// <param name="termbaseId">The identifier of the termbase where the concept exists.</param>
        /// <param name="conceptXml">The updated concept details associated with the concept.</param>
        Task UpdateConceptXmlV2(Guid termbaseId, ConceptXmlObject conceptXml);

        /// <summary>
        /// Locks a termbase concept for editing.
        /// </summary>
        Task LockConceptV2(Guid termbaseId, int conceptId);

        /// <summary>
        /// Locks a termbase concept for editing.
        /// </summary>
        /// <param name="stealLock">If set to true, steals the lock previously acquired by the same user.</param>
        Task LockConceptV2(Guid termbaseId, int conceptId, bool stealLock);

        /// <summary>
        /// Unlocks a termbase concept.
        /// </summary>
        Task UnlockConceptV2(Guid termbaseId, int conceptId);

        /// <summary>
        /// Deletes a concept from a termbase using the v2 API.
        /// </summary>
        Task DeleteConceptV2(Guid termbaseId, int conceptId);

        /// <summary>
        /// Searches terms in a termbase using the v2 API.
        /// </summary>
        Task<TermbaseSearchResult> SearchTermbaseV2(Guid termbaseId, TermbaseSearchRequest request);

        /// <summary>
        /// Searches for a concept in a termbase using the v2 API.
        /// </summary>
        Task<ConceptXmlObject> SearchConceptV2(Guid termbaseId, SearchConceptRequest request);

        /// <summary>
        /// Browses entries in a termbase using the v2 API.
        /// </summary>
        Task<TermbaseBrowseResult> BrowseExTermbaseV2(Guid termbaseId, TermbaseBrowseRequest request);

        /// <summary>
        /// Retrieves a catalog object from a termbase using the v2 API.
        /// </summary>
        Task<XmlObject> GetCatalogObjectV2(Guid termbaseId, int catalogObjectId);

        /// <summary>
        /// Deletes a catalog object from a termbase using the v2 API.
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <param name="catalogObjectId"></param>
        Task DeleteCatalogObjectV2(Guid termbaseId, int catalogObjectId);

        /// <summary>
        /// Retrieves a multimedia (image) file from a termbase using the v2 API.
        /// </summary>
        Task<byte[]> GetMultimediaV2(Guid termbaseId, int imageId);

        /// <summary>
        /// Creates a multimedia (image) file in a termbase using the v2 API.
        /// </summary>
        Task<int> AddMultimediaV2(Guid termbaseId, MultimediaRequest request);

        /// <summary>
        /// Deletes a multimedia (image) file from a termbase using the v2 API.
        /// </summary>
        Task DeleteMultimediaV2(Guid termbaseId, int conceptId);

    }
}
