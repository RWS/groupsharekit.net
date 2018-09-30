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
        /// <param name="organizationId">string</param>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> <see cref="Organization"/>s.</returns>
        public Task<Organization> Get(string organizationId)
        {
            Ensure.ArgumentNotNullOrEmptyString(organizationId,"organizationId");

            return ApiConnection.Get<Organization>(ApiUrls.Organization(organizationId), null);
        }

        /// <summary>
        /// Gets<see cref="Organization"/>.
        /// </summary>
        /// <remarks>
        /// <param name="tag">string</param>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> <see cref="Organization"/>s.</returns>
        public Task<IReadOnlyList<Organization>> GetByTag(string tag)
        {
            Ensure.ArgumentNotNullOrEmptyString(tag, "tag");

            return ApiConnection.GetAll<Organization>(ApiUrls.GetOrganizationsByTag(tag), null);
        }

        /// <summary>
        /// Gets all <see cref="Organization"/>'s.
        /// </summary>
        /// <remarks>
        ///<param name="request"><see cref="OrganizationRequest"/></param>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
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

        /// <summary>
        /// Delete <see cref="Organization"/>'s.
        /// </summary>
        /// <remarks>
        ///<param name="organizationId">string</param>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        public Task DeleteOrganization(string organizationId)
        {
            Ensure.ArgumentNotNullOrEmptyString(organizationId,"organizationId");

            return ApiConnection.Delete(ApiUrls.Organization(organizationId));
        }

        /// <summary>
        /// Update <see cref="Organization"/>'s.
        /// </summary>
        /// <remarks>
        /// <param name="organization"><see cref="Organization"/></param>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> <see cref="Organization"/>.</returns>
        public Task<string> Update(Organization organization)
        {
            return ApiConnection.Put<string>(ApiUrls.Organizations(), organization);
        }

        /// <summary>
        /// Create <see cref="Organization"/>'s.
        /// </summary>
        /// <remarks>
        /// <param name="organization"><see cref="Organization"/></param>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>Id of created organization.</returns>
        public async Task<string> Create(Organization organization)
        {
            return await ApiConnection.Post<string>(ApiUrls.Organizations(), organization,"application/json");
        }

        /// <summary>
        /// Gets all organization resources <see cref="OrganizationResources"/>'s.
        /// </summary>
        /// <remarks>
        /// <param name="organizationId">string></param>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>List of <see cref="OrganizationResources"/></returns>
        public async Task<IReadOnlyList<OrganizationResources>> GetAllOrganizationResources(string organizationId)
        {
            return await ApiConnection.GetAll<OrganizationResources>(ApiUrls.OrganizationResources(organizationId));
        }


        /// <summary>
        /// Moves a resource to a organization .
        /// </summary>
        /// <remarks>
        /// <param name="request"><see cref="OrganizationResourcesRequest"/></param>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        public Task MoveResourceToOrganization(OrganizationResourcesRequest request)
        {
            return ApiConnection.Put<string>(ApiUrls.MoveOrganizationsResources(), request);
        }

        /// <summary>
        /// Links resource to a organization
        /// <param name="resource"><see cref="OrganizationResourcesRequest"/></param>
        /// </summary>
        public async Task LinkResourceToOrganization(OrganizationResourcesRequest resource)
        {
            Ensure.ArgumentNotNull(resource, "resource");

            await ApiConnection.Put<OrganizationResourcesRequest>(ApiUrls.LinkResourceToOrganization(), resource);
        }

        /// <summary>
        /// Unlink a resource from a organization .
        /// </summary>
        /// <remarks>
        /// <param name="resource"><see cref="OrganizationResourcesRequest"/></param>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        public async Task UnlinkResourceToOrganization(OrganizationResourcesRequest resource)
        {
            Ensure.ArgumentNotNull(resource, "resource");
            await ApiConnection.Delete(ApiUrls.LinkResourceToOrganization(), resource, "application/json");
        }
    }
}