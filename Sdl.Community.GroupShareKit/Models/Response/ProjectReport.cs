using System;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    [Flags]
    public enum ProjectStatus
    {
        Pending = 1,
        Started = 2,
        Completed = 4,
        Archived = 8,
        Detached = 16
    }

    public class ProjectReport
    {
        public string ProjectName { get; set; }

        public DateTime? PublishedAt { get; set; }

        public DateTime? DeliveryBy { get; set; }

        public int? Words { get; set; }

        public int PreTranslatedWords { get; set; }

        public int Overdues { get; set; }

        public string SourceLanguage { get; set; }

        public string TargetLanguage { get; set; }

        public ProjectStatus Status { get; set; }

        public string Location { get; set; }

        public bool IsSecure { get; set; }

        public string ProjectTemplate { get; set; }

        public int ProjectProgress { get; set; }

        public int NumberOfFiles { get; set; }

        public int NumberOfPerfectMatchProjects { get; set; }

        public int NumberOfTranslationMemories { get; set; }

        public int NumberOfTermbases { get; set; }

        public string TranslationProviders { get; set; }

        public Guid ProjectId { get; set; }
    }
}
