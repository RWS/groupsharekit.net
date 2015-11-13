using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Exceptions;
using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Http;
using Sdl.Community.GroupShareKit.Models.Response;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class OrganizationClient : ApiClient, IOrganizationClient
    {
        public OrganizationClient(ApiConnection apiConnection):base(apiConnection)
        {
        }

        /// <summary>
        /// Gets<see cref="Organization"/>.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="Organization"/>s.</returns>
        public Task<Organization> Get(string organizationId)
        {
            Ensure.ArgumentNotNullOrEmptyString(organizationId,"organizationId");

            return ApiConnection.Get<Organization>(ApiUrls.Organization(organizationId), null);
        }

        /// <summary>
        /// Gets all <see cref="Organization"/>'s.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="Organization"/>s.</returns>
        public async Task<IReadOnlyList<Organization>> GetAll(OrganizationRequest request)
        {
            Ensure.ArgumentNotNull(request, "request");

            return await ApiConnection.GetAll<Organization>(ApiUrls.Organizations(), request.ToParametersDictionary());
        }
    }
}