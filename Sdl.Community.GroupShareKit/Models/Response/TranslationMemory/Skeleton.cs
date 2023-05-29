using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class Skeleton
    {
        /// <summary>
        /// Gets or sets file id
        /// </summary>
        public string FileId { get; set; }
        /// <summary>
        /// Gets or sets a list of comment definitions
        /// </summary>
        public List<CommentDefinition> CommentDefinitions { get; set; }
        /// <summary>
        /// Gets or sets a list of context definitions
        /// </summary>
        public List<ContextDefinition> ContextDefinitions { get; set; }
        /// <summary>
        /// Gets or sets a list of contexts
        /// </summary>
        public List<Context> Contexts { get; set; }
        /// <summary>
        /// Gets or sets a list of formatting groups
        /// </summary>
        public List<FormattingGroup> FormattingGroups { get; set; }
        /// <summary>
        /// Gets or sets a list of structure tag definitions
        /// </summary>
        public List<StructureTagDefinition> StructureTagDefinitions { get; set; }
        /// <summary>
        /// Gets or sets a list of tag pair definitions
        /// </summary>
        public List<TagPairDefinition> TagPairDefinitions { get; set; }
        /// <summary>
        /// Gets or sets a list of placeholder tag definitions
        /// </summary>
        public List<PlaceholderTagDefinition> PlaceholderTagDefinitions { get; set; }
        /// <summary>
        /// Gets or sets a list of terminology data
        /// </summary>
        public List<TerminologyData> TerminologyData { get; set; }
        /// <summary>
        /// Gets or sets metadata
        /// </summary>
        public Metadata Metadata { get; set; }
    }
}
