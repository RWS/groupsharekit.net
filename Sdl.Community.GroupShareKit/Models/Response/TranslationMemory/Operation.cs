using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class Operation
    {
        /// <summary>
        /// Gets or sets the path
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// Gets or sets operation
        /// </summary>
        public string Op { get; set; }
        /// <summary>
        /// Gets or sets from
        /// </summary>
        public string From { get; set; }

        public List<Values> Value { get; set; }
    }

    public class Values
    {
        public string CultureName { get; set; }
        public string Type { get; set; }
        public List<string> Items { get; set; }
    }
}
