using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Models.Response;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class UserClientTests
    {
        [Fact]
        public async Task GetAllUsers()
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();

            var userRequest = new UsersRequest(1,2,7);

            var users = await groupShareClient.User.GetAllUsers(userRequest);

            Assert.True(users.Count>0);
        }

        [Theory]
        [InlineData("rcrisan")]
        public async Task GetUser(string userName)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var response = await groupShareClient.User.Get(new UserRequest(userName));

            Assert.True(response.Name.Equals(userName));
        }

        [Theory]
        [InlineData("83551d37-2568-4bc6-9342-2fce68ed6b0a")]
        public async Task GetUserById(string userId)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();

            var user = await groupShareClient.User.GetUserById(userId);

            Assert.Equal(user.UniqueId.ToString(),userId);
        }

        [Theory]
        [InlineData("aghisa")]
        public async Task Update(string userName)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var response = await groupShareClient.User.Get(new UserRequest(userName));

            response.Description = "Description";

            var user = await groupShareClient.User.Update(response);

            Assert.True(user != string.Empty);

            var userUpdated = await groupShareClient.User.Get(new UserRequest(userName));
            Assert.Equal(userUpdated.Description, "Description");

        }

        [Theory]
        [InlineData("testuser", "de-DE")]
        public async Task UpdateUserLanguageDirections(string userName, string locale)
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var expected = await groupShareClient.User.Get(new UserRequest(userName));

            expected.Locale = locale;
            await groupShareClient.User.Update(expected);

            var actual = await groupShareClient.User.Get(new UserRequest(userName));

            Assert.True(expected.Locale.Equals(actual.Locale));
        }

        [Fact]
        public async Task Create()
        {
            var groupShareClient = await Helper.GetAuthenticatedClient();
            var uniqueId = Guid.NewGuid().ToString();

            var newUser = new CreateUserRequest
            {
                UniqueId = uniqueId,
                Name = "User",
                Password = "Password1",
                DisplayName = "test",
                Description = null,
                PhoneNumber = null,
                Locale = "en-US",
                OrganizationId = "5bdb10b8-e3a9-41ae-9e66-c154347b8d17",
                UserType = "SDLUser",
                Roles = new List<Role>
                {
                    new Role
                    {
                         OrganizationId = "5bdb10b8-e3a9-41ae-9e66-c154347b8d17",
                          RoleId = "793f3f38-3899-49e5-b793-99a53cd1d24d",//power user
                           UserId = uniqueId
                    }
                }
            };

            var userId = await groupShareClient.User.Create(newUser);

            Assert.True(userId != string.Empty);

            await groupShareClient.User.Delete(userId);
        }
    }
}
