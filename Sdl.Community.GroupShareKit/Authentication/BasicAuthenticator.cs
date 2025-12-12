using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Http;

namespace Sdl.Community.GroupShareKit.Authentication
{
    class BasicAuthenticator : IAuthenticationHandler
    {
        ///<summary>
        ///Authenticate a request using the basic access authentication scheme
        ///</summary>
        ///<param name="request">The request to authenticate</param>
        ///<param name="credentials">The credentials to attach to the request</param>
        public void Authenticate(IRequest request, Credentials credentials)
        {
            Ensure.ArgumentNotNull(request,"request");
            Ensure.ArgumentNotNull(credentials,"credentials");
            Ensure.ArgumentNotNull(credentials.Login,"credentials.Login");
            Ensure.ArgumentNotNull(credentials.Password,"credentials.Password");
        }
    }
}