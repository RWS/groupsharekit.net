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
        public async Task GetServers()
        {
            var serverId = await CreateTestDbServer();
            var response = await GroupShareClient.TranslationMemories.GetDbServers();

            Assert.True(response.Items.Count > 0);
            await GroupShareClient.TranslationMemories.DeleteDbServer(serverId);
        }

        [Fact]
        public async Task CreateServer()
        {
            var databaseServerId = Guid.NewGuid();
            var name = $"Server - {databaseServerId}";
            var description = "Created using GroupShare Kit";

            var databaseServerRequest = new CreateDatabaseServerRequest
            {
                DatabaseServerId = databaseServerId,
                Name = name,
                Description = description,
                OwnerId = Guid.Parse(Helper.OrganizationId),
                Location = Helper.OrganizationPath,
                Host = Helper.GsServerName
            };

            var serverId = await GroupShareClient.TranslationMemories.CreateDbServer(databaseServerRequest);
            var server = await GroupShareClient.TranslationMemories.GetDbServer(serverId);

            Assert.Equal(databaseServerId, server.DatabaseServerId);
            Assert.Equal(name, server.Name);
            Assert.Equal(Guid.Parse(Helper.OrganizationId), server.OwnerId);
            Assert.Equal(description, server.Description);

            await GroupShareClient.TranslationMemories.DeleteDbServer(serverId);
        }

        [Fact]
        public async Task GetServer()
        {
            var serverId = await CreateTestDbServer();
            var server = await GroupShareClient.TranslationMemories.GetDbServer(serverId);

            Assert.Equal(server.DatabaseServerId, serverId);
            await GroupShareClient.TranslationMemories.DeleteDbServer(serverId);
        }

        [Fact]
        public async Task UpdateServer()
        {
            var serverId = await CreateTestDbServer();

            var request = new UpdateDatabaseServerRequest
            {
                Name = $"Edited name - {Guid.NewGuid()}",
                Description = "Edited description"
            };

            await GroupShareClient.TranslationMemories.UpdateDbServer(serverId, request);

            var updatedServer = await GroupShareClient.TranslationMemories.GetDbServer(serverId);

            Assert.Equal(request.Name, updatedServer.Name);
            Assert.Equal(request.Description, updatedServer.Description);

            await GroupShareClient.TranslationMemories.DeleteDbServer(serverId);
        }

        [Fact]
        public async Task DeleteServer()
        {
            var serverId = await CreateTestDbServer();
            await GroupShareClient.TranslationMemories.DeleteDbServer(serverId);

            Task result() => GroupShareClient.TranslationMemories.GetDbServer(serverId);
            await Assert.ThrowsAsync<ForbiddenException>(result);
        }

        public async Task<Guid> CreateTestDbServer()
        {
            var dbServerRequest = new CreateDatabaseServerRequest
            {
                Name = $"Server - {Guid.NewGuid()}",
                Description = "Created using GroupShare Kit",
                OwnerId = Guid.Parse(Helper.OrganizationId),
                Location = Helper.OrganizationPath,
                Host = Helper.GsServerName
            };

            var serverId = await GroupShareClient.TranslationMemories.CreateDbServer(dbServerRequest);

            return serverId;
        }
    }
}