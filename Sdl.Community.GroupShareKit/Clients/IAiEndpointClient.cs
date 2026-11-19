using Sdl.Community.GroupShareKit.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Clients
{
    public interface IAiEndpointClient
    {
        Task<IEnumerable<AiEndpoint>> GetAiEndpoints();

        Task<AiEndpoint> AddAiEndpoint(AiEndpoint aiEndpoint);

        Task<AiEndpoint> UpdateAiEndpoint(Guid id, AiEndpoint aiEndpoint);

        Task DeleteAiEndpoint(Guid aiEndpointId);
    }
}
