using Sdl.Community.GroupShareKit.Clients;
using Sdl.Community.GroupShareKit.Exceptions;
using Sdl.Community.GroupShareKit.Models.Response;
using System.Threading.Tasks;
using Xunit;

namespace Sdl.Community.GroupShareKit.Tests.Integration.Clients
{
    public class MtProviderClientTests
    {
        [Fact]
        public async Task GetMtProviderToken()
        {
            var groupShareClient = Helper.GsClient;

            var bodyParameters = new MtProviderSettings()
            {
                ClientId = "client id",
                ClientSecret = "client secret",
                TranslationProviderType = "MTCloud"
            };

           await Assert.ThrowsAsync<ApiException>(() =>groupShareClient.MtProviderClient.GetMtProviderToken(bodyParameters));
        }

        [Fact]
        public async Task GetMtProviderCredentials()
        {
            var groupShareClient = Helper.GsClient;

            var userId = await groupShareClient.User.Get(new UserRequest(groupShareClient.Credentials.Login));

            var mtProviderCredentialsData = await groupShareClient.MtProviderClient.GetMtProviderCredentials(userId.UniqueId);

            Assert.NotNull(mtProviderCredentialsData);
        }

        [Fact]
        public async Task AddMtProviderCredentials()
        {
            var groupShareClient = Helper.GsClient;

            var userId = await groupShareClient.User.Get(new UserRequest(groupShareClient.Credentials.Login));

            var bodyParameters = new MtProviderSettings()
            {
                ClientId = "client id",
                ClientSecret = "client secret",
                TranslationProviderType = "MTCloud"
            };

           await Assert.ThrowsAsync<ApiException>(() => groupShareClient.MtProviderClient.AddMtProviderCredentials(userId.UniqueId, bodyParameters));
        }

        [Fact]
        public async Task UpdateMtProviderCredentials()
        {
            var groupShareClient = Helper.GsClient;

            var userId = await groupShareClient.User.Get(new UserRequest(groupShareClient.Credentials.Login));

            //this will provide a lis of MtProviderSettings, from which you need to select the ProviderSettingId used for the translation provider you want to update
            var mtProviderCredentialsData = await groupShareClient.MtProviderClient.GetMtProviderCredentials(userId.UniqueId);

            var bodyParameters = new MtProviderSettings()
            {
                ClientId = "client id",
                ClientSecret = "client secret",
                ProviderSettingId = 1,
                TranslationProviderType = "MTCloud"
            };

            await Assert.ThrowsAsync<ApiException>(() => groupShareClient.MtProviderClient.UpdateMtProviderCredentials(userId.UniqueId, bodyParameters));
        }

        [Fact]
        public async Task DeleteMtProviderCredentials()
        {
            var groupShareClient = Helper.GsClient;

            var userId = await groupShareClient.User.Get(new UserRequest(groupShareClient.Credentials.Login));

            //this will provide a lis of MtProviderSettings, from which you need to select the ProviderSettingId used for the translation provider you want to update
            var mtProviderCredentialsData = await groupShareClient.MtProviderClient.GetMtProviderCredentials(userId.UniqueId);

            var providerSettingsId = 1;

            await Assert.ThrowsAsync<ApiException>(() => groupShareClient.MtProviderClient.DeleteMtProviderCredentials(userId.UniqueId, providerSettingsId));
        }
    }
}
