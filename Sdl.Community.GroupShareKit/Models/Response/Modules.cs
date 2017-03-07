using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class Modules
    {
        /// <summary>
        /// Gets of sets if is a project server
        /// </summary>
        public bool ProjectServer { get; set; }
        /// <summary>
        /// Gets of sets if is a translation memory server
        /// </summary>
        public bool TranslationMemoryServer { get; set; }
        /// <summary>
        /// Gets of sets if is a multi term server
        /// </summary>
        public bool MultiTermServer { get; set; }
        /// <summary>
        /// Gets of sets if is a multi term online
        /// </summary>
        public bool MultiTermOnline { get; set; }
    }
}
