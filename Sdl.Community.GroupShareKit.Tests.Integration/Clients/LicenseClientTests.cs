using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class LicenseClientTests
    {
        [Fact]
        public async Task GetLicenseInformations()
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var license = await groupShareClient.License.GetLicenseInformations();

            Assert.True(license!=null);
        }
    }
}
