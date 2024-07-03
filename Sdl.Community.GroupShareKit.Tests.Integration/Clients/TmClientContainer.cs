using Sdl.Community.GroupShareKit.Models.Response.TranslationMemory;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class TmClientContainerTests
    {
        private readonly GroupShareClient GroupShareClient = Helper.GsClient;
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
            var dbServerId = await GroupShareClient.TranslationMemories.CreateDbServer(_databaseServerRequest);
            var containerId = await CreateTestTmContainer(dbServerId);
            var response = await GroupShareClient.TranslationMemories.GetContainers();

            Assert.True(response.Items.Count > 0);
            Assert.Contains(response.Items, container => container.ContainerId.Equals(containerId));

            await GroupShareClient.TranslationMemories.DeleteContainer(containerId);
            await GroupShareClient.TranslationMemories.DeleteDbServer(dbServerId);
        }

        [Fact]
        public async Task CreateContainer()
        {
            var dbServerId = await GroupShareClient.TranslationMemories.CreateDbServer(_databaseServerRequest);
            var containerName = $"Container_{DateTime.Now.Ticks}";

            var request = new CreateContainerRequest
            {
                DatabaseServerId = dbServerId,
                DisplayName = containerName,
                DatabaseName = containerName,
                IsShared = false,
                OwnerId = Guid.Parse(Helper.OrganizationId),
                Location = Helper.OrganizationPath,
            };

            var containerId = await GroupShareClient.TranslationMemories.CreateContainer(request);
            var container = await GroupShareClient.TranslationMemories.GetContainer(containerId);

            Assert.Equal(containerName, container.DisplayName);
            Assert.Equal(containerName, container.DatabaseName);
            Assert.Equal(dbServerId, container.DatabaseServerId);
            Assert.False(container.IsShared);

            await GroupShareClient.TranslationMemories.DeleteContainer(containerId);
            await GroupShareClient.TranslationMemories.DeleteDbServer(dbServerId);
        }

        [Fact]
        public async Task GetContainer()
        {
            var dbServerId = await GroupShareClient.TranslationMemories.CreateDbServer(_databaseServerRequest);
            var containerId = await CreateTestTmContainer(dbServerId);
            var container = await GroupShareClient.TranslationMemories.GetContainer(containerId);

            Assert.Equal(container.ContainerId, containerId);

            await GroupShareClient.TranslationMemories.DeleteContainer(containerId);
            await GroupShareClient.TranslationMemories.DeleteDbServer(dbServerId);
        }

        [Fact]
        public async Task DeleteContainer()
        {
            var dbServerId = await GroupShareClient.TranslationMemories.CreateDbServer(_databaseServerRequest);
            var containerId = await CreateTestTmContainer(dbServerId);

            var containersBefore = await GroupShareClient.TranslationMemories.GetContainers();
            var containersBeforeCount = containersBefore.Items.Count;

            await GroupShareClient.TranslationMemories.DeleteContainer(containerId);
            var containers = await GroupShareClient.TranslationMemories.GetContainers();
            var containersCount = containers.Items.Count;

            Assert.True(containersCount < containersBeforeCount);
            await GroupShareClient.TranslationMemories.DeleteDbServer(dbServerId);
        }

        [Fact]
        public async Task UpdateContainer()
        {
            var dbServerId = await GroupShareClient.TranslationMemories.CreateDbServer(_databaseServerRequest);
            var containerId = await CreateTestTmContainer(dbServerId);

            var newContainerName = $"Container_{DateTime.Now.Ticks}";

            var updateRequest = new UpdateContainerRequest
            {
                ContainerId = containerId,
                DisplayName = newContainerName,
                IsShared = false
            };

            //Update container
            await GroupShareClient.TranslationMemories.UpdateContainer(containerId, updateRequest);

            var container = await GroupShareClient.TranslationMemories.GetContainer(containerId);

            Assert.Equal(newContainerName, container.DisplayName);

            //Delete created container and database server
            await GroupShareClient.TranslationMemories.DeleteContainer(containerId);
            await GroupShareClient.TranslationMemories.DeleteDbServer(dbServerId);
        }

        public async Task<Guid> CreateTestTmContainer(Guid serverId)
        {
            var containerName = $"Container_{DateTime.Now.Ticks}";

            var request = new CreateContainerRequest
            {
                OwnerId = Guid.Parse(Helper.OrganizationId),
                Location = Helper.OrganizationPath,
                DatabaseServerId = serverId,
                DatabaseName = containerName,
                DisplayName = containerName,
                IsShared = false
            };

            var containerId = await GroupShareClient.TranslationMemories.CreateContainer(request);
            return containerId;
        }
    }
}