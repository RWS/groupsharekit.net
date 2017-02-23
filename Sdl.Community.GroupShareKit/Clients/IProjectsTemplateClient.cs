using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Models.Response;

namespace Sdl.Community.GroupShareKit.Clients
{
    public interface IProjectsTemplateClient
    {

        Task<IReadOnlyList<ProjectTemplates>> GetAllTemplates();
        Task<string> CreateTemplate(ProjectTemplates projectRequest);
        Task<string> GetTemplateById(string templateId);
        Task Delete(string id);
    }
}
