namespace Sdl.Community.GroupShareKit.Clients
{
    /// <summary>
    /// Used to request projects for an organization.
    /// </summary>
    /// <remarks>
    /// API docs: http://sdldevelopmentpartners.sdlproducts.com/documentation/api
    /// </remarks>
    public class ProjectsRequest:RequestParameters
    {
        public ProjectsRequest(string organizationPath,bool includeChildren)
        {
            Group = organizationPath;
            IncludeChildren = includeChildren;
        }

        /// <summary>
        /// Gets or sets the organization path for which the projects are returned
        /// </summary>
        /// <value>
        /// The organization path
        /// </value>
        public string Group { get; set; }

        /// <summary>
        /// Get or sets if the response should include projects for the child organizations
        /// </summary>
        /// <value>
        /// The include children
        /// </value>
        public bool IncludeChildren { get; set; }


    }
}