using System;
using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class TranslationMemoryDetailsV3
    {
        public string Name { get; set; }

        public Guid TranslationMemoryId { get; set; }

        public string Uri { get; set; }

        public List<TranslationMemoryLanguageDetails> PairList { get; set; }

        public List<string> Scope { get; set; }

        public bool IsForAllLanguagePairs { get; set; }

        public string ParentUri { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsLocal { get; set; }

        public bool OverrideParent { get; set; }
    }
}
