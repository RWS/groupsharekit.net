using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class SortParameters : IJsonRequest
    {
        /// <summary>
        /// Gets or sets the property option
        /// </summary>
        /// <value>ProjectName</value>
        /// <value>CreatedAt</value>
        /// <value>DueDate</value>
        ///  <value>CustomerName</value>
        /// <value>Status</value>
        /// <value>SourceLanguage</value>
        /// <value>OrganizationPath</value>
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
            ProjectName,
            CreatedAt,
            DueDate,
            CustomerName,
            Status,
            SourceLanguage,
            OrganizationPath
        }

        public enum DirectionOption
        {
            ASC,
            DESC
        }

        public string Stringify()
        {
            var sort = new SortParameters()
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
