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
        public ProjectsRequest(string page,string limit,FilterOptions filter,SortParameters sort)
        {
            Page = page;
            Limit = limit;
            Filter = filter;
            Sort = sort;
        }

        public ProjectsRequest()
        {
            
        }
        /// <summary>
        /// Gets or sets the organization path for which the projects are returned
        /// </summary>
        /// <value>
        /// The organization path
        /// </value>
        public string Page { get; set; }

        /// <summary>
        /// Get or sets if the response should include projects for the child organizations
        /// </summary>
        /// <value>
        /// The include children
        /// </value>
        public string Limit { get; set; }

        public FilterOptions Filter { get; set; }
        public SortParameters Sort { get; set; }

    }
}