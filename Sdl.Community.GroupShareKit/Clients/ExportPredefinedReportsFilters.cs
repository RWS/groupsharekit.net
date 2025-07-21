using Sdl.Community.GroupShareKit.Models;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class ExportPredefinedReportsFilters : PredefinedReportsFilters
    {
        public ReportLanguage Language { get; set; }
        public string TimeZone { get; set; }
    }
}
