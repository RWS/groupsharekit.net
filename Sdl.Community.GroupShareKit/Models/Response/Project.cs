using System;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class Project
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public string OrganizationName { get; set; }
        public string ProjectDescription { get; set; }
        public string CustomerName { get; set; }
        public Guid OrganizationId { get; set; }
        public string SourceLanguage { get; set; }
        public string TargetLanguage { get; set; }
        public DateTime DueDate { get; set; }
        public object AnalysisStatistics { get; set; }
        public string CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string CompletedAt { get; set; }
        public object CompletedBy { get; set; }
        public string PublishedAt { get; set; }
        public string PublishedBy { get; set; }
        public object ConfirmationStatistics { get; set; }
        public int Status { get; set; }
    }
}
