using System;
using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class PhasesWithAssignees
    {
        /// <summary>
        /// Gets or sets the file id
        /// </summary>
        public string FileUniqueId { get; set; }
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
        /// Gets or sets the current phase id
        /// </summary>
        public int CurrentPhaseId { get; set; }
        /// <summary>
        /// Gets or sets the due date
        /// </summary>
        public DateTime? DueDate { get; set; }
        /// <summary>
        /// Gets or sets a list of phases <see cref="Phase"/>
        /// </summary>
        public List<Phase> Phases { get; set; }
    }
}
