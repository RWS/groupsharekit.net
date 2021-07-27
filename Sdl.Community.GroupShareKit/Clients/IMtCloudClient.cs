using Sdl.Community.GroupShareKit.Models.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Clients
{
    public interface IMtProviderClient
    {
        Task<Guid> AddMtProviderCredentials(Guid userId, MtProviderSettings mtProviderSettings);
        Task DeleteMtProviderCredentials(Guid userId, int providerSettingId);
        Task<MtCloudToken> GetMtProviderToken(MtProviderSettings mtProviderSettings);
        Task<Guid> UpdateMtProviderCredentials(Guid userId, MtProviderSettings mtProviderSettings);
        Task<List<MtProviderSettings>> GetMtProviderCredentials(Guid userId);
    }
}