using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class ParagraphUnit
    {
        /// <summary>
        /// Gets or sets the id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets parent file id
        /// </summary>
        public string ParentFileId { get; set; }
        /// <summary>
        /// Gets or sets if is structure
        /// </summary>
        public bool IsStructure { get; set; }
        /// <summary>
        /// Gets or sets if is locked
        /// </summary>
        public bool IsLocked { get; set; }
        /// <summary>
        /// Gets or sets structure context id
        /// </summary>
        public int StructureContextId { get; set; }
        /// <summary>
        /// Gets or sets  list of context list
        /// </summary>
        public List<int> ContextList { get; set; }
        /// <summary>
        /// Gets or sets index
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// Gets or sets source language details
        /// </summary>
        public ParagraphUnitLanguageDetails Source { get; set; }
        /// <summary>
        /// Gets or sets target language details
        /// </summary>
        public ParagraphUnitLanguageDetails Target { get; set; }
        /// <summary>
        /// Gets or sets comment definition ids
        /// </summary>
        public List<int> CommentDefinitionIds { get; set; }
        /// <summary>
        /// Gets or sets metadata
        /// </summary>
        public Metadata Metadata { get; set; }
    }
}
