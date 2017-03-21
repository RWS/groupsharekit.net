﻿using System;
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
            var templateId = await groupShareClient.FieldService.CreateFieldTemplate(fieldTemplate);
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
            var templateId = await groupShareClient.FieldService.CreateFieldTemplate(fieldTemplate);

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

        [Theory]
        [InlineData("ec6acfc3-e166-486f-9823-3220499dc95b")]
        public async Task GetFieldsForTemplate(string fieldTemplateId)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var fields = await groupShareClient.FieldService.GetFieldsForTemplate(fieldTemplateId);

            Assert.True(fields.Count>0);
        }

        [Theory]
        [InlineData("ec6acfc3-e166-486f-9823-3220499dc95b", "b31c9cb5-bef4-4f0b-b4da-92f5bd06ec48")]
        public async Task GetFieldForTemplate(string fieldTemplateId,string fieldId)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var field = await groupShareClient.FieldService.GetFieldForTemplate(fieldTemplateId, fieldId);

            Assert.Equal(field.FieldId,fieldId);
        }

        [Theory]
        [InlineData("ec6acfc3-e166-486f-9823-3220499dc95b", "b31c9cb5-bef4-4f0b-b4da-92f5bd06ec48")]
        public async Task UpdateFieldForTemplate(string fieldTemplateId, string fieldId)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var field = await groupShareClient.FieldService.GetFieldForTemplate(fieldTemplateId, fieldId);
            field.Name = "Updated field Name";
            await groupShareClient.FieldService.UpdateFieldForTemplate(fieldTemplateId, fieldId, field);
        }
        [Theory]
        [InlineData("3244d091-7ce3-4ada-99db-7682cce6f0ff", "another field")]
        public async Task CreateFieldForTemplate(string fieldTemplateId,string fieldName)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var field = new FieldRequest
            {
                FieldId = Guid.NewGuid().ToString(),
                Name = fieldName,
                Type =  FieldRequest.TypeEnum.SingleString,
                Values = new List<string>() { "andrea2","test" }
            };

            var fieldId = await groupShareClient.FieldService.CreateFieldForTemplate(fieldTemplateId, field);

            Assert.True(fieldId!=string.Empty);
        }

        [Theory]
        [InlineData("253988f6-0bd3-4aaa-85f6-5e99e8e32a8f", "Name")]
        public async Task DeleteFieldForTemplate(string fieldTemplateId, string fieldName)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var field = new FieldRequest
            {
                FieldId = Guid.NewGuid().ToString(),
                Name = fieldName,
                Type = FieldRequest.TypeEnum.MultiplePicklist,
                Values = new List<string>()
            };

            var fieldId = await groupShareClient.FieldService.CreateFieldForTemplate(fieldTemplateId, field);
            Assert.True(fieldId != string.Empty);

            await groupShareClient.FieldService.DeleteFieldForTemplate(fieldTemplateId, fieldId);
        }

    }
}
