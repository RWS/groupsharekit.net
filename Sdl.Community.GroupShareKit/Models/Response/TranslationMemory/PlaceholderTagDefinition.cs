using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class PlaceholderTagDefinition
    {
        /// <summary>
        /// Gets or sets the id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets display text
        /// </summary>
        public string DisplayText { get; set; }
        /// <summary>
        /// Gets or sets tag content
        /// </summary>
        public string TagContent { get; set; }
        /// <summary>
        /// Gets or sets text equivalent
        /// </summary>
        public string TextEquivalent { get; set; }
        /// <summary>
        /// Gets or sets segmentation hint
        /// </summary>
        public string SegmentationHint { get; set; }
        /// <summary>
        /// Gets or sets subcontent
        /// </summary>
        public List<SubContent> SubContent { get; set; }
        /// <summary>
        /// Gets or sets metadata
        /// </summary>
        public Metadata Metadata { get; set; }
    }
}
