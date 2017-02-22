using System;
using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response
{

    public class Organization
    {
        public Guid UniqueId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public Guid ParentOrganizationId { get; set; }
        public bool IsLibrary  { get; set; }
        public List<Organization> ChildOrganizations { get; set; }

       
    }

}
