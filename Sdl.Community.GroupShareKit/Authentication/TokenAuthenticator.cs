using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Http;

namespace Sdl.Community.GroupShareKit.Authentication
{
    class TokenAuthenticator: IAuthenticationHandler
    {
        ///<summary>
        ///Authenticate a request using the OAuth2 Token (sent in a header) authentication scheme
        ///</summary>
        ///<param name="request">The request to authenticate</param>
        ///<param name="credentials">The credentials to attach to the request</param>
        public void Authenticate(IRequest request, Credentials credentials)
        {
            Ensure.ArgumentNotNull(request, "request");
            Ensure.ArgumentNotNull(credentials, "credentials");
            Ensure.ArgumentNotNull(credentials.Token, "credentials.Token");

            var token = credentials.GetToken();
            var bearerId = credentials.BearerId;

            if (token != null)
            {
                request.Headers["Authorization"] = string.Format(CultureInfo.InvariantCulture, "Bearer {0}", token);
                if (!string.IsNullOrWhiteSpace(bearerId))
                    request.Headers["BearerId"] = string.Format(CultureInfo.InvariantCulture, "{0}", bearerId);
            }
        }
    }
}
