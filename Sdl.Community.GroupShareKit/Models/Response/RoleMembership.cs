﻿using System;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class RoleMembership
    {
        public Guid OrganizationId { get; set; }

        public Guid RoleId { get; set; }

        public Guid UserId { get; set; }
    }
}
