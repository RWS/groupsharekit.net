using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class TermbaseClient
    {
        [Fact]
        public async Task GetTermbases()
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var termbases = await groupShareClient.TermBase.GetTermbases();

            Assert.True(termbases !=null);
        }

        //needs to be tested later when we'll have a termbase in GS
        [Theory]
        [InlineData("")]
        public async Task GetTermbaseById(string termbaseId)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var termbase = await groupShareClient.TermBase.GetTermbaseById("termbaseId");
        }

    }
}
