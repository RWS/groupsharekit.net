namespace Sdl.Community.GroupShareKit.Authentication
{
    /// <summary>
    /// Authentication protocols supported by the GroupShare API
    /// </summary>
    public enum AuthenticationType
    {
        /// <summary>
        /// Basic authentication using username and password
        /// </summary>
        Basic,

        /// <summary>
        /// Use "Negotiate" authentication scheme that acts as a wrapper that can use either:
        /// Kerberos or NTLM
        /// </summary>
        Negotiate,

        /// <summary>
        /// Delegated access to a third party
        /// </summary>
        Oauth
    }
}