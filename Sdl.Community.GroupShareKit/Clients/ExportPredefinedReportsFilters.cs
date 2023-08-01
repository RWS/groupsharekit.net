using System.ComponentModel;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class ExportPredefinedReportsFilters : PredefinedReportsFilters
    {
        public ReportLanguage Language { get; set; }
        public string TimeZone { get; set; }
    }

    public enum ReportLanguage
    {
        [Description("English")]
        En,
        [Description("German")]
        De,
        [Description("Spanish")]
        Es,
        [Description("French")]
        Fr,
        [Description("Japanese")]
        Ja,
        [Description("Italian")]
        It,
        [Description("Korean")]
        Ko,
        [Description("Russian")]
        Ru,
        [Description("Chinese")]
        Zh
    }
}
