using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class ProjectTemplateSettingsV4/* : ProjectTemplateSettings*/
    {
        [JsonProperty(PropertyName = "sourceLanguageCode", Required = Required.Always)]
        public string SourceLanguageCode { get; set; }

        [JsonProperty(PropertyName = "targetLanguageCodes", Required = Required.Always)]
        public IList<string> TargetLanguageCodes { get; set; }

        [JsonProperty(PropertyName = "translationMemories")]
        public IList<TranslationMemoryDetailsV3> TranslationMemories { get; set; }

        [JsonProperty(PropertyName = "termbases")]
        public IList<TermbaseDetailsV3> Termbases { get; set; }

        [JsonProperty(PropertyName = "targetLanguageSettingsBundles")]
        public IList<TargetLanguageSettings> TargetLanguageSettingsBundles { get; set; }

        [JsonProperty(PropertyName = "subTaskTemplates")]
        public IList<TemplateBatchTask> SubTaskTemplates { get; set; }

        [JsonProperty("segmentLockingSettings")]
        public IList<SegmentLockingSettings> SegmentLockingSettings { get; set; }

        [JsonProperty(PropertyName = "enableSegmentLockTask")]
        public bool? EnableSegmentLockTask { get; set; } = false;
    }
}
