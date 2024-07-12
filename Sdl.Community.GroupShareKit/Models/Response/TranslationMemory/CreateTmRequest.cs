using System;
using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    [Obsolete("CreateTmRequest is deprecated, please use CreateTranslationMemoryRequest instead.")]
    public class CreateTmRequest
    {
        public string TranslationMemoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContainerId { get; set; }
        public List<LanguageDirection> LanguageDirections { get; set; }
        public string FieldTemplateId { get; set; }
        public string LanguageResourceTemplateId { get; set; }
        public string Copyright { get; set; }
        public string FuzzyIndexes { get; set; }
        public string Recognizers { get; set; }
        public string WordCountFlags { get; set; }
        public string OwnerId { get; set; }
        public string Location { get; set; }
        public FuzzyIndexTuningSettings FuzzyIndexTuningSettings { get; set; }
    }
}
