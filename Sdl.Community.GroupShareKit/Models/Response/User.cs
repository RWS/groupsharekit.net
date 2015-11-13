using System;
using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class User
    {
        public Guid UniqueId { get; set; }
        public string Name { get; set; }
        public object Password { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Locale { get; set; }
        public Guid OrganizationId { get; set; }
        public string UserType { get; set; }
        public bool IsProtected { get; set; }
        public List<Role> Roles { get; set; }
    }
}
