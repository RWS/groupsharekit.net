using Newtonsoft.Json;
using System;

namespace Sdl.Community.GroupShareKit.Clients.Logging
{
    public class LogsFilter : IJsonRequest
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string[] Level { get; set; }
        public string[] ProcessName { get; set; }

        public string Stringify()
        {
            return JsonConvert.SerializeObject(this,
                 Formatting.Indented,
                 new JsonSerializerSettings
                 {
                     NullValueHandling = NullValueHandling.Ignore,
                     DateTimeZoneHandling = DateTimeZoneHandling.Utc
                 });
        }
    }
}
