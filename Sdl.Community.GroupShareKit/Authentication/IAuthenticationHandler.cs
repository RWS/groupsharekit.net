using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Http;

namespace Sdl.Community.GroupShareKit.Authentication
{
    public interface IAuthenticationHandler
    {
        void Authenticate(IRequest request, Credentials credentials);
    }
}
