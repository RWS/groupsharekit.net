namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class Statistics
    {
        /// <summary>
        /// Gets or sets the type percent complete
        /// </summary>
        public int TypePercentComplete { get; set; }
        /// <summary>
        /// Gets or sets the total words number
        /// </summary>
        public int TotalWords { get; set; }
        /// <summary>
        /// Gets or sets the unspecified words number
        /// </summary>
        public int UnspecifiedWords { get; set; }
        /// <summary>
        /// Gets or sets the draft words number
        /// </summary>
        public int DraftWords { get; set; }
        /// <summary>
        /// Gets or sets the  translated words number
        /// </summary>
        public int TranslatedWords { get; set; }
        /// <summary>
        /// Gets or sets the rejected translation words number
        /// </summary>
        public int RejectedTranslationWords { get; set; }
        /// <summary>
        /// Gets or sets the approved translation words number
        /// </summary>
        public int ApprovedTranslationWords { get; set; }
        /// <summary>
        /// Gets or sets the rejected signoff words number
        /// </summary>
        public int RejectedSignOffWords { get; set; }
        /// <summary>
        /// Gets or sets the approved signoff words number
        /// </summary>
        public int ApprovedSignOffWords { get; set; }
    }
}
