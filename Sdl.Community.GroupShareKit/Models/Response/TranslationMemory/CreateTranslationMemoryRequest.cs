using System;
using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class CreateTranslationMemoryRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string FuzzyIndexes { get; set; }

        public string Recognizers { get; set; }

        public string WordCountFlags { get; set; }

        public string Copyright { get; set; }

        public Guid OwnerId { get; set; }

        public int UnalignedCount { get; set; }

        public List<LanguageDirection> LanguageDirections { get; set; }

        public FuzzyIndexTuningSettings FuzzyIndexTuningSettings { get; set; }

        public Guid FieldTemplateId { get; set; }

        public Guid LanguageResourceTemplateId { get; set; }

        public Guid? ContainerId { get; set; }
    }
}
