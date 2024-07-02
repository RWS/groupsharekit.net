using System;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    [Obsolete("ContainerRequest is deprecated, please use CreateContainerRequest instead.")]
    public class ContainerRequest
    {
        /// <summary>
        /// Gets or sets database server id
        /// </summary>
        public string DatabaseServerId { get; set; }
        /// <summary>
        /// Gets or sets container id
        /// </summary>
        public string ContainerId { get; set; }
        /// <summary>
        /// Gets or sets database name
        /// </summary>
        public string DatabaseName { get; set; }
        /// <summary>
        /// Gets or sets display name
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// Gets or sets if is shared
        /// </summary>
        public bool IsShared { get; set; }
        /// <summary>
        /// Gets or sets owner id
        /// </summary>
        public string OwnerId { get; set; }
        /// <summary>
        /// Gets or sets location
        /// </summary>
        public string Location { get; set; }
    }
}
