namespace Sdl.Community.GroupShareKit.Clients
{
    public class CreateProjectSkeletonRequest
    {
        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the organization id.
        /// </summary>
        /// <value>
        /// The organization id.
        /// </value>
        public string OrganizationId { get; set; }

        public CreateProjectSkeletonRequest(string name, string organizationId)
        {
            Name = name;
            OrganizationId = organizationId;
        }
    }
}
