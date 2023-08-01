using System;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class PredefinedReportsFilters
    {
        public string OrganizationPath { get; set; }
        public bool? ShowAll { get; set; }
        public DateTime? PublishStart { get; set; }
        public DateTime? PublishEnd { get; set; }
        public DateTime? DueStart { get; set; }
        public DateTime? DueEnd { get; set; }
        public int? Status { get; set; }
        public string SourceLanguages { get; set; }
        public string TargetLanguages { get; set; }
        public string AssignedUsersIds { get; set; }
    }
}
