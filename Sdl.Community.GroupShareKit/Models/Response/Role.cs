﻿using System.Collections.Generic;
using System;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class Role
    {
        ///// <summary>
        ///// Gets or sets the organization id
        ///// </summary>
        //public string OrganizationId { get; set; }
        ///// <summary>
        ///// Gets or sets the role id
        ///// </summary>
        //public string RoleId { get; set; }
        ///// <summary>
        ///// Gets or sets the user id
        ///// </summary>
        //public string UserId { get; set; }

        public Guid UniqueId { get; set; }

        public string Name { get; set; }

        public List<Permission> Permissions { get; set; }

        public bool IsProtected { get; set; }
    }
}