using System;
using System.Collections.Generic;
using Sdl.Community.GroupShareKit.Models.Response.TranslationMemory;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    [Obsolete("ProjectSettings is deprecated, please use LanguageFileSettings instead.")]
    public class ProjectSettings
    {
	    public MatchSettings Translation { get; set; }
	    public List<TmSettings> TranslationMemories { get; set; }
	    public List<TermbaseInformations> Termbases { get; set; }
	    public MatchSettings Terminology { get; set; }
    }
}
