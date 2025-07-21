using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Http;
using Sdl.Community.GroupShareKit.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Clients.Activities
{
    public class ActivityClient : ApiClient, IActivityClient
    {
        public ActivityClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        public async Task<JsonCollection<Activity>> GetActivities()
        {
            return await ApiConnection.Get<JsonCollection<Activity>>(ApiUrls.Activities(), null);
        }

        public async Task<JsonCollection<Activity>> GetActivities(ActivitiesFilter filter)
        {
            var filterParameters = new Dictionary<string, string>
            {
                { "page", filter.Page.ToString() },
                { "start", filter.Start.ToString() },
                { "limit", filter.Limit.ToString() },
                { "filter", filter.Filter },
                { "language", filter.Language.ToString() },
                { "timeZone", filter.TimeZone },
                { "sort", filter.Sort }
            };

            return await ApiConnection.Get<JsonCollection<Activity>>(ApiUrls.Activities(), filterParameters);
        }

        public async Task<byte[]> ExportActivities()
        {
            return await ApiConnection.Get<byte[]>(ApiUrls.ExportActivities(), null);
        }

        public async Task<byte[]> ExportActivities(ExportActivitiesFilter filter)
        {
            var filterParameters = new Dictionary<string, string>
            {
                { "Page", filter.Page.ToString() },
                { "Limit", filter.Limit.ToString() },
                { "Filter", filter.Filter },
                { "Language", filter.Language.ToString() },
                { "TimeZone", filter.TimeZone }
            };

            return await ApiConnection.Get<byte[]>(ApiUrls.ExportActivities(), filterParameters);
        }

    }
}
