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
    public class FieldService
    {
        [Theory]
        [InlineData("New Template")]
        public async Task CreateFieldTemplate(string templateName)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var fieldTemplate = new FieldTemplate
            {
                Name = templateName,
                Description = "test",
                FieldTemplateId = Guid.NewGuid().ToString(),
                IsTmSpecific = false,
                Location = "/SDL Community Developers",
                OwnerId = "5bdb10b8-e3a9-41ae-9e66-c154347b8d17"


            };
            var templateId = await groupShareClient.FieldService.CreateTemplate(fieldTemplate);
            Assert.True(templateId!=string.Empty);

        }

        [Fact]
        public async Task GetFieldTemplates()
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var fieldTemplates = await groupShareClient.FieldService.GetFieldTemplates();

            Assert.True(fieldTemplates.Items.Count>0);
        }

        [Theory]
        [InlineData("253988f6-0bd3-4aaa-85f6-5e99e8e32a8f")]
        public async Task  GetFieldTemplateById(string templateId)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();

            var template = await groupShareClient.FieldService.GetFieldTemplateById(templateId);
            Assert.Equal(template.Name, "New Template");
            Assert.Equal(template.FieldTemplateId,templateId);
        }

        [Theory]
        [InlineData("253988f6-0bd3-4aaa-85f6-5e99e8e32a8f")]
        public async Task UpdateFieldTemplate(string fieldTemplateId)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var fieldRequest = new FieldTemplateRequest
            {
                Name = "Updated name"
            };
            await groupShareClient.FieldService.UpdateFieldTemplate(fieldTemplateId, fieldRequest);

            var updatedTemplate = await groupShareClient.FieldService.GetFieldTemplateById(fieldTemplateId);
            Assert.Equal(updatedTemplate.Name, "Updated name");
        }

        [Fact]
        public async Task DeleteFieldTemplate()
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var fieldTemplate = new FieldTemplate
            {
                Name = "Template to be deleted",
                Description = "test",
                FieldTemplateId = Guid.NewGuid().ToString(),
                IsTmSpecific = false,
                Location = "/SDL Community Developers",
                OwnerId = "5bdb10b8-e3a9-41ae-9e66-c154347b8d17"


            };
            var templateId = await groupShareClient.FieldService.CreateTemplate(fieldTemplate);

            await groupShareClient.FieldService.DeleteFieldTemplate(templateId);
        }

        [Theory]
        [InlineData("253988f6-0bd3-4aaa-85f6-5e99e8e32a8f")]
        public async Task AddOperations(string templateId)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var request = new FieldTemplatePatchRequest
            {
                Operations = new List<Operation>
                {
                    new Operation
                    {
                        From = "andrea"
                        
                    }
                }
            };
            await groupShareClient.FieldService.AddOperationsForFieldTemplate(templateId, request);

            var template = await groupShareClient.FieldService.GetFieldTemplateById(templateId);

        }
    }
}
