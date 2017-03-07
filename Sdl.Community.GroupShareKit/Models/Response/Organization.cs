using System;
using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response
{

    public class Organization
    {
        /// <summary>
        /// Gets or sets organization id
        /// </summary>
        public Guid UniqueId { get; set; }
        /// <summary>
        /// Gets or sets organization name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets  description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets organization path
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// Gets or sets parent organization id
        /// </summary>
        public Guid ParentOrganizationId { get; set; }
        /// <summary>
        /// Gets or sets if the organization is library
        /// </summary>
        public bool IsLibrary  { get; set; }
        /// <summary>
        /// Gets or sets a list of child organizations <see cref="Organization"/>
        /// </summary>
        public List<Organization> ChildOrganizations { get; set; }

       
    }

}
