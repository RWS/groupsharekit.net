using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class DatabaseServer
    {
        /// <summary>
        /// Gets or sets data base server id
        /// </summary>
        public string DatabaseServerId { get; set; }
        /// <summary>
        /// Gets or sets name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets host
        /// </summary>
        public string Host { get; set; }
        /// <summary>
        /// Gets or sets user name
        /// </summary>
        public string UserName  { get; set; }
        /// <summary>
        /// Gets or sets password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Gets or sets a list of containers
        /// </summary>
        public List<Container> Containers { get; set; }
    }
}
