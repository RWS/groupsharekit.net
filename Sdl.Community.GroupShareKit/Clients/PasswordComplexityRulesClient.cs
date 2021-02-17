using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Http;
using Sdl.Community.GroupShareKit.Models.Response;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class PasswordComplexityRulesClient : ApiClient, IPasswordComplexityRulesClient
    {
        public PasswordComplexityRulesClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }
        public Task<PasswordConstraints> GetPasswordConstraints()
        {
            var passwordComplexityUrl = ApiUrls.GetPasswordComplexityRules();

            return ApiConnection.Get<PasswordConstraints>(passwordComplexityUrl, null);
        }
    }
}
