using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class ProjectTemplateSettingsV3 : ProjectTemplateSettings
    {
        public IList<TargetLanguageSettings> TargetLanguageSettingsBundles { get; set; }

        public IList<TemplateBatchTask> SubTaskTemplates { get; set; }
    }
}
