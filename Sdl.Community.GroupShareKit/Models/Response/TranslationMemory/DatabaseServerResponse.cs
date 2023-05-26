using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class DatabaseServerResponse
    {
        /// <summary>
        /// Gets or sets a list of detabase server details
        /// </summary>
        public List<DatabaseServer> Items { get; set; }
        /// <summary>
        /// Gets or sets the number of database servers
        /// </summary>
        public int Count { get; set; }
    }
}
