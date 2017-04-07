using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class FieldFilter
    {
        /// <summary>
        /// Gets or sets filed name
        /// </summary>
        public string Name { get; set; }
      
        /// <summary>
        /// Gets or sets field values
        /// </summary>
        public List<string> Values { get; set; }


        /// <summary>
        /// Gets or sets filed type
        /// </summary>
        [JsonConverter(typeof (StringEnumConverter))]
        public TypeEnum Type { get; set; }

        public enum TypeEnum
        {
            SingleString
        }
    }
}
