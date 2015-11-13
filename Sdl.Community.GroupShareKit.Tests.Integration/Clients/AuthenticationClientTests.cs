using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Authentication;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class AuthenticationClientTests
    {
        [Fact]
        public async Task GetAndCheckAuthorizationToken()
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
  
            Assert.True(groupShareClient.Credentials.AuthenticationType == AuthenticationType.Oauth);

            var users = await groupShareClient.User.GetAllUsers();

            Assert.True(users != null);
        }
    }
}
