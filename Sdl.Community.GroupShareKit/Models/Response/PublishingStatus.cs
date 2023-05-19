namespace Sdl.Community.GroupShareKit.Models.Response
{
    public enum PublishProjectStatus
    {
        Uploading = 0,
        Scheduled = 1,
        Publishing = 2,
        Completed = 3,
        Cancelled = 4,
        Error = 5,
        Cancelling = 6
    }

    public class PublishingStatus
    {
        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the error message
        /// </summary>
        public string ErrorMessage { get; set; }
        /// <summary>
        /// Gets or sets the number of completed percent
        /// </summary>
        public int PercentComplete { get; set; }
        /// <summary>
        /// Gets or sets the status number
        /// </summary>
        public PublishProjectStatus Status { get; set; }
    }
}
