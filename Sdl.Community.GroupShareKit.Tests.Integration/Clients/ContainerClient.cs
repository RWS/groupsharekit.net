using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Models.Response.TranslationMemory;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
   public  class ContainerClient
    {
       [Fact]
       public async Task GetContainers()
       {
            var groupShareClient = await Helper.GetAuthenticatedClient();

           var response = await groupShareClient.Container.GetContainers();
            Assert.True(response.Items.Count>0);
       }

       [Fact]
       public async Task CreateContainer()
       {
            var groupShareClient = await Helper.GetAuthenticatedClient();
           var request = new ContainerRequest
           {
               OwnerId = "10356fd8-a087-4676-a320-d72c8f1fa0bd",
               Location = "/SDL Community Developers/Project Resources",
               ContainerId = Guid.NewGuid().ToString(),
               DatabaseServerId = "8294e2e4-30dd-4dec-9bd9-7cb10bcf70b0",
               DatabaseName = "containerName",
               DisplayName = " Container",
               IsShared = false
           };

           var containerId = await groupShareClient.Container.CreateContainer(request);
            Assert.True(containerId!=string.Empty);
       }

       [Theory]
       [InlineData("1327bcee-97ea-44e8-84f7-8a8a4f13b5b5")]
       public async Task GetContainerById(string containerId)
       {
            var groupShareClient = await Helper.GetAuthenticatedClient();
           var container = await groupShareClient.Container.GetContainerById(containerId);

            Assert.Equal(container.ContainerId,containerId);
       }

       [Fact]
       public async Task DeleteContainer()
       {
            var groupShareClient = await Helper.GetAuthenticatedClient();
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

            var containerId = await groupShareClient.Container.CreateContainer(request);

           await groupShareClient.Container.DeleteContainer(containerId);
       }

       [Theory]
       [InlineData("61807b9d-7863-43b4-9701-6c78eaf21b2e")]
       public async Task UpdateContainer(string containerId)
       {
            var groupShareClient = await Helper.GetAuthenticatedClient();
           var updateRequest = new UpdateContainerRequest
           {
               ContainerId = containerId,
               DisplayName = "Updated Name",
               IsShared = false
           };

           await groupShareClient.Container.UpdateContainer(containerId,updateRequest);

           var container = await groupShareClient.Container.GetContainerById(containerId);

            Assert.Equal(container.DisplayName, "Updated Name");
       }

    }
}
