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
        private static readonly GroupShareClient GroupShareClient = Helper.GsClient;

        [Fact]
        public async Task Users_GetAllUsers_WithoutRoles_ReturnsUsers()
        {
            var userRequest = new UsersRequest(1, 1, 10);
            var users = await GroupShareClient.User.GetAllUsers(userRequest);

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
            var response = await GroupShareClient.User.Get(new UserRequest(userName));

            Assert.Equal(userName, response.Name);
        }

        [Theory]
        [MemberData(nameof(UserData.UserId), MemberType = typeof(UserData))]
        public async Task Users_GetUserById_ReturnsUser(Guid userId)
        {
            var user = await GroupShareClient.User.GetUser(userId);

            Assert.Equal(user.UniqueId, userId);
        }

        [Theory]
        [MemberData(nameof(UserData.Username), MemberType = typeof(UserData))]
        public async Task Users_UpdateByUsername_Succeeds(string userName)
        {
            var user = await GroupShareClient.User.Get(new UserRequest(userName));

            var updatedDescription = $"Updated description - {DateTime.Now.ToLongDateString()}";
            user.Description = updatedDescription;

            var userId = await GroupShareClient.User.UpdateUser(user);
            Assert.Equal(user.UniqueId, userId);

            var updatedUser = await GroupShareClient.User.Get(new UserRequest(userName));
            Assert.Equal(updatedDescription, updatedUser.Description);
        }

        [Fact]
        public async Task Users_UpdateUserLanguageDirections_Succeeds()
        {
            var uniqueId = Guid.NewGuid();
            var name = $"user - {uniqueId}";

            var userRequest = new CreateUserRequest
            {
                UniqueId = uniqueId.ToString(),
                Name = name,
                Password = "Password1",
                DisplayName = name,
                Description = "Created using GroupShare Kit",
                PhoneNumber = null,
                OrganizationId = Helper.OrganizationId,
                UserType = "SDLUser",
                Roles = new List<RoleMembership>
                {
                    new RoleMembership
                    {
                         OrganizationId = Guid.Parse(Helper.OrganizationId),
                         RoleId = Guid.Parse(Helper.PowerUserRoleId),
                         UserId = uniqueId
                    }
                }
            };

            var userId = await GroupShareClient.User.CreateUser(userRequest);
            var user = await GroupShareClient.User.GetUser(userId);

            Assert.Equal(userRequest.Name, user.Name);
            Assert.Equal(userRequest.Description, user.Description);
            Assert.Equal(Guid.Parse(userRequest.OrganizationId), user.OrganizationId);

            await GroupShareClient.User.Update(user);

            var updatedUser = await GroupShareClient.User.GetUser(userId);

            await GroupShareClient.User.DeleteUser(userId);
        }

        [Fact]
        public async Task Users_CreateUser_Succeeds()
        {
            var uniqueId = Guid.NewGuid();

            var userRequest = new CreateUserRequest
            {
                UniqueId = uniqueId.ToString(),
                Name = $"user - {uniqueId}",
                Password = "Password1",
                DisplayName = "test",
                Description = "Created using GroupShare Kit",
                PhoneNumber = null,
                OrganizationId = Helper.OrganizationId,
                UserType = "SDLUser",
                Roles = new List<RoleMembership>
                {
                    new RoleMembership
                    {
                         OrganizationId = Guid.Parse(Helper.OrganizationId),
                         RoleId = Guid.Parse(Helper.PowerUserRoleId),
                         UserId = uniqueId
                    }
                }
            };

            var userId = await GroupShareClient.User.CreateUser(userRequest);
            var user = await GroupShareClient.User.GetUser(userId);

            Assert.Equal(userRequest.Name, user.Name);
            Assert.Equal(userRequest.Description, user.Description);
            Assert.Equal(Guid.Parse(userRequest.OrganizationId), user.OrganizationId);

            await GroupShareClient.User.DeleteUser(userId);
        }
    }
}