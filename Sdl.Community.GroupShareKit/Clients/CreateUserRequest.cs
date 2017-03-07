using System;
using System.Collections.Generic;
using Sdl.Community.GroupShareKit.Models.Response;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class CreateUserRequest
    {
        public string UniqueId { get; set; }
        public string Name { get; set; }
        public object Password { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Locale { get; set; }
        public string OrganizationId { get; set; }
        public string UserType { get; set; }
        public List<Role> Roles { get; set; }
    }
}
