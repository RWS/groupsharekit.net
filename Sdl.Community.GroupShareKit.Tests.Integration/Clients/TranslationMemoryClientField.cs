using Sdl.Community.GroupShareKit.Models.Response.TranslationMemory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class TranslationMemoryClientField
    {
        [Fact]
        public async Task CreateFieldTemplate()
        {
            var groupShareClient = Helper.GsClient;
            var tplId = Guid.NewGuid();

            var fieldTemplate = new FieldTemplate
            {
                Name = $"{tplId}",
                Description = "test field template",
                FieldTemplateId = tplId.ToString(),
                IsTmSpecific = false,
                Location = Helper.OrganizationPath,
                OwnerId = Helper.OrganizationId
            };

            var templateId = await groupShareClient.TranslationMemories.CreateFieldTemplate(fieldTemplate);
            Assert.True(templateId != string.Empty);

            await groupShareClient.TranslationMemories.DeleteFieldTemplate(templateId);
        }

        [Fact]
        public async Task GetFieldTemplateById()
        {
            var groupShareClient = Helper.GsClient;

            var tplId = Guid.NewGuid();
            var fieldTemplate = new FieldTemplate
            {
                Name = $"{tplId}",
                Description = "test field template",
                FieldTemplateId = tplId.ToString(),
                IsTmSpecific = false,
                Location = Helper.OrganizationPath,
                OwnerId = Helper.OrganizationId
            };

            var templateId = await groupShareClient.TranslationMemories.CreateFieldTemplate(fieldTemplate);
            Assert.True(templateId != string.Empty);

            var template = await groupShareClient.TranslationMemories.GetFieldTemplateById(templateId);
            Assert.Equal($"{tplId}", template.Name);
            Assert.Equal(template.FieldTemplateId, tplId.ToString());

            await groupShareClient.TranslationMemories.DeleteFieldTemplate(templateId);
        }

        [Fact]
        public async Task UpdateFieldTemplate()
        {
            var groupShareClient = Helper.GsClient;

            var fieldTemplateName = $"Field template - {Guid.NewGuid()}";

            var fieldTemplateRequest = new CreateFieldTemplateRequest
            {
                Name = fieldTemplateName,
                Description = "Created using GroupShare Kit",
                IsTmSpecific = false,
                OwnerId = Guid.Parse(Helper.OrganizationId)
            };

            var templateId = await groupShareClient.TranslationMemories.CreateFieldTemplate(fieldTemplateRequest);

            var fieldTemplate = await groupShareClient.TranslationMemories.GetFieldTemplateById(templateId.ToString());
            Assert.Equal(fieldTemplateName, fieldTemplate.Name);

            var newName = $"Edited name - {Guid.NewGuid()}";
            await groupShareClient.TranslationMemories.UpdateFieldTemplate(templateId.ToString(), new FieldTemplateRequest { Name = newName });

            var updatedTemplate = await groupShareClient.TranslationMemories.GetFieldTemplateById(templateId.ToString());
            Assert.Equal(newName, updatedTemplate.Name);

            await groupShareClient.TranslationMemories.DeleteFieldTemplate(templateId.ToString());
        }

        // WTF
        [Fact]
        public async Task AddOperations()
        {
            var groupShareClient = Helper.GsClient;

            var tplId = Guid.NewGuid();

            var fieldTemplate = new FieldTemplate
            {
                Name = $"{tplId}",
                Description = "test field template",
                FieldTemplateId = tplId.ToString(),
                IsTmSpecific = false,
                Location = Helper.OrganizationPath,
                OwnerId = Helper.OrganizationId
            };

            var templateId = await groupShareClient.TranslationMemories.CreateFieldTemplate(fieldTemplate);
            Assert.True(templateId != string.Empty);

            await groupShareClient.TranslationMemories.AddOperationsForFieldTemplate(
                templateId,
                new FieldTemplatePatchRequest
                {
                    Operations = new List<Operation>
                    {
                        new Operation
                        {
                            Path = "/fields",
                            Op = "replace",
                            Value = null
                        }
                    }
                });

            await groupShareClient.TranslationMemories.DeleteFieldTemplate(templateId);
        }

        [Fact]
        public async Task CreateFieldForTemplate()
        {
            var groupShareClient = Helper.GsClient;

            var templateGuid = Guid.NewGuid();
            var fieldTemplate = new FieldTemplate
            {
                Name = $"field template - {templateGuid}",
                Description = "test field template",
                IsTmSpecific = false,
                Location = Helper.OrganizationPath,
                OwnerId = Helper.OrganizationId
            };

            var fieldTemplateId = await groupShareClient.TranslationMemories.CreateFieldTemplate(fieldTemplate);

            var fieldGuid = Guid.NewGuid();
            var field = new FieldRequest
            {
                Name = fieldGuid.ToString(),
                Type = FieldRequest.TypeEnum.SingleString,
                Values = new List<string> { "test", "a", "is", "this" }
            };

            var fieldId = await groupShareClient.TranslationMemories.CreateFieldForTemplate(fieldTemplateId, field);
            Assert.True(fieldId != string.Empty);

            var fields = await groupShareClient.TranslationMemories.GetFieldsForTemplate(fieldTemplateId);
            Assert.Single(fields);
            Assert.Equal(4, fields[0].Values.Count);

            await groupShareClient.TranslationMemories.DeleteFieldTemplate(fieldTemplateId);
        }

        [Fact]
        public async Task DeleteFieldForTemplate()
        {
            var groupShareClient = Helper.GsClient;

            var templateGuid = Guid.NewGuid();
            var fieldTemplate = new FieldTemplate
            {
                Name = $"field template - {templateGuid}",
                Description = "test field template",
                IsTmSpecific = false,
                Location = Helper.OrganizationPath,
                OwnerId = Helper.OrganizationId
            };

            var fieldTemplateId = await groupShareClient.TranslationMemories.CreateFieldTemplate(fieldTemplate);

            var fieldGuid = Guid.NewGuid();
            var field = new FieldRequest
            {
                Name = fieldGuid.ToString(),
                Type = FieldRequest.TypeEnum.SingleString,
                Values = new List<string> { "test", "a", "is", "this" }
            };

            var fieldId = await groupShareClient.TranslationMemories.CreateFieldForTemplate(fieldTemplateId, field);
            Assert.True(fieldId != string.Empty);

            var fields = await groupShareClient.TranslationMemories.GetFieldsForTemplate(fieldTemplateId);
            Assert.Single(fields);
            Assert.Equal(4, fields[0].Values.Count);

            await groupShareClient.TranslationMemories.DeleteFieldForTemplate(fieldTemplateId, fieldId);

            fields = await groupShareClient.TranslationMemories.GetFieldsForTemplate(fieldTemplateId);
            Assert.Empty(fields);

            await groupShareClient.TranslationMemories.DeleteFieldTemplate(fieldTemplateId);
        }
    }
}