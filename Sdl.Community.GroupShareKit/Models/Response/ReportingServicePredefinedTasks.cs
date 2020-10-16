using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class ReportingServicePredefinedTasks
    {
        public string OriginalName { get; set; }

        public Guid ProjectGuid { get; set; }

        public string ProjectName { get; set; }

        public string SourceLanguage { get; set; }

        public string TargetLanguage { get; set; }

        public DateTime? DueDate { get; set; }

        public string OriginalFileType { get; set; }

        public DateTime LastModified { get; set; }

        public int? UnspecifiedWords { get; set; }

        public int? DraftWords { get; set; }

        public int? TranslatedWords { get; set; }

        public int? RejectedTranslationWords { get; set; }

        public int? ApprovedTranslationWords { get; set; }

        public int? RejectedSignOffWords { get; set; }

        public int? ApprovedSignOffWords { get; set; }

        public string AllLocations { get; set; }

        public string Location { get; set; }

        public bool isLink { get; set; }

        public string ProjectPhase { get; set; }

        public int NumberOfTbs { get; set; }

        public string TranslationProviders { get; set; }

        public int AssigneesCount { get; set; }

        public bool IsCheckedOut { get; set; }

        public int PreTranslatedWords { get; set; }

        public int PerfectMatch { get; set; }

        public int Repeated { get; set; }

        public int New { get; set; }

        public int ContextMatch { get; set; }

        public int TotalWords { get; set; }

        public int HundredPercent { get; set; }

        public string ReportContent { get; set; }

        public int FuzzyFiftyPercent { get; set; }

        public int FuzzySeventyFivePercent { get; set; }

        public int FuzzyEightyFivePercent { get; set; }

        public int FuzzyNinetyFivePercent { get; set; }

        public string AssignedUsers { get; set; }

        public bool IsImplicit { get; set; }

        public DateTime? ProjectCreatedAt { get; set; }

        public DateTime? ProjectDueDate { get; set; }

        public int ProjectStatusId { get; set; }

        public Guid LanguageFileUniqueId { get; set; }

        public string AssignedUsersName { get; set; }
    }
}
