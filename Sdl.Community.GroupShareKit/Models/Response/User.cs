using System;
using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class User
    {
        /// <summary>
        /// Gets or sets the  user id
        /// </summary>
        public Guid UniqueId { get; set; }
        /// <summary>
        /// Gets or sets the user name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the password
        /// </summary>
        //public object Password { get; set; }
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
        /// Gets or sets the  organization id
        /// </summary>
        public Guid OrganizationId { get; set; }
        /// <summary>
        /// Gets or sets the user type
        /// </summary>
        public string UserType { get; set; }
        /// <summary>
        /// Gets or sets if the user is protected 
        /// </summary>
        public bool IsProtected { get; set; }
        /// <summary>
        /// Gets or sets a list of roles <see cref="Role"/> 
        /// </summary>
        //public List<Role> Roles { get; set; }
    }
}
