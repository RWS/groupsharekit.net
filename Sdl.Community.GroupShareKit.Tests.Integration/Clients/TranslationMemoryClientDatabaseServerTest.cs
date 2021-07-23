using Sdl.Community.GroupShareKit.Models.Response.TranslationMemory;
using System;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Exceptions;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class TranslationMemoryClientDatabaseServerTest
    {
        private static readonly GroupShareClient gsClient = Helper.GsClient;

        [Fact]
        public async Task GetDbServers()
        {
            var serverId = await CreateNewDbServer();
            var response = await gsClient.TranslationMemories.GetDbServers();

            Assert.True(response.Items.Count > 0);
            await gsClient.TranslationMemories.DeleteDbServer(serverId);
        }

        [Fact]
        public async Task CreateDbServer()
        {
            var serverId = await CreateNewDbServer();

            Assert.True(serverId != string.Empty);
            await gsClient.TranslationMemories.DeleteDbServer(serverId);
        }

        [Fact]
        public async Task GetDbServer()
        {
            var serverId = await CreateNewDbServer();
            var server = await gsClient.TranslationMemories.GetDbServerById(serverId);

            Assert.Equal(server.DatabaseServerId, serverId);
            await gsClient.TranslationMemories.DeleteDbServer(serverId);
        }

        [Fact]
        public async Task UpdateDbServer()
        {
            var serverId = await CreateNewDbServer();

            Assert.True(serverId != string.Empty);

            var request = new RequestDbServer("Updated server name", "", "", "");

            await gsClient.TranslationMemories.UpdateDbServer(serverId, request);
            var updatedServer = await gsClient.TranslationMemories.GetDbServerById(serverId);

            Assert.Equal("Updated server name", updatedServer.Name);

            await gsClient.TranslationMemories.DeleteDbServer(serverId);
        }

        [Fact]
        public async Task DeleteDbServer()
        {
            var serverId = await CreateNewDbServer();
            await gsClient.TranslationMemories.DeleteDbServer(serverId).ConfigureAwait(false);

            Task result() => gsClient.TranslationMemories.GetDbServerById(serverId);
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

            var serverId = await gsClient.TranslationMemories.CreateDbServer(dbServerRequest);
            return serverId;
        }
    }
}