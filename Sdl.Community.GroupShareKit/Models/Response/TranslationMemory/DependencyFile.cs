namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class DependencyFile
    {
        /// <summary>
        /// Gets or sets the id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets the usage
        /// </summary>
        public string Usage { get; set; }
        /// <summary>
        /// Gets or sets the location
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// Gets or sets file name
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Gets or sets metadata
        /// </summary>
        public Metadata Metadata { get; set; }
    }
}
