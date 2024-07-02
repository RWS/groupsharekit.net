using Newtonsoft.Json;
using System;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class LanguageResource
    {
        /// <summary>
        /// Gets or sets language resource id
        /// </summary>
        [JsonProperty("languageResourceId", NullValueHandling = NullValueHandling.Ignore)]
        public Guid LanguageResourceId { get; set; }

        /// <summary>
        /// Gets or sets type 
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public LanguageResourceType Type { get; set; }

        /// <summary>
        /// Gets or sets language resource culture name
        /// </summary>
        [JsonProperty("cultureName", NullValueHandling = NullValueHandling.Ignore)]
        public string CultureName { get; set; }

        /// <summary>
        /// Gets or sets language resource template id
        /// </summary>
        [JsonProperty("languageResourceTemplateId", NullValueHandling = NullValueHandling.Ignore)]
        public Guid LanguageResourceTemplateId { get; set; }

        /// <summary>
        /// Gets or sets data
        /// </summary>
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public string Data { get; set; }
    }
}
