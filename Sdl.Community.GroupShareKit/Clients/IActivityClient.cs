using Sdl.Community.GroupShareKit.Models.Response;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Clients
{
    public interface IActivityClient
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<JsonCollection<Activity>> GetActivities();
    }
}
