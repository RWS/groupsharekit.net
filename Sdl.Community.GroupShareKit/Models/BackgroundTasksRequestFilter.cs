using Newtonsoft.Json;
using System;

namespace Sdl.Community.GroupShareKit.Models
{
    public class BackgroundTasksRequestFilter
    {
        public DateTime? CreatedStart { get; set; }

        public DateTime? CreatedEnd { get; set; }

        public int[] Status { get; set; }

        public int[] Type { get; set; }

        public string SerializeFilter()
        {
            var serializerSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            return JsonConvert.SerializeObject(this, serializerSettings);
        }
    }
}
