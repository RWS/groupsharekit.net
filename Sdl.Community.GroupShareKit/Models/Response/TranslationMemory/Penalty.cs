using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class Penalty
    {
        public int Malus { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public PenaltyTypeEnum PenaltyType { get; set; }

        public enum PenaltyTypeEnum
        {
            Unknown,
            TargetSegmentMismatch,
            FilterPenalty,
            ProviderPenalty,
            MemoryTagsDeleted,
            TagMismatch,
            MultipleTranslations,
            AutoLocalization,
            TextReplacement,
            Alignment
        }

    }
}
