using Sdl.Community.GroupShareKit.Models.Response.TranslationMemory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class TranslationMemoryClientLanguageResourceTemplatesTests : IDisposable
    {
        private static readonly GroupShareClient GroupShareClient = Helper.GsClient;

        private Guid _languageResourceId;
        private Guid _languageResourceTemplateId;

        public TranslationMemoryClientLanguageResourceTemplatesTests()
        {
            _languageResourceTemplateId = CreateTestLanguageResourceTemplate().Result;
            //_languageResourceId = GroupShareClient.TranslationMemories.GetLanguageResources(_languageResourceTemplateId).Result;
        }

        [Fact]
        public async Task GetAllLanguageResourceTemplates()
        {
            var templatesResponse = await GroupShareClient.TranslationMemories.GetAllLanguageResourceTemplates();

            Assert.True(templatesResponse.Items.Count > 0);
        }

        [Fact]
        public async Task GetLanguageResourceTemplate()
        {
            var languageResourceTemplate = await GroupShareClient.TranslationMemories.GetLanguageResourceTemplate(_languageResourceTemplateId);

            Assert.Equal(_languageResourceTemplateId, Guid.Parse(languageResourceTemplate.LanguageResourceTemplateId));
        }

        [Fact]
        public async Task UpdateLanguageResourceTemplate()
        {
            var updateRequest = new UpdateTemplateRequest
            {
                Name = "UpdatedName",
                Description = "Edited using GroupShare Kit"
            };

            await GroupShareClient.TranslationMemories.UpdateLanguageResourceTemplate(_languageResourceTemplateId, updateRequest);

            var languageResourceTemplate = await GroupShareClient.TranslationMemories.GetLanguageResourceTemplate(_languageResourceTemplateId);

            Assert.Equal("UpdatedName", languageResourceTemplate.Name);
        }

        [Fact]
        public async Task CreateLanguageResourceTemplate()
        {
            var languageResourceTemplate = await GroupShareClient.TranslationMemories.GetLanguageResourceTemplate(_languageResourceTemplateId);

            Assert.Equal("Created using GroupShare Kit", languageResourceTemplate.Description);
        }

        [Fact]
        public async Task DeleteLanguageResourceTemplateTemplate()
        {
            var languageResourceTemplateId = await CreateTestLanguageResourceTemplate();
            var initialLanguageResourceTemplates = await GroupShareClient.TranslationMemories.GetAllLanguageResourceTemplates();
            var initialCount = initialLanguageResourceTemplates.Items.Count;

            await GroupShareClient.TranslationMemories.DeleteLanguageResourceTemplate(languageResourceTemplateId);
            var languageresourceTemplates = await GroupShareClient.TranslationMemories.GetAllLanguageResourceTemplates();

            Assert.True(languageresourceTemplates.Items.Count < initialCount);
        }

        public void Dispose()
        {
            GroupShareClient.TranslationMemories.DeleteLanguageResourceTemplate(_languageResourceTemplateId).Wait();
        }

        public async Task<Guid> CreateTestLanguageResourceTemplate()
        {
            //var request = new ResourceServiceDefaultsRequest(ResourceServiceDefaultsRequest.ResourceType.Variables, "ro-ro");
            //var resource = await GroupShareClient.TranslationMemories.GetDefaultsType(request);

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
                LanguageResources = new List<LanguageResource>
                {
                    new LanguageResource
                    {
                        CultureName = "ro-ro",
                        Type = LanguageResourceType.Variables,
                        Data = "test"
                    }
                }
            };

            var languageResourceTemplateId = await GroupShareClient.TranslationMemories.CreateLanguageResourceTemplate(languageResourceTemplateRequest);

            return languageResourceTemplateId;
        }
    }
}