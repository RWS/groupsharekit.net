using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class DatabaseServerRequest
    {
        /// <summary>
        /// Gets or sets database server id
        /// </summary>
        public string DatabaseServerId { get; set; }
        /// <summary>
        /// Gets or sets db server name
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
        public string UserName { get; set; }
        /// <summary>
        /// Gets or sets  the password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Gets or sets owner id
        /// </summary>
        public string OwnerId { get; set; }
        /// <summary>
        /// Gets or sets the location
        /// </summary>
        public string Location { get; set; }
    }
}
