using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class ModuleClientTests
    {
        [Fact]
        public async Task GetModules()
        {
            var groupShareClient = Helper.GsClient;
            var modules = await groupShareClient.ModuleClient.GetModules();

            Assert.True(modules != null);
        }
    }
}