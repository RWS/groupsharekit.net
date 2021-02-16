using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Sdl.Community.GroupShareKit.Clients
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
                     ContractResolver = new CamelCasePropertyNamesContractResolver()
                 });
        }
    }
}
