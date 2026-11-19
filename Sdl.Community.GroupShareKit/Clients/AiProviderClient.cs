using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Http;
using Sdl.Community.GroupShareKit.Models.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class AiProviderClient : ApiClient, IAiProviderClient
    {
        public AiProviderClient(IApiConnection apiConnection) : base(apiConnection) 
        { 
        }

        /// <summary>
        /// Gets all AI provider settings for the specified user.
        /// </summary>
        public async Task<IEnumerable<AiProviderSettings>> GetAiProviderSettings(Guid userId)
        {
            return await ApiConnection.Get<List<AiProviderSettings>>(ApiUrls.AiProvider(userId), null);
        }

        /// <summary>
        /// Validates the AI provider settings without consuming tokens.
        /// </summary>
        public async Task AuthenticateAiProvider(AiProviderSettings providerSettings)
        {
            await ApiConnection.Post(ApiUrls.AuthenticateAiProvider(), providerSettings, "application/json");
        }

        /// <summary>
        /// Registers an AI provider for the specified user.
        /// </summary>
        public async Task<Guid> RegisterAiProvider(Guid userId, AiProviderSettings providerSettings)
        {
            return await ApiConnection.Post<Guid>(ApiUrls.AiProvider(userId), providerSettings, "application/json");
        }

        /// <summary>
        /// Updates AI provider settings for the specified user.
        /// </summary>
        public async Task<Guid> UpdateAiProviderSettings(Guid userId, AiProviderSettings providerSettings)
        {
            return await ApiConnection.Put<Guid>(ApiUrls.AiProvider(userId), providerSettings);
        }

        /// <summary>
        /// Deletes the AI provider settings for the specified user.
        /// </summary>
        public async Task DeleteAiProviderSettings(Guid userId, int providerSettingId)
        {
            await ApiConnection.Delete(ApiUrls.AiProviderSettings(userId, providerSettingId));
        }

    }
}
