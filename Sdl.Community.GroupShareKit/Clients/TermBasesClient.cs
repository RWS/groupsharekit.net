using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Exceptions;
using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Http;
using Sdl.Community.GroupShareKit.Models.Response;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class TermBasesClient : ApiClient, ITermBases
    {
        public TermBasesClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        /// <summary>
        /// Gets  <see cref="Termbase"/>s.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
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
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> <see cref="TermbaseDetails"/></returns>
        public async Task<TermbaseResponse> GetTermbaseById(string termbaseId)
        {
           Ensure.ArgumentNotNullOrEmptyString(termbaseId,"termbaseId");
            return await ApiConnection.Get<TermbaseResponse>(ApiUrls.GetTermbaseById(termbaseId), null);
        }


        /// <summary>
        /// Gets  <see cref="Filter"/>s.
        /// </summary>
        /// <param name="termbaseId"></param>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> <see cref="Filter"/></returns>
        public async Task<FilterResponse> GetFilters(string termbaseId)
        {
           Ensure.ArgumentNotNullOrEmptyString(termbaseId,"termbaseId");
            return await ApiConnection.Get<FilterResponse>(ApiUrls.GetFilers(termbaseId),null);
        }

        /// <summary>
        /// Serch for a term in a termbase  
        /// </summary>
        /// <param name="request"><see cref="SearchTermRequest"/></param>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> <see cref="SearchResponse"/></returns>
        public async Task<SearchResponse> SearchTerm(SearchTermRequest request)
        {
            Ensure.ArgumentNotNull(request,"request");
            return await ApiConnection.Get<SearchResponse>(ApiUrls.Search(), request.ToParametersDictionary());
        }

        /// <summary>
        /// Gets <see cref="Models.Response.ConceptResponse"/> 
        /// </summary>
        /// <param name="response"><see cref="ConceptResponse"/></param>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> <see cref="Models.Response.ConceptResponse"/></returns>
        public async Task<Models.Response.ConceptResponse> GetConcept(ConceptResponse response)
        {
            Ensure.ArgumentNotNull(response,"request");
            return await ApiConnection.Get<Models.Response.ConceptResponse>(ApiUrls.GetConcepts(response), null);
        }

        /// <summary>
        /// Gets <see cref="Models.Response.ConceptResponse"/> 
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> <see cref="Models.Response.ConceptResponse"/></returns>
        public async Task<Models.Response.ConceptResponse> GetConcept(string termbaseId, string conceptId)
        {
            Ensure.ArgumentNotNullOrEmptyString(termbaseId, "termbaseId");
            Ensure.ArgumentNotNullOrEmptyString(conceptId, "conceptId");
            return await ApiConnection.Get<Models.Response.ConceptResponse>(ApiUrls.GetConcepts(termbaseId, conceptId), null);
        }

        /// <summary>
        /// Updates a entry in termbase<see cref="Models.Response.ConceptResponse"/> 
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> Updated<see cref="Models.Response.ConceptResponse"/> </returns>
        public async Task<Models.Response.ConceptResponse> EditConcept(string termbaseId, Models.Response.ConceptResponse concept)
        {
            Ensure.ArgumentNotNullOrEmptyString(termbaseId, "termbaseId");
            Ensure.ArgumentNotNull(concept,"concept");

            return await ApiConnection.Put<Models.Response.ConceptResponse>(ApiUrls.GetConcepts(termbaseId), concept);
        }

        

        /// <summary>
        /// Creates termbase concept <see cref="Concept"/> 
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> </returns>
        public async Task<Models.Response.ConceptResponse> CreateConcept(string termbaseId, Models.Response.ConceptResponse conceptResponse)
        {
            Ensure.ArgumentNotNullOrEmptyString(termbaseId,"termbaseId");
            Ensure.ArgumentNotNull(conceptResponse,"conceptRequest");

             return await ApiConnection.Post<Models.Response.ConceptResponse>(ApiUrls.GetConcepts(termbaseId), conceptResponse,"application/json");
        }

        /// <summary>
        /// Deletes termbase concept <see cref="Concept"/> 
        /// </summary>
        /// <param name="termbaseId">Termbase id</param>
        /// <param name="conceptId">Concept id</param>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
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
    }
}
