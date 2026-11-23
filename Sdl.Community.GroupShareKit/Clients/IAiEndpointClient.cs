using Sdl.Community.GroupShareKit.Models.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Clients
{
    public interface IAiEndpointClient
    {
        /// <summary>
        /// Gets all AI endpoints available at organization level, that have system wide settings enabled.
        /// </summary>
        Task<IEnumerable<AiEndpoint>> GetAiEndpoints();

        /// <summary>
        /// Creates system wide settings for a new AI endpoint.
        /// </summary>
        Task<AiEndpoint> AddAiEndpoint(AiEndpoint endpoint);

        /// <summary>
        /// Updates system wide settings for an existing AI endpoint.
        /// </summary>
        Task<AiEndpoint> UpdateAiEndpoint(string id, AiEndpoint endpoint);

        /// <summary>
        /// Deletes system wide settings for an AI endpoint.
        /// </summary>
        Task DeleteAiEndpoint(string id);
    }
}
