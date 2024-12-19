using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class ProjectTemplateSettingsV4 : ProjectTemplateSettingsV3
    {
        public IList<SegmentLockingSettings> SegmentLockingSettings { get; set; }

        public bool? EnableSdlXliffAnalysisReport { get; set; } = false;

        public bool? EnableSegmentLockTask { get; set; } = false;
    }
}
