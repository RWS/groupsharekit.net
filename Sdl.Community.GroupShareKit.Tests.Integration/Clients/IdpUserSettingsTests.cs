using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class IdpUserSettingsTests
    {
        [Fact]
        public async Task IdpUserSettings()
        {
            var groupShareClient = Helper.GsClient;

            var idpUserSettings = await groupShareClient.IdpUserSettingsClient.GetIdpUserSettings();
          
            Assert.True(idpUserSettings != null);
           
        }
    }
}
