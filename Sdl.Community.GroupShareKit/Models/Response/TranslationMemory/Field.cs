using System.Collections.Generic;
using Newtonsoft.Json;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class Field
    {
        /// <summary>
        /// Gets or sets field id
        /// </summary>
        [JsonProperty("fieldId", NullValueHandling = NullValueHandling.Ignore)]
        public string FieldId { get; set; }
        /// <summary>
        /// Gets or sets field template id
        /// </summary>
        [JsonProperty("fieldTemplateId", NullValueHandling = NullValueHandling.Ignore)]
        public string FieldTemplateId { get; set; }
        /// <summary>
        /// Gets or sets name
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets type
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }
        /// <summary>
        /// Gets or sets a list of values
        /// </summary>
        [JsonProperty("values", NullValueHandling = NullValueHandling.Ignore)]
        public List<Value> Values { get; set; }
    }
}
