using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Http;
using Sdl.Community.GroupShareKit.Models.Response;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class IdpUserSettingsClient : ApiClient, IIdpUserSettingsClient
    {
        public IdpUserSettingsClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }
        public Task<IdpUserSettings> GetIdpUserSettings()
        {
            var idpUserSettingsUrl = ApiUrls.GetIdpUserSettings();

            return ApiConnection.Get<IdpUserSettings>(idpUserSettingsUrl, null);
        }
    }
}
