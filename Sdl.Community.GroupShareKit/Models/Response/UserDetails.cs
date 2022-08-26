namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class UserDetails
    {
        /// <summary>
        /// Gets or sets the user id
        /// </summary>
        public string UniqueId { get; set; }
        /// <summary>
        /// Gets or sets the user name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the display name
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// Gets or sets the email
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// Gets or sets the phone number
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Gets or sets the organziation id
        /// </summary>
        public string OrganizationId { get; set; }
        /// <summary>
        /// Gets or sets the user type
        /// </summary>
        public string UserType { get; set; }
        /// <summary>
        /// Gets or sets the isProtected parameter
        /// </summary>
        public string IsProtected { get; set; }
    }
}
