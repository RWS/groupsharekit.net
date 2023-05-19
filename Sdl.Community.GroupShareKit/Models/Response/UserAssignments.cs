using System;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class UserAssignments
    {
        /// <summary>
        /// Gets or sets the project id
        /// </summary>
        public string ProjectId { get; set; }
        /// <summary>
        /// Gets or sets the project
        /// </summary>
        public string Project { get; set; }
        /// <summary>
        /// Gets or sets the  language file id
        /// </summary>
        public string LanguageFileId { get; set; }
        /// <summary>
        /// Gets or sets the language file
        /// </summary>
        public string LanguageFile { get; set; }
        /// <summary>
        /// Gets or sets the due date
        /// </summary>
        public DateTime? DueDate { get; set; }
        /// <summary>
        /// Gets or sets the phase id number
        /// </summary>
        public int PhaseId { get; set; }
        /// <summary>
        /// Gets or sets the phase
        /// </summary>
        public string Phase { get; set; }

        /// <summary>
        /// Gets or sets the source language
        /// </summary>
        public string SourceLanguage { get; set; }
        /// <summary>
        /// Gets or sets the target language
        /// </summary>
        public string TargetLanguage { get; set; }
    }
}
