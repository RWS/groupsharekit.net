using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response.MultiTerm
{
    public class TermbaseV2 : TermbaseListModelV2
    {
        public string CreationDate { get; set; }

        public string Copyright { get; set; }

        public int NumberOfConcepts { get; set; }

        public IEnumerable<CatalogObject> Filters { get; set; }

        public IEnumerable<LanguageModelV2> Languages { get; set; }

        public IEnumerable<TermbaseFieldModel> Attributes { get; set; }

        public IEnumerable<EntryClassModel> EntryClasses { get; set; }

        public IEnumerable<CatalogObject> Layouts { get; set; }

        public IEnumerable<CatalogObject> InputModels { get; set; }

        public IEnumerable<CatalogObject> ExportDefinitions { get; set; }

        public IEnumerable<CatalogObject> ImportDefinitions { get; set; }
    }

    public class LanguageModelV2
    {
        public string Code { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public bool TargetOnly { get; set; }

        public bool Bidi { get; set; }

        public bool CanRead { get; set; }

        public bool CanWrite { get; set; }

        public bool CanRemove { get; set; }

        public int? TermCount { get; set; }

        public int? EntryCount { get; set; }
    }
}
