using Sdl.Community.GroupShareKit.Models.Response.TranslationMemory;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class LanguageResourceServiceDefaultsRequest
    {
        public string Language { get; set; }
        public LanguageResourceType Type { get; set; }

        public LanguageResourceServiceDefaultsRequest(LanguageResourceType type, string language)
        {
            Type = type;
            Language = language;
        }
    }
}
