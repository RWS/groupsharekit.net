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

        /// <summary>
        /// Gets all the activities.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <returns>A collection of <see cref="Activity"/> objects.</returns>
        public async Task<JsonCollection<Activity>> GetActivities()
        {
            return await ApiConnection.Get<JsonCollection<Activity>>(ApiUrls.Activities(), null);
        }

        /// <summary>
        /// Gets filtered activities.
        /// </summary>
        /// <param name="filter"><see cref="ActivitiesFilter"/></param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <returns>A collection of <see cref="Activity"/> objects.</returns>
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

        /// <summary>
        /// Exports activities.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        public async Task<byte[]> ExportActivities()
        {
            return await ApiConnection.Get<byte[]>(ApiUrls.ExportActivities(), null);
        }

        /// <summary>
        /// Exports filtered activities.
        /// </summary>
        /// <param name="filter"><see cref="ExportActivitiesFilter"/></param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        public async Task<byte[]> ExportActivities(ExportActivitiesFilter filter)
        {
            var filterParameters = new Dictionary<string, string>
            {
                { "page", filter.Page.ToString() },
                { "limit", filter.Limit.ToString() },
                { "filter", filter.Filter },
                { "language", filter.Language.ToString() },
                { "timeZone", filter.TimeZone }
            };

            return await ApiConnection.Get<byte[]>(ApiUrls.ExportActivities(), filterParameters);
        }

        /// <summary>
        /// Exports activities and deletes them from the server.
        /// </summary>
        /// <param name="filter"><see cref="ExportActivitiesFilter"/></param>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        public async Task<byte[]> ArchiveActivities(ExportActivitiesFilter filter)
        {
            var filterParameters = new Dictionary<string, string>
            {
                { "page", filter.Page.ToString() },
                { "limit", filter.Limit.ToString() },
                { "filter", filter.Filter },
                { "language", filter.Language.ToString() },
                { "timeZone", filter.TimeZone }
            };

            return await ApiConnection.Post<byte[]>(ApiUrls.ArchiveActivities(), filterParameters);
        }

    }
}
