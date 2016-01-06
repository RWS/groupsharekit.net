using System;
using System.Collections.Generic;
using Sdl.Community.GroupShareKit.Models.Response;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class RoleRequest
    {
        public Guid UniqueId { get; set; }
        public string Name { get; set; }
        public bool IsProtected { get; set; }
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
