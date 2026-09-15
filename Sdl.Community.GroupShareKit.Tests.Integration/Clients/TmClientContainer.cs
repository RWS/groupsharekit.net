using Sdl.Community.GroupShareKit.Models.Response.TranslationMemory;
using System;
using System.Linq;
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
                Host = Helper.GsServerName,
                Authentication = "Windows"
            };
        }

        [Fact]
        public async Task GetContainers()
        {
            var response = await GroupShareClient.TranslationMemories.GetContainers();

            Assert.True(response.Items.Count > 0);
        }

        [Fact]
        public async Task CreateContainer()
        {
            var organizationId = Guid.Parse(Helper.OrganizationId);
            var existingContainers = await GroupShareClient.TranslationMemories.GetContainers();
            var sourceContainer = existingContainers.Items
                .FirstOrDefault(item => item.OwnerId == organizationId)
                ?? existingContainers.Items.FirstOrDefault();

            Assert.NotNull(sourceContainer);

            var containerName = $"Container_{DateTime.Now.Ticks}";
            var request = new CreateContainerRequest
            {
                DatabaseServerId = sourceContainer.DatabaseServerId,
                DisplayName = containerName,
                DatabaseName = containerName,
                IsShared = false,
                OwnerId = sourceContainer.OwnerId,
                Location = sourceContainer.Location
            };

            var containerId = await GroupShareClient.TranslationMemories.CreateContainer(request);

            var container = await GroupShareClient.TranslationMemories.GetContainer(containerId);

            Assert.Equal(containerId, container.ContainerId);
            Assert.Equal(containerName, container.DisplayName);
            Assert.Equal(containerName, container.DatabaseName);
            Assert.Equal(sourceContainer.DatabaseServerId, container.DatabaseServerId);
            Assert.False(container.IsShared);

            await GroupShareClient.TranslationMemories.DeleteContainer(containerId);
        }

        [Fact]
        public async Task GetContainer()
        {
            var containers = await GroupShareClient.TranslationMemories.GetContainers();
            Assert.True(containers?.Items?.Count > 0);
            var containerId = containers.Items[0].ContainerId;

            var container = await GroupShareClient.TranslationMemories.GetContainer(containerId);

            Assert.Equal(containerId, container.ContainerId);
        }

        [Fact]
        public async Task DeleteContainer()
        {
            var containersBefore = await GroupShareClient.TranslationMemories.GetContainers();
            var containerToDelete = containersBefore.Items
                .FirstOrDefault(container =>
                    container.OwnerId == Guid.Parse(Helper.OrganizationId) &&
                    container.DisplayName != null &&
                    container.DatabaseName != null &&
                    container.DisplayName.StartsWith("Container_", StringComparison.Ordinal) &&
                    container.DatabaseName.StartsWith("Container_", StringComparison.Ordinal));

            if (containerToDelete == null)
            {
                return;
            }

            var containersBeforeCount = containersBefore.Items.Count;

            await GroupShareClient.TranslationMemories.DeleteContainer(containerToDelete.ContainerId);
            var containers = await GroupShareClient.TranslationMemories.GetContainers();
            var containersCount = containers.Items.Count;

            Assert.True(containersCount < containersBeforeCount);
        }

        [Fact]
        public async Task UpdateContainer()
        {
            var organizationId = Guid.Parse(Helper.OrganizationId);
            var existingContainers = await GroupShareClient.TranslationMemories.GetContainers();
            var sourceContainer = existingContainers.Items
                .FirstOrDefault(item => item.OwnerId == organizationId)
                ?? existingContainers.Items.FirstOrDefault();

            Assert.NotNull(sourceContainer);

            var seedContainerName = $"Container_{DateTime.Now.Ticks}";
            var createRequest = new CreateContainerRequest
            {
                DatabaseServerId = sourceContainer.DatabaseServerId,
                DisplayName = seedContainerName,
                DatabaseName = seedContainerName,
                IsShared = false,
                OwnerId = sourceContainer.OwnerId,
                Location = sourceContainer.Location
            };

            var containerId = await GroupShareClient.TranslationMemories.CreateContainer(createRequest);

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

            //Delete created container
            await GroupShareClient.TranslationMemories.DeleteContainer(containerId);
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