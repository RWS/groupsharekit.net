﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Models.Response.TranslationMemory;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
   public  class TmClientContainer
    {
       [Fact]
       public async Task GetContainers()
       {
            var groupShareClient = await Helper.GetAuthenticatedClient();

           var response = await groupShareClient.TranslationMemories.GetContainers();
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
               DatabaseName = "containerName1",
               DisplayName = " Container",
               IsShared = false
           };

           var containerId = await groupShareClient.TranslationMemories.CreateContainer(request);
            Assert.True(containerId!=string.Empty);

            await groupShareClient.TranslationMemories.DeleteContainer(containerId);
        }

       [Theory]
       [InlineData("bb9c7d71-a7b5-46ba-9f42-47ffd41b80f7")]
       public async Task GetContainerById(string containerId)
       {
            var groupShareClient = await Helper.GetAuthenticatedClient();
           var container = await groupShareClient.TranslationMemories.GetContainerById(containerId);

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

            var containerId = await groupShareClient.TranslationMemories.CreateContainer(request);

           await groupShareClient.TranslationMemories.DeleteContainer(containerId);
       }

       [Fact]  
       public async Task UpdateContainer()
       {
            //Creates a new container
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

            var containerId = await groupShareClient.TranslationMemories.CreateContainer(request);

            var updateRequest = new UpdateContainerRequest
           {
               ContainerId = containerId,
               DisplayName = "Updated Name",
               IsShared = false
           };
            //Update container
           await groupShareClient.TranslationMemories.UpdateContainer(containerId,updateRequest);

           var container = await groupShareClient.TranslationMemories.GetContainerById(containerId);

            Assert.Equal(container.DisplayName, "Updated Name");

            //Deletes created container
           await groupShareClient.TranslationMemories.DeleteContainer(containerId);

       }

    }
}