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

        public async Task<string> CreateTemplate(ProjectTemplates templateRequest)
        {
            return await ApiConnection.Post<string>(ApiUrls.ProjectTemplates(), templateRequest, "application/json");
        }

        public async Task<string> GetTemplateById(string templateId)
        {
            Ensure.ArgumentNotNullOrEmptyString(templateId, "templateId");
            return await ApiConnection.Get<string>(ApiUrls.ProjectTemplates(templateId), null);
        }

        public async Task Delete(string templateId)
        {
            Ensure.ArgumentNotNullOrEmptyString(templateId, "templateId");
            await ApiConnection.Delete(ApiUrls.ProjectTemplates(templateId));
        }
    }
}
