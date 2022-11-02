using System;
using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class OrganizationPermissions
    {
        public Guid OrganizationId { get; set; }
        public string Name { get; set; }
        public List<string> Permissions { get; set; }
        public List<OrganizationPermissions> ChildOrganizations { get; set; }
    }
}
