using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class ProjectSettingsV2
    {
        [JsonProperty("generalSettings")]
        public GeneralSettings GeneralSettings { get; set; }

        [JsonProperty("perfectMatch")]
        public PerfectMatch PerfectMatch { get; set; }

        [JsonProperty("translationMemories")]
        public List<TranslationMemoryReference> TranslationMemories { get; set; }

        [JsonProperty("termbases")]
        public List<Termbase> Termbases { get; set; }

        [JsonProperty("terminology")]
        public Terminology Terminology { get; set; }
    }
}
