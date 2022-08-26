namespace Sdl.Community.GroupShareKit.Models.Response.Logs
{
    public class PagedLogEntriesWithTotalCount
    {
        public int Count { get; set; }
        public LogEntry[] Items { get; set; }
    }
}
