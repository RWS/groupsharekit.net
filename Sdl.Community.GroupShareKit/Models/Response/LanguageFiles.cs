using System;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class LanguageFiles
    {
        /// <summary>
        /// Gets or sets the file id
        /// </summary>
        public Guid FileUniqueId { get; set; }
        /// <summary>
        /// Gets or sets file name
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
        /// Gets or sets the percent complete number
        /// </summary>
        public int PercentComplete { get; set; }
        /// <summary>
        /// Gets or sets the language code
        /// </summary>
        public string LanguageCode { get; set; }
        /// <summary>
        /// Gets or sets the project phase id
        /// </summary>
        public int ProjectPhaseId { get; set; }
    }
}
