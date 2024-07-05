using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Exceptions;
using Sdl.Community.GroupShareKit.Models.Response;

namespace Sdl.Community.GroupShareKit.Clients
{
    public interface IOrganizationClient
    {
        /// <summary>
        /// Gets organization by Id<see cref="Organization"/>.
        /// </summary>
        ///  <param name="organizationId">string></param>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> <see cref="Organization"/>s.</returns>
        [Obsolete("This method is obsolete. Call 'GetOrganization(Guid)' instead.")]
        Task<Organization> Get(string organizationId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="organizationId"></param>
        /// <returns></returns>
        Task<Organization> GetOrganization(Guid organizationId);

        /// <summary>
        /// Gets organization by Id<see cref="Organization"/>.
        /// </summary>
        ///  <param name="tag">string></param>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns> <see cref="Organization"/>s.</returns>
        Task<IReadOnlyList<Organization>> GetByTag(string tag);

        /// <summary>
        /// Gets all <see cref="Organization"/>'s.
        /// </summary>
        /// <param name="request"><see cref="OrganizationRequest"/></param>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="Organization"/>s.</returns>
        Task<IReadOnlyList<Organization>> GetAll(OrganizationRequest request);

        /// <summary>
        /// Delete <see cref="Organization"/>'s.
        /// </summary>
        /// <param name="organizationId">string</param>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="Organization"/>s.</returns>
        [Obsolete("This method is obsolete. Call 'DeleteOrganization(Guid)' instead.")]
        Task DeleteOrganization(string organizationId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="organizationId"></param>
        /// <returns></returns>
        Task DeleteOrganization(Guid organizationId);

        /// <summary>
        /// Updates <see cref="Organization"/>'s.
        /// </summary>
        /// <param name="organization"><see cref="Organization"/></param>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="Organization"/>s.</returns>
        [Obsolete("This method is obsolete. Call 'UpdateOrganization(Guid)' instead.")]
        Task<string> Update(Organization organization);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        Task<Guid> UpdateOrganization(Organization organization);

        /// <summary>
        /// Create <see cref="Organization"/>'s.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        ///  <param name="organization"><see cref="Organization"/></param>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="Organization"/>s.</returns>
        [Obsolete("This method is obsolete. Call 'CreateOrganization(Guid)' instead.")]
        Task<string> Create(Organization organization);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        Task<Guid> CreateOrganization(Organization organization);

        /// <summary>
        /// Gets all resources for a organization 
        /// </summary>
        /// <param name="organizationId">string</param>
        /// <returns>A list of<see cref="OrganizationResources"/></returns>
        [Obsolete("This method is obsolete. Call 'GetOrganizationResources(Guid)' instead.")]
        Task<IReadOnlyList<OrganizationResources>> GetAllOrganizationResources(string organizationId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="organizationId"></param>
        /// <returns></returns>
        Task<IReadOnlyList<OrganizationResources>> GetOrganizationResources(Guid organizationId);

        /// <summary>
        /// Moves a resource to specific organization
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <param name="request"><see cref="OrganizationResourcesRequest"/></param> 
        Task MoveResourceToOrganization(OrganizationResourcesRequest request);

        /// <summary>
        /// Links a resource to specific organization
        /// </summary>  
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <param name="resource"><see cref="OrganizationResourcesRequest"/></param> 
        Task LinkResourceToOrganization(OrganizationResourcesRequest resource);

        /// <summary>
        /// Unlinks a resource from a specific organization
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <param name="resource"><see cref="OrganizationResourcesRequest"/></param> 
        Task UnlinkResourceToOrganization(OrganizationResourcesRequest resource);

        /// <summary>
        /// Returns the guid of an organization identified by a given path.
        /// </summary>
        /// <remarks>
        /// <param name="path">Path of the organization.</param>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task<Guid> GetOrganizationId(string path);
    }
}