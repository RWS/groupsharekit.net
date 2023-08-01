namespace Sdl.Community.GroupShareKit.Clients
{
    public class PredefinedReportsFiltersV2 : PredefinedReportsFilters
    {
        public string OrderBy { get; set; }
        public string SortDirection { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }
}
