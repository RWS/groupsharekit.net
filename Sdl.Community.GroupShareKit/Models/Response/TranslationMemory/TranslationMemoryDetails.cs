using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class TranslationMemoryDetails
    {
        /// <summary>
        /// Gets or sets translation memory id
        /// </summary>
        public string TranslationMemoryId { get; set; }
        /// <summary>
        /// Gets or sets tm name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets container id
        /// </summary>
        public string ContainerId { get; set; }

        /// <summary>
        /// Gets or sets language directions
        /// </summary>
        public List<LanguageDirection> LanguageDirections { get; set; }

        /// <summary>
        /// Gets or sets container informations
        /// </summary>
        public Container Container { get; set; }
        /// <summary>
        /// Gets or sets field template id
        /// </summary>
        public string FieldTemplateId { get; set; }
        /// <summary>
        /// Gets or sets language resource template id
        /// </summary>
        public string LanguageResourceTemplateId { get; set; }
        /// <summary>
        /// Gets or sets field temlate informations
        /// </summary>
        public FieldTemplate FieldTemplate { get; set; }

        /// <summary>
        /// Gets or sets recognizers
        /// </summary>
        public string Recognizers { get; set; }
        /// <summary>
        /// Gets or sets fuzzy indexes
        /// </summary>
        public string FuzzyIndexes { get; set; }
        /// <summary>
        /// Gets or sets created date
        /// </summary>
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Gets or sets copyright
        /// </summary>
        public string Copyright { get; set; }
        /// <summary>
        /// Gets or sets location
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// Gets or sets a list of background task
        /// </summary>
        public List<BackgroundTask> BackgroundTasks { get; set; }
        /// <summary>
        /// Gets or sets tokenizer flags
        /// </summary>
        public string TokenizerFlags { get; set; }
        /// <summary>
        /// Gets or sets  word count flags
        /// </summary>
        public string WordCountFlags    { get; set; }
        /// <summary>
        /// Gets or sets if it should recompute statistics
        /// </summary>
        public bool ShouldRecomputeStatistics { get; set; }
        /// <summary>
        /// Gets or sets last recomputed date
        /// </summary>
        public DateTime? LastRecomputedDate { get; set; }
        /// <summary>
        /// Gets or sets last recomputed number
        /// </summary>
        public int? LastRecomputedSize { get; set; }
        /// <summary>
        /// Gets or sets last reindex date
        /// </summary>
        public DateTime? LastReIndexDate { get; set; }
        /// <summary>
        /// Gets or sets last reindex size
        /// </summary>
        public int? LastReIndexSize { get; set; }
        /// <summary>
        /// Gets or sets fuzzy index settings
        /// </summary>
        public FuzzyIndexTuningSettings FuzzyIndexTuningSettings { get; set; }
        /// <summary>
        /// Gets or sets a list of metadata
        /// </summary>
      //  public List<Metadata> Metadata { get; set; }
        /// <summary>
        /// Gets or sets owner id
        /// </summary>
        public string OwnerId { get; set; }
    }
}
