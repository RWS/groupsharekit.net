using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class Permission
    {
        public Guid UniqueId { get; set; }
        public string FullName { get; set; }

        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string ResourceName { get; set; }
        public string PermissionName { get; set; }
    }
}
