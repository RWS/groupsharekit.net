using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
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
        /// Gets or sets the number of completed precent
        /// </summary>
        public int PercentComplete { get; set; }
        /// <summary>
        /// Gets or sets the status number
        /// </summary>
        public int Status { get; set; }
    }
}
