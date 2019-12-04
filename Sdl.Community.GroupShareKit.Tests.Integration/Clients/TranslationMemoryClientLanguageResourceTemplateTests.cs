using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Models.Response.TranslationMemory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class TranslationMemoryClientLanguageResourceTemplateTests
    {
        [Fact]
        public async Task GetAllLanguageResourceTemplates()
        {
            var groupShareClient = Helper.GsClient;
            var templatesResponse = await groupShareClient.TranslationMemories.GetAllLanguageResourceTemplates();

            Assert.True(templatesResponse.Items.Count > 0);
        }

        [Fact]
        public async Task GetLanguageResourceTemplateById()
        {
            var groupShareClient = Helper.GsClient;
            var request = new ResourceServiceDefaultsRequest(ResourceServiceDefaultsRequest.ResourceType.Variables,
               "ro-ro");

            var resource = await groupShareClient.TranslationMemories.GetDefaultsType(request);
            var template = new LanguageResourceTemplate
            {
                LanguageResourceTemplateId = Guid.NewGuid().ToString(),
                Name = $"test LRTemplate {Guid.NewGuid()}",
                Description = "Created from Groupshare kit",
                OwnerId = Helper.OrganizationId,
                Location = Helper.Organization,
                IsTmSpecific = false,
                LanguageResources = new List<Resource>
                {
                   new Resource
                   {
                       Type = "Variables",
                       LanguageResourceTemplateId = resource.LanguageResourceTemplateId,
                       Data = "test",
                       CultureName = "ro-ro",
                   }
                }
            };

            var id = await groupShareClient.TranslationMemories.CreateTemplate(template);
            var templateById = await groupShareClient.TranslationMemories.GetTemplateById(id);

            Assert.Equal(templateById.LanguageResourceTemplateId, id);
            await groupShareClient.TranslationMemories.DeleteTemplate(id);
        }

        [Fact]
        public async Task UpdateLanguageResourceTemplate()
        {
            var groupShareClient = Helper.GsClient;
            var request = new ResourceServiceDefaultsRequest(ResourceServiceDefaultsRequest.ResourceType.Variables,
              "ro-ro");

            var resource = await groupShareClient.TranslationMemories.GetDefaultsType(request);
            var template = new LanguageResourceTemplate
            {
                LanguageResourceTemplateId = Guid.NewGuid().ToString(),
                Name = $"test LRTemplate {Guid.NewGuid()}",
                Description = "Created from Groupshare kit",
                OwnerId = Helper.OrganizationId,
                Location = Helper.Organization,
                IsTmSpecific = false,
                LanguageResources = new List<Resource>
                {
                   new Resource
                   {
                       Type = "Variables",
                       LanguageResourceTemplateId = resource.LanguageResourceTemplateId,
                       Data = "test",
                       CultureName = "ro-ro",
                   }
                }
            };

            var id = await groupShareClient.TranslationMemories.CreateTemplate(template);
            var updateRequest = new FieldTemplateRequest
            {
                Name = "UpdatedName",
                Description = "updated from kit"
            };

            await groupShareClient.TranslationMemories.EditTemplate(id, updateRequest);

            var templateById = await groupShareClient.TranslationMemories.GetTemplateById(id);

            Assert.Equal("UpdatedName", templateById.Name);
            await groupShareClient.TranslationMemories.DeleteTemplate(id);
        }

        [Fact]
        public async Task CreateTemplate()
        {
            var groupShareClient = Helper.GsClient;
            var request = new ResourceServiceDefaultsRequest(ResourceServiceDefaultsRequest.ResourceType.Variables,
                "ro-ro");

            var resource = await groupShareClient.TranslationMemories.GetDefaultsType(request);
            var template = new LanguageResourceTemplate
            {
                LanguageResourceTemplateId = Guid.NewGuid().ToString(),
                Name = $"test LRTemplate {Guid.NewGuid()}",
                Description = "Created from Groupshare kit",
                OwnerId = Helper.OrganizationId,
                Location = Helper.Organization,
                IsTmSpecific = false,
                LanguageResources = new List<Resource>
                {
                   new Resource
                   {
                       Type = "Variables",
                       LanguageResourceTemplateId = resource.LanguageResourceTemplateId,
                       Data = "test",
                       CultureName = "ro-ro",
                   }
                }
            };

            var id = await groupShareClient.TranslationMemories.CreateTemplate(template);
            Assert.True(id != string.Empty);

            await groupShareClient.TranslationMemories.DeleteTemplate(id);
        }

        [Fact]
        public async Task DeleteTemplate()
        {
            var groupShareClient = Helper.GsClient;
            var template = new LanguageResourceTemplate
            {
                LanguageResourceTemplateId = Guid.NewGuid().ToString(),
                Name = $"test LRTemplate {Guid.NewGuid()}",
                Description = "Template to be deleted",
                OwnerId = Helper.OrganizationId,
                Location = Helper.Organization,
                IsTmSpecific = false,
                LanguageResources = new List<Resource>()
            };

            var id = await groupShareClient.TranslationMemories.CreateTemplate(template);
            var lrTemplatesBefore = await groupShareClient.TranslationMemories.GetAllLanguageResourceTemplates();
            var lrTemplatesCountBefore = lrTemplatesBefore.Items.Count;

            await groupShareClient.TranslationMemories.DeleteTemplate(id);
            var lrTemplates = await groupShareClient.TranslationMemories.GetAllLanguageResourceTemplates();
            var lrTemplatesCount = lrTemplates.Items.Count;

            Assert.True(lrTemplatesCount < lrTemplatesCountBefore);
        }
    }
}