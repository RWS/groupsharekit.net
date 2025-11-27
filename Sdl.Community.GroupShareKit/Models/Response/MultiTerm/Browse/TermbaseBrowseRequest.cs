using System.ComponentModel.DataAnnotations;

namespace Sdl.Community.GroupShareKit.Models.Response.MultiTerm.Browse
{
    public class TermbaseBrowseRequest
    {
        [Required(ErrorMessage = "Direction is required.")]
        public Direction SortDirection { get; set; }

        [Required(ErrorMessage = "Source index is required.")]
        public string SourceIndex { get; set; }

        [Required(ErrorMessage = "Target index is required.")]
        public string TargetIndex { get; set; }

        public int? FilterId { get; set; }

        public int? LastConceptId { get; set; }

        public string LastTerm { get; set; }

        public int? PageSize { get; set; }
    }

    public enum Direction
    {
        Asc,
        Desc
    }
}
