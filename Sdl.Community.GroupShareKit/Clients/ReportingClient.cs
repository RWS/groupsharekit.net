using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Http;
using Sdl.Community.GroupShareKit.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class ReportingClient : ApiClient, IReportingClient
    {
        public ReportingClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        public Task<List<ReportingServicePredefinedProjects>> PredefinedProjects(PredefinedReportsFilters filters)
        {
            var predefinedProjectsUrl = ApiUrls.GetPredefinedProjectsData();

            var filterParameters = new Dictionary<string, string>
            {
                { "showAll" , filters.ShowAll.ToString() },
                { "publishStart", filters.PublishStart.ToString() },
                { "publishEnd", filters.PublishEnd.ToString() },
                { "dueStart", filters.DueStart.ToString() },
                { "dueEnd", filters.DueEnd.ToString() },
                { "status" , filters.Status.ToString() },
                { "OrganizationPath", filters.OrganizationPath },
                { "SourceLanguages", filters.SourceLanguages },
                { "TargetLanguages", filters.TargetLanguages },
                { "AssignedUserIds", filters.AssignedUsersIds }
            };

            return ApiConnection.Get<List<ReportingServicePredefinedProjects>>(predefinedProjectsUrl, filterParameters);
        }

        public Task<ReportingServicePredefinedProjectsV2> PredefinedProjectsV2(PredefinedReportsFiltersV2 filters)
        {
            var predefinedProjectsV2Url = ApiUrls.GetPredefinedProjectsDataV2();

            var filterParameters = new Dictionary<string, string>
            {
                { "showAll" , filters.ShowAll.ToString() },
                { "publishStart", filters.PublishStart.ToString() },
                { "publishEnd", filters.PublishEnd.ToString() },
                { "dueStart", filters.DueStart.ToString() },
                { "dueEnd", filters.DueEnd.ToString() },
                { "status" , filters.Status.ToString() },
                { "OrganizationPath", filters.OrganizationPath },
                { "SourceLanguages", filters.SourceLanguages },
                { "TargetLanguages", filters.TargetLanguages },
                { "AssignedUserIds", filters.AssignedUsersIds },
                { "OrderBy", filters.OrderBy },
                { "SortDirection", filters.SortDirection },
                { "Page", filters.Page.ToString() },
                { "PageSize", filters.PageSize.ToString() }
            };

            return ApiConnection.Get<ReportingServicePredefinedProjectsV2>(predefinedProjectsV2Url, filterParameters);
        }

        public Task<List<ReportingServicePredefinedTasks>> PredefinedTasks(PredefinedReportsFilters filters)
        {
            var predefinedTasksUrl = ApiUrls.GetPredefinedTasksData();

            var filterParameters = new Dictionary<string, string>
            {
                { "showAll" , filters.ShowAll.ToString() },
                { "publishStart", filters.PublishStart.ToString() },
                { "publishEnd", filters.PublishEnd.ToString() },
                { "dueStart", filters.DueStart.ToString() },
                { "dueEnd", filters.DueEnd.ToString() },
                { "status" , filters.Status.ToString() },
                { "OrganizationPath", filters.OrganizationPath },
                { "SourceLanguages", filters.SourceLanguages },
                { "TargetLanguages", filters.TargetLanguages },
                { "AssignedUserIds", filters.AssignedUsersIds }
            };

            return ApiConnection.Get<List<ReportingServicePredefinedTasks>>(predefinedTasksUrl, filterParameters);
        }

        public Task<ReportingServicePredefinedTasksV2> PredefinedTasksV2(PredefinedReportsFiltersV2 filters)
        {
            var predefinedTasksV2Url = ApiUrls.GetPredefinedTasksDataV2();

            var filterParameters = new Dictionary<string, string>
            {
                { "showAll" , filters.ShowAll.ToString() },
                { "publishStart", filters.PublishStart.ToString() },
                { "publishEnd", filters.PublishEnd.ToString() },
                { "dueStart", filters.DueStart.ToString() },
                { "dueEnd", filters.DueEnd.ToString() },
                { "status" , filters.Status.ToString() },
                { "OrganizationPath", filters.OrganizationPath },
                { "SourceLanguages", filters.SourceLanguages },
                { "TargetLanguages", filters.TargetLanguages },
                { "AssignedUserIds", filters.AssignedUsersIds },
                { "OrderBy", filters.OrderBy },
                { "SortDirection", filters.SortDirection },
                { "Page", filters.Page.ToString() },
                { "PageSize", filters.PageSize.ToString() }
            };

            return ApiConnection.Get<ReportingServicePredefinedTasksV2>(predefinedTasksV2Url, filterParameters);
        }

        public Task<List<ReportingServicePredefinedTmLeverage>> PredefinedTmLeverage(PredefinedReportsFilters filters)
        {
            var predefinedTmLeverageUrl = ApiUrls.GetPredefinedTmLeverageData();

            var filterParameters = new Dictionary<string, string>
            {
                { "showAll" , filters.ShowAll.ToString() },
                { "publishStart", filters.PublishStart.ToString() },
                { "publishEnd", filters.PublishEnd.ToString() } ,
                { "dueStart", filters.DueStart.ToString() },
                { "dueEnd", filters.DueEnd.ToString() },
                { "status" , filters.Status.ToString() },
                { "OrganizationPath", filters.OrganizationPath },
                { "SourceLanguages", filters.SourceLanguages },
                { "TargetLanguages", filters.TargetLanguages },
                { "AssignedUserIds", filters.AssignedUsersIds }
            };

            return ApiConnection.Get<List<ReportingServicePredefinedTmLeverage>>(predefinedTmLeverageUrl, filterParameters);
        }

        public Task<ReportingServiceDeliveriesDueSoonProjects> DeliveriesDueSoon(ReportingServiceSortingParameters sortParameters)
        {
            var deliveriesDueSoonUrl = ApiUrls.GetDeliveriesDueSoonData();

            var requestSortParameters = new Dictionary<string, string>
            {
                { "OrderBy" , sortParameters.OrderBy },
                { "OrderDirection", sortParameters.OrderDirection },
            };

            return ApiConnection.Get<ReportingServiceDeliveriesDueSoonProjects>(deliveriesDueSoonUrl, requestSortParameters);
        }

        public Task<List<ReportingServiceYourTasks>> YourTasks(ReportingServiceSortingParameters sortParameters)
        {
            var yourTasksUrl = ApiUrls.GetYourTasksData();

            var requestSortParameters = new Dictionary<string, string>
            {
                { "OrderBy" , sortParameters.OrderBy },
                { "OrderDirection", sortParameters.OrderDirection },
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

        public async Task<byte[]> ExportPredefinedReports(ExportPredefinedReportsFilters filters)
        {
            var filterParameters = new Dictionary<string, string>
            {
                { "showAll" , filters.ShowAll.ToString() },
                { "publishStart", filters.PublishStart.ToString() },
                { "publishEnd", filters.PublishEnd.ToString() },
                { "dueStart", filters.DueStart.ToString() },
                { "dueEnd", filters.DueEnd.ToString() },
                { "status" , filters.Status.ToString() },
                { "OrganizationPath", filters.OrganizationPath },
                { "SourceLanguages", filters.SourceLanguages },
                { "TargetLanguages", filters.TargetLanguages },
                { "AssignedUserIds", filters.AssignedUsersIds },
                { "Language", filters.Language.ToString() },
                { "TimeZone", filters.TimeZone }
            };

            return await ApiConnection.Get<byte[]>(ApiUrls.ExportPredefinedReports(), filterParameters);
        }
    }
}
