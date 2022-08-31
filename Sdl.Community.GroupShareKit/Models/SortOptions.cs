using Newtonsoft.Json;

namespace Sdl.Community.GroupShareKit.Models
{
    public class SortOptions
    {
        [JsonProperty("property")]
        public string Property { get; set; }

        [JsonProperty("direction")]
        public string Direction { get; set; }

        public static string GetSerializedDefaultBackgroundTasksSort()
        {
            var sort = new SortOptions
            {
                Property = "CreatedAt",
                Direction = "DESC"
            };

            return JsonConvert.SerializeObject(sort);
        }
    }
}
