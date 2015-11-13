using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    /// <summary>
    /// Represents an oauth access given to a particular application.
    /// </summary>
    public class Authorization
    {
        public Authorization()
        {
            
        }

        public Authorization(string userName,string token, DateTimeOffset expirationDate, string[] scopes)
        {
            UserName = userName;
            Token = token;
            ExpirationDate = expirationDate;
            Scopes = scopes;
        }

        public string UserName { get; set; }

        public string Token { get; set; }

        public DateTimeOffset ExpirationDate { get; set; }

        public string[] Scopes { get; set; }
    }
}
