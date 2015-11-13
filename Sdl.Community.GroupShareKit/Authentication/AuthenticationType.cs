namespace Sdl.Community.GroupShareKit.Authentication
{
    /// <summary>
    /// Authentication protocols supported by the GroupShare API
    /// </summary>
    public enum AuthenticationType
    {
        /// <summary>
        /// Username &amp; password
        /// </summary>
        Basic,
        /// <summary>
        /// Delegated access to a third party
        /// </summary>
        Oauth
    }
}