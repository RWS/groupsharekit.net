using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Models.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Tests.Integration.Setup;
using Xunit;
using System.Linq;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class UserClientTests
    {
        [Fact]
        public async Task Users_GetAllUsers_WithoutRoles_ReturnsUsers()
        {
            var groupShareClient = Helper.GsClient;
            var userRequest = new UsersRequest(1, 1, 10);
            var users = await groupShareClient.User.GetAllUsers(userRequest);

            var currentUser = users.Items.First(user => user.Name == Helper.GsUser);

            Assert.True(users.Count > 0);
            Assert.True(users.Items.Count > 0);
            Assert.NotNull(currentUser.Name);
            Assert.NotNull(currentUser.OrganizationId);
            Assert.NotNull(currentUser.UniqueId);
            Assert.Equal(currentUser.Name, Helper.GsUser);
        }

        [Theory]
        [MemberData(nameof(UserData.Username), MemberType = typeof(UserData))]
        public async Task Users_GetUserByUsername_ReturnsUser(string userName)
        {
            var groupShareClient = Helper.GsClient;
            var response = await groupShareClient.User.Get(new UserRequest(userName));

            Assert.Equal(userName, response.Name);
        }

        [Theory]
        [MemberData(nameof(UserData.UserId), MemberType = typeof(UserData))]
        public async Task Users_GetUserById_ReturnsUser(string userId)
        {
            var groupShareClient = Helper.GsClient;
            var user = await groupShareClient.User.GetUserById(userId);

            Assert.Equal(user.UniqueId.ToString(), userId);
        }

        [Theory]
        [MemberData(nameof(UserData.Username), MemberType = typeof(UserData))]
        public async Task Users_UpdateByUsername_Succeeds(string userName)
        {
            var description = $"Updated description at {DateTime.Now.ToLongDateString()}";

            var groupShareClient = Helper.GsClient;
            var response = await groupShareClient.User.Get(new UserRequest(userName));
            response.Description = description;

            var user = await groupShareClient.User.Update(response);
            Assert.True(user != string.Empty);

            var userUpdated = await groupShareClient.User.Get(new UserRequest(userName));
            Assert.Equal(description, userUpdated.Description);
        }

        [Fact]
        public async Task Users_UpdateUserLanguageDirections_Succeeds()
        {
            var groupShareClient = Helper.GsClient;

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
                //Locale = "en-US",
                OrganizationId = Helper.OrganizationId,
                UserType = "SDLUser",
                Roles = new List<RoleMembership>
                {
                    new RoleMembership
                    {
                         OrganizationId = Guid.Parse(Helper.OrganizationId),
                         RoleId = Guid.Parse(Helper.PowerUserRoleId),
                         UserId = Guid.Parse(uniqueId)
                    }
                }
            };

            var userId = await groupShareClient.User.Create(newUser);
            try
            {
                Assert.True(userId != string.Empty);

                var expectedUser = await groupShareClient.User.GetUserById(userId);
                Assert.Equal(name, expectedUser.Name);

                //expectedUser.Locale = "de-DE";
                await groupShareClient.User.Update(expectedUser);

                var actualUser = await groupShareClient.User.GetUserById(userId);

                //Assert.Equal("de-DE", actualUser.Locale);
            }
            finally
            {
                await groupShareClient.User.Delete(userId);
            }
        }

        [Fact]
        public async Task Users_CreateUser_Succeeds()
        {
            var groupShareClient = Helper.GsClient;
            var uniqueId = Guid.NewGuid().ToString();

            var newUser = new CreateUserRequest
            {
                UniqueId = uniqueId,
                Name = $"automated user {uniqueId}",
                Password = "Password1",
                DisplayName = "test",
                Description = null,
                PhoneNumber = null,
                //Locale = "en-US",
                OrganizationId = Helper.OrganizationId,
                UserType = "SDLUser",
                Roles = new List<RoleMembership>
                {
                    new RoleMembership
                    {
                         OrganizationId = Guid.Parse(Helper.OrganizationId),
                         RoleId = Guid.Parse(Helper.PowerUserRoleId),
                         UserId = Guid.Parse(uniqueId)
                    }
                }
            };

            var userId = await groupShareClient.User.Create(newUser);

            Assert.True(userId != string.Empty);

            await groupShareClient.User.Delete(userId);
        }
    }
}