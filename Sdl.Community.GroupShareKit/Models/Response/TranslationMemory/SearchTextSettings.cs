using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class SearchTextSettings
    {
        public int MinScore { get; set; }
        public int MaxResults { get; set; }
        public List<ConcordanceSearchFilter> Filters { get; set; }
        public List<Penalty> Penalties { get; set; }
    }
}
