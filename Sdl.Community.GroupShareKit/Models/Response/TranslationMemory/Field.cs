using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class Field
    {
        /// <summary>
        /// Gets or sets field id
        /// </summary>
        public string FieldId { get; set; }
        /// <summary>
        /// Gets or sets field templat eid
        /// </summary>
        public string FieldTemplateId { get; set; }
        /// <summary>
        /// Gets or sets name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets type
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Gets or sets a list of values
        /// </summary>
        public List<Value> Values { get; set; }
    }
}
