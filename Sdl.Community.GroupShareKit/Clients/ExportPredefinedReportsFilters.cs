namespace Sdl.Community.GroupShareKit.Clients
{
    public class ExportPredefinedReportsFilters : PredefinedReportsFilters
    {
        public ReportLanguage Language { get; set; }
        public string TimeZone { get; set; }
    }

    public enum ReportLanguage
    {
        En,
        De,
        Es,
        Fr,
        Ja,
        It,
        Ko,
        Ru,
        Zh
    }
}
