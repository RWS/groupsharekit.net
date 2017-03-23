using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Exceptions;
using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Http;
using Sdl.Community.GroupShareKit.Models.Response.TranslationMemory;

namespace Sdl.Community.GroupShareKit.Clients.TranslationMemory
{
    public class ContainerClient:ApiClient,IContainer
    {
        public ContainerClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }


        /// <summary>
        ///Returns a list of all available containers
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        ///<returns><see cref="ContainerResponse"/></returns>
        public async Task<ContainerResponse> GetContainers()
        {
            return await ApiConnection.Get<ContainerResponse>(ApiUrls.Containers(), null);
        }

        /// <summary>
        ///creates a new container
        /// </summary>
        /// <remarks>
        /// <param name="request"><see cref="ContainerRequest"/></param>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        ///<returns>Container's Id</returns>
        public async Task<string> CreateContainer(ContainerRequest request)
        {
            Ensure.ArgumentNotNull(request,"container request");

            return await ApiConnection.Post<string>(ApiUrls.Containers(), request, "application/json");
        }

        /// <summary>
        ///Returns a specified container
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        ///<returns><see cref="Container"/></returns>
        public async Task<Container> GetContainerById(string containerId)
        {
           Ensure.ArgumentNotNullOrEmptyString(containerId,"container id");

            return await ApiConnection.Get<Container>(ApiUrls.Containers(containerId), null);
        }

        /// <summary>
        ///Deletes  specified container
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        public async Task DeleteContainer(string containerId)
        {
            Ensure.ArgumentNotNullOrEmptyString(containerId, "container id");
             await ApiConnection.Delete(ApiUrls.Containers(containerId));
        }

        /// <summary>
        ///Updates  specified container
        /// </summary>
        /// <remarks>
        /// <param name="request"><see cref="UpdateContainerRequest"/></param>
        /// This method requires authentication.
        /// See the <a href="http://sdldevelopmentpartners.sdlproducts.com/documentation/api">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        public async Task UpdateContainer(string containerId, UpdateContainerRequest request)
        {
            Ensure.ArgumentNotNullOrEmptyString(containerId, "container id");
            Ensure.ArgumentNotNull(request,"request");

            await ApiConnection.Put<string>(ApiUrls.Containers(containerId), request);
        }
    }
}
