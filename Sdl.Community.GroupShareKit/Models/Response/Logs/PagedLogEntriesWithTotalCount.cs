using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response.Logs
{
    public class PagedLogEntriesWithTotalCount
    {
        public int Count { get; set; }
        public LogEntry[] Items { get; set; }
    }
}
