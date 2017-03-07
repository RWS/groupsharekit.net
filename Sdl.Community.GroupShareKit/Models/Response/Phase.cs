using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class Phase
    {
        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the order number
        /// </summary>
        public int Order { get; set; }
        /// <summary>
        /// Gets or sets the project phase id
        /// </summary>
        public int ProjectPhaseId { get; set; }
        /// <summary>
        /// Gets or sets a list of assignees
        /// </summary>
        public List<string> Assignees { get; set; }
    }
}