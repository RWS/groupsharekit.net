using System.Text.Json.Serialization;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class AnalysisTaskSettings
    {
        [JsonPropertyName("targetLanguage")]
        public string TargetLanguage { get; set; }

        [JsonPropertyName("reportCrossFileRepetitions"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ReportCrossFileRepetitions { get; set; }

        [JsonPropertyName("reportInternalFuzzyMatchLeverage"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ReportInternalFuzzyMatchLeverage { get; set; }

        [JsonPropertyName("reportLockedSegmentsSeparately"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ReportLockedSegmentsSeparately { get; set; }

        [JsonPropertyName("excludeLockedSegments"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ExcludeLockedSegments { get; set; }

        [JsonPropertyName("presentIndividualFileDetails"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? PresentIndividualFileDetails { get; set; }

        [JsonPropertyName("exportUnknownSegments"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ExportUnknownSegments { get; set; }

        [JsonPropertyName("unknownSegmentsMaximumMatchValue"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? UnknownSegmentsMaximumMatchValue { get; set; }

        [JsonPropertyName("exportFrequentSegments"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ExportFrequentSegments { get; set; }

        [JsonPropertyName("frequentSegmentsNoOfOccurrences"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? FrequentSegmentsNoOfOccurrences { get; set; }
    }

}
