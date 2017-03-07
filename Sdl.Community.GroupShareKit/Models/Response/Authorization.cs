using System;

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

        /// <summary>
        /// Gets or sets the user name
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the expiration date
        /// </summary>
        public DateTimeOffset ExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets the scopes
        /// </summary>
        public string[] Scopes { get; set; }
    }
}
