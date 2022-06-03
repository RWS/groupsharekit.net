using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Sdl.Community.GroupShareKit.Clients.Logging
{
    public class LogsSortParameters : IJsonRequest
    {
        /// <summary>
        /// Gets or sets the property option
        /// </summary>
        /// <value>logDate</value>

        [JsonConverter(typeof(StringEnumConverter))]
        public PropertyOption Property { get; set; }

        /// <summary>
        /// Gets or sets direction option
        /// </summary>
        /// <value>ASC</value>
        /// <value>DESC</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public DirectionOption Direction { get; set; }


        public enum PropertyOption
        {
            LogDate
        }
        public enum DirectionOption
        {
            ASC,
            DESC
        }

        public string Stringify()
        {
            var sort = new LogsSortParameters
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
