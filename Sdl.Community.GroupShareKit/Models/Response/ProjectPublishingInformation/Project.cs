using System;

namespace Sdl.Community.GroupShareKit.Models.Response.ProjectPublishingInformation
{
    public class Project
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Customer Customer { get; set; }
        public string OrganizationPath { get; set; }
        public string SourceLanguageCode { get; set; }
        public string[] TargetLanguageCodes { get; set; }
        public DateTime? DueDate { get; set; }
        public ProjectStatus Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}
