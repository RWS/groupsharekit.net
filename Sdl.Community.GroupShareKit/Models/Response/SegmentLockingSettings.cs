using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class SegmentLockingSettings
    {
        [JsonProperty("useAndCondition")]
        public bool? UseAndCondition { get; set; }

        [JsonProperty("targetLanguage")]
        public string TargetLanguage { get; set; }

        [JsonProperty("translationStatuses")]
        public IList<string> TranslationStatuses { get; set; }

        [JsonProperty("translationOrigins")]
        public IList<string> TranslationOrigins { get; set; }

        [JsonProperty("score")]
        public int? Score { get; set; }

        [JsonProperty("mtqe")]
        public IList<string> MTQE { get; set; }

        public SegmentLockingSettings() { }

        public SegmentLockingSettings(bool useAndCondition, string targetLanguage, IList<string> translationStatuses, IList<string> translationOrigins, int score, IList<string> mtqe) 
        {
            UseAndCondition = useAndCondition;
            TargetLanguage = targetLanguage;
            TranslationStatuses = translationStatuses;
            TranslationOrigins = translationOrigins;
            Score = score;
            MTQE = mtqe;
        }
    }
}
