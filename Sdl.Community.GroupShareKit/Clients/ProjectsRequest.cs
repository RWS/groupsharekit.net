using System;
using Newtonsoft.Json;

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

        public ProjectsRequest(string organizationPath,bool includeSubOrgs, int status)
        {
            Filter= new FilterOptions(organizationPath, includeSubOrgs, status);
        }

        public ProjectsRequest(SortParameters sortParam)
        {
            Sort = sortParam;
        }

        public ProjectsRequest(string page,string limit)
        {
            Page = page;
            Limit = limit;
        }
        public string Page { get; set; }
        public string Limit { get; set; }

        public FilterOptions Filter { get; set; }
        public SortParameters Sort { get; set; }

    }
}