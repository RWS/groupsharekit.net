using Sdl.Community.GroupShareKit.Models.Response.TranslationMemory;
using System;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Exceptions;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class TranslationMemoryClientDatabaseServerTest
    {
        [Fact]
        public async Task GetDbServers()
        {
            var groupShareClient = Helper.GsClient;

            var response = await groupShareClient.TranslationMemories.GetDbServers();

            Assert.True(response.Items.Count > 0);
        }

        [Fact]
        public async Task CreateDbServer()
        {
            var groupShareClient = Helper.GsClient;
            var dbServerRequest = new DatabaseServerRequest
            {
                DatabaseServerId = Guid.NewGuid().ToString(),
                Name = "Test Server",
                Description = "Added from kit",
                OwnerId = Helper.OrganizationId,
                Location = Helper.OrganizationPath,
                Host = Helper.GsServerName
            };

            var serverId = await groupShareClient.TranslationMemories.CreateDbServer(dbServerRequest);

            Assert.True(serverId != string.Empty);

            await groupShareClient.TranslationMemories.DeleteDbServer(serverId);
        }

        [Fact]
        public async Task GetDbServer()
        {
            var groupShareClient = Helper.GsClient;
            var dbServerRequest = new DatabaseServerRequest
            {
                DatabaseServerId = Guid.NewGuid().ToString(),
                Name = "Test Server",
                Description = "Added from kit",
                OwnerId = Helper.OrganizationId,
                Location = Helper.OrganizationPath,
                Host = Helper.GsServerName
            };

            var serverId = await groupShareClient.TranslationMemories.CreateDbServer(dbServerRequest);
            var server = await groupShareClient.TranslationMemories.GetDbServerById(serverId);

            Assert.Equal(server.DatabaseServerId, serverId);
        }

        [Fact]
        public async Task UpdateDbServer()
        {
            var groupShareClient = Helper.GsClient;

             var dbServerRequest = new DatabaseServerRequest
            {
                DatabaseServerId = Guid.NewGuid().ToString(),
                Name = "Test Server",
                Description = "Added from kit",
                OwnerId = Helper.OrganizationId,
                Location = Helper.OrganizationPath,
                Host = Helper.GsServerName
            };

            var serverId = await groupShareClient.TranslationMemories.CreateDbServer(dbServerRequest);

            Assert.True(serverId != string.Empty);

            var request = new RequestDbServer("Updated server name", "", "", "");

            await groupShareClient.TranslationMemories.UpdateDbServer(serverId, request);
            var updatedServer = await groupShareClient.TranslationMemories.GetDbServerById(serverId);

            Assert.Equal("Updated server name", updatedServer.Name);

            await groupShareClient.TranslationMemories.DeleteDbServer(serverId);
        }

        [Fact]
        public async Task DeleteDbServer()
        {
            var groupShareClient = Helper.GsClient;

            var databaseServerId = Guid.NewGuid().ToString();
            var dbServerRequest = new DatabaseServerRequest
            {
                DatabaseServerId = databaseServerId,
                Name = $"Database server {databaseServerId}",
                Description = "added from integration test",
                OwnerId = Helper.OrganizationId,
                Location = Helper.OrganizationPath,
                Host = Helper.GsServerName
            };

            var serverId = await groupShareClient.TranslationMemories.CreateDbServer(dbServerRequest).ConfigureAwait(false);
            await groupShareClient.TranslationMemories.DeleteDbServer(serverId).ConfigureAwait(false);

            Task result() => groupShareClient.TranslationMemories.GetDbServerById(serverId);
            await Assert.ThrowsAsync<ForbiddenException>(result);
        }
    }
}