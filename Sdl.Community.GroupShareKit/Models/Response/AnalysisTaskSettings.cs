using Newtonsoft.Json;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class AnalysisTaskSettings
    {
        [JsonProperty("targetLanguage")]
        public string TargetLanguage { get; set; }

        [JsonProperty("reportCrossFileRepetitions", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ReportCrossFileRepetitions { get; set; }

        [JsonProperty("reportInternalFuzzyMatchLeverage", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ReportInternalFuzzyMatchLeverage { get; set; }

        [JsonProperty("reportLockedSegmentsSeparately", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ReportLockedSegmentsSeparately { get; set; }

        [JsonProperty("excludeLockedSegments", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ExcludeLockedSegments { get; set; }

        [JsonProperty("presentIndividualFileDetails", NullValueHandling = NullValueHandling.Ignore)]
        public bool? PresentIndividualFileDetails { get; set; }

        [JsonProperty("exportUnknownSegments", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ExportUnknownSegments { get; set; }

        [JsonProperty("unknownSegmentsMaximumMatchValue", NullValueHandling = NullValueHandling.Ignore)]
        public int? UnknownSegmentsMaximumMatchValue { get; set; }

        [JsonProperty("exportFrequentSegments", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ExportFrequentSegments { get; set; }

        [JsonProperty("frequentSegmentsNoOfOccurrences", NullValueHandling = NullValueHandling.Ignore)]
        public int? FrequentSegmentsNoOfOccurrences { get; set; }
    }

}
