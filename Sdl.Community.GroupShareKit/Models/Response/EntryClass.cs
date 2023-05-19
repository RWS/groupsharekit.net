namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class EntryClass
    {
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets if is default entry
        /// </summary>
        public bool IsDefault { get; set; }
        /// <summary>
        /// Gets or sets write permission
        /// </summary>
        public bool CanWrite { get; set; }
        /// <summary>
        /// Gets or sets read permission
        /// </summary>
        public bool CanRead { get; set; }
        /// <summary>
        /// Gets or sets it
        /// </summary>
        public string Id { get; set; }
    }
}
