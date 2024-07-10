﻿using Sdl.Community.GroupShareKit.Exceptions;
using Sdl.Community.GroupShareKit.Models.Response;
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
    }
}
