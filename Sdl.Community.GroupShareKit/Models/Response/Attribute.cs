using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class Atribute
    {
        /// <summary>
        /// Gets or sets if allows multiple values
        /// </summary>
        public bool AllowMultipleValues { get; set; }
        /// <summary>
        /// Gets or sets pick list values
        /// </summary>
        public List<string> PickListValues { get; set; }
        /// <summary>
        /// Gets or sets the level
        /// </summary>
        public string Level { get; set; }
        /// <summary>
        /// Gets or sets data type
        /// </summary>
        public string DataType { get; set; }
        /// <summary>
        /// Gets or sets name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets the type
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Gets or sets mandatory
        /// </summary>
        public bool Mandatory { get; set; }
        /// <summary>
        /// Gets or sets id allows custom values
        /// </summary>
        public bool AllowCustomValues { get; set; }
    }
}
