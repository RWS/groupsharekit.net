using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Models.Response;
using Sdl.Community.GroupShareKit.Tests.Integration.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class TwoFactorAuthenticationClientTests : IClassFixture<IntegrationTestsProjectData>
    {
        private readonly GroupShareClient GroupShareClient = Helper.GsClient;

        [Fact]
        public async Task GetTwoFactorAuthenticationGlobalSetting()
        {
            var requireTwoFaGlobalSetting = await GroupShareClient.TwoFactorAuthenticationClient.GetRequireTwoFaGlobalSetting();
            Assert.False(requireTwoFaGlobalSetting);
        }

        [Fact]
        public async Task GetTwoFactorAuthenticationEnforcementStatusForCurrentUser()
        {
            var userPageRequest = new UsersRequest(1, 1, 10);
            var users = await GroupShareClient.User.GetAllUsers(userPageRequest);

            var currentUser = users.Items.First(user => user.Name == Helper.GsUser);
            var currentUserId = Guid.Parse(currentUser.UniqueId);
            var twoFaEnforcementStatus = await GroupShareClient.TwoFactorAuthenticationClient.GetTwoFaEnforcementStatus(currentUserId);

            Assert.Equal(currentUserId, twoFaEnforcementStatus.UserGuid);
            Assert.False(twoFaEnforcementStatus.Require2FA);
        }

        [Fact]
        public async Task GetTwoFactorAuthenticationEnforcementStatusesForMultipleUsers()
        {
            var userPageRequest = new UsersRequest(1, 1, 3);
            var users = await GroupShareClient.User.GetAllUsers(userPageRequest);
            var userIds = users.Items.Select(user => Guid.Parse(user.UniqueId)).ToList();

            var twoFaEnforcementStatuses = await GroupShareClient.TwoFactorAuthenticationClient.GetTwoFaEnforcementStatuses(userIds);

            Assert.All(twoFaEnforcementStatuses, status => Assert.False(status.Require2FA));
        }

        [Fact]
        public async Task SetTwoFactorAuthenticationEnforcementStatusForUser()
        {
            var uniqueId = Guid.NewGuid();

            var userRequest = new CreateUserRequest
            {
                UniqueId = uniqueId.ToString(),
                Name = $"user - {uniqueId}",
                Password = "Password1",
                DisplayName = "User 2FA",
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
            var twoFaEnforcementStatus = await GroupShareClient.TwoFactorAuthenticationClient.GetTwoFaEnforcementStatus(userId);

            Assert.Equal(userId, twoFaEnforcementStatus.UserGuid);
            Assert.False(twoFaEnforcementStatus.Require2FA);

            await GroupShareClient.TwoFactorAuthenticationClient.SetTwoFaEnforcementStatus(userId, true);
            twoFaEnforcementStatus = await GroupShareClient.TwoFactorAuthenticationClient.GetTwoFaEnforcementStatus(userId);

            Assert.Equal(userId, twoFaEnforcementStatus.UserGuid);
            Assert.True(twoFaEnforcementStatus.Require2FA);

            await GroupShareClient.User.DeleteUser(userId);
        }

        [Fact]
        public async Task SetTwoFactorAuthenticationStatusForCurrentUser()
        {
            var userPageRequest = new UsersRequest(1, 1, 10);
            var users = await GroupShareClient.User.GetAllUsers(userPageRequest);

            var currentUser = users.Items.First(user => user.Name == Helper.GsUser);
            var currentUserId = Guid.Parse(currentUser.UniqueId);

            var twoFaSettings = await GroupShareClient.TwoFactorAuthenticationClient.GetUserTwoFaSettings(currentUserId);
            Assert.False(twoFaSettings.Enabled);

            await GroupShareClient.TwoFactorAuthenticationClient.SetTwoFaStatus(currentUserId, true);

            twoFaSettings = await GroupShareClient.TwoFactorAuthenticationClient.GetUserTwoFaSettings(currentUserId);
            Assert.True(twoFaSettings.Enabled);

            await GroupShareClient.TwoFactorAuthenticationClient.SetTwoFaStatus(currentUserId, false);

            twoFaSettings = await GroupShareClient.TwoFactorAuthenticationClient.GetUserTwoFaSettings(currentUserId);
            Assert.False(twoFaSettings.Enabled);
        }


    }
}
