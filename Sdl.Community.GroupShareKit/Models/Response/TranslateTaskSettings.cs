using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class TranslateTaskSettings
    {
        [JsonPropertyName("targetLanguage")]
        public string TargetLanguage { get; set; }

        [JsonPropertyName("minimumMatchScore"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? MinimumMatchScore { get; set; }

        [JsonPropertyName("translationOverwriteMode"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TranslationUpdateMode? TranslationOverwriteMode { get; set; }

        [JsonPropertyName("overwritePerfectMatch"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? OverwritePerfectMatch { get; set; }

        [JsonPropertyName("lockContextMatchSegments"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? LockContextMatchSegments { get; set; }

        [JsonPropertyName("lockExactMatchSegments"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? LockExactMatchSegments { get; set; }

        [JsonPropertyName("confirmAfterApplyingExactMatch"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ConfirmAfterApplyingExactMatch { get; set; }

        [JsonPropertyName("confirmAfterApplyingInContextExactMatch"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ConfirmAfterApplyingInContextExactMatch { get; set; }

        [JsonPropertyName("noTranslationMemoryMatchFoundAction"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
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
