using Newtonsoft.Json;
using System;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class UpdateContainerRequest
    {
        /// <summary>
        /// Gets or sets container id
        /// </summary>
        [JsonProperty("containerId")]
        public Guid ContainerId { get; set; }

        /// <summary>
        /// Gets or sets display name
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets isShared property
        /// </summary>
        [JsonProperty("isShared", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsShared { get; set; }
    }
}
