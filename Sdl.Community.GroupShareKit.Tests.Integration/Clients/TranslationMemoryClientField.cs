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

            await groupShareClient.TranslationMemories.UpdateFieldTemplate(
                templateId,
                new FieldTemplateRequest { Name = "updated field template" });

            var updatedTemplate = await groupShareClient.TranslationMemories.GetFieldTemplateById(templateId);
            Assert.Equal("updated field template", updatedTemplate.Name);

            await groupShareClient.TranslationMemories.DeleteFieldTemplate(templateId);
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
            Assert.True(fields.Count == 1);
            Assert.True(fields[0].Values.Count == 4);

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
            Assert.True(fields.Count == 1);
            Assert.True(fields[0].Values.Count == 4);

            await groupShareClient.TranslationMemories.DeleteFieldForTemplate(fieldTemplateId, fieldId);

            fields = await groupShareClient.TranslationMemories.GetFieldsForTemplate(fieldTemplateId);
            Assert.True(fields.Count == 0);

            await groupShareClient.TranslationMemories.DeleteFieldTemplate(fieldTemplateId);
        }
    }
}