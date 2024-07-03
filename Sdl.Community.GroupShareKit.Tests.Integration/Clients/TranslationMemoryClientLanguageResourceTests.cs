using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Models.Response.TranslationMemory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class TranslationMemoryClientLanguageResourceTests : IDisposable
    {
        private static readonly GroupShareClient GroupShareClient = Helper.GsClient;

        private Guid _languageResourceId;
        private Guid _languageResourceTemplateId;

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

        [Fact]
        public async Task UpdateLanguageResourceForTemplate()
        {
            var languageResource = await GroupShareClient.TranslationMemories.GetLanguageResourceForTemplate(_languageResourceTemplateId, _languageResourceId);
            languageResource.CultureName = "de-de";

            await GroupShareClient.TranslationMemories.UpdateLanguageResourceForTemplate(_languageResourceTemplateId, _languageResourceId, languageResource);
            var updatedResource = await GroupShareClient.TranslationMemories.GetLanguageResourceForTemplate(_languageResourceTemplateId, _languageResourceId);

            Assert.Equal("de-de", updatedResource.CultureName);
        }

        [Fact]
        public async Task ImportFileForLanguageResource()
        {
            var rawData = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\test.txt"));

            await GroupShareClient.TranslationMemories.ImportFileForLanguageResource(_languageResourceTemplateId, _languageResourceId, rawData);
            var languageResource = await GroupShareClient.TranslationMemories.GetLanguageResourceForTemplate(_languageResourceTemplateId, _languageResourceId);
            var dataDecoded = StringExtensions.FromBase64String(languageResource.Data);

            Assert.Contains("car", dataDecoded);
            Assert.Contains("window", dataDecoded);
        }

        [Fact]
        public async Task ExportFileForLanguageResource()
        {
            var export = await GroupShareClient.TranslationMemories.ExportFileForLanguageResource(_languageResourceTemplateId, _languageResourceId);

            Assert.True(export.Length > 0);
        }

        [Fact]
        public async Task ResetLanguageResourceToDefault()
        {
            var languageResourcesBeforeReset = await GroupShareClient.TranslationMemories.GetLanguageResources(_languageResourceTemplateId);
            Assert.Single(languageResourcesBeforeReset);

            await GroupShareClient.TranslationMemories.ResetLanguageResourceToDefault(_languageResourceTemplateId, _languageResourceId);

            var languageResourcesAfterReset = await GroupShareClient.TranslationMemories.GetLanguageResources(_languageResourceTemplateId);
            Assert.Empty(languageResourcesAfterReset);
        }

        public void Dispose()
        {
            GroupShareClient.TranslationMemories.DeleteLanguageResourceTemplate(_languageResourceTemplateId).Wait();
        }

        private async Task<Guid> CreateTestLanguageResourceTemplate()
        {
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
                        CultureName = "en-us",
                        Type = LanguageResourceType.Variables,
                        Data = "test"
                    }
                }
            };

            var languageResourceTemplateId = await GroupShareClient.TranslationMemories.CreateLanguageResourceTemplate(languageResourceTemplateRequest);
            _languageResourceId = (await GroupShareClient.TranslationMemories.GetLanguageResources(languageResourceTemplateId)).Single().LanguageResourceId;

            return languageResourceTemplateId;
        }
    }
}