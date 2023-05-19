using System;

namespace Sdl.Community.GroupShareKit.Models.Response.ProjectPublishingInformation
{
    public class ProjectPublishingInformation
    {
        public Guid ProjectId { get; set; }
        public ProjectPublishValidity Validity { get; set; }
        public Project Project { get; set; }
        public ProjectPublishingState PublishProjectInfo { get; set; }
    }
}
