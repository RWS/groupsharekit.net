using System;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class Permission
    {
        /// <summary>
        /// Gets or sets the permission id
        /// </summary>
        public Guid UniqueId { get; set; }
        /// <summary>
        /// Gets or sets the full name
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the display name
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the resource name
        /// </summary>
        public string ResourceName { get; set; }
        /// <summary>
        /// Gets or sets the permission name
        /// </summary>
        public string PermissionName { get; set; }
    }
}
