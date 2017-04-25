using System;
using System.Collections.Generic;
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
               File.ReadAllBytes(@"C:\Users\aghisa\Documents\Studio 2017\Project Templates\SampleTemplate.sdltpl");
            var templateRequest = new ProjectTemplates(" kit","", "5bdb10b8-e3a9-41ae-9e66-c154347b8d17",rawData);
            var templateId = await groupShareClient.ProjectsTemplates.CreateTemplate(templateRequest);

            Assert.True(templateId!=string.Empty);

              await groupShareClient.ProjectsTemplates.Delete(templateId);
        }


    }
}
