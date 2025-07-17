using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models
{
    public class ActivitiesRequestFilter
    {
        public List<string> ActivitySources { get; set; }

        public List<Guid> Users { get; set; }

        public DateTime? LastUsedStart { get; set; }

        public DateTime? LastUsedEnd { get; set; }

        public string SerializeFilter()
        {
            var serializerSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DateFormatString = "yyyy-MM-ddTHH:mm:ss.fffZ" };
            return JsonConvert.SerializeObject(this, serializerSettings);
        }
    }
}
