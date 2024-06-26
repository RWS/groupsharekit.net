using Newtonsoft.Json;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class UpdateDatabaseServerRequest
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("userName", NullValueHandling = NullValueHandling.Ignore)]
        public string UserName { get; set; }

        [JsonProperty("password", NullValueHandling = NullValueHandling.Ignore)]
        public string Password { get; set; }

        [JsonProperty("authentication", NullValueHandling = NullValueHandling.Ignore)]
        public string Authentication { get; set; }
    }
}
