using Sdl.Community.GroupShareKit.Models;
using Sdl.Community.GroupShareKit.Models.Response;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Clients.Activities
{
    public interface IActivityClient
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<JsonCollection<Activity>> GetActivities();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<JsonCollection<Activity>> GetActivities(ActivitiesFilter filter/*, string sort = null*/);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<byte[]> ExportActivities();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<byte[]> ExportActivities(ExportActivitiesFilter filter);
    }
}
