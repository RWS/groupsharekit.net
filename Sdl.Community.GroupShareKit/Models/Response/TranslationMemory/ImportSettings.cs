using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

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
        /// Gets or sets if TM from user id should be used
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
        /// Gets or sets if matching sublanguages should be checked
        /// </summary>
        public bool? CheckMatchingSublanguages { get; set; }

        /// <summary>
        /// Gets or sets a list of confirmation levels
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
        public Settings.ProcessingMode? TuProcessingMode { get; set; }

        /// <summary>
        /// Gets or sets field values
        /// </summary>
        public List<FieldValue> FieldValues { get; set; }

        public enum ProcessingMode
        {
            ProcessRawTUOnly,
            ProcessCleanedTUOnly,
            ProcessBothTUs
        }

        public enum FieldsBehaviour
        {
            AddToSetup,
            Ignore,
            SkipTranslationUnit,
            Error
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
