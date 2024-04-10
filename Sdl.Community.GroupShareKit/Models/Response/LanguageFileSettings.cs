using Sdl.Community.GroupShareKit.Models.Response.TranslationMemory;
using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class LanguageFileSettings
    {
        public Setting Translation { get; set; }
        public IList<TmSettings> TranslationMemories { get; set; }
        public IList<TermbaseInformations> Termbases { get; set; }
        public Setting Terminology { get; set; }
    }

    public class Setting
    {
        public int MinimumMatch { get; set; }
    }
}
