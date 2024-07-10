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
        public OrganizationClient(ApiConnection apiConnection) : base(apiConnection)
        {
        }

        [Obsolete("This method is obsolete. Call 'GetOrganization(Guid)' instead.")]
        public Task<Organization> Get(string organizationId)
        {
            Ensure.ArgumentNotNullOrEmptyString(organizationId, "organizationId");

            return ApiConnection.Get<Organization>(ApiUrls.Organization(organizationId), null);
        }

        /// <summary>
        /// Gets an <see cref="Organization"/> by Guid.
        /// </summary>
        /// <param name="organizationId">Organization Guid</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>An <see cref="Organization"/>.</returns>
        public Task<Organization> GetOrganization(Guid organizationId)
        {
            Ensure.ArgumentNotNull(organizationId, "organizationId");

            return ApiConnection.Get<Organization>(ApiUrls.Organization(organizationId), null);
        }

        /// <summary>
        /// Gets<see cref="Organization"/>.
        /// </summary>
        /// <remarks>
        /// <param name="tag">string</param>
        /// This method requires authentication.
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

        [Obsolete("This method is obsolete. Call 'DeleteOrganization(Guid)' instead.")]
        public Task DeleteOrganization(string organizationId)
        {
            Ensure.ArgumentNotNullOrEmptyString(organizationId, "organizationId");

            return ApiConnection.Delete(ApiUrls.Organization(organizationId));
        }

        /// <summary>
        /// Deletes an <see cref="Organization"/>
        /// </summary>
        /// <param name="organizationId"></param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="Organization"/>s.</returns>
        public Task DeleteOrganization(Guid organizationId)
        {
            Ensure.ArgumentNotNull(organizationId, "organizationId");

            return ApiConnection.Delete(ApiUrls.Organization(organizationId));
        }

        [Obsolete("This method is obsolete. Call 'UpdateOrganization(Guid)' instead.")]
        public Task<string> Update(Organization organization)
        {
            return ApiConnection.Put<string>(ApiUrls.Organizations(), organization);
        }

        /// <summary>
        /// Updates an <see cref="Organization"/>.
        /// </summary>
        /// <param name="organization"><see cref="Organization"/></param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>The organization's Guid.</returns>
        public Task<Guid> UpdateOrganization(Organization organization)
        {
            return ApiConnection.Put<Guid>(ApiUrls.Organizations(), organization);
        }

        [Obsolete("This method is obsolete. Call 'CreateOrganization(Guid)' instead.")]
        public async Task<string> Create(Organization organization)
        {
            return await ApiConnection.Post<string>(ApiUrls.Organizations(), organization, "application/json");
        }

        /// <summary>
        /// Creates an <see cref="Organization"/>.
        /// </summary>
        /// <param name="organization"><see cref="Organization"/></param>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>The organization's Guid.</returns>
        public async Task<Guid> CreateOrganization(Organization organization)
        {
            return await ApiConnection.Post<Guid>(ApiUrls.Organizations(), organization, "application/json");
        }

        [Obsolete("This method is obsolete. Call 'GetOrganizationResources(Guid)' instead.")]
        public async Task<IReadOnlyList<OrganizationResources>> GetAllOrganizationResources(string organizationId)
        {
            return await ApiConnection.GetAll<OrganizationResources>(ApiUrls.OrganizationResources(organizationId));
        }

        /// <summary>
        /// Gets all the <see cref="OrganizationResources"/> of an <see cref="Organization"/>.
        /// </summary>
        /// <param name="organizationId">Organization Guid</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="OrganizationResources"/>.</returns>
        public async Task<IReadOnlyList<OrganizationResources>> GetOrganizationResources(Guid organizationId)
        {
            return await ApiConnection.GetAll<OrganizationResources>(ApiUrls.OrganizationResources(organizationId));
        }

        /// <summary>
        /// Moves a resource to a organization .
        /// </summary>
        /// <remarks>
        /// <param name="request"><see cref="OrganizationResourcesRequest"/></param>
        /// This method requires authentication.
        
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
        /// Unlink a resource from a organization.
        /// </summary>
        /// <remarks>
        /// <param name="resource"><see cref="OrganizationResourcesRequest"/></param>
        /// This method requires authentication.
        
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

        /// <summary>
        /// Returns the guid of an organization identified by a given path.
        /// </summary>
        /// <remarks>
        /// <param name="resourceGroupPath">Path of the organization.</param>
        /// This method requires authentication.
        
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        public async Task<Guid> GetOrganizationId(string resourceGroupPath)
        {
            Ensure.ArgumentNotNullOrEmptyString(resourceGroupPath, nameof(resourceGroupPath));

            var requestParameters = new Dictionary<string, string> { ["resourceGroupPath"] = resourceGroupPath };
            return await ApiConnection.Get<Guid>(ApiUrls.GetOrganizationByPath(), requestParameters);
        }
    }
}