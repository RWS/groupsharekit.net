using Newtonsoft.Json;
using System;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    [Obsolete]
    public class Resource
    {
        /// <summary>
        /// Gets or sets language resource id
        /// </summary>
        [JsonProperty("languageResourceId", NullValueHandling = NullValueHandling.Ignore)]
        public string LanguageResourceId { get; set; }
        /// <summary>
        /// Gets or sets language resource template id
        /// </summary>
        [JsonProperty("languageResourceTemplateId", NullValueHandling = NullValueHandling.Ignore)]
        public string LanguageResourceTemplateId { get; set; }
        /// <summary>
        /// Gets or sets language resource culture name
        /// </summary>
        [JsonProperty("cultureName", NullValueHandling = NullValueHandling.Ignore)]
        public string CultureName { get; set; }
        /// <summary>
        /// Gets or sets type 
        /// Type possible value: Variables, Abbreviations, OrdinalFollowers, SegmentationRules
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }
        /// <summary>
        /// Gets or sets data
        /// </summary>
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public string Data { get; set; }

    }
}
