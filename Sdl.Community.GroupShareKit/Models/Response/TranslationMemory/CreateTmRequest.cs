using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
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
