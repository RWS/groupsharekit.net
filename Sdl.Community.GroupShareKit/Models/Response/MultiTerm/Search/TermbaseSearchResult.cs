using Sdl.Community.GroupShareKit.Models.Response.MultiTerm.Browse;

namespace Sdl.Community.GroupShareKit.Models.Response.MultiTerm.Search
{
    public class TermbaseSearchResult : TermbaseBrowseResult
    {
        public string LastTerm { get; set; }

        public int LastConceptId { get; set; }
    }
}
