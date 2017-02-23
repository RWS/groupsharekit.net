using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
   public class ModuleClientTests
    {
       [Fact]
       public async Task GetModules()
       {
            var groupShareClient = await Helper.GetAuthenticatedClient();
           var modules = await groupShareClient.ModuleClient.GetModules();

            Assert.True(modules!=null);
       }
    }
}
