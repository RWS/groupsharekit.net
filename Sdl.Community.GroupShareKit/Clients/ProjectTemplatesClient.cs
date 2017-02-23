using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Http;
using Sdl.Community.GroupShareKit.Models.Response;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class ProjectTemplatesClient : ApiClient,IProjectsTemplateClient
    {
        public ProjectTemplatesClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        public async Task<IReadOnlyList<ProjectTemplates>> GetAllTemplates()
        {
           return await ApiConnection.GetAll<ProjectTemplates>(ApiUrls.ProjectTemplates(),null);
        }
    }
}
