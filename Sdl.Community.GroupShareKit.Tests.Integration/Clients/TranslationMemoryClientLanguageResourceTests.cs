using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Models.Response.TranslationMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class TranslationMemoryClientLanguageResourceTests
    {
        private static readonly GroupShareClient GroupShareClient = Helper.GsClient;

        private Guid _languageResourceTemplateId;
        private Guid _languageDirectionId;

        public TranslationMemoryClientLanguageResourceTests()
        {
            _languageResourceTemplateId = CreateTestLanguageResourceTemplate().Result;
        }

        [Fact]
        public async Task GetLanguageResourcesForTemplate()
        {
            var resources = await GroupShareClient.TranslationMemories.GetLanguageResources(_languageResourceTemplateId);

            Assert.True(resources.Count > 0);
        }

        [Fact]
        public async Task CreateLanguageResourceForTemplate()
        {
            var resource = new Resource
            {
                Type = "OrdinalFollowers",
                CultureName = "ro-ro",
                Data = "test data"
            };

            var languageResourceId = await GroupShareClient.TranslationMemories.CreateLanguageResourceForTemplate(_languageResourceTemplateId, resource);
            var languageResources = await GroupShareClient.TranslationMemories.GetLanguageResources(_languageResourceTemplateId);
            var initialLanguageResourcesCount = languageResources.Count;
            var addedLanguageResource = languageResources.Single(lr => Guid.Parse(lr.LanguageResourceId) == languageResourceId);

            Assert.Equal(resource.Type, addedLanguageResource.Type);
            Assert.Equal(resource.CultureName, addedLanguageResource.CultureName);

            await GroupShareClient.TranslationMemories.DeleteLanguageResourceForTemplate(_languageResourceTemplateId, languageResourceId);
            languageResources = await GroupShareClient.TranslationMemories.GetLanguageResources(_languageResourceTemplateId);

            Assert.True(languageResources.Count < initialLanguageResourcesCount);
        }

        //[Theory]
        //[InlineData("ro-ro")]
        //public async Task GetDefaultResource(string language)
        //{
        //    var groupShareClient = Helper.GsClient;
        //    var request = new ResourceServiceDefaultsRequest(ResourceServiceDefaultsRequest.ResourceType.Variables, language);

        //    var resource = await groupShareClient.TranslationMemories.GetDefaultsType(request);

        //    Assert.True(resource != null);
        //}

        //[Theory]
        //[InlineData("fe611664-c7c2-4074-8840-e350208ffaf9", "30bdb0b9-7f34-4642-8dcb-a574294035cb")]
        //public async Task GetLanguageResourceForTemplate(string templateId, string languageResourceId)
        //{
        //    var groupShareClient = Helper.GsClient;
        //    var resource =
        //        await groupShareClient.TranslationMemories.GetLanguageResourceForTemplate(templateId, languageResourceId);

        //    Assert.True(resource!=null);
        //}

        //[Theory]
        //[InlineData("fe611664-c7c2-4074-8840-e350208ffaf9", "30bdb0b9-7f34-4642-8dcb-a574294035cb")]
        //public async Task UpdateLanguageResourceForTemplate(string templateId, string languageResourceId)
        //{
        //    var groupShareClient = Helper.GsClient;
        //    var resource =
        //        await groupShareClient.TranslationMemories.GetLanguageResourceForTemplate(templateId, languageResourceId);
        //    resource.CultureName = "de-de";

        //        await
        //            groupShareClient.TranslationMemories.UpdateLanguageResourceForTemplate(templateId, languageResourceId,
        //                resource);

        //    var updatedResource = 
        //        await groupShareClient.TranslationMemories.GetLanguageResourceForTemplate(templateId, languageResourceId);

        //    Assert.Equal(updatedResource.CultureName, "de-de");
        //}

        //[Theory]
        //[InlineData("fe611664-c7c2-4074-8840-e350208ffaf9", "30bdb0b9-7f34-4642-8dcb-a574294035cb")]
        //public async Task ImportFileForLanguageResource(string templateId, string languageResourceId)
        //{
        //    var groupShareClient = Helper.GsClient;

        //    var rawData =
        //       File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\test.txt"));

        //    await
        //        groupShareClient.TranslationMemories.ImportFileForLanguageResource(templateId, languageResourceId, rawData);
        //}
        //[Theory]
        //[InlineData("fe611664-c7c2-4074-8840-e350208ffaf9", "30bdb0b9-7f34-4642-8dcb-a574294035cb")]
        //public async Task ExportFileForLanguageResource(string templateId, string languageResourceId)
        //{
        //    var groupShareClient = Helper.GsClient;
        //    var document =await
        //        groupShareClient.TranslationMemories.ExportFileForLanguageResource(templateId, languageResourceId);

        //    Assert.True(document.Count()!=0);
        //}
        //[Theory]
        //// [InlineData("fe611664-c7c2-4074-8840-e350208ffaf9", "4ba4843e-fa19-4447-8a42-26aef99a3f9c")]
        //[InlineData("fe611664-c7c2-4074-8840-e350208ffaf9", "30bdb0b9-7f34-4642-8dcb-a574294035cb")]
        //public async Task ResetToDefaultLanguageResource(string templateId, string languageResourceId)
        //{
        //    var groupShareClient = Helper.GsClient;
        //    await groupShareClient.TranslationMemories.ResetToDefaultLanguageResource(templateId, languageResourceId);

        //}

        private async Task<Guid> CreateTestLanguageResourceTemplate()
        {
            var request = new ResourceServiceDefaultsRequest(ResourceServiceDefaultsRequest.ResourceType.Variables, "ro-ro");
            var resource = await GroupShareClient.TranslationMemories.GetDefaultsType(request);

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