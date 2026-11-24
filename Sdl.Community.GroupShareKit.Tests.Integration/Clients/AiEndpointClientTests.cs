using Sdl.Community.GroupShareKit.Models.Response;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class AiEndpointClientTests
    {
        private static readonly GroupShareClient GroupShareClient = Helper.GsClient;

        [Fact]
        public async Task Add_update_delete_AiEndpoint_settings()
        {
            var uniqueId = Guid.NewGuid().ToString("N");
            var initialSettings = new AiEndpoint
            {
                DisplayName = "LM Studio",
                Provider = "lm-studio",
                Endpoint = $"http://url-{uniqueId}/v1",
                MaxConcurrentRequests = 2
            };

            var retrievedSettings = await GroupShareClient.AiEndpointClient.AddAiEndpoint(initialSettings);
            Assert.Equal(initialSettings.DisplayName, retrievedSettings.DisplayName);
            Assert.Equal(initialSettings.Provider, retrievedSettings.Provider);
            Assert.Equal(initialSettings.Endpoint, retrievedSettings.Endpoint);
            Assert.Equal(initialSettings.MaxConcurrentRequests, retrievedSettings.MaxConcurrentRequests);

            var updatedSettings = new AiEndpoint
            {
                Id = retrievedSettings.Id,
                DisplayName = "OpenAI",
                Provider = "openai",
                Endpoint = $"http://url-{uniqueId}/v1/updated",
                MaxConcurrentRequests = 3
            };

            retrievedSettings = await GroupShareClient.AiEndpointClient.UpdateAiEndpoint(retrievedSettings.Id, updatedSettings);
            Assert.Equal(updatedSettings.DisplayName, retrievedSettings.DisplayName);
            Assert.Equal(updatedSettings.Provider, retrievedSettings.Provider);
            Assert.Equal(updatedSettings.Endpoint, retrievedSettings.Endpoint);
            Assert.Equal(updatedSettings.MaxConcurrentRequests, retrievedSettings.MaxConcurrentRequests);

            var aiEndpoints = await GroupShareClient.AiEndpointClient.GetAiEndpoints();
            Assert.Contains(aiEndpoints, x => x.Id == retrievedSettings.Id);

            await GroupShareClient.AiEndpointClient.DeleteAiEndpoint(retrievedSettings.Id);

            aiEndpoints = await GroupShareClient.AiEndpointClient.GetAiEndpoints();
            Assert.DoesNotContain(aiEndpoints, x => x.Id == retrievedSettings.Id);
        }

    }
}
