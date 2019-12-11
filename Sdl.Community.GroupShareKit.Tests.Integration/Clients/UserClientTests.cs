using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Models.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class UserClientTests
    {
        [Fact]
        public async Task GetAllUsers()
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var userRequest = new UsersRequest(1, 2, 7);
            var users = await groupShareClient.User.GetAllUsers(userRequest);

            Assert.True(users.Count > 0);
        }

        [Theory]
        [InlineData("rcrisan")]
        public async Task GetUser(string userName)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var response = await groupShareClient.User.Get(new UserRequest(userName));

            Assert.Equal(userName, response.Name);
        }

        [Theory]
        [InlineData("83551d37-2568-4bc6-9342-2fce68ed6b0a")]
        public async Task GetUserById(string userId)
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var user = await groupShareClient.User.GetUserById(userId);

            Assert.Equal(user.UniqueId.ToString(), userId);
        }

        //[Theory]
        //[InlineData("aghisa")]
        //public async Task Update(string userName)
        //{
        //    var groupShareClient = await Helper.GetGroupShareClient();
        //    var response = await groupShareClient.User.Get(new UserRequest(userName));
        //    response.Description = "Updated Description";

        //    var user = await groupShareClient.User.Update(response);
        //    Assert.True(user != string.Empty);

        //    var userUpdated = await groupShareClient.User.Get(new UserRequest(userName));
        //    Assert.Equal("Updated Description", userUpdated.Description);
        //}

        [Fact]
        public async Task UpdateUserLanguageDirections()
        {
            var groupShareClient = await Helper.GetGroupShareClient();

            var uniqueId = Guid.NewGuid().ToString();
            var name = $"automated user {uniqueId}";

            var newUser = new CreateUserRequest
            {
                UniqueId = uniqueId,
                Name = name,
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
            try
            {
                Assert.True(userId != string.Empty);

                var expectedUser = await groupShareClient.User.GetUserById(userId);
                Assert.Equal(name, expectedUser.Name);

                expectedUser.Locale = "de-DE";
                await groupShareClient.User.Update(expectedUser);

                var actualUser = await groupShareClient.User.GetUserById(userId);

                Assert.Equal("de-DE", actualUser.Locale);
            }
            finally
            {
                await groupShareClient.User.Delete(userId);
            }
        }

        [Fact]
        public async Task Create()
        {
            var groupShareClient = await Helper.GetGroupShareClient();
            var uniqueId = Guid.NewGuid().ToString();

            var newUser = new CreateUserRequest
            {
                UniqueId = uniqueId,
                Name = "User test",
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