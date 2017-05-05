using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Models.Response.TranslationMemory;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class TranslationMemoryClientLanguageResourceTests
    {
        [Theory]
        [InlineData("b8ca7722-2d0a-4cfb-ae33-a36814aa0efc")]
        public async Task GetLanguageResourcesForTemplate(string templateId)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var resources = await groupShareClient.TranslationMemories.GetLanguageResourcesForTemplate(templateId);

            Assert.True(resources.Count>0);
        }

        [Theory]
        [InlineData("b8ca7722-2d0a-4cfb-ae33-a36814aa0efc", "ro-ro")]
        public async Task CreateLanguageResourceForTemplate(string templateId,string language)
        {
            var groupShareClient = await Helper.GetGroupShareClient();

            var resource = new Resource
            {
                Type = "OrdinalFollowers",
                LanguageResourceTemplateId = Guid.NewGuid().ToString(),
                LanguageResourceId = Guid.NewGuid().ToString(),
                CultureName = "de-de",
                Data = "test data"
            };
            var id = await groupShareClient.TranslationMemories.CreateLanguageResourceForTemplate(templateId, resource);

            Assert.True(id!=string.Empty);

        }

        [Theory]
        [InlineData("ro-ro")]
        public async Task GetDefaultResource(string language)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var request = new ResourceServiceDefaultsRequest(ResourceServiceDefaultsRequest.ResourceType.Variables, language);

            var resource = await groupShareClient.TranslationMemories.GetDefaultsType(request);

            Assert.True(resource!=null);

        }

        [Theory]
        [InlineData("fe611664-c7c2-4074-8840-e350208ffaf9", "4ba4843e-fa19-4447-8a42-26aef99a3f9c")]
        public async Task GetLanguageResourceForTemplate(string templateId, string languageResourceId)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var resource =
                await groupShareClient.TranslationMemories.GetLanguageResourceForTemplate(templateId, languageResourceId);

            Assert.True(resource!=null);
        }

        [Theory]
        [InlineData("fe611664-c7c2-4074-8840-e350208ffaf9", "4ba4843e-fa19-4447-8a42-26aef99a3f9c")]
        public async Task UpdateLanguageResourceForTemplate(string templateId, string languageResourceId)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var resource =
                await groupShareClient.TranslationMemories.GetLanguageResourceForTemplate(templateId, languageResourceId);
            resource.CultureName = "de-de";

                await
                    groupShareClient.TranslationMemories.UpdateLanguageResourceForTemplate(templateId, languageResourceId,
                        resource);

            var updatedResource = 
                await groupShareClient.TranslationMemories.GetLanguageResourceForTemplate(templateId, languageResourceId);

            Assert.Equal(updatedResource.CultureName, "de-de");
        }


        [Theory]
        [InlineData("b8ca7722-2d0a-4cfb-ae33-a36814aa0efc", "14eb022b-863c-4d15-bc5e-76b4a813a016")]
        public async Task ImportFileForLanguageResource(string templateId, string languageResourceId)
        {
            var groupShareClient = await Helper.GetGroupShareClient();

            var rawData =
               File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\test.txt"));

            await
                groupShareClient.TranslationMemories.ImportFileForLanguageResource(templateId, languageResourceId, rawData);
        }
        [Theory]
        [InlineData("b8ca7722-2d0a-4cfb-ae33-a36814aa0efc", "14eb022b-863c-4d15-bc5e-76b4a813a016")]
        public async Task ExportFileForLanguageResource(string templateId, string languageResourceId)
        {
            var groupShareClient = await Helper.GetGroupShareClient();

          

            var document =await
                groupShareClient.TranslationMemories.ExportFileForLanguageResource(templateId, languageResourceId);

            Assert.True(document.Count()!=0);
        }
        [Theory]
        [InlineData("fe611664-c7c2-4074-8840-e350208ffaf9", "4ba4843e-fa19-4447-8a42-26aef99a3f9c")]
        public async Task ResetToDefaultLanguageResource(string templateId, string languageResourceId)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            await groupShareClient.TranslationMemories.ResetToDefaultLanguageResource(templateId, languageResourceId);

        }


    }
}
