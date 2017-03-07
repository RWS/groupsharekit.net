using System;
using System.Collections.Generic;
using Sdl.Community.GroupShareKit.Models.Response;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class RoleRequest
    {
        /// <summary>
        /// Gets or sets the role id
        /// </summary>
        public Guid UniqueId { get; set; }
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets option if the role is protected
        /// </summary>
        public bool IsProtected { get; set; }
        /// <summary>
        /// Gets or sets a list of premission <see cref="Permission"/>
        /// </summary>
        public List<Permission> Permissions { get; set; }


        public RoleRequest(Guid id, string name, bool isProtected, List<Permission> permissions)
        {
            UniqueId = id;
            Name = name;
            IsProtected = isProtected;
            Permissions = permissions;
        }

    }

}
