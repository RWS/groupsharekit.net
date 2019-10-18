using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class LicenseClientTests
    {
        [Fact]
        public async Task GetLicenseInformations()
        {
            var groupShareClient = Helper.GsClient;
            var license = await groupShareClient.License.GetLicenseInformations();

            Assert.True(license != null);
        }
    }
}