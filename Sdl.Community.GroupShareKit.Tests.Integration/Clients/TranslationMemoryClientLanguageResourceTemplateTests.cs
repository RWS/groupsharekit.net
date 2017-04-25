using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Models.Response.TranslationMemory;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class TranslationMemoryClientLanguageResourceTemplateTests
    {
        [Fact]
        public async Task GetAllLanguageResourceTemplates()
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var templatesResponse = await groupShareClient.TranslationMemories.GetAllLanguageResourceTemplates();

            Assert.True(templatesResponse.Items.Count>0);
        }

        [Theory]
        [InlineData("78df3807-06ac-438e-b2c8-5e233df1a6a2")]
        public async Task GetLanguageResourceTemplateById(string templateId)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var template = await groupShareClient.TranslationMemories.GetTemplateById(templateId);

            Assert.Equal(template.LanguageResourceTemplateId, templateId);
        }

        [Theory]
        [InlineData("78df3807-06ac-438e-b2c8-5e233df1a6a2")]
        public async Task UpdateLanguageResourceTemplate(string templateId)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var request = new FieldTemplateRequest
            {
                Name = "UpdatedName",
                Description = "updated from kit"
            };

             await groupShareClient.TranslationMemories.EditTemplate(templateId, request);

            var template = await groupShareClient.TranslationMemories.GetTemplateById(templateId);

            Assert.Equal(template.Name, "UpdatedName");
        }

        [Theory]
        [InlineData("Kit2")]
        public async Task CreateTemplate(string templateName)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var request = new ResourceServiceDefaultsRequest(ResourceServiceDefaultsRequest.ResourceType.Variables,
                "ro-ro");

            var resource = await groupShareClient.TranslationMemories.GetDefaultsType(request);
            var template = new LanguageResourceTemplate
            {
                LanguageResourceTemplateId = Guid.NewGuid().ToString(),
                Name = templateName,
                Description = "",
                OwnerId = "5bdb10b8-e3a9-41ae-9e66-c154347b8d17",
                Location = "/SDL Community Developers",
                IsTmSpecific = false,
               // LanguageResources = new List<Resource> {resource}
               LanguageResources = new List<Resource>
               {
                   new Resource
                   {
                       Type = "Variables",
                       LanguageResourceTemplateId = "78df3807-06ac-438e-b2c8-5e233df1a6a2",
                       Data = "andrea",
                       CultureName = "ro-ro",
                       
                   }
               }

            };

            var id = await groupShareClient.TranslationMemories.CreateTemplate(template);

            Assert.True(id != string.Empty);
        }

        [Theory]
        [InlineData("Template to be deleted")]
        public async Task DeleteTemplate(string templateName)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var template = new LanguageResourceTemplate
            {
                LanguageResourceTemplateId = Guid.NewGuid().ToString(),
                Name = templateName,
                Description = "",
                OwnerId = "5bdb10b8-e3a9-41ae-9e66-c154347b8d17",
                Location = "/SDL Community Developers",
                IsTmSpecific = false,
                LanguageResources = new List<Resource>()
            };

            var id = await groupShareClient.TranslationMemories.CreateTemplate(template);

            await groupShareClient.TranslationMemories.DeleteTemplate(id);
        }
    }
}
