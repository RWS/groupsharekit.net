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

        /// <summary>
        /// Gets the password complexity rules.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>A list of <see cref="PasswordConstraints"/>s.</returns>
        public Task<PasswordConstraints> GetPasswordConstraints()
        {
            var passwordComplexityUrl = ApiUrls.GetPasswordComplexityRules();

            return ApiConnection.Get<PasswordConstraints>(passwordComplexityUrl, null);
        }
    }
}
