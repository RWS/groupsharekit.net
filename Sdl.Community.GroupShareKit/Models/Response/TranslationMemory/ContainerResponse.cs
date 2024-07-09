using System;
using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    [Obsolete("ContainerResponse is deprecated, please use Containers instead.")]
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
