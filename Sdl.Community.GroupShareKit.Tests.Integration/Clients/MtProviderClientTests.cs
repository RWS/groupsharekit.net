using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Exceptions;
using Sdl.Community.GroupShareKit.Models.Response;
using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class MtProviderClientTests
    {
        private static readonly GroupShareClient GroupShareClient = Helper.GsClient;

        [Fact]
        public async Task GetMtProviderToken_Throws_APIException_ForInvalidCredentials()
        {
            var bodyParameters = new MtProviderSettings()
            {
                ClientId = "client id",
                ClientSecret = "client secret",
                TranslationProviderType = "MTCloud"
            };

            await Assert.ThrowsAsync<ApiException>(() => GroupShareClient.MtProviderClient.GetMtProviderToken(bodyParameters));
        }

        [Fact]
        public async Task GetMtProviderCredentials_Returns_Null_When_NoCredentials_Are_Set()
        {
            var userId = await GroupShareClient.User.Get(new UserRequest(GroupShareClient.Credentials.Login));

            var mtProviderCredentialsData = await GroupShareClient.MtProviderClient.GetMtProviderCredentials(userId.UniqueId);

            Assert.NotNull(mtProviderCredentialsData);
        }

        [Fact]
        public async Task AddMtProviderCredentials_ThrowsApiException_When_AddingInvalidCredentials()
        {
            var userId = await GroupShareClient.User.Get(new UserRequest(GroupShareClient.Credentials.Login));

            var bodyParameters = new MtProviderSettings()
            {
                ClientId = "client id",
                ClientSecret = "client secret",
                TranslationProviderType = "MTCloud"
            };

            await Assert.ThrowsAsync<ApiException>(() => GroupShareClient.MtProviderClient.AddMtProviderCredentials(userId.UniqueId, bodyParameters));
        }

        [Fact]
        public async Task UpdateMtProviderCredentials_ThrowsApiException_When_UpdatingWithInvalidCredentials()
        {
            var userId = await GroupShareClient.User.Get(new UserRequest(GroupShareClient.Credentials.Login));

            //this will provide a list of MtProviderSettings, from which you need to select the ProviderSettingId used for the translation provider you want to update
            var mtProviderCredentialsData = await GroupShareClient.MtProviderClient.GetMtProviderCredentials(userId.UniqueId);

            var bodyParameters = new MtProviderSettings()
            {
                ClientId = "client id",
                ClientSecret = "client secret",
                ProviderSettingId = 1,
                TranslationProviderType = "MTCloud"
            };

            await Assert.ThrowsAsync<ApiException>(() => GroupShareClient.MtProviderClient.UpdateMtProviderCredentials(userId.UniqueId, bodyParameters));
        }

        [Fact]
        public async Task DeleteMtProviderCredentials_ThrowsApiException_WhenNoCredentialsExistToDelete()
        {
            var userId = await GroupShareClient.User.Get(new UserRequest(GroupShareClient.Credentials.Login));

            //this will provide a list of MtProviderSettings, from which you need to select the ProviderSettingId used for the translation provider you want to update
            var mtProviderCredentialsData = await GroupShareClient.MtProviderClient.GetMtProviderCredentials(userId.UniqueId);

            var providerSettingsId = 1;

            await Assert.ThrowsAsync<ApiException>(() => GroupShareClient.MtProviderClient.DeleteMtProviderCredentials(userId.UniqueId, providerSettingsId));
        }
    }
}
