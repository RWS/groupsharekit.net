using System;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class ProjectDetails
    {
        /// <summary>
        /// Gets or sets the project id
        /// </summary>
        public string ProjectId { get; set; }
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the organization name
        /// </summary>
        public string OrganizationName { get; set; }
        /// <summary>
        /// Gets or sets the project description
        /// </summary>
        public string ProjectDescription { get; set; }
        /// <summary>
        /// Gets or sets the customer name
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Gets or sets the organization id
        /// </summary>
        public string OrganizationId { get; set; }
        /// <summary>
        /// Gets or sets the organization path
        /// </summary>
        public string OrganizationPath { get; set; }
        /// <summary>
        /// Gets or sets the source language
        /// </summary>
        public string SourceLanguage { get; set; }
        /// <summary>
        /// Gets or sets the target language
        /// </summary>
        public string TargetLanguage { get; set; }
        /// <summary>
        /// Gets or sets the due date
        /// </summary>
        public DateTime? DueDate { get; set; }
        /// <summary>
        /// Gets or sets created date
        /// </summary>
        public DateTime? CreatedAt { get; set; }
        /// <summary>
        /// Gets or sets the name who created the project
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Gets or sets thecomplated date
        /// </summary>
        public DateTime? CompletedAt { get; set; }
        /// <summary>
        /// Gets or sets the name of user who completed project
        /// </summary>
        public string CompletedBy { get; set; }
        /// <summary>
        /// Gets or sets the status number
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// Gets or sets the project analysis statistics
        /// </summary>
        public ProjectStatistics Statistics { get; set; }
    }
}
