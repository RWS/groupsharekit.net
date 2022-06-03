using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class BackgroundTaskDetails
    {
        /// <summary>
        /// Gets or sets the key
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// Gets or sets  status
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Gets or sets the details
        /// </summary>
        public List<string> Details { get; set; }
        /// <summary>
        /// Gets or sets the statistics
        /// </summary>
        public Statistics Statistics { get; set; }
    }
}
