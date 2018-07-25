using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Clients.TranslationMemory;
using Sdl.Community.GroupShareKit.Http;

namespace Sdl.Community.GroupShareKit
{
    /// <summary>
    /// A Client for the GroupShare API v2. 
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
        /// Refer to the API docmentation for more information: http://gs2017dev.sdl.com:41234/documentation/api/index#/
        /// </remarks>
        IProjectClient Project { get; }

        /// <summary>
        /// The base address of the GroupShare API.
        /// </summary>
        Uri BaseAddress { get; }

        /// <summary>
        /// Access GroupShare's TM API.
        /// </summary>
        /// <remarks>
        /// Refer to the API docmentation for more information: http://gs2017dev.sdl.com:41234/documentation/api/index#/
        /// </remarks>
        ITranslationMemoriesClient TranslationMemories { get; set; }

        /// <summary>
        /// Access GroupShare's User API.
        /// </summary>
        /// <remarks>
        /// Refer to the API docmentation for more information: http://gs2017dev.sdl.com:41234/documentation/api/index#/
        /// </remarks>
        IUserClient User { get; }

        /// <summary>
        /// Access GroupShare's ModuleClient API.
        /// </summary>
        /// <remarks>
        /// Refer to the API docmentation for more information: http://gs2017dev.sdl.com:41234/documentation/api/index#/
        /// </remarks>
        IModuleClient ModuleClient { get; set; }

        /// <summary>
        /// Access GroupShare's Organizations API.
        /// </summary>
        /// <remarks>
        /// Refer to the API docmentation for more information: http://gs2017dev.sdl.com:41234/documentation/api/index#/
        /// </remarks>
        IOrganizationClient Organization { get; set; }

        /// <summary>
        /// Access GroupShare's Authentication API.
        /// </summary>
        /// <remarks>
        /// Refer to the API docmentation for more information: http://gs2017dev.sdl.com:41234/documentation/api/index#/
        /// </remarks>
        IAuthenticateClient Authenticate { get; set; }

        /// <summary>
        /// Access GroupShare's Role API.
        /// </summary>
        /// <remarks>
        /// Refer to the API docmentation for more information: http://gs2017dev.sdl.com:41234/documentation/api/index#/
        /// </remarks>
        IRoleClient Role { get; set; }

        /// <summary>
        /// Access GroupShare's Permission API.
        /// </summary>
        /// <remarks>
        /// Refer to the API docmentation for more information: http://gs2017dev.sdl.com:41234/documentation/api/index#/
        /// </remarks>
        IPermissionClient Permission { get; set; }

        /// <summary>
        /// Access GroupShare's License API.
        /// </summary>
        /// <remarks>
        /// Refer to the API docmentation for more information: http://gs2017dev.sdl.com:41234/documentation/api/index#/
        /// </remarks>
        ILicense License { get; set; }

        /// <summary>
        /// Access GroupShare's Terminology API.
        /// </summary>
        /// <remarks>
        /// Refer to the API docmentation for more information: http://gs2017dev.sdl.com:41234/documentation/api/index#/
        /// </remarks>
        ITerminology Terminology { get; set; }
    }
}