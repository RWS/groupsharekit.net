using Sdl.Community.GroupShareKit.Models.Response.TranslationMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class TranslationMemoryClientFieldTemplatesTests : IDisposable
    {
        private static readonly GroupShareClient GroupShareClient = Helper.GsClient;

        private Guid _fieldTemplateId;

        public TranslationMemoryClientFieldTemplatesTests()
        {
            _fieldTemplateId = CreateTestFieldTemplate().Result;
        }

        [Fact]
        public async Task CreateFieldTemplate()
        {
            var id = Guid.NewGuid();

            var fieldTemplateRequest = new CreateFieldTemplateRequest
            {
                Name = $"Field template - {id}",
                Description = "test field template",
                FieldTemplateId = id,
                IsTmSpecific = false,
                Location = Helper.OrganizationPath,
                OwnerId = Guid.Parse(Helper.OrganizationId)
            };

            var fieldTemplateId = await GroupShareClient.TranslationMemories.CreateFieldTemplate(fieldTemplateRequest);
            Assert.Equal(fieldTemplateRequest.FieldTemplateId, fieldTemplateId);

            await GroupShareClient.TranslationMemories.DeleteFieldTemplate(fieldTemplateId);
        }

        [Fact]
        public async Task GetFieldTemplate()
        {
            var fieldTemplateId = Guid.NewGuid();
            var fieldTemplateName = $"Field template - {fieldTemplateId}";

            var fieldTemplateRequest = new CreateFieldTemplateRequest
            {
                FieldTemplateId = fieldTemplateId,
                Name = fieldTemplateName,
                Description = "Created using GroupShare Kit",
                IsTmSpecific = false,
                OwnerId = Guid.Parse(Helper.OrganizationId)
            };

            var resultedFieldTemplateId = await GroupShareClient.TranslationMemories.CreateFieldTemplate(fieldTemplateRequest);
            Assert.Equal(fieldTemplateId, resultedFieldTemplateId);

            var fieldTemplate = await GroupShareClient.TranslationMemories.GetFieldTemplate(fieldTemplateId);
            Assert.Equal(fieldTemplateName, fieldTemplate.Name);

            await GroupShareClient.TranslationMemories.DeleteFieldTemplate(fieldTemplateId);
        }

        [Fact]
        public async Task UpdateFieldTemplate()
        {
            var fieldTemplate = await GroupShareClient.TranslationMemories.GetFieldTemplate(_fieldTemplateId);

            var newName = $"Edited name - {Guid.NewGuid()}";
            await GroupShareClient.TranslationMemories.UpdateFieldTemplate(_fieldTemplateId, new UpdateTemplateRequest { Name = newName });

            var updatedTemplate = await GroupShareClient.TranslationMemories.GetFieldTemplate(_fieldTemplateId);
            Assert.Equal(newName, updatedTemplate.Name);

            await GroupShareClient.TranslationMemories.DeleteFieldTemplate(_fieldTemplateId);
        }

        [Fact]
        public async Task AddUpdateFieldTemplateFields()
        {
            var fields = await GroupShareClient.TranslationMemories.GetFieldsForTemplate(_fieldTemplateId);
            Assert.Empty(fields);

            var fieldRequest = new FieldRequest
            {
                Name = "Text field",
                Type = FieldRequest.TypeEnum.SingleString,
                Values = new List<string> { }
            };

            var fieldId = await GroupShareClient.TranslationMemories.CreateFieldForTemplate(_fieldTemplateId, fieldRequest);
            fields = await GroupShareClient.TranslationMemories.GetFieldsForTemplate(_fieldTemplateId);
            Assert.Equal(fieldRequest.Name, fields.Single().Name);

            var newFieldName = "Text field - edited";

            var value = new List<OperationValue>
            {
                new OperationValue
                {
                    FieldId = fieldId,
                    FieldTemplateId = _fieldTemplateId,
                    Name = newFieldName,
                    Type = "SingleString",
                    Values = new List<string> { }
                }
            };

            var operations = new List<Operation>
            {
                new Operation
                {
                    Path = "/fields",
                    Op = "replace",
                    Value = value
                }
            };

            await GroupShareClient.TranslationMemories.AddOperationsForFieldTemplate(_fieldTemplateId, operations);

            fields = await GroupShareClient.TranslationMemories.GetFieldsForTemplate(_fieldTemplateId);
            Assert.Equal(newFieldName, fields.Single().Name);

            await GroupShareClient.TranslationMemories.DeleteFieldTemplate(_fieldTemplateId);
        }

        [Fact]
        public async Task CreateFieldForTemplate()
        {
            var fieldGuid = Guid.NewGuid();
            var fieldRequest = new FieldRequest
            {
                Name = fieldGuid.ToString(),
                Type = FieldRequest.TypeEnum.SingleString,
                Values = new List<string> { "test", "a", "is", "this" }
            };

            var fieldId = await GroupShareClient.TranslationMemories.CreateFieldForTemplate(_fieldTemplateId, fieldRequest);
            var field = await GroupShareClient.TranslationMemories.GetFieldForTemplate(_fieldTemplateId, fieldId);

            Assert.Equal(fieldRequest.Name, field.Name);
            Assert.Equal(fieldRequest.Type.ToString(), field.Type);
            Assert.Equal(_fieldTemplateId, Guid.Parse(field.FieldTemplateId));

            var fields = await GroupShareClient.TranslationMemories.GetFieldsForTemplate(_fieldTemplateId);
            Assert.Equal(4, fields[0].Values.Count);

            await GroupShareClient.TranslationMemories.DeleteFieldTemplate(_fieldTemplateId);
        }

        [Fact]
        public async Task DeleteFieldForTemplate()
        {
            var fieldGuid = Guid.NewGuid();
            var field = new FieldRequest
            {
                Name = fieldGuid.ToString(),
                Type = FieldRequest.TypeEnum.SingleString,
                Values = new List<string> { "test", "a", "is", "this" }
            };

            var fieldId = await GroupShareClient.TranslationMemories.CreateFieldForTemplate(_fieldTemplateId, field);

            var fields = await GroupShareClient.TranslationMemories.GetFieldsForTemplate(_fieldTemplateId);
            Assert.Single(fields);
            Assert.Equal(4, fields[0].Values.Count);

            await GroupShareClient.TranslationMemories.DeleteFieldForTemplate(_fieldTemplateId, fieldId);

            fields = await GroupShareClient.TranslationMemories.GetFieldsForTemplate(_fieldTemplateId);
            Assert.Empty(fields);

            await GroupShareClient.TranslationMemories.DeleteFieldTemplate(_fieldTemplateId);
        }

        public void Dispose()
        {
            GroupShareClient.TranslationMemories.DeleteFieldTemplate(_fieldTemplateId).Wait();
        }

        private async Task<Guid> CreateTestFieldTemplate()
        {
            var fieldTemplate = new CreateFieldTemplateRequest
            {
                Name = $"Field template - {Guid.NewGuid()}",
                Description = "Created using GroupShare Kit",
                IsTmSpecific = false,
                OwnerId = Guid.Parse(Helper.OrganizationId)
            };

            _fieldTemplateId = await GroupShareClient.TranslationMemories.CreateFieldTemplate(fieldTemplate);
            return _fieldTemplateId;
        }
    }
}