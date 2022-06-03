namespace Sdl.Community.GroupShareKit.Clients
{
    /// <summary>
    /// Used to request a user.
    /// </summary>
    /// <remarks>
    /// API docs: http://gs2017dev.sdl.com:41234/documentation/api/index#/
    /// </remarks>
    public class UserRequest : RequestParameters
    {
        /// <summary>
        /// Gets or sets the user domain for which all details will be returned
        /// </summary>
        /// <value>
        /// The user domain
        /// </value>
        public string Domain { get; set; }

        /// <summary>
        /// Gets or sets the username for which all details will be returned
        /// </summary>
        /// <value>
        /// The username
        /// </value>
        public string Name { get; set; }

        public UserRequest(string userName)
        {
            Name = userName;
        }

        public UserRequest(string domain, string userName)
        {
            Domain = domain;
            Name = userName;
        }
    }
}