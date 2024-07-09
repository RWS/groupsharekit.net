using Newtonsoft.Json;
using System;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    [Obsolete]
    public class DatabaseServerRequest
    {
        /// <summary>
        /// Gets or sets database server id
        /// </summary>
        [JsonProperty("databaseServerId", NullValueHandling = NullValueHandling.Ignore)]
        public string DatabaseServerId { get; set; }

        /// <summary>
        /// Gets or sets db server name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets description
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets host
        /// </summary>
        [JsonProperty("host")]
        public string Host { get; set; }

        /// <summary>
        /// Gets or sets user name
        /// </summary>
        [JsonProperty("userName", NullValueHandling = NullValueHandling.Ignore)]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets  the password
        /// </summary>
        [JsonProperty("password", NullValueHandling = NullValueHandling.Ignore)]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets owner id
        /// </summary>
        [JsonProperty("ownerId")]
        public string OwnerId { get; set; }

        /// <summary>
        /// Gets or sets the location
        /// </summary>
        [JsonProperty("location")]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the authentication method. It can be 'Windows' or 'Database'. For 'Database', a user and password must be specified. 
        /// To be able to create containers, a valid database server instance must be specified (and also valid username and password for 'Database' authentication type)
        /// </summary>
        [JsonProperty("authentication", NullValueHandling = NullValueHandling.Ignore)]
        public string Authentication { get; set; }
    }
}
