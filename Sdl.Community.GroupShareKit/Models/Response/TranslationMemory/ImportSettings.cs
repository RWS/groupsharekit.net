using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class ImportSettings
    {
        /// <summary>
        /// Gets or sets the filter
        /// </summary>
        public FilterDuplicates Filter { get; set; }
        /// <summary>
        /// Gets or sets if segment should be imported as a plain text
        /// </summary>
        public bool? ImportAsPlainText { get; set; }
        /// <summary>
        /// Gets or sets if tm from  user id thoud be used
        /// </summary>
        public bool? UseTmUserIdFromBilingualFile { get; set; }
        /// <summary>
        /// Gets or sets if recomputed statistics should be triggered
        /// </summary>
        public bool? TriggerRecomputeStatistics { get; set; }
        /// <summary>
        /// Gets or sets if invalid translation units should be exported
        /// </summary>
        public bool? ExportInvalidTranslationUnits { get; set; }
        /// <summary>
        /// Gets or sets id should use acronyms autosubstitution
        /// </summary>
        public bool? AcronymsAutoSubstitution { get; set; }
        /// <summary>
        /// Gets or sets  if maching sublanguages should be checked
        /// </summary>
        public bool? CheckMatchingSublanguages { get; set; }
        /// <summary>
        /// Gets or sets a list of comfirmation levels
        /// </summary>
        public List<string> ConfirmationLevels { get; set; }

        /// <summary>
        /// Gets or sets existing tus update mode
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public Settings.UpdateMode ExistingTUsUpdateMode { get; set; }

        /// <summary>
        /// Gets or sets existing fields update mode
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public Settings.ExistingFieldsMode? ExistingFieldsUpdateMode { get; set; }

        /// <summary>
        /// Gets or sets new fields behaviour
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public Settings.FieldsBehaviour? NewFieldsBehaviour { get; set; }

        /// <summary>
        /// Gets or sets tu processing mode
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public Settings.ProccesingMode? TuProcessingMode { get; set; }

        /// <summary>
        /// Gets or sets field values
        /// </summary>
        public List<FieldValue> FieldValues { get; set; }

        public enum ProccesingMode
        {
            ProcessCleanedTUOnly
        }
        public enum FieldsBehaviour
        {
            AddToSetup
        }
        public enum ExistingFieldsMode
        {
            Merge, //this is the default
            Overwrite,
            LeaveUnchanged
        }
        public enum UpdateMode
        {
            AddNew,
            Overwrite,
            LeaveUnchanged,
            KeepMostRecent,
            OverwriteCurrent

        }

    }
}
