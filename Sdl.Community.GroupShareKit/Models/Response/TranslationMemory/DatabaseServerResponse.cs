using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
