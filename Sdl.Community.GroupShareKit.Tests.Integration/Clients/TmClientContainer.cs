using Sdl.Community.GroupShareKit.Models.Response.TranslationMemory;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class TmClientContainer
    {
        private readonly DatabaseServerRequest DbServerRequest;
        public TmClientContainer()
        {
           var groupShareClient = Helper.GsClient;
           DbServerRequest = new DatabaseServerRequest
           {
               DatabaseServerId = Guid.NewGuid().ToString(),
               Name = "Test Server",
               Description = "Added from kit",
               OwnerId = Helper.OrganizationId,
               Location =Helper.OrganizationPath,
               Host = Helper.GsServerName
           };
        }

        [Fact]
        public async Task GetContainers()
        {
            var groupShareClient = Helper.GsClient;

            var response = await groupShareClient.TranslationMemories.GetContainers();
            Assert.True(response.Items.Count > 0);
        }

        [Fact]
        public async Task CreateContainer()
        {
            var groupShareClient = Helper.GsClient;
            var dbServerId = await groupShareClient.TranslationMemories.CreateDbServer(DbServerRequest);
            var containerGuid = Guid.NewGuid().ToString();
            var request = new ContainerRequest
            {
                OwnerId = Helper.OrganizationId,
                Location = Helper.OrganizationPath,
                ContainerId = containerGuid,
                DatabaseServerId = dbServerId,
                DatabaseName = "TestContainer",
                DisplayName = "TestContainer",
                IsShared = false
            };

            var containerId = await groupShareClient.TranslationMemories.CreateContainer(request);
            Assert.True(containerId != string.Empty);

            await groupShareClient.TranslationMemories.DeleteContainer(containerId);
            await groupShareClient.TranslationMemories.DeleteDbServer(dbServerId);
        }

        [Fact]
        public async Task GetContainerById()
        {
            var groupShareClient = Helper.GsClient;
            var dbServerId = await groupShareClient.TranslationMemories.CreateDbServer(DbServerRequest);
            var containerGuid = Guid.NewGuid().ToString();
            var request = new ContainerRequest
            {
                OwnerId = Helper.OrganizationId,
                Location = Helper.OrganizationPath,
                ContainerId = containerGuid,
                DatabaseServerId = dbServerId,
                DatabaseName = "TestContainer",
                DisplayName = "TestContainer",
                IsShared = false
            };
            var containerId = await groupShareClient.TranslationMemories.CreateContainer(request);
            var container = await groupShareClient.TranslationMemories.GetContainerById(containerId);
            Assert.Equal(container.ContainerId, containerId);

            await groupShareClient.TranslationMemories.DeleteContainer(containerId);
            await groupShareClient.TranslationMemories.DeleteDbServer(dbServerId);
        }

        [Fact]
        public async Task DeleteContainer()
        {
            var groupShareClient = Helper.GsClient;
            var dbServerId = await groupShareClient.TranslationMemories.CreateDbServer(DbServerRequest);
            var containerGuid = Guid.NewGuid().ToString();
            var request = new ContainerRequest
            {
                OwnerId = Helper.OrganizationId,
                Location = Helper.OrganizationPath,
                ContainerId = containerGuid,
                DatabaseServerId = dbServerId,
                DatabaseName = "TestContainer",
                DisplayName = "TestContainer",
                IsShared = false
            };

            var containerId = await groupShareClient.TranslationMemories.CreateContainer(request);
            var containersBefore= await groupShareClient.TranslationMemories.GetContainers();
            var containersBeforeCount = containersBefore.Items.Count;
            await groupShareClient.TranslationMemories.DeleteContainer(containerId);
            var containers = await groupShareClient.TranslationMemories.GetContainers();
            var containersCount = containers.Items.Count;

            Assert.True(containersCount < containersBeforeCount);
        }

        [Fact]
        public async Task UpdateContainer()
        {
            //Creates a new container
            var groupShareClient = Helper.GsClient;
            var dbServerId = await groupShareClient.TranslationMemories.CreateDbServer(DbServerRequest);
            var containerGuid = Guid.NewGuid().ToString();
            var request = new ContainerRequest
            {
                OwnerId = Helper.OrganizationId,
                Location = Helper.OrganizationPath,
                ContainerId = containerGuid,
                DatabaseServerId = dbServerId,
                DatabaseName = "TestContainer",
                DisplayName = "TestContainer",
                IsShared = false
            };

            var containerId = await groupShareClient.TranslationMemories.CreateContainer(request);

            var updateRequest = new UpdateContainerRequest
            {
                ContainerId = containerId,
                DisplayName = "Updated Name",
                IsShared = false
            };

            //Update container
            await groupShareClient.TranslationMemories.UpdateContainer(containerId, updateRequest);

            var container = await groupShareClient.TranslationMemories.GetContainerById(containerId);

            Assert.Equal("Updated Name", container.DisplayName);

            //Deletes created container and db server
            await groupShareClient.TranslationMemories.DeleteContainer(containerId);
            await groupShareClient.TranslationMemories.DeleteDbServer(dbServerId);
        }
    }
}