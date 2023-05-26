﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Clients.Logging;
using Sdl.Community.GroupShareKit.Clients.TranslationMemory;
using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Http;

namespace Sdl.Community.GroupShareKit
{
    /// <summary>
    /// A Client for the GroupShare API v1. 
    /// </summary>
    public class GroupShareClient : IGroupShareClient
    {
        public const string ManagementApi = "ManagementRestApi";
        public const string ProjectApi = "ProjectServerRestApi";
        public const string MultiTermApi = "MultiTermRestApi";
        public const string TmServerApi = "TMServerRestApi";

        public static IEnumerable<string> AllScopes =
            new[]
            {
                ManagementApi,
                ProjectApi,
                MultiTermApi,
                TmServerApi
            };

        /// <summary>
        /// Create a new instance of the GroupShare API v1 client pointing to the specified baseAddress.
        /// </summary>
        /// <param name="credentialStore">Provides credentials to the client when making requests</param>
        /// <param name="baseAddress">
        /// The address to point this client to.</param>
        public GroupShareClient(ICredentialStore credentialStore, Uri baseAddress)
            : this(new Connection(baseAddress, credentialStore))
        {
        }

        /// <summary>
        /// Create a new instance of the GroupShare API v1 client using the specified connection.
        /// </summary>
        /// <param name="connection">The underlying <seealso cref="IConnection"/> used to make requests</param>
        public GroupShareClient(IConnection connection)
        {
            Ensure.ArgumentNotNull(connection, "connection");

            Connection = connection;
            var apiConnection = new ApiConnection(connection);
            Project = new ProjectClient(apiConnection);
            User = new UserClient(apiConnection);
            Organization = new OrganizationClient(apiConnection);
            Authenticate = new AuthenticateClient(apiConnection);
            Role = new RoleClient(apiConnection);
            Permission = new PermissionClient(apiConnection);
            ModuleClient = new ModuleClient(apiConnection);
            License = new LicenseClient(apiConnection);
            TranslationMemories = new TranslationMemoriesClient(apiConnection);
            Terminology = new TerminologyClient(apiConnection);
            TranslateAndAnalysis = new TranslateAndAnalysisClient(apiConnection);
            Reporting = new ReportingClient(apiConnection);
            PasswordComplexityRules = new PasswordComplexityRulesClient(apiConnection);
            IdpUserSettingsClient = new IdpUserSettingsClient(apiConnection);
            Logs = new LogsClient(apiConnection);
            MtProviderClient = new MtProviderClient(apiConnection);
        }

        /// <summary>
        /// Creates a new instance of the GroupShare API v1 client that has the authorization token configured
        /// </summary>
        /// <param name="user">Provides the user for which to obtain the token.</param>
        /// <param name="password">Provides the password for the specified user.</param>
        /// <param name="baseAddress">The address to point this client to.</param>
        /// <param name="scopes">The token scope(s).</param>
        /// <returns></returns>

        public static async Task<string> GetRequestToken(string user, string password, Uri baseAddress,
            IEnumerable<string> scopes)
        {
            var credentials = new Credentials(user, password);

            var inMemoryCredentials = new InMemoryCredentialStore(credentials);

            var tokenGroupShareClient = new GroupShareClient(inMemoryCredentials, baseAddress);

            var authorization = await tokenGroupShareClient.Authenticate.Post(scopes);
            return authorization.Token;
        }

        public static async Task<GroupShareClient> AuthenticateClient(string token, string user, string password, string bearerId, Uri baseAddress,
            IEnumerable<string> scopes)
        {
            var credentials = new Credentials(token, user, password, bearerId);

            var inMemoryCredentials = new InMemoryCredentialStore(credentials);

            var groupShareClient = new GroupShareClient(inMemoryCredentials, baseAddress);

            return groupShareClient;
        }

        public IMtProviderClient MtProviderClient{ get; }

        public IProjectClient Project { get; }
        public IReportingClient Reporting { get; }
        public ITranslationMemoriesClient TranslationMemories { get; set; }

        public IUserClient User { get; }
        public IModuleClient ModuleClient { get; set; }
        public IOrganizationClient Organization { get; set; }

        public IAuthenticateClient Authenticate { get; set; }

        public IRoleClient Role { get; set; }
        public IPermissionClient Permission { get; set; }
        public ILicense License { get; set; }
        public ITerminology Terminology { get; set; }
        public ITranslateAndAnalysis TranslateAndAnalysis { get; set; }
        public IPasswordComplexityRulesClient PasswordComplexityRules { get; set; }
        public IIdpUserSettingsClient IdpUserSettingsClient { get; set; }
        public ILogsClient Logs { get; set; }

        /// <summary>
        /// Convenience property for getting and setting credentials.
        /// </summary>
        /// <remarks>
        /// You can use this property if you only have a single hard-coded credential. Otherwise, pass in an 
        /// <see cref="ICredentialStore"/> to the constructor. 
        /// Setting this property will change the <see cref="ICredentialStore"/> to use 
        /// the default <see cref="InMemoryCredentialStore"/> with just these credentials.
        /// </remarks>
        public Credentials Credentials
        {
            get => Connection.Credentials;
            set
            {
                Ensure.ArgumentNotNull(value, "value");
                Connection.Credentials = value;
            }
        }

        /// <summary>
        /// The base address of the GroupShare API.
        /// </summary>
        public Uri BaseAddress => Connection.BaseAddress;

        /// <summary>
        /// Provides a client connection to make rest requests to HTTP endpoints.
        /// </summary>
        public IConnection Connection { get; }

    }
}
