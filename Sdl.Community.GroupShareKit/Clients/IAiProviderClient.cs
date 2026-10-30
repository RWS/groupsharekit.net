using Sdl.Community.GroupShareKit.Models.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Clients
{
    public interface IAiProviderClient
    {
        Task<IEnumerable<AiProviderSettings>> GetAiProviderSettings(Guid userId);

        Task AuthenticateAiProvider(AiProviderSettings providerSettings);

        Task<Guid> RegisterAiProvider(Guid userId, AiProviderSettings providerSettings);

        Task<Guid> UpdateAiProviderSettings(Guid userId, AiProviderSettings providerSettings);

        Task DeleteAiProviderSettings(Guid userId, int providerSettingId);
    }
}
