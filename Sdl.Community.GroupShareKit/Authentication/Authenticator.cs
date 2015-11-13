using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Http;

namespace Sdl.Community.GroupShareKit.Authentication
{
    class Authenticator
    {
        private readonly Dictionary<AuthenticationType, IAuthenticationHandler> _authenticators =
            new Dictionary<AuthenticationType, IAuthenticationHandler>()
            {
                {AuthenticationType.Basic, new BasicAuthenticator()},
                {AuthenticationType.Oauth, new TokenAuthenticator() }
            };

        public Authenticator(ICredentialStore credentialStore)
        {
            Ensure.ArgumentNotNull(credentialStore,"credentialStore");

            CredentialStore = credentialStore;
        }

        public async Task Apply(IRequest request)
        {
            Ensure.ArgumentNotNull(request, "request");

            var credentials = await CredentialStore.GetCredentials().ConfigureAwait(false);
            _authenticators[credentials.AuthenticationType].Authenticate(request,credentials);
        }

        public ICredentialStore CredentialStore { get; set; }
    }
}
