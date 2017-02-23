using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
