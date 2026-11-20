using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class TranslateTaskSettings
    {
        [JsonProperty("targetLanguage")]
        public string TargetLanguage { get; set; }

        [JsonProperty("minimumMatchScore", NullValueHandling = NullValueHandling.Ignore)]
        public int? MinimumMatchScore { get; set; }

        [JsonProperty("translationOverwriteMode", NullValueHandling = NullValueHandling.Ignore)]
        public TranslationUpdateMode? TranslationOverwriteMode { get; set; }

        [JsonProperty("overwritePerfectMatch", NullValueHandling = NullValueHandling.Ignore)]
        public bool? OverwritePerfectMatch { get; set; }

        [JsonProperty("lockContextMatchSegments", NullValueHandling = NullValueHandling.Ignore)]
        public bool? LockContextMatchSegments { get; set; }

        [JsonProperty("lockExactMatchSegments", NullValueHandling = NullValueHandling.Ignore)]
        public bool? LockExactMatchSegments { get; set; }

        [JsonProperty("confirmAfterApplyingExactMatch", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ConfirmAfterApplyingExactMatch { get; set; }

        [JsonProperty("confirmAfterApplyingInContextExactMatch", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ConfirmAfterApplyingInContextExactMatch { get; set; }

        [JsonProperty("noTranslationMemoryMatchFoundAction", NullValueHandling = NullValueHandling.Ignore)]
        public NoTranslationMemoryMatchFoundAction? NoTranslationMemoryMatchFoundAction { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum TranslationUpdateMode
    {
        /// <summary>
        /// Keep existing bilingual segments (don't overwrite existing translations)
        /// </summary>
        KeepExistingTranslation,

        /// <summary>
        /// Overwrite existing translations if the current TM yields a better match than the one recorded in the input
        /// </summary>
        OverwriteExistingTranslationIfBetterMatch,

        /// <summary>
        /// Always overwrite existing translations
        /// </summary>
        OverwriteExistingTranslation,
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum NoTranslationMemoryMatchFoundAction
    {
        CopySourceToTarget,

        ApplyAutomatedTranslation,

        LeaveEmpty,
    }

}
