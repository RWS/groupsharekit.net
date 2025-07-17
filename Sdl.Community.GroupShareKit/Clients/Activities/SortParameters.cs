using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

namespace Sdl.Community.GroupShareKit.Clients.Activities
{
    public class SortParameters : IJsonRequest
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public PropertyOption Property { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public DirectionOption Direction { get; set; }

        public enum PropertyOption
        {
            LastActivity,
            ActivitySource,
            UserName,
            UserDisplayName,
            OrganizationName,
            CalsConsumed,
            Login,
            ActivitySourceDetails
        }

        public enum DirectionOption
        {
            ASC,
            DESC
        }

        public string Stringify()
        {
            var sort = new SortParameters
            {
                Property = Property,
                Direction = Direction
            };

            return JsonConvert.SerializeObject(sort,
                    Formatting.Indented,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }
    }
}
