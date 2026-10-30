using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Exceptions;
using Sdl.Community.GroupShareKit.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class AiProviderClientTests
    {
        private static readonly GroupShareClient GroupShareClient = Helper.GsClient;

        [Fact]
        public async Task Get_AiProvider_settings_for_current_user()
        {
            var user = await GroupShareClient.User.Get(new UserRequest(GroupShareClient.Credentials.Login));

            var providerSettings = await GroupShareClient.AiProviderClient.GetAiProviderSettings(user.UniqueId);
            Assert.Empty(providerSettings);
        }

        [Fact]
        public async Task AuthenticateAiProvider_fails_with_invalid_credentials()
        {
            var providerSettings = new AiProviderSettings
            {
                Url = "http://url/v1",
                ApiKey = "apiKey"
            };

            await Assert.ThrowsAsync<ApiException>(() => GroupShareClient.AiProviderClient.AuthenticateAiProvider(providerSettings));
        }

        [Fact]
        public async Task Register_update_delete_AiProvider_settings()
        {
            var uniqueId = Guid.NewGuid();

            var userRequest = new CreateUserRequest
            {
                UniqueId = uniqueId.ToString(),
                Name = $"user - {uniqueId}",
                Password = "Password1",
                DisplayName = "User AI provider",
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

            var initialSettings = new AiProviderSettings
            {
                ProviderId = "lm-studio",
                ProviderName = "LM Studio (local)",
                DisplayName = "LM Studio",
                Url = "http://url/v1",
                ModelsPath = "http://url/v1/models",
                ApiKey = "apiKey"
            };

            await GroupShareClient.AiProviderClient.RegisterAiProvider(userId, initialSettings);

            var retrievedSettings = (await GroupShareClient.AiProviderClient.GetAiProviderSettings(userId)).Single();
            Assert.Equal(initialSettings.ProviderId, retrievedSettings.ProviderId);
            Assert.Equal(initialSettings.ProviderName, retrievedSettings.ProviderName);
            Assert.Equal(initialSettings.DisplayName, retrievedSettings.DisplayName);
            Assert.Equal(initialSettings.Url, retrievedSettings.Url);
            Assert.Equal(initialSettings.ModelsPath, retrievedSettings.ModelsPath);
            Assert.Empty(retrievedSettings.ApiKey);

            var updatedSettings = new AiProviderSettings
            {
                ProviderId = "lm-studio",
                ProviderName = "LM Studio (local)",
                DisplayName = "LM Studio - edited",
                Url = "http://url/v2",
                ModelsPath = "http://url/v2/models",
                ApiKey = "apiKey",
                ProviderSettingId = retrievedSettings.ProviderSettingId
            };

            await GroupShareClient.AiProviderClient.UpdateAiProviderSettings(userId, updatedSettings);

            retrievedSettings = (await GroupShareClient.AiProviderClient.GetAiProviderSettings(userId)).Single();
            Assert.Equal(updatedSettings.ProviderId, retrievedSettings.ProviderId);
            Assert.Equal(updatedSettings.ProviderName, retrievedSettings.ProviderName);
            Assert.Equal(updatedSettings.DisplayName, retrievedSettings.DisplayName);
            Assert.Equal(updatedSettings.Url, retrievedSettings.Url);
            Assert.Equal(updatedSettings.ModelsPath, retrievedSettings.ModelsPath);
            Assert.Empty(retrievedSettings.ApiKey);

            await GroupShareClient.AiProviderClient.DeleteAiProviderSettings(userId, retrievedSettings.ProviderSettingId);

            var settingsList = await GroupShareClient.AiProviderClient.GetAiProviderSettings(userId);
            Assert.Empty(settingsList);

            await GroupShareClient.User.DeleteUser(userId);
        }

    }
}
