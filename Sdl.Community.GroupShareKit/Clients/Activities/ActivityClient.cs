using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Http;
using Sdl.Community.GroupShareKit.Models;
using Sdl.Community.GroupShareKit.Models.Response;
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

        public async Task<JsonCollection<Activity>> GetActivities(int page = 1, int start = 0, int limit = 150, string sort = null, string filter = null)
        {
            return await ApiConnection.Get<JsonCollection<Activity>>(ApiUrls.Activities(page, start, limit, sort, filter), null);
        }

    }
}
