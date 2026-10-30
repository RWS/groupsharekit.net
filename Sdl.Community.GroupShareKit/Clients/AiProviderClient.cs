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

        public async Task<IEnumerable<AiProviderSettings>> GetAiProviderSettings(Guid userId)
        {
            return await ApiConnection.Get<List<AiProviderSettings>>(ApiUrls.AiProvider(userId), null);
        }

        public async Task AuthenticateAiProvider(AiProviderSettings providerSettings)
        {
            await ApiConnection.Post(ApiUrls.AuthenticateAiProvider(), providerSettings, "application/json");
        }

        public async Task<Guid> RegisterAiProvider(Guid userId, AiProviderSettings providerSettings)
        {
            return await ApiConnection.Post<Guid>(ApiUrls.AiProvider(userId), providerSettings, "application/json");
        }

        public async Task<Guid> UpdateAiProviderSettings(Guid userId, AiProviderSettings providerSettings)
        {
            return await ApiConnection.Put<Guid>(ApiUrls.AiProvider(userId), providerSettings);
        }

        public async Task DeleteAiProviderSettings(Guid userId, int providerSettingId)
        {
            await ApiConnection.Delete(ApiUrls.DeleteAiProviderSettings(userId, providerSettingId));
        }

    }
}
