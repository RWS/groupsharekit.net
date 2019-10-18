using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Models.Response.TranslationMemory;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class TranslationMemoryClientLanguageResourceTests
    {
        //[Theory]
        //[InlineData("fe611664-c7c2-4074-8840-e350208ffaf9")]
        //public async Task GetLanguageResourcesForTemplate(string templateId)
        //{
        //    var groupShareClient = Helper.GsClient;
        //    var resources = await groupShareClient.TranslationMemories.GetLanguageResourcesForTemplate(templateId);

        //    Assert.True(resources.Count > 0);
        //}

        //[Theory]
        //[InlineData("a3b1fd22-e3cd-4931-9e2a-91f6c6c246c0", "en-de")]
        //public async Task CreateLanguageResourceForTemplate(string templateId, string language)
        //{
        //    var groupShareClient = Helper.GsClient;

        //    var resource = new Resource
        //    {
        //        Type = "OrdinalFollowers",
        //        LanguageResourceTemplateId = Guid.NewGuid().ToString(),
        //        LanguageResourceId = Guid.NewGuid().ToString(),
        //        CultureName = language,
        //        Data = "test data"
        //    };
        //    var id = await groupShareClient.TranslationMemories.CreateLanguageResourceForTemplate(templateId, resource);

        //    Assert.True(id != string.Empty);
        //    await groupShareClient.TranslationMemories.DeleteLanguageResourceForTemplate(templateId, id);
        //}

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
    }
}