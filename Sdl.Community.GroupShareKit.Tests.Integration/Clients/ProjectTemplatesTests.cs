using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Models.Response;
using Xunit;
using File = System.IO.File;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
   public  class ProjectTemplatesTests
   {
       private ProjectClientTests _projectTests = new ProjectClientTests();
        [Fact]
        public async Task GetAllProjectsTemplates()
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var templates = await groupShareClient.ProjectsTemplates.GetAllTemplates();

            Assert.True(templates.Count>0);
        }

       [Theory]
       [InlineData("7bf6410d-58a7-4817-a559-7aa8a3a99aa9")]
       public async Task<string> GetTemplateById(string templateId)
       {
            var groupShareClient = await Helper.GetGroupShareClient();

            var template = await groupShareClient.ProjectsTemplates.GetTemplateById(templateId);

            Assert.True(template!=string.Empty);
           return template;
       }

        [Fact]
       public async Task CreateTemplate()
       {
            var groupShareClient = await Helper.GetGroupShareClient();

            var rawData =
               File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\SampleTemplate.sdltpl"));
            var id = Guid.NewGuid().ToString();
            var templateRequest = new ProjectTemplates(id,"kit","", "5bdb10b8-e3a9-41ae-9e66-c154347b8d17");
            var templateId = await groupShareClient.ProjectsTemplates.CreateTemplate(templateRequest,rawData);

            Assert.True(templateId!=string.Empty);

              await groupShareClient.ProjectsTemplates.Delete(templateId);
        }


    }
}
