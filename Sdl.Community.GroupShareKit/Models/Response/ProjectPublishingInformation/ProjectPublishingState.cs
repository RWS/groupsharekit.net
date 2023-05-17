namespace Sdl.Community.GroupShareKit.Models.Response.ProjectPublishingInformation
{
    public class ProjectPublishingState
    {
        public PublishingState Status { get; set; }
        public int PercentComplete { get; set; }
        public string CurrentOperationDescription { get; set; }
        public string ErrorMessage { get; set; }
    }
}
