using Sdl.Community.GroupShareKit.Models.Response.TranslationMemory;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class TranslationMemoryClientDatabaseServerTest
    {
        [Fact]
        public async Task GetDbServers()
        {
            var groupShareClient = await Helper.GetGroupShareClient();

            var response = await groupShareClient.TranslationMemories.GetDbServers();

            Assert.True(response.Items.Count>0);
        }

        [Fact]
        public async Task CreateDbServer()
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var dbServerRequest = new DatabaseServerRequest
            {
                DatabaseServerId = Guid.NewGuid().ToString(),
                Name = "Added server",
                Description = "Added from kit",
                OwnerId = "5bdb10b8-e3a9-41ae-9e66-c154347b8d17",
                Location = "/SDL Community Developers",
                Password = "Commun1tyRocks",
                UserName = "SDLCommunity",
                Host = "Added server"
            };

            var serverId = await groupShareClient.TranslationMemories.CreateDbServer(dbServerRequest);

            Assert.True(serverId != string.Empty);

            await groupShareClient.TranslationMemories.DeleteDbServer(serverId);
        }

        [Theory]
        [InlineData("6c32b2ed-77b3-41fa-87f3-02cce2db72e4")]
        public async Task GetDbServer(string serverId)
        {
            var groupShareClient = await Helper.GetGroupShareClient();

            var server = await groupShareClient.TranslationMemories.GetDbServerById(serverId);

            Assert.Equal(server.DatabaseServerId,serverId);
        }

        [Fact]
        public async Task UpdateDbServer()
        {
            var groupShareClient = await Helper.GetGroupShareClient();

            var dbServerRequest = new DatabaseServerRequest
            {
                DatabaseServerId = Guid.NewGuid().ToString(),
                Name = "Added server",
                Description = "Added from kit",
                OwnerId = "5bdb10b8-e3a9-41ae-9e66-c154347b8d17",
                Location = "/SDL Community Developers",
                Password = "Commun1tyRocks",
                UserName = "SDLCommunity",
                Host = "Added server"
            };

            var serverId = await groupShareClient.TranslationMemories.CreateDbServer(dbServerRequest);

            Assert.True(serverId != string.Empty);

            var request = new RequestDbServer("Updated server name", "", "SDLCommunity", "Commun1tyRocks");

            await groupShareClient.TranslationMemories.UpdateDbServer(serverId, request);
            var updatedServer = await groupShareClient.TranslationMemories.GetDbServerById(serverId);

            Assert.Equal("Updated server name", updatedServer.Name);

            await groupShareClient.TranslationMemories.DeleteDbServer(serverId);
        }

        [Fact]
        public async Task DeleteDbServer()
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var dbServerRequest = new DatabaseServerRequest
            {
                DatabaseServerId = Guid.NewGuid().ToString(),
                Name = "server",
                Description = "Added from kit",
                OwnerId = "5bdb10b8-e3a9-41ae-9e66-c154347b8d17",
                Location = "/SDL Community Developers",
                Password = "Commun1tyRocks",
                UserName = "SDLCommunity",
                Host = "server"
            };

            var serverId = await groupShareClient.TranslationMemories.CreateDbServer(dbServerRequest);

            await groupShareClient.TranslationMemories.DeleteDbServer(serverId);
        }        
    }
}