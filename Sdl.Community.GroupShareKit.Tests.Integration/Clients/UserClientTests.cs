using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Models.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Tests.Integration.Setup;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class UserClientTests
    {
        [Fact]
        public async Task GetAllUsers()
        {
            var groupShareClient = Helper.GsClient;
            var userRequest = new UsersRequest(1, 2, 7);
            var users = await groupShareClient.User.GetAllUsers(userRequest);

            Assert.True(users.Count > 0);
        }

        [Theory]
        [MemberData(nameof(UserData.Username), MemberType = typeof(UserData))]
        public async Task GetUser(string userName)
        {
            var groupShareClient = Helper.GsClient;
            var response = await groupShareClient.User.Get(new UserRequest(userName));

            Assert.Equal(userName, response.Name);
        }

        [Theory]
        [MemberData(nameof(UserData.UserId), MemberType = typeof(UserData))]
        public async Task GetUserById(string userId)
        {
            var groupShareClient = Helper.GsClient;
            var user = await groupShareClient.User.GetUserById(userId);

            Assert.Equal(user.UniqueId.ToString(), userId);
        }

        [Theory]
        [MemberData(nameof(UserData.Username), MemberType = typeof(UserData))]
        public async Task Update(string userName)
        {
            var description = $"Updated description at {DateTime.Now.ToLongDateString()}";

            var groupShareClient = await Helper.GetGroupShareClient();
            var response = await groupShareClient.User.Get(new UserRequest(userName));
            response.Description = description;

            var user = await groupShareClient.User.Update(response);
            Assert.True(user != string.Empty);

            var userUpdated = await groupShareClient.User.Get(new UserRequest(userName));
            Assert.Equal(description, userUpdated.Description);
        }

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
                DisplayName = name,
                Description = null,
                PhoneNumber = null,
                Locale = "en-US",
                OrganizationId = Helper.OrganizationId,
                UserType = "SDLUser",
                Roles = new List<Role>
                {
                    new Role
                    {
                         OrganizationId = Helper.OrganizationId,
                         RoleId = Helper.PowerUserRoleId,
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
                Name = $"automated user {uniqueId}",
                Password = "Password1",
                DisplayName = "test",
                Description = null,
                PhoneNumber = null,
                Locale = "en-US",
                OrganizationId = Helper.OrganizationId,
                UserType = "SDLUser",
                Roles = new List<Role>
                {
                    new Role
                    {
                         OrganizationId = Helper.OrganizationId,
                         RoleId = Helper.PowerUserRoleId,
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