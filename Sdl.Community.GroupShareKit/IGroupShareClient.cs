using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Http;

namespace Sdl.Community.GroupShareKit
{
    /// <summary>
    /// A Client for the GroupShare API v1. 
    /// </summary>
    public interface IGroupShareClient
    {
        /// <summary>
        /// Provides a client connection to make rest requests to HTTP endpoints.
        /// </summary>
        IConnection Connection { get; }

        /// <summary>
        /// Access GroupShare's Project API.
        /// </summary>
        /// <remarks>
        /// Refer to the API docmentation for more information: http://sdldevelopmentpartners.sdlproducts.com/documentation/api
        /// </remarks>
        IProjectClient Project { get; }

        /// <summary>
        /// Access GroupShare's User API.
        /// </summary>
        /// <remarks>
        /// Refer to the API docmentation for more information: http://sdldevelopmentpartners.sdlproducts.com/documentation/api
        /// </remarks>
        IUserClient User { get; }

        /// <summary>
        /// Access GroupShare's Organization API.
        /// </summary>
        /// <remarks>
        /// Refer to the API docmentation for more information: http://sdldevelopmentpartners.sdlproducts.com/documentation/api
        /// </remarks>
        IOrganizationClient Organization { get; set; }

        /// <summary>
        /// Access GroupShare's Authentication API.
        /// </summary>
        /// <remarks>
        /// Refer to the API docmentation for more information: http://sdldevelopmentpartners.sdlproducts.com/documentation/api
        /// </remarks>
        IAuthenticateClient Authenticate { get; set; }

        /// <summary>
        /// The base address of the GroupShare API.
        /// </summary>
        Uri BaseAddress { get; }


    }
}