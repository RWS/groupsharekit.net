using Sdl.Community.GroupShareKit.Authentication;
using Sdl.Community.GroupShareKit.Helpers;

namespace Sdl.Community.GroupShareKit.Http
{
    public class Credentials
    {
        public Credentials(string token, string login, string password, string bearerId = "")
        {
            Ensure.ArgumentNotNullOrEmptyString(token, "token");
            Ensure.ArgumentNotNullOrEmptyString(login, "login");
            Ensure.ArgumentNotNullOrEmptyString(password, "password");

            Login = login;
            Password = password;
            Token = token;
            BearerId = bearerId;
            AuthenticationType = AuthenticationType.Oauth;
        }

        internal Credentials(string login, string password)
        {
            Ensure.ArgumentNotNullOrEmptyString(login, "login");
            Ensure.ArgumentNotNullOrEmptyString(password, "password");

            Login = login;
            Password = password;
            AuthenticationType = AuthenticationType.Basic;
        }

        public string Login
        {
            get;
            private set;
        }

        public string Token { get; set; }

        public string Password
        {
            get;
            private set;
        }

        public string BearerId
        {
            get;
            private set;
        }

        public AuthenticationType AuthenticationType
        {
            get;
            private set;
        }

        public string GetToken()
        {
            return Token;
        }
    }
}