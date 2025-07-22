using Sdl.Community.GroupShareKit.Models.Response;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Clients.Activities
{
    public interface IActivityClient
    {
        /// <summary>
        /// Gets all the activities.
        /// </summary>
        Task<JsonCollection<Activity>> GetActivities();

        /// <summary>
        /// Gets filtered activities.
        /// </summary>
        /// <param name="filter"></param>
        Task<JsonCollection<Activity>> GetActivities(ActivitiesFilter filter);

        /// <summary>
        /// Exports activities.
        /// </summary>
        Task<byte[]> ExportActivities();

        /// <summary>
        /// Exports filtered activities.
        /// </summary>
        /// <param name="filter"></param>
        Task<byte[]> ExportActivities(ExportActivitiesFilter filter);

        /// <summary>
        /// Exports activities and deletes them from the server.
        /// </summary>
        /// <param name="filter"></param>
        Task<byte[]> ArchiveActivities(ExportActivitiesFilter filter);
    }
}
