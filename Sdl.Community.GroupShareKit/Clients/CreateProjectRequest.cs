using System;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class CreateProjectRequest
    {
        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the raw data (a zip file which contains all the files).
        /// </summary>
        /// <value>
        /// The raw data.
        /// </value>
        public byte[] RawData { get; set; }

        /// <summary>
        /// Gets or sets the organization id.
        /// </summary>
        /// <value>
        /// The organization id.
        /// </value>
        public string OrganizationId { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the due date
        /// </summary>
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// Gets or sets the template id
        /// </summary>
        public string ProjectTemplateId { get; set; }


        public CreateProjectRequest(string fileName, string organizationId,
            string description, DateTime dueDate, string projectTemplateId, byte[] rawData)
        {
            Name = fileName;
            OrganizationId = organizationId;
            Description = description;
            DueDate = dueDate;
            ProjectTemplateId = projectTemplateId;
            RawData = rawData;
        }
    }
}
