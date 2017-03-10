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

            Assert.True(termbases.TotalCount>0);
        }

        //needs to be tested later when we'll have a termbase in GS
        [Theory]
        [InlineData("cf6c4742-ba81-494e-8a53-fa186ce118f8")]
        public async Task GetTermbaseById(string termbaseId)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var termbase = await groupShareClient.TermBase.GetTermbaseById("termbaseId");

            Assert.Equal(termbase.Name, "TestFromMultiterm");
            Assert.Equal(termbase.Id,termbaseId);
        }

    }
}
