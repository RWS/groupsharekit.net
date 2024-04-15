using System;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class ProjectTemplateV4
    {
        /// <summary>
        /// Gets or sets the template name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the organization id
        /// </summary>
        public Guid OrganizationId { get; set; }

        public int Number { get; set; }

        public ProjectTemplateSettingsV4 Settings { get; set; }

        public ProjectTemplateV4() { }

        public ProjectTemplateV4(string name, string description, Guid organizationId, ProjectTemplateSettingsV4 templateSettings)
        {
            Name = name;
            Description = description;
            OrganizationId = organizationId;
            Settings = templateSettings;
        }
    }
}
