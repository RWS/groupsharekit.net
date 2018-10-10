using Sdl.Community.GroupShareKit.Models.Response.TranslationMemory;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class TmClientContainer
    {
        [Fact]
        public async Task GetContainers()
        {
            var groupShareClient = await Helper.GetGroupShareClient();

            var response = await groupShareClient.TranslationMemories.GetContainers();
            Assert.True(response.Items.Count > 0);
        }

        [Fact]
        public async Task CreateContainer()
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var request = new ContainerRequest
            {
                OwnerId = "10356fd8-a087-4676-a320-d72c8f1fa0bd",
                Location = "/SDL Community Developers/Project Resources",
                ContainerId = Guid.NewGuid().ToString(),
                DatabaseServerId = "8294e2e4-30dd-4dec-9bd9-7cb10bcf70b0",
                DatabaseName = "containerName1",
                DisplayName = " Container",
                IsShared = false
            };

            var containerId = await groupShareClient.TranslationMemories.CreateContainer(request);
            Assert.True(containerId != string.Empty);

            await groupShareClient.TranslationMemories.DeleteContainer(containerId);
        }

        [Theory]
        [InlineData("ee2871af-a5a5-46ca-9b05-0f216744e8fe")]
        public async Task GetContainerById(string containerId)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var container = await groupShareClient.TranslationMemories.GetContainerById(containerId);

            Assert.Equal(container.ContainerId, containerId);
        }

        [Fact]
        public async Task DeleteContainer()
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var request = new ContainerRequest
            {
                OwnerId = "10356fd8-a087-4676-a320-d72c8f1fa0bd",
                Location = "/SDL Community Developers/Project Resources",
                ContainerId = Guid.NewGuid().ToString(),
                DatabaseServerId = "8294e2e4-30dd-4dec-9bd9-7cb10bcf70b0",
                DatabaseName = "Testcontainer1",
                DisplayName = " Testcontainer1",
                IsShared = false
            };

            var containerId = await groupShareClient.TranslationMemories.CreateContainer(request);

            await groupShareClient.TranslationMemories.DeleteContainer(containerId);
        }

        [Fact]
        public async Task UpdateContainer()
        {
            //Creates a new container
            var groupShareClient = await Helper.GetGroupShareClient();
            var request = new ContainerRequest
            {
                OwnerId = "10356fd8-a087-4676-a320-d72c8f1fa0bd",
                Location = "/SDL Community Developers/Project Resources",
                ContainerId = Guid.NewGuid().ToString(),
                DatabaseServerId = "8294e2e4-30dd-4dec-9bd9-7cb10bcf70b0",
                DatabaseName = "Testcontainer1",
                DisplayName = " Testcontainer1",
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

            //Deletes created container
            await groupShareClient.TranslationMemories.DeleteContainer(containerId);
        }
    }
}