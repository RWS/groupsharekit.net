using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sdl.Community.GroupShareKit.Models.Response.MultiTerm.Concepts
{
    public class ConceptV2
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Id { get; set; }

        public EntryClassBase EntryClass { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<Field> Attributes { get; set; }

        public IEnumerable<IndexLanguage> Languages { get; set; }

        public IEnumerable<Transaction> Transactions { get; set; }

        public class EntryClassBase
        {
            public int Id { get; set; }
        }

        public class IndexLanguage
        {
            public LanguageDescription Language { get; set; }

            public IEnumerable<Term> Terms { get; set; }

            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public IEnumerable<Field> Attributes { get; set; }

            public bool? Delete { get; set; }
        }

        public class LanguageDescription
        {
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public string Code { get; set; }

            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public string Name { get; set; }

            public string Id { get; set; }
        }

        public class Term
        {
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public IEnumerable<Field> Attributes { get; set; }

            public string Text { get; set; }

            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public string Id { get; set; }

            public bool? Delete { get; set; }

            public IEnumerable<Transaction> Transactions { get; set; }
        }

        public class Field
        {
            public string Id { get; set; }

            public string Name { get; set; }

            public string Delete { get; set; }

            public IEnumerable<Field> Attributes { get; set; }
        }

    }
}
