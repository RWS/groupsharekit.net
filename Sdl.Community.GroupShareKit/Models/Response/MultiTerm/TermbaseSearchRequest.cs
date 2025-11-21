using System.ComponentModel.DataAnnotations;

namespace Sdl.Community.GroupShareKit.Models.Response.MultiTerm
{
    public class TermbaseSearchRequest
    {
        [Required(ErrorMessage = "Query is required.")]
        public string Query { get; set; }

        [Required(ErrorMessage = "Source index is required.")]
        public string SourceIndex { get; set; }

        public string TargetIndex { get; set; }

        public bool? TargetRequired { get; set; }

        public SearchType? SearchType { get; set; }

        public int? LastConceptId { get; set; }

        public string LastTerm { get; set; }

        public int? PageSize { get; set; }

        public int? FilterId { get; set; }
    }

    public enum SearchType
    {
        Normal,
        FullText,
        Fuzzy
    }
}
