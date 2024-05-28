using Sdl.Community.GroupShareKit.Models.Response.TranslationMemory;
using System;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Exceptions;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class TranslationMemoryClientDatabaseServerTest
    {
        private static readonly GroupShareClient GroupShareClient = Helper.GsClient;

        [Fact]
        public async Task GetDbServers()
        {
            var serverId = await CreateNewDbServer();
            var response = await GroupShareClient.TranslationMemories.GetDbServers();

            Assert.True(response.Items.Count > 0);
            await GroupShareClient.TranslationMemories.DeleteDbServer(serverId);
        }

        [Fact]
        public async Task CreateDbServer()
        {
            var serverId = await CreateNewDbServer();

            Assert.True(serverId != string.Empty);
            await GroupShareClient.TranslationMemories.DeleteDbServer(serverId);
        }

        [Fact]
        public async Task GetDbServer()
        {
            var serverId = await CreateNewDbServer();
            var server = await GroupShareClient.TranslationMemories.GetDbServerById(serverId);

            Assert.Equal(server.DatabaseServerId, serverId);
            await GroupShareClient.TranslationMemories.DeleteDbServer(serverId);
        }

        [Fact]
        public async Task UpdateDbServer()
        {
            var serverId = await CreateNewDbServer();

            Assert.True(serverId != string.Empty);

            var request = new RequestDbServer("Updated server name", "", "", "");

            await GroupShareClient.TranslationMemories.UpdateDbServer(serverId, request);
            var updatedServer = await GroupShareClient.TranslationMemories.GetDbServerById(serverId);

            Assert.Equal("Updated server name", updatedServer.Name);

            await GroupShareClient.TranslationMemories.DeleteDbServer(serverId);
        }

        [Fact]
        public async Task DeleteDbServer()
        {
            var serverId = await CreateNewDbServer();
            await GroupShareClient.TranslationMemories.DeleteDbServer(serverId);

            Task result() => GroupShareClient.TranslationMemories.GetDbServerById(serverId);
            await Assert.ThrowsAsync<ForbiddenException>(result);
        }

        public async Task<string> CreateNewDbServer()
        {
            var dbServerRequest = new DatabaseServerRequest
            {
                DatabaseServerId = Guid.NewGuid().ToString(),
                Name = "Test Server",
                Description = "Added from kit",
                OwnerId = Helper.OrganizationId,
                Location = Helper.OrganizationPath,
                Host = Helper.GsServerName
            };

            var serverId = await GroupShareClient.TranslationMemories.CreateDbServer(dbServerRequest);
            return serverId;
        }
    }
}