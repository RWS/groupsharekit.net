using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class Project
    {
        /// <summary>
        /// Gets or sets the projects number
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// Gets or sets the projects list <see cref="ProjectDetails"/>
        /// </summary>
        public List<ProjectDetails> Items { get; set; }
    }
}
