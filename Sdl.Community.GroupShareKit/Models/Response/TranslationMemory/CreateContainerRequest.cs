using Newtonsoft.Json;
using System;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class CreateContainerRequest
    {
        /// <summary>
        /// Gets or sets container id
        /// </summary>
        [JsonProperty("containerId", NullValueHandling = NullValueHandling.Ignore)]
        public Guid ContainerId { get; set; }

        /// <summary>
        /// Gets or sets database server id
        /// </summary>
        [JsonProperty("databaseServerId")]
        public Guid DatabaseServerId { get; set; }

        /// <summary>
        /// Gets or sets database name
        /// </summary>
        [JsonProperty("databaseName")]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets display name
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets isShared property
        /// </summary>
        [JsonProperty("isShared")]
        public bool IsShared { get; set; }

        /// <summary>
        /// Gets or sets owner id
        /// </summary>
        [JsonProperty("ownerId")]
        public Guid OwnerId { get; set; }

        /// <summary>
        /// Gets or sets location
        /// </summary>
        [JsonProperty("location")]
        public string Location { get; set; }
    }
}
