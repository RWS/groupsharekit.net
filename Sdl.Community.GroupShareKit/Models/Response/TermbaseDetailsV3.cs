using System;
using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class TermbaseDetailsV3
    {
        public string Name { get; set; }

        public int Entries { get; set; }

        public List<TermbaseLanguage> Languages { get; set; }

        public string ServerUrl { get; set; }

        public bool IsLocal { get; set; }

        public bool IsFileBased { get; set; }

        public bool HasNoLanguageMapping { get; set; }

        public bool IsDeleted { get; set; }

        public Guid TermbaseId { get; set; }
    }
}
