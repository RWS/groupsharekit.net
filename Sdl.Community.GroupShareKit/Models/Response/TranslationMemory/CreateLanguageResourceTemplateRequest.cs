using System;
using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class CreateLanguageResourceTemplateRequest
    {
        public bool IsTmSpecific { get; set; }

        public Guid OwnerId { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public List<LanguageResource> LanguageResources { get; set; }

        public string Recognizers { get; set; }

        public string TokenizerFlags { get; set; }

        public string WordCountFlags { get; set; }
    }
}
