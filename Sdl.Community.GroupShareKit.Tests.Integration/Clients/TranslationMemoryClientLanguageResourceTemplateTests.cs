using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Models.Response.TranslationMemory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class TranslationMemoryClientLanguageResourceTemplatesTests
    {
        private static readonly GroupShareClient GroupShareClient = Helper.GsClient;

        [Fact]
        public async Task GetAllLanguageResourceTemplates()
        {
            var languageResourceTemplateId = await CreateTestLanguageResourceTemplate();
            var templatesResponse = await GroupShareClient.TranslationMemories.GetAllLanguageResourceTemplates();

            Assert.True(templatesResponse.Items.Count > 0);
            await GroupShareClient.TranslationMemories.DeleteLanguageResourceTemplate(languageResourceTemplateId);
        }

        [Fact]
        public async Task GetLanguageResourceTemplate()
        {
            var languageResourceTemplateId = await CreateTestLanguageResourceTemplate();
            var languageResourceTemplate = await GroupShareClient.TranslationMemories.GetLanguageResourceTemplate(languageResourceTemplateId);

            Assert.Equal(languageResourceTemplateId, Guid.Parse(languageResourceTemplate.LanguageResourceTemplateId));
            await GroupShareClient.TranslationMemories.DeleteLanguageResourceTemplate(languageResourceTemplateId);
        }

        [Fact]
        public async Task UpdateLanguageResourceTemplate()
        {
            var languageResourceTemplateId = await CreateTestLanguageResourceTemplate();
            var updateRequest = new UpdateTemplateRequest
            {
                Name = "UpdatedName",
                Description = "Edited using GroupShare Kit"
            };

            await GroupShareClient.TranslationMemories.UpdateLanguageResourceTemplate(languageResourceTemplateId, updateRequest);

            var languageResourceTemplate = await GroupShareClient.TranslationMemories.GetLanguageResourceTemplate(languageResourceTemplateId);

            Assert.Equal("UpdatedName", languageResourceTemplate.Name);
            await GroupShareClient.TranslationMemories.DeleteLanguageResourceTemplate(languageResourceTemplateId);
        }

        [Fact]
        public async Task CreateLanguageResourceTemplate()
        {
            var languageResourceTemplateId = await CreateTestLanguageResourceTemplate();
            var languageResourceTemplate = await GroupShareClient.TranslationMemories.GetLanguageResourceTemplate(languageResourceTemplateId);

            Assert.Equal("Created using GroupShare Kit", languageResourceTemplate.Description);

            await GroupShareClient.TranslationMemories.DeleteLanguageResourceTemplate(languageResourceTemplateId);
        }

        [Fact]
        public async Task DeleteLanguageResourceTemplateTemplate()
        {
            var languageResourceTemplateId = await CreateTestLanguageResourceTemplate();
            var lrTemplatesBefore = await GroupShareClient.TranslationMemories.GetAllLanguageResourceTemplates();
            var lrTemplatesCountBefore = lrTemplatesBefore.Items.Count;

            await GroupShareClient.TranslationMemories.DeleteLanguageResourceTemplate(languageResourceTemplateId);
            var lrTemplates = await GroupShareClient.TranslationMemories.GetAllLanguageResourceTemplates();
            var lrTemplatesCount = lrTemplates.Items.Count;

            Assert.True(lrTemplatesCount < lrTemplatesCountBefore);
        }

        public async Task<Guid> CreateTestLanguageResourceTemplate()
        {
            var request = new ResourceServiceDefaultsRequest(ResourceServiceDefaultsRequest.ResourceType.Variables, "ro-ro");
            var resource = await GroupShareClient.TranslationMemories.GetDefaultsType(request);

            //var template = new LanguageResourceTemplate
            //{
            //    LanguageResourceTemplateId = Guid.NewGuid().ToString(),
            //    Name = $"Language processing rule - {Guid.NewGuid()}",
            //    Description = "Created using GroupShare Kit",
            //    OwnerId = Helper.OrganizationId,
            //    Location = Helper.OrganizationPath,
            //    IsTmSpecific = false,
            //    LanguageResources = new List<Resource>
            //    {
            //       new Resource
            //       {
            //           Type = "Variables",
            //           LanguageResourceTemplateId = resource.LanguageResourceTemplateId,
            //           Data = "test",
            //           CultureName = "ro-ro",
            //       }
            //    }
            //};

            var languageResourceTemplateRequest = new CreateLanguageResourceTemplateRequest
            {
                Name = $"Language processing rule - {Guid.NewGuid()}",
                Description = "Created using GroupShare Kit",
                IsTmSpecific = false,
                Recognizers = "RecognizeAll",
                WordCountFlags = "DefaultFlags",
                TokenizerFlags = "DefaultFlags",
                OwnerId = Guid.Parse(Helper.OrganizationId),
                LanguageResources = new List<Resource>
                {
                    new Resource
                    {
                        CultureName = "ro-ro",
                        Type = "Variables",
                        Data = "test"
                    }
                }
            };

            var languageResourceTemplateId = await GroupShareClient.TranslationMemories.CreateLanguageResourceTemplate(languageResourceTemplateRequest);
            return languageResourceTemplateId;
        }
    }
}