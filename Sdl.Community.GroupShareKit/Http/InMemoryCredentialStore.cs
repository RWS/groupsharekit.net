using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Helpers;

namespace Sdl.Community.GroupShareKit.Http
{
    public class InMemoryCredentialStore: ICredentialStore
    {
        private readonly Credentials _credentials;
        public InMemoryCredentialStore(Credentials credentials)
        {
            Ensure.ArgumentNotNull(credentials,"credentials");

            _credentials = credentials;
        }

        public Task<Credentials> GetCredentials()
        {
            return Task.FromResult(_credentials);
        }
    }
}
