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

        public Task<List<ReportingServicePredefinedProjects>> PredefinedProjects(PredefinedReportsFilters predefinedFilters)
        {
            var predefinedProjectsUrl = ApiUrls.GetPredefinedProjectsData();

            var filterParameters = new Dictionary<string, string>
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

            return ApiConnection.Get<List<ReportingServicePredefinedProjects>>(predefinedProjectsUrl, filterParameters);
        }

        public Task<List<ReportingServicePredefinedTasks>> PredefinedTasks(PredefinedReportsFilters predefinedFilters)
        {
            var predefinedTasksUrl = ApiUrls.GetPredefinedTasksData();

            var filterParameters = new Dictionary<string, string>
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
            return ApiConnection.Get<List<ReportingServicePredefinedTasks>>(predefinedTasksUrl, filterParameters);
        }

        public Task<List<ReportingServicePredefinedTmLeverage>> PredefinedTmLeverage(PredefinedReportsFilters predefinedFilters)
        {
            var predefinedTmLeverageUrl = ApiUrls.GetPredefinedTmLeverageData();

            var filterParameters = new Dictionary<string, string>
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
            return ApiConnection.Get<List<ReportingServicePredefinedTmLeverage>>(predefinedTmLeverageUrl, filterParameters);
        }

        public Task<ReportingServiceDeliveriesDueSoonProjects> DeliveriesDueSoon(ReportingServiceSortingParameters sortParameters)
        {
            var deliveriesDueSoonUrl = ApiUrls.GetDeliveriesDueSoonData();

            var requestSortParameters = new Dictionary<string, string>
            {
                { "OrderBy" , sortParameters.OrderBy},
                { "OrderDirection", sortParameters.OrderDirection},
   
            };
            return ApiConnection.Get<ReportingServiceDeliveriesDueSoonProjects>(deliveriesDueSoonUrl, requestSortParameters);
        }

        public Task<List<ReportingServiceYourTasks>> YourTasks(ReportingServiceSortingParameters sortParameters)
        {
            var yourTasksUrl = ApiUrls.GetYourTasksData();

            var requestSortParameters = new Dictionary<string, string>
            {
                { "OrderBy" , sortParameters.OrderBy},
                { "OrderDirection", sortParameters.OrderDirection},

            };
            return ApiConnection.Get<List<ReportingServiceYourTasks>>(yourTasksUrl, requestSortParameters);
        }

        public Task<List<ReportingServiceProjectsPerMonth>> ProjectsPerMonth()
        {
            var projectsPerMonthUrl = ApiUrls.GetProjectsPerMonthData();

            return ApiConnection.Get<List<ReportingServiceProjectsPerMonth>>(projectsPerMonthUrl, null);
        }

        public Task<List<ReportingServiceWordsPerMonth>> WordsPerMonth()
        {
            var wordsPerMonthUrl = ApiUrls.GetWordsPerMonthData();

            return ApiConnection.Get<List<ReportingServiceWordsPerMonth>>(wordsPerMonthUrl, null);
        }

        public Task<List<ReportingServiceWordsPerOrganization>> WordsPerOrganization()
        {
            var wordsPerOrganizationUrl = ApiUrls.GetWordsPerOrganizationData();

            return ApiConnection.Get<List<ReportingServiceWordsPerOrganization>>(wordsPerOrganizationUrl, null);
        }

        public Task<List<ReportingServiceTopLanguagePairs>> TopLanguagePairs()
        {
            var topLanguagePairsUrl = ApiUrls.GetTopLanguagePairsData();

            return ApiConnection.Get<List<ReportingServiceTopLanguagePairs>>(topLanguagePairsUrl, null);
        }
    }
}
