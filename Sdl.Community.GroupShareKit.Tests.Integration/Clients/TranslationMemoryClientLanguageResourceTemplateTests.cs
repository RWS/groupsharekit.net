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
        private static readonly GroupShareClient GroupShareClient = Helper.GsClient;

        [Fact]
        public async Task GetAllLanguageResourceTemplates()
        {
            var id = await CreateNewLanguageResourceTemplateAsync();
            var templatesResponse = await GroupShareClient.TranslationMemories.GetAllLanguageResourceTemplates();

            Assert.True(templatesResponse.Items.Count > 0);
            await GroupShareClient.TranslationMemories.DeleteTemplate(id);
        }

        [Fact]
        public async Task GetLanguageResourceTemplateById()
        {
            var id = await CreateNewLanguageResourceTemplateAsync();
            var templateById = await GroupShareClient.TranslationMemories.GetTemplateById(id);

            Assert.Equal(templateById.LanguageResourceTemplateId, id);
            await GroupShareClient.TranslationMemories.DeleteTemplate(id);
        }

        [Fact]
        public async Task UpdateLanguageResourceTemplate()
        {
            var id = await CreateNewLanguageResourceTemplateAsync();
            var updateRequest = new FieldTemplateRequest
            {
                Name = "UpdatedName",
                Description = "updated from kit"
            };

            await GroupShareClient.TranslationMemories.EditTemplate(id, updateRequest);

            var templateById = await GroupShareClient.TranslationMemories.GetTemplateById(id);

            Assert.Equal("UpdatedName", templateById.Name);
            await GroupShareClient.TranslationMemories.DeleteTemplate(id);
        }

        [Fact]
        public async Task CreateTemplate()
        {
            var id = await CreateNewLanguageResourceTemplateAsync();
            Assert.True(id != string.Empty);

            await GroupShareClient.TranslationMemories.DeleteTemplate(id);
        }

        [Fact]
        public async Task DeleteTemplate()
        {
            var id = await CreateNewLanguageResourceTemplateAsync();
            var lrTemplatesBefore = await GroupShareClient.TranslationMemories.GetAllLanguageResourceTemplates();
            var lrTemplatesCountBefore = lrTemplatesBefore.Items.Count;

            await GroupShareClient.TranslationMemories.DeleteTemplate(id);
            var lrTemplates = await GroupShareClient.TranslationMemories.GetAllLanguageResourceTemplates();
            var lrTemplatesCount = lrTemplates.Items.Count;

            Assert.True(lrTemplatesCount < lrTemplatesCountBefore);
        }

        public async Task<string> CreateNewLanguageResourceTemplateAsync()
        {
            var request = new ResourceServiceDefaultsRequest(ResourceServiceDefaultsRequest.ResourceType.Variables,
                "ro-ro");
            var resource = await GroupShareClient.TranslationMemories.GetDefaultsType(request);
            var template = new LanguageResourceTemplate
            {
                LanguageResourceTemplateId = Guid.NewGuid().ToString(),
                Name = $"test LRTemplate {Guid.NewGuid()}",
                Description = "Created from Groupshare kit",
                OwnerId = Helper.OrganizationId,
                Location = Helper.OrganizationPath,
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
            var id = await GroupShareClient.TranslationMemories.CreateTemplate(template);
            return id;
        }
    }
}