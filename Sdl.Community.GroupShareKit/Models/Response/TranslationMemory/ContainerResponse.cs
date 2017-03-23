using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class ContainerResponse
    {
        /// <summary>
        /// Gets or sets a list of containers
        /// </summary>
        public List<Container> Items { get; set; }
        /// <summary>
        /// Gets or sets container numbers
        /// </summary>
        public int? Count { get; set; }
    }
}
