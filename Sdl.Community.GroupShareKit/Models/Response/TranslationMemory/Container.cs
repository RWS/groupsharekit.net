using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class Container
    {
        /// <summary>
        /// Gets or sets container id
        /// </summary>
        public string ContainerId { get; set; }
        /// <summary>
        /// Gets or sets database server id
        /// </summary>
        public string DatabaseServerId { get; set; }
        /// <summary>
        /// Gets or sets database server
        /// </summary>
        public DatabaseServer DatabaseServer { get; set; }
        /// <summary>
        /// Gets or sets display name
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// Gets or sets database name
        /// </summary>
        public string DatabaseName { get; set; }
        /// <summary>
        /// Gets or sets if is shared
        /// </summary>
        public bool IsShared { get; set; }
        /// <summary>
        /// Gets or sets a translation memory list
        /// </summary>
        public List<TranslationMemoryDetails> TranslationMemories { get; set; }

        /// <summary>
        /// Gets or sets the container location
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// Gets or sets the owner id
        /// </summary>
        public string OwnerId { get; set; }



    }


}
