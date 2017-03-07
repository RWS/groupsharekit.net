using System;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class ProjectFile
    {
        /// <summary>
        /// Gets or sets the file id
        /// </summary>
        public Guid FileUniqueId { get; set; }
        /// <summary>
        /// Gets or sets the file name
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Gets or sets the status number
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// Gets or sets the status name
        /// </summary>
        public string StatusName { get; set; }
        /// <summary>
        /// Gets or sets the completed percent number
        /// </summary>
        public int PercentComplete { get; set; }
        /// <summary>
        /// Gets or sets the language code
        /// </summary>
        public string LanguageCode { get; set; }
        /// <summary>
        /// Gets or sets the current phase
        /// </summary>
        public string CurrentPhase { get; set; }

    }
}
