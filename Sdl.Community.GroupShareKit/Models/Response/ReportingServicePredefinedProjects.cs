using System;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class ReportingServicePredefinedProjects
    {
        public string ProjectName { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? PublishAt { get; set; }

        public DateTime? DeliveryBy { get; set; }

        public int Words { get; set; }

        public int PretranslatedWords { get; set; }

        public int Overdues { get; set; }

        public string SourceLanguage { get; set; }

        public string TargetLanguages { get; set; }
  
        public int Status { get; set; }

        public string Location { get; set; }

        public bool IsSecure { get; set; }

        public string Template { get; set; }

        public int ProjectProgress { get; set; }

        public int NumberOfFiles { get; set; }

        public int PerfectMatchProjects { get; set; }

        public int NumberOfTMs { get; set; }

        public int NumberOfTbs { get; set; }

        public string TranslationProviders { get; set; }

        public Guid ProjectGuid { get; set; }

        public string AssignedUsers { get; set; }

        public bool IsImplicit { get; set; }
    }
}
