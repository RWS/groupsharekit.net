using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public enum FileStatus
    {
        Unspecified = 0,
        InTranslation = 1,
        Translated = 2,
        InReview = 3,
        RejectedTranslation = 4,
        ApprovedTranslation = 5,
        InSignOff = 6,
        RejectedSignOff = 7,
        ApprovedSignOff = 8,
    }

    public class TasksReport
    {
        public string OriginalName { get; set; }

        public Guid ProjectId { get; set; }

        public string ProjectName { get; set; }

        public string SourceLanguageCode { get; set; }

        public string TargetLanguageCode { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public string OriginalFileType { get; set; }

        public DateTime? LastModified { get; set; }

        public FileStatus FileStatus { get; set; }

        public string ResourceGroupPath { get; set; }

        public Phase Phase { get; set; }

        public int Progress { get; set; }

        public int NumberOfTbs { get; set; }

        public string TranslationProviders { get; set; }

        public int Assignees { get; set; }

        public int IsCheckedOut { get; set; }

        public int PreTranslatedWords { get; set; }

        public int? PerfectMatch { get; set; }

        public int? Repeated { get; set; }

        public int? New { get; set; }

        public int? ContextMatch { get; set; }

        public int TotalWords { get; set; }

        public int? ExactMatch { get; set; }

        public int? Locked { get; set; }

        public int? CrossFileRepetitions { get; set; }

        public int? FuzzyMatch50 { get; set; }

        public int? FuzzyMatch75 { get; set; }

        public int? FuzzyMatch85 { get; set; }

        public int? FuzzyMatch95 { get; set; }

    }
}
