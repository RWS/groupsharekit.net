using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Models.Response;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
   public  class ProjectTemplatesTests
    {
        [Fact]
        public async Task GetAllProjectsTemplates()
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var templates = await groupShareClient.ProjectsTemplates.GetAllTemplates();

            Assert.True(templates.Count>0);
        }

       [Theory]
       [InlineData("7bf6410d-58a7-4817-a559-7aa8a3a99aa9")]
       public async Task GetTemplateById(string templateId)
       {
            var groupShareClient = await Helper.GetAuthenticatedClient();

           var template = await groupShareClient.ProjectsTemplates.GetTemplateById(templateId);

            Assert.True(template!=string.Empty);
       }

        [Fact]
       public async Task CreateTemplate()
       {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var templateRequest = new ProjectTemplates("4499f098-0c69-449a-a95e-1058367d3653","Test","", "5bdb10b8-e3a9-41ae-9e66-c154347b8d17");
            var templateId = await groupShareClient.ProjectsTemplates.CreateTemplate(templateRequest);

            Assert.True(templateId!=string.Empty);

            await groupShareClient.ProjectsTemplates.Delete(templateId);
       }
    }
}
