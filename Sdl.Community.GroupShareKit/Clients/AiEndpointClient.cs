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

        public async Task<IEnumerable<AiEndpoint>> GetAiEndpoints()
        {
            return await ApiConnection.Get<List<AiEndpoint>>(ApiUrls.AiEndpoints(), null);
        }

        public async Task<AiEndpoint> AddAiEndpoint(AiEndpoint aiEndpoint)
        {
            return await ApiConnection.Post<AiEndpoint>(ApiUrls.AiEndpoints(), aiEndpoint, "application/json");
        }

        public async Task<AiEndpoint> UpdateAiEndpoint(Guid id, AiEndpoint aiEndpoint)
        {
            return await ApiConnection.Put<AiEndpoint>(ApiUrls.AiEndpoint(id), aiEndpoint);
        }

        public async Task DeleteAiEndpoint(Guid aiEndpointId)
        {
            await ApiConnection.Delete(ApiUrls.AiEndpoint(aiEndpointId));
        }
    }
}
