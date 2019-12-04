using System;
using System.Globalization;
using System.Text;
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

            var header = string.Format(
                CultureInfo.InvariantCulture,
                "Basic {0}",
                Convert.ToBase64String(Encoding.UTF8.GetBytes(
                    string.Format(CultureInfo.InvariantCulture, "{0}:{1}", credentials.Login, credentials.Password))));

            request.Headers["Authorization"] = header;
        }
    }
}