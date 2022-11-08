namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class ProjectTemplates
    {
        public string Id { get; set; }
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
        /// <summary>
        /// Gets or sets the raw template data
        /// </summary>
       // public byte[] RawData { get; set; }

        public ProjectTemplates() { }

        public ProjectTemplates(string id, string name, string description, string organizationId)
        {
            Id = id;
            Name = name;
            Description = description;
            OrganizationId = organizationId;
            //    RawData = rawData;
        }
    }
}
