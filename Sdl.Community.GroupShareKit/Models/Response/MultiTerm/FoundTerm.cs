namespace Sdl.Community.GroupShareKit.Models.Response.MultiTerm
{
    public class FoundTerm
    {
        public int ConceptId { get; set; }

        public string Term { get; set; }

        public int Score { get; set; }

        public int OffsetStart { get; set; }

        public int OffsetLength { get; set; }
    }
}
