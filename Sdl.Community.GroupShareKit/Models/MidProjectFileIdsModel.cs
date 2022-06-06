using Newtonsoft.Json;
using System;

namespace Sdl.Community.GroupShareKit.Models
{
    public class MidProjectFileIdsModel
    {
        [JsonProperty(PropertyName = "fileIds")]
        public Guid[] FileIds { get; set; }
    }
}
