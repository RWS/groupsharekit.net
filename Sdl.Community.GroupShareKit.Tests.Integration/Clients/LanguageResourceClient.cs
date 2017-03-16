using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Models.Response.TranslationMemory;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class LanguageResourceClient
    {
        [Theory]
        [InlineData("b8ca7722-2d0a-4cfb-ae33-a36814aa0efc")]
        public async Task GetLanguageResourcesForTemplate(string templateId)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var resources = await groupShareClient.LanguageResource.GetLanguageResourcesForTemplate(templateId);

            Assert.True(resources.Count>0);
        }

        [Theory]
        [InlineData("b8ca7722-2d0a-4cfb-ae33-a36814aa0efc", "ro-ro")]
        public async Task CreateLanguageResourceForTemplate(string templateId,string language)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();

            var resource = new Resource
            {
                Type = "OrdinalFollowers",
                LanguageResourceTemplateId = Guid.NewGuid().ToString(),
                LanguageResourceId = Guid.NewGuid().ToString(),
                CultureName = "sq-al",
                Data = "test data"
            };
            var id = await groupShareClient.LanguageResource.CreateLanguageResourceForTemplate(templateId, resource);

            Assert.True(id!=string.Empty);

        }

        [Theory]
        [InlineData("ro-ro")]
        public async Task GetDefaultResource(string language)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var request = new ResourceServiceDefaultsRequest(ResourceServiceDefaultsRequest.ResourceType.Variables, language);

            var resource = await groupShareClient.LanguageResource.GetDefaultsType(request);

            Assert.True(resource!=null);

        }

        [Theory]
        [InlineData("b8ca7722-2d0a-4cfb-ae33-a36814aa0efc", "a81c0e63-9274-48df-80f0-f2598e90fb00")]
        public async Task GetLanguageResourceForTemplate(string templateId, string languageResourceId)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var resource =
                await groupShareClient.LanguageResource.GetLanguageResourceForTemplate(templateId, languageResourceId);

            Assert.True(resource!=null);
        }

        [Theory]
        [InlineData("b8ca7722-2d0a-4cfb-ae33-a36814aa0efc", "a81c0e63-9274-48df-80f0-f2598e90fb00")]
        public async Task UpdateLanguageResourceForTemplate(string templateId, string languageResourceId)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var resource =
                await groupShareClient.LanguageResource.GetLanguageResourceForTemplate(templateId, languageResourceId);
            resource.CultureName = "ro-ro";
            var updatedReponse =
                await
                    groupShareClient.LanguageResource.UpdateLanguageResourceForTemplate(templateId, languageResourceId,
                        resource);

            var updatedResource = 
                await groupShareClient.LanguageResource.GetLanguageResourceForTemplate(templateId, languageResourceId);

            Assert.Equal(updatedResource.Data,"ro-ro");
        }

        [Theory]
        [InlineData("4b4f20e7-9371-4438-8566-8a4904d44a5d", "23bc4cf8-3fc3-4c4a-8687-86d82496b446")]
        public async Task DeleteLanguageResourceForTemplate(string templateId, string languageResourceId)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            await groupShareClient.LanguageResource.DeleteLanguageResourceForTemplate(templateId, languageResourceId);
        }
    }
}
