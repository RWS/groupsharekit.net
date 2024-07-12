using System;
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
        IProjectClient Project { get; }

        /// <summary>
        /// The base address of the GroupShare API.
        /// </summary>
        Uri BaseAddress { get; }

        /// <summary>
        /// Access GroupShare's TM API.
        /// </summary>
        ITranslationMemoriesClient TranslationMemories { get; set; }

        /// <summary>
        /// Access GroupShare's User API.
        /// </summary>
        IUserClient User { get; }

        /// <summary>
        /// Access GroupShare's ModuleClient API.
        /// </summary>
        IModuleClient ModuleClient { get; set; }

        /// <summary>
        /// Access GroupShare's Organizations API.
        /// </summary>
        IOrganizationClient Organization { get; set; }

        /// <summary>
        /// Access GroupShare's Authentication API.
        /// </summary>
        IAuthenticateClient Authenticate { get; set; }

        /// <summary>
        /// Access GroupShare's Role API.
        /// </summary>
        IRoleClient Role { get; set; }

        /// <summary>
        /// Access GroupShare's Permission API.
        /// </summary>
        IPermissionClient Permission { get; set; }

        /// <summary>
        /// Access GroupShare's License API.
        /// </summary>
        ILicense License { get; set; }

        /// <summary>
        /// Access GroupShare's Terminology API.
        /// </summary>
        ITerminology Terminology { get; set; }

        /// <summary>
        /// Access GroupShare's TranslateAndAnalysis API.
        /// </summary>
        ITranslateAndAnalysis TranslateAndAnalysis { get; set; }
    }
}