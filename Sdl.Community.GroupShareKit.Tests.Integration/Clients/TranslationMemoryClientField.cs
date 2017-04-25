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
    public class TranslationMemoryClientField
    {
        [Theory]
        [InlineData("LastTemplate")]
        public async Task CreateFieldTemplate(string templateName)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var fieldTemplate = new FieldTemplate
            {
                Name = templateName,
                Description = "test",
                FieldTemplateId = Guid.NewGuid().ToString(),
                IsTmSpecific = false,
                Location = "/SDL Community Developers",
                OwnerId = "5bdb10b8-e3a9-41ae-9e66-c154347b8d17"


            };
            var templateId = await groupShareClient.TranslationMemories.CreateFieldTemplate(fieldTemplate);
            Assert.True(templateId!=string.Empty);

        }

        [Fact]
        public async Task GetFieldTemplates()
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var fieldTemplates = await groupShareClient.TranslationMemories.GetFieldTemplates();

            Assert.True(fieldTemplates.Items.Count>0);
        }

        [Theory]
        [InlineData("3d24c52b-4d3e-447e-a44d-42174f269526")]
        public async Task  GetFieldTemplateById(string templateId)
        {
            var groupShareClient = await Helper.GetGroupShareClient();

            var template = await groupShareClient.TranslationMemories.GetFieldTemplateById(templateId);
            Assert.Equal(template.Name, "Ro Copy");
            Assert.Equal(template.FieldTemplateId,templateId);
        }

        [Theory]
        [InlineData("253988f6-0bd3-4aaa-85f6-5e99e8e32a8f")]
        public async Task UpdateFieldTemplate(string fieldTemplateId)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var fieldRequest = new FieldTemplateRequest
            {
                Name = "Updated name"
            };
            await groupShareClient.TranslationMemories.UpdateFieldTemplate(fieldTemplateId, fieldRequest);

            var updatedTemplate = await groupShareClient.TranslationMemories.GetFieldTemplateById(fieldTemplateId);
            Assert.Equal(updatedTemplate.Name, "Updated name");
        }

        [Fact]
        public async Task DeleteFieldTemplate()
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var fieldTemplate = new FieldTemplate
            {
                Name = "Template to be deleted",
                Description = "test",
                FieldTemplateId = Guid.NewGuid().ToString(),
                IsTmSpecific = false,
                Location = "/SDL Community Developers",
                OwnerId = "5bdb10b8-e3a9-41ae-9e66-c154347b8d17"


            };
            var templateId = await groupShareClient.TranslationMemories.CreateFieldTemplate(fieldTemplate);

            await groupShareClient.TranslationMemories.DeleteFieldTemplate(templateId);
        }

        [Theory]
        [InlineData("253988f6-0bd3-4aaa-85f6-5e99e8e32a8f")]
        public async Task AddOperations(string templateId)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
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
            await groupShareClient.TranslationMemories.AddOperationsForFieldTemplate(templateId, request);

            var template = await groupShareClient.TranslationMemories.GetFieldTemplateById(templateId);

        }

        [Theory]
        [InlineData("ec6acfc3-e166-486f-9823-3220499dc95b")]
        public async Task GetFieldsForTemplate(string fieldTemplateId)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var fields = await groupShareClient.TranslationMemories.GetFieldsForTemplate(fieldTemplateId);

            Assert.True(fields.Count>0);
        }

        [Theory]
        [InlineData("ec6acfc3-e166-486f-9823-3220499dc95b", "b31c9cb5-bef4-4f0b-b4da-92f5bd06ec48")]
        public async Task GetFieldForTemplate(string fieldTemplateId,string fieldId)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var field = await groupShareClient.TranslationMemories.GetFieldForTemplate(fieldTemplateId, fieldId);

            Assert.Equal(field.FieldId,fieldId);
        }

        [Theory]
        [InlineData("ec6acfc3-e166-486f-9823-3220499dc95b", "b31c9cb5-bef4-4f0b-b4da-92f5bd06ec48")]
        public async Task UpdateFieldForTemplate(string fieldTemplateId, string fieldId)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var field = await groupShareClient.TranslationMemories.GetFieldForTemplate(fieldTemplateId, fieldId);
            field.Name = "Updated name";
            await groupShareClient.TranslationMemories.UpdateFieldForTemplate(fieldTemplateId, fieldId, field);
        }
        [Theory]
        [InlineData("3244d091-7ce3-4ada-99db-7682cce6f0ff", "another field")]
        public async Task CreateFieldForTemplate(string fieldTemplateId,string fieldName)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var field = new FieldRequest
            {
                FieldId = Guid.NewGuid().ToString(),
                Name = fieldName,
                Type =  FieldRequest.TypeEnum.SingleString,
                Values = new List<string>() { "andrea2","test" }
            };

            var fieldId = await groupShareClient.TranslationMemories.CreateFieldForTemplate(fieldTemplateId, field);

            Assert.True(fieldId!=string.Empty);
        }

        [Theory]
        [InlineData("253988f6-0bd3-4aaa-85f6-5e99e8e32a8f", "Name")]
        public async Task DeleteFieldForTemplate(string fieldTemplateId, string fieldName)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var field = new FieldRequest
            {
                FieldId = Guid.NewGuid().ToString(),
                Name = fieldName,
                Type = FieldRequest.TypeEnum.MultiplePicklist,
                Values = new List<string>()
            };

            var fieldId = await groupShareClient.TranslationMemories.CreateFieldForTemplate(fieldTemplateId, field);
            Assert.True(fieldId != string.Empty);

            await groupShareClient.TranslationMemories.DeleteFieldForTemplate(fieldTemplateId, fieldId);
        }

    }
}
