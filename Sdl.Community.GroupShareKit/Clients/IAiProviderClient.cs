using Sdl.Community.GroupShareKit.Models.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Clients
{
    public interface IAiProviderClient
    {
        /// <summary>
        /// Gets all AI provider settings for the specified user.
        /// </summary>
        Task<IEnumerable<AiProviderSettings>> GetAiProviderSettings(Guid userId);

        /// <summary>
        /// Validates the AI provider settings without consuming tokens.
        /// </summary>
        Task AuthenticateAiProvider(AiProviderSettings providerSettings);

        /// <summary>
        /// Registers an AI provider for the specified user.
        /// </summary>
        Task<Guid> RegisterAiProvider(Guid userId, AiProviderSettings providerSettings);

        /// <summary>
        /// Updates AI provider settings for the specified user.
        /// </summary>
        Task<Guid> UpdateAiProviderSettings(Guid userId, AiProviderSettings providerSettings);

        /// <summary>
        /// Deletes the AI provider settings for the specified user.
        /// </summary>
        Task DeleteAiProviderSettings(Guid userId, int providerSettingId);
    }
}
