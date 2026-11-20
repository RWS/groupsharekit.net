using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Http;
using Sdl.Community.GroupShareKit.Models.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class AiEndpointClient : ApiClient, IAiEndpointClient
    {
        public AiEndpointClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        /// <summary>
        /// Gets all AI endpoints available at organization level, that have system wide settings enabled.
        /// </summary>
        public async Task<IEnumerable<AiEndpoint>> GetAiEndpoints()
        {
            return await ApiConnection.Get<List<AiEndpoint>>(ApiUrls.AiEndpoints(), null);
        }

        /// <summary>
        /// Creates system wide settings for a new AI endpoint.
        /// </summary>
        public async Task<AiEndpoint> AddAiEndpoint(AiEndpoint endpoint)
        {
            Ensure.ArgumentNotNull(endpoint, nameof(endpoint));

            return await ApiConnection.Post<AiEndpoint>(ApiUrls.AiEndpoints(), endpoint, "application/json");
        }

        /// <summary>
        /// Updates system wide settings for an existing AI endpoint.
        /// </summary>
        public async Task<AiEndpoint> UpdateAiEndpoint(Guid id, AiEndpoint endpoint)
        {
            Ensure.ArgumentNotNull(endpoint, nameof(endpoint));

            return await ApiConnection.Put<AiEndpoint>(ApiUrls.AiEndpoint(id), endpoint);
        }

        /// <summary>
        /// Deletes system wide settings for an AI endpoint.
        /// </summary>
        public async Task DeleteAiEndpoint(Guid id)
        {
            await ApiConnection.Delete(ApiUrls.AiEndpoint(id));
        }
    }
}
