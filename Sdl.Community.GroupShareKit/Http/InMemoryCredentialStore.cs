using Sdl.Community.GroupShareKit.Helpers;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Http
{
    public class InMemoryCredentialStore : ICredentialStore
    {
        private readonly Credentials _credentials;
        public InMemoryCredentialStore(Credentials credentials)
        {
            Ensure.ArgumentNotNull(credentials, "credentials");

            _credentials = credentials;
        }

        public Task<Credentials> GetCredentials()
        {
            return Task.FromResult(_credentials);
        }
    }
}
