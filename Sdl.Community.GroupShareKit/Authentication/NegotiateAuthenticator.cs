using Sdl.Community.GroupShareKit.Http;

namespace Sdl.Community.GroupShareKit.Authentication
{
    class NegotiateAuthenticator : IAuthenticationHandler
    {
        public void Authenticate(IRequest request, Credentials credentials)
        {
            // You could use an external library to generate a Kerberos/NTLM token.
            // The credentials.Token should contain base64 encoded Kerberos/NTLM token.
            if (!string.IsNullOrEmpty(credentials.Token))
            {
                request.Headers["Authorization"] = $"Negotiate {credentials.Token}";
            }
        }
    }
}