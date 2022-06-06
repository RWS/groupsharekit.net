using Sdl.Community.GroupShareKit.Http;

namespace Sdl.Community.GroupShareKit.Authentication
{
    public interface IAuthenticationHandler
    {
        void Authenticate(IRequest request, Credentials credentials);
    }
}
