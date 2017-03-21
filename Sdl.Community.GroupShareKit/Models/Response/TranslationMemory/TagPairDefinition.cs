using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class TagPairDefinition
    {
        /// <summary>
        /// Gets or sets the is
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets start tag display text
        /// </summary>
        public string StartTagDisplayText { get; set; }
        /// <summary>
        /// Gets or sets start tag content
        /// </summary>
        public string StartTagContent { get; set; }
        /// <summary>
        /// Gets or sets end tag display text
        /// </summary>
        public string EndTagDisplayText { get; set; }
        /// <summary>
        /// Gets or sets end tag content
        /// </summary>
        public string EndTagContent { get; set; }
        /// <summary>
        /// Gets or sets if has the ability to hide
        /// </summary>
        public bool CanHide { get; set; }
        /// <summary>
        /// Gets or sets segmentation hint
        /// </summary>
        public string SegmentationHint { get; set; }
        /// <summary>
        /// Gets or sets formatting group id
        /// </summary>
        public int FormattingGroupId { get; set; }
        /// <summary>
        /// Gets or sets a list of subcontent
        /// </summary>
        public List<SubContent> SubContent   { get; set; }
        /// <summary>
        /// Gets or sets metadata
        /// </summary>
        public Metadata Metadata { get; set; }
    }
}
