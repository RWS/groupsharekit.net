using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class CreateFieldTemplateRequest
    {
        [JsonProperty("fieldTemplateId", NullValueHandling = NullValueHandling.Ignore)]
        public Guid FieldTemplateId { get; set; }

        [JsonProperty("isTmSpecific")]
        public bool IsTmSpecific { get; set; }

        [JsonProperty("ownerId")]
        public Guid OwnerId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("fields")]
        public IList<Field> Fields { get; set; }
    }
}
