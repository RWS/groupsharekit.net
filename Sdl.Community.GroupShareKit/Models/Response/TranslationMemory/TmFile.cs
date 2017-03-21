using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class TmFile
    {
        /// <summary>
        /// Gets or sets the id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets original encoding
        /// </summary>
        public string OriginalEncoding { get; set; }
        /// <summary>
        /// Gets or sets preferred target encoding
        /// </summary>
        public string PreferredTargetEncoding { get; set; }
        /// <summary>
        /// Gets or sets original file name
        /// </summary>
        public string OriginalFileName { get; set; }
        /// <summary>
        /// Gets or sets file type definition id
        /// </summary>
        public string FileTypeDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets dependency files
        /// </summary>
        public List<DependencyFile> DependencyFiles { get; set; }
        /// <summary>
        /// Gets or sets comment definition id
        /// </summary>
        public List<int> CommentDefinitionIds { get; set; }
        /// <summary>
        /// Gets or sets skeleton
        /// </summary>
        public Skeleton Skeleton { get; set; }
        /// <summary>
        /// Gets or sets paragraph units
        /// </summary>

        public List<ParagraphUnit> ParagraphUnits { get; set; }
        /// <summary>
        /// Gets or sets metadata
        /// </summary>
        public Metadata Metadata { get; set; }
    }
}
