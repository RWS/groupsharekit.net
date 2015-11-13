using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Clients;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class UserClientTests
    {
        [Theory]
        [InlineData("test_api")]
        public async Task GetUser(string userName)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var response = await groupShareClient.User.Get(new UserRequest(userName));

            Assert.True(response.Name.Equals(userName));
        }

        [Theory]
        [InlineData("test_api", "de-DE")]
        [InlineData("test_user","en-US")]
        public async Task UpdateUserLanguageDirections(string userName,string locale)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var expected = await groupShareClient.User.Get(new UserRequest(userName));

            expected.Locale = locale;
            var response = await groupShareClient.User.Update(expected);

            var actual = await groupShareClient.User.Get(new UserRequest(userName));

            Assert.True(expected.Locale.Equals(actual.Locale));
        }
    }
}
