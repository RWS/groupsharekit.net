using Newtonsoft.Json;

namespace Sdl.Community.GroupShareKit.Clients.Activities
{
    public class ActivitiesFilter : ExportActivitiesFilter
    {
        [JsonProperty("start")]
        public int? Start { get; set; }

        [JsonProperty("sort")]
        public string Sort { get; set; }
    }
}
