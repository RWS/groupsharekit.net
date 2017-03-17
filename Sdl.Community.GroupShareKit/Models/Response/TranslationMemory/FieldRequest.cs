using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class FieldRequest
    {
        /// <summary>
        /// Gets or sets field id
        /// </summary>
        public string FieldId { get; set; }
        /// <summary>
        /// Gets or sets type
        /// </summary>
        public TypeEnum Type { get; set; }

        /// <summary>
        /// Gets or sets name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a list of values
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
