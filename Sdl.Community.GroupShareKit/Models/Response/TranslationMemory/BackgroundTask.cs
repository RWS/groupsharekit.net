using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class BackgroundTask
    {
        /// <summary>
        /// Gets or sets background task id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets display name
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// Gets or sets  type
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Gets or sets settings
        /// </summary>
        public Settings Settings { get; set; }
        /// <summary>
        /// Gets or sets background task details
        /// </summary>
        public BackgroundTaskDetails Details { get; set; }
        /// <summary>
        /// Gets or sets the status
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Gets or sets callback url
        /// </summary>
        public string CallbackUrl { get; set; }
        /// <summary>
        /// Gets or sets created date
        /// </summary>
        public DateTime? CreatedAt { get; set; }
        /// <summary>
        /// Gets or sets  updated date
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
        /// <summary>
        /// Gets or sets owner id
        /// </summary>
        public string OwnerId { get; set; }
        
    }
}
