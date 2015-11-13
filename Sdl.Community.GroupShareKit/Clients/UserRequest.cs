namespace Sdl.Community.GroupShareKit.Clients
{
    /// <summary>
    /// Used to request a user.
    /// </summary>
    /// <remarks>
    /// API docs: http://sdldevelopmentpartners.sdlproducts.com/documentation/api
    /// </remarks>
    public class UserRequest:RequestParameters
    {
        public UserRequest(string userName)
        {
            Name = userName;
        }

        /// <summary>
        /// Gets or sets the username for which all details will be returned
        /// </summary>
        /// <value>
        /// The username
        /// </value>
        public string Name { get; set; }
    }
}