using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class ProjectTemplateSettingsV4 : ProjectTemplateSettingsV3
    {
        [JsonProperty("segmentLockingSettings")]
        public IList<SegmentLockingSettings> SegmentLockingSettings { get; set; }

        [JsonProperty(PropertyName = "enableSegmentLockTask")]
        public bool? EnableSegmentLockTask { get; set; } = false;
    }
}
