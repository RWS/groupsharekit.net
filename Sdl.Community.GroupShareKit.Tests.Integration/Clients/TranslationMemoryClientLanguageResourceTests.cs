using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Models.Response.TranslationMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class TranslationMemoryClientLanguageResourceTests : IDisposable
    {
        private static readonly GroupShareClient GroupShareClient = Helper.GsClient;

        private Guid _languageResourceTemplateId;
        //private Guid _languageDirectionId;

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
            var resource = new LanguageResource
            {
                Type = LanguageResourceType.OrdinalFollowers,
                CultureName = "ro-ro",
                Data = "test data"
            };

            var languageResourceId = await GroupShareClient.TranslationMemories.CreateLanguageResourceForTemplate(_languageResourceTemplateId, resource);
            var languageResources = await GroupShareClient.TranslationMemories.GetLanguageResources(_languageResourceTemplateId);
            var initialLanguageResourcesCount = languageResources.Count;
            var addedLanguageResource = languageResources.Single(lr => lr.LanguageResourceId == languageResourceId);

            Assert.Equal(resource.Type, addedLanguageResource.Type);
            Assert.Equal(resource.CultureName, addedLanguageResource.CultureName);

            await GroupShareClient.TranslationMemories.DeleteLanguageResourceForTemplate(_languageResourceTemplateId, languageResourceId);
            languageResources = await GroupShareClient.TranslationMemories.GetLanguageResources(_languageResourceTemplateId);

            Assert.True(languageResources.Count < initialLanguageResourcesCount);
        }

        [Fact]
        public async Task GetLanguageResourceServiceDefaults()
        {
            string cultureName = "fr-fr";
            var abbreviationsRequest = new LanguageResourceServiceDefaultsRequest(LanguageResourceType.Abbreviations, cultureName);
            var abbreviationsDefaults = await GroupShareClient.TranslationMemories.GetLanguageResourceServiceDefaults(abbreviationsRequest);

            Assert.False(string.IsNullOrEmpty(abbreviationsDefaults.Data));
            Assert.Equal(LanguageResourceType.Abbreviations, abbreviationsDefaults.Type);
            Assert.Equal(cultureName, abbreviationsDefaults.CultureName);

            var segmentationRulesRequest = new LanguageResourceServiceDefaultsRequest(LanguageResourceType.SegmentationRules, cultureName);
            var segmentationRulesDefaults = await GroupShareClient.TranslationMemories.GetLanguageResourceServiceDefaults(segmentationRulesRequest);

            Assert.False(string.IsNullOrEmpty(segmentationRulesDefaults.Data));
            Assert.Equal(LanguageResourceType.SegmentationRules, segmentationRulesDefaults.Type);
            Assert.Equal(cultureName, segmentationRulesDefaults.CultureName);
        }

        [Fact]
        public async Task GetLanguageResourceForTemplate()
        {
            var languageResourceGerman = new LanguageResource
            {
                Type = LanguageResourceType.OrdinalFollowers,
                CultureName = "de-de",
                Data = "test data - ordinal followers"
            };

            var languageResourceFrench = new LanguageResource
            {
                Type = LanguageResourceType.Variables,
                CultureName = "fr-fr",
                Data = "test data - variables"
            };

            var ordinalFollowersLanguageResourceId = await GroupShareClient.TranslationMemories.CreateLanguageResourceForTemplate(_languageResourceTemplateId, languageResourceGerman);
            var variablesLanguageResourceId = await GroupShareClient.TranslationMemories.CreateLanguageResourceForTemplate(_languageResourceTemplateId, languageResourceFrench);

            var retrievedOrdinalFollowers = await GroupShareClient.TranslationMemories.GetLanguageResourceForTemplate(_languageResourceTemplateId, ordinalFollowersLanguageResourceId);
            Assert.Equal(LanguageResourceType.OrdinalFollowers, retrievedOrdinalFollowers.Type);
            Assert.Equal(languageResourceGerman.CultureName, retrievedOrdinalFollowers.CultureName);

            var retrievedVariables = await GroupShareClient.TranslationMemories.GetLanguageResourceForTemplate(_languageResourceTemplateId, variablesLanguageResourceId);
            Assert.Equal(LanguageResourceType.Variables, retrievedVariables.Type);
            Assert.Equal(languageResourceFrench.CultureName, retrievedVariables.CultureName);
        }

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

        public void Dispose()
        {
            GroupShareClient.TranslationMemories.DeleteLanguageResourceTemplate(_languageResourceTemplateId).Wait();
        }

        private async Task<Guid> CreateTestLanguageResourceTemplate()
        {
            //var request = new LanguageResourceServiceDefaultsRequest(LanguageResourceType.Variables, "ro-ro");
            //var resource = await GroupShareClient.TranslationMemories.GetLanguageResourceServiceDefaults(request);

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