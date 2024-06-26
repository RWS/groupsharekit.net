using Sdl.Community.GroupShareKit.Models.Response.TranslationMemory;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class TmClientContainerTests
    {
        private readonly GroupShareClient groupShareClient = Helper.GsClient;
        private readonly CreateDatabaseServerRequest _databaseServerRequest;

        public TmClientContainerTests()
        {
            _databaseServerRequest = new CreateDatabaseServerRequest
            {
                DatabaseServerId = Guid.NewGuid(),
                Name = $"Server - {Guid.NewGuid()}",
                Description = "Created using GroupShare Kit",
                OwnerId = Guid.Parse(Helper.OrganizationId),
                Location = Helper.OrganizationPath,
                Host = Helper.GsServerName
            };
        }

        [Fact]
        public async Task GetContainers()
        {
            var dbServerId = await groupShareClient.TranslationMemories.CreateDbServer(_databaseServerRequest);
            var containerId = await CreateNewTmContainer(dbServerId);
            var response = await groupShareClient.TranslationMemories.GetContainers();

            Assert.True(response.Items.Count > 0);

            await groupShareClient.TranslationMemories.DeleteContainer(containerId);
            await groupShareClient.TranslationMemories.DeleteDbServer(dbServerId);
        }

        [Fact]
        public async Task CreateContainer()
        {
            var dbServerId = await groupShareClient.TranslationMemories.CreateDbServer(_databaseServerRequest);
            var randomNumber = new Random().Next(100, 10000);
            var name = $"Container_{randomNumber}";

            var request = new CreateContainerRequest
            {
                DatabaseServerId = dbServerId,
                DisplayName = name,
                DatabaseName = name,
                IsShared = false,
                OwnerId = Guid.Parse(Helper.OrganizationId),
                Location = Helper.OrganizationPath,
            };

            var containerId = await groupShareClient.TranslationMemories.CreateContainer(request);
            var container = await groupShareClient.TranslationMemories.GetContainer(containerId);

            Assert.Equal(name, container.DisplayName);
            Assert.Equal(name, container.DatabaseName);
            Assert.Equal(dbServerId, container.DatabaseServerId);
            Assert.False(container.IsShared);

            await groupShareClient.TranslationMemories.DeleteContainer(containerId);
            await groupShareClient.TranslationMemories.DeleteDbServer(dbServerId);
        }

        [Fact]
        public async Task GetContainerById()
        {
            var dbServerId = await groupShareClient.TranslationMemories.CreateDbServer(_databaseServerRequest);
            var containerId = await CreateNewTmContainer(dbServerId);
            var container = await groupShareClient.TranslationMemories.GetContainer(containerId);

            Assert.Equal(container.ContainerId, containerId);

            await groupShareClient.TranslationMemories.DeleteContainer(containerId);
            await groupShareClient.TranslationMemories.DeleteDbServer(dbServerId);
        }

        [Fact]
        public async Task DeleteContainer()
        {
            var dbServerId = await groupShareClient.TranslationMemories.CreateDbServer(_databaseServerRequest);
            var containerId = await CreateNewTmContainer(dbServerId);

            var containersBefore = await groupShareClient.TranslationMemories.GetContainers();
            var containersBeforeCount = containersBefore.Items.Count;

            await groupShareClient.TranslationMemories.DeleteContainer(containerId);
            var containers = await groupShareClient.TranslationMemories.GetContainers();
            var containersCount = containers.Items.Count;

            Assert.True(containersCount < containersBeforeCount);
            await groupShareClient.TranslationMemories.DeleteDbServer(dbServerId);
        }

        [Fact]
        public async Task UpdateContainer()
        {
            var dbServerId = await groupShareClient.TranslationMemories.CreateDbServer(_databaseServerRequest);
            var containerId = await CreateNewTmContainer(dbServerId);

            var updateRequest = new UpdateContainerRequest
            {
                ContainerId = containerId,
                DisplayName = "Updated Name",
                IsShared = false
            };

            //Update container
            await groupShareClient.TranslationMemories.UpdateContainer(containerId, updateRequest);

            var container = await groupShareClient.TranslationMemories.GetContainer(containerId);

            Assert.Equal("Updated Name", container.DisplayName);

            //Deletes created container and db server
            await groupShareClient.TranslationMemories.DeleteContainer(containerId);
            await groupShareClient.TranslationMemories.DeleteDbServer(dbServerId);
        }

        public async Task<Guid> CreateNewTmContainer(Guid serverId)
        {
            var containerGuid = Guid.NewGuid().ToString();
            var request = new CreateContainerRequest
            {
                OwnerId = Guid.Parse(Helper.OrganizationId),
                Location = Helper.OrganizationPath,
                DatabaseServerId = serverId,
                DatabaseName = "TestContainer",
                DisplayName = "TestContainer",
                IsShared = false
            };

            var containerId = await groupShareClient.TranslationMemories.CreateContainer(request);
            return containerId;
        }
    }
}