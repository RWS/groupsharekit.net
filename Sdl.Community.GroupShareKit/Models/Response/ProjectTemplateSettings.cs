using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class ProjectTemplateSettings
    {
        public string SourceLanguageCode { get; set; }
        public IList<string> TargetLanguages { get; set; }
        public IList<TranslationMemoryDetailsV3> TranslationMemories { get; set; }

        public IList<TermbaseDetailsV3> Termbases { get; set; }
    }
}
