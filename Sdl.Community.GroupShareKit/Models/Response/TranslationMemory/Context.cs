namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class Context
    {
        /// <summary>
        /// Gets or sets the id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets context definition id
        /// </summary>
        public int ContextDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets parent context id
        /// </summary>
        public int ParentContextId { get; set; }
        /// <summary>
        /// Gets or sets metadata
        /// </summary>
        public Metadata Metadata { get; set; }
    }
}
