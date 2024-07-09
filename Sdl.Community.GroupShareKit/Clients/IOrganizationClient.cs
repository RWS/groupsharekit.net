using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Exceptions;
using Sdl.Community.GroupShareKit.Models.Response;

namespace Sdl.Community.GroupShareKit.Clients
{
    public interface IOrganizationClient
    {
        [Obsolete("This method is obsolete. Call 'GetOrganization(Guid)' instead.")]
        Task<Organization> Get(string organizationId);

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
        Task<Organization> GetOrganization(Guid organizationId);

        /// <summary>
        /// Gets <see cref="Organization"/>s by tag.
        /// </summary>
        /// <param name="tag">Organization tag</param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="Organization"/>s.</returns>
        Task<IReadOnlyList<Organization>> GetByTag(string tag);

        /// <summary>
        /// Gets all <see cref="Organization"/>s.
        /// </summary>
        /// <param name="request"><see cref="OrganizationRequest"/></param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="Organization"/>s.</returns>
        Task<IReadOnlyList<Organization>> GetAll(OrganizationRequest request);

        [Obsolete("This method is obsolete. Call 'DeleteOrganization(Guid)' instead.")]
        Task DeleteOrganization(string organizationId);

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
        Task DeleteOrganization(Guid organizationId);

        [Obsolete("This method is obsolete. Call 'UpdateOrganization(Guid)' instead.")]
        Task<string> Update(Organization organization);

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
        Task<Guid> UpdateOrganization(Organization organization);

        [Obsolete("This method is obsolete. Call 'CreateOrganization(Guid)' instead.")]
        Task<string> Create(Organization organization);

        /// <summary>
        /// Creates an <see cref="Organization"/>.
        /// </summary>
        /// <param name="organization"><see cref="Organization"/></param>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>The organization's Guid.</returns>
        Task<Guid> CreateOrganization(Organization organization);

        [Obsolete("This method is obsolete. Call 'GetOrganizationResources(Guid)' instead.")]
        Task<IReadOnlyList<OrganizationResources>> GetAllOrganizationResources(string organizationId);

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
        Task<IReadOnlyList<OrganizationResources>> GetOrganizationResources(Guid organizationId);

        /// <summary>
        /// Moves a resource to a specific <see cref="Organization"/>.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <param name="request"><see cref="OrganizationResourcesRequest"/></param> 
        Task MoveResourceToOrganization(OrganizationResourcesRequest request);

        /// <summary>
        /// Links a resource to a specific <see cref="Organization"/>.
        /// </summary>  
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <param name="resource"><see cref="OrganizationResourcesRequest"/></param> 
        Task LinkResourceToOrganization(OrganizationResourcesRequest resource);

        /// <summary>
        /// Unlinks a resource from a specific <see cref="Organization"/>.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <param name="resource"><see cref="OrganizationResourcesRequest"/></param> 
        Task UnlinkResourceToOrganization(OrganizationResourcesRequest resource);

        /// <summary>
        /// Returns the Guid of an <see cref="Organization"/> identified by path.
        /// </summary>
        /// <remarks>
        /// <param name="path">Path of the organization.</param>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task<Guid> GetOrganizationId(string path);
    }
}