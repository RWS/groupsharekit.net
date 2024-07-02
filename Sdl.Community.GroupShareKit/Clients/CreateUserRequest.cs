using Sdl.Community.GroupShareKit.Models.Response;
using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class CreateUserRequest
    {
        /// <summary>
        /// Gets or sets the unique id
        /// </summary>
        public string UniqueId { get; set; }
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the password
        /// </summary>
        public object Password { get; set; }
        /// <summary>
        /// Gets or sets the display name
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the email address 
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// Gets or sets the phone number
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Gets or sets the locale
        /// </summary>
        //public string Locale { get; set; }
        /// <summary>
        /// Gets or sets the organization id
        /// </summary>
        public string OrganizationId { get; set; }
        /// <summary>
        /// Gets or sets the user type
        /// </summary>
        public string UserType { get; set; }
        /// <summary>
        /// Gets or sets a list of user role 
        /// </summary>
        //public List<Role> Roles { get; set; }
        public List<RoleMembership> Roles { get; set; }
    }
}
