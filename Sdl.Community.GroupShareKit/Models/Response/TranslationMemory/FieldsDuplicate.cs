using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class FieldsDuplicate
    {
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public TypeEnum Type { get; set; }

        /// <summary>
        /// Gets or sets a list of field values
        /// </summary>
        public List<string> Values { get; set; }
        public enum TypeEnum
        {
            SingleString,
            MultipleString,
            Integer,
            DateTime,
            SinglePicklist,
            MultiplePicklist
        }
    }
}
