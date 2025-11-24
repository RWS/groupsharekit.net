using System.Text.Json.Serialization;

namespace Sdl.Community.GroupShareKit.Models.Response.MultiTerm.Images
{
    public class MultimediaRequest
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Extension { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Base64data { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ConceptId { get; set; }
    }
}
