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

        Task<JsonCollection<Activity>> GetActivities(int page = 1, int start = 0, int limit = 150, string sort = null, string filter = null);
    }
}
