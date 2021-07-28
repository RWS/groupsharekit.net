using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Http;
using Sdl.Community.GroupShareKit.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class MtProviderClient : ApiClient, IMtProviderClient
    {
        public MtProviderClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        public Task<MtCloudToken> GetMtProviderToken(MtProviderSettings mtProviderSettings)
        {
            var mtCloudAccessTokenUrl = ApiUrls.MtProviderCredentials();         

            return ApiConnection.Post<MtCloudToken>(mtCloudAccessTokenUrl, mtProviderSettings, "application/json");
        }

        public Task<List<MtProviderSettings>> GetMtProviderCredentials(Guid userId)
        {
            var mtCloudAccessTokenUrl = ApiUrls.GetMtProviderCredentials(userId);          

            return ApiConnection.Get<List<MtProviderSettings>>(mtCloudAccessTokenUrl, new TimeSpan(0, 0, 30));
        }

        public Task<Guid> AddMtProviderCredentials(Guid userId, MtProviderSettings mtProviderSettings)
        {
            var mtCloudAccessTokenUrl = ApiUrls.AddMtProviderCredentials(userId);

            return ApiConnection.Post<Guid>(mtCloudAccessTokenUrl, mtProviderSettings, "application/json");
        }

        public Task<Guid> UpdateMtProviderCredentials(Guid userId, MtProviderSettings mtProviderSettings)
        {
            var mtCloudAccessTokenUrl = ApiUrls.UpdateMtProviderCredentials(userId);

            return ApiConnection.Put<Guid>(mtCloudAccessTokenUrl, mtProviderSettings);
        }

        public Task DeleteMtProviderCredentials(Guid userId, int providerSettingId)
        {
            var mtCloudAccessTokenUrl = ApiUrls.DeleteMtProviderCredentials(userId, providerSettingId);

            return ApiConnection.Delete(mtCloudAccessTokenUrl);
        }
    }
}
