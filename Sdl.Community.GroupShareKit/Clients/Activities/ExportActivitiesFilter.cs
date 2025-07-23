using Newtonsoft.Json;
using Sdl.Community.GroupShareKit.Models;

namespace Sdl.Community.GroupShareKit.Clients.Activities
{
    public class ExportActivitiesFilter
    {
        [JsonProperty("page")]
        public int? Page { get; set; }

        [JsonProperty("limit")]
        public int? Limit { get; set; }

        [JsonProperty("filter")]
        public string Filter { get; set; }

        [JsonProperty("language")]
        public ReportLanguage? Language { get; set; }

        [JsonProperty("timeZone")]
        public string TimeZone { get; set; }
    }
}
