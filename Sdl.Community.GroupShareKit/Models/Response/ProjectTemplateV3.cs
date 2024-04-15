namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class ProjectTemplateV3
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
        public string OrganizationId { get; set; }

        public int Number { get; set; }

        public ProjectTemplateSettingsV3 Settings { get; set; }
    }
}
