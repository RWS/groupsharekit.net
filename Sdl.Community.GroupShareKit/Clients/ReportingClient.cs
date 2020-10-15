using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Http;
using Sdl.Community.GroupShareKit.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class ReportingClient : ApiClient, IReportingClient
    {
        public ReportingClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        public Task<List<ReportingServiceProjects>> PredefinedProjects(PredefinedReportsFilters predefinedFilters)
        {
            var predefinedProjectsUrl = ApiUrls.GetPredefinedProjectsData();

            var filterParameters = new Dictionary<string, string>()
            {
                { "showAll" , predefinedFilters.ShowAll.ToString()},
                { "publishStart", predefinedFilters.PublishStart.ToString()},
                { "publishEnd", predefinedFilters.PublishEnd.ToString()},
                { "dueStart", predefinedFilters.DueStart.ToString()},
                { "dueEnd", predefinedFilters.DueEnd.ToString()},
                { "status" , predefinedFilters.Status.ToString() },
                { "OrganizationPath", predefinedFilters.OrganizationPath},
                { "SourceLanguages", predefinedFilters.SourceLanguages},
                { "TargetLanguages", predefinedFilters.TargetLanguages},
                { "AssignedUserIds", predefinedFilters.AssignedUsersIds}          
            };

            return ApiConnection.Get<List<ReportingServiceProjects>>(predefinedProjectsUrl, filterParameters);
        }

        public Task<List<ReportingServiceTasks>> PredefinedTasks(PredefinedReportsFilters predefinedFilters)
        {
            var predefinedTasksUrl = ApiUrls.GetPredefinedProjectsData();

            var filterParameters = new Dictionary<string, string>()
            {
                { "showAll" , predefinedFilters.ShowAll.ToString()},
                { "publishStart", predefinedFilters.PublishStart.ToString()},
                { "publishEnd", predefinedFilters.PublishEnd.ToString()},
                { "dueStart", predefinedFilters.DueStart.ToString()},
                { "dueEnd", predefinedFilters.DueEnd.ToString()},
                { "status" , predefinedFilters.Status.ToString() },
                { "OrganizationPath", predefinedFilters.OrganizationPath},
                { "SourceLanguages", predefinedFilters.SourceLanguages},
                { "TargetLanguages", predefinedFilters.TargetLanguages},
                { "AssignedUserIds", predefinedFilters.AssignedUsersIds}
            };
            return ApiConnection.Get<List<ReportingServiceTasks>>(predefinedTasksUrl, filterParameters);
        }

        public Task<List<ReportingServiceTmLeverage>> PredefinedTmLeverage(PredefinedReportsFilters predefinedFilters)
        {
            var predefinedTmLeverageUrl = ApiUrls.GetPredefinedProjectsData();

            var filterParameters = new Dictionary<string, string>()
            {
                { "showAll" , predefinedFilters.ShowAll.ToString()},
                { "publishStart", predefinedFilters.PublishStart.ToString()},
                { "publishEnd", predefinedFilters.PublishEnd.ToString()},
                { "dueStart", predefinedFilters.DueStart.ToString()},
                { "dueEnd", predefinedFilters.DueEnd.ToString()},
                { "status" , predefinedFilters.Status.ToString() },
                { "OrganizationPath", predefinedFilters.OrganizationPath},
                { "SourceLanguages", predefinedFilters.SourceLanguages},
                { "TargetLanguages", predefinedFilters.TargetLanguages},
                { "AssignedUserIds", predefinedFilters.AssignedUsersIds}
            };
            return ApiConnection.Get<List<ReportingServiceTmLeverage>>(predefinedTmLeverageUrl, filterParameters);
        }
    }
}
