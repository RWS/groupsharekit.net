using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class TranslationMemotiesClient
    {
        [Fact]
        public async Task GetTms()
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();

            var tmsResponse = await groupShareClient.TranslationMemories.GetTms();

            Assert.True(tmsResponse.Items.Count>0);
        }
    }
}
