using System.Collections.Generic;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Exceptions;
using Sdl.Community.GroupShareKit.Models.Response;

namespace Sdl.Community.GroupShareKit.Clients
{
    public interface IOrganizationClient
    {

        /// <summary>
        /// Gets organizarion by Id<see cref="Organization"/>.
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
        Task<Organization> Get(string organizationId);

        /// <summary>
        /// Gets organizarion by Id<see cref="Organization"/>.
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
        Task DeleteOrganization(string organizationId);

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
        Task<string> Update(Organization organization);

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
        Task<string> Create(Organization organization);

        /// <summary>
        /// Gets all resources for a organization 
        /// </summary>
        /// <param name="organizationId">string</param>
        /// <returns>A list of<see cref="OrganizationResources"/></returns>
        Task<IReadOnlyList<OrganizationResources>> GetAllOrganizationResources(string organizationId);

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
    }
}