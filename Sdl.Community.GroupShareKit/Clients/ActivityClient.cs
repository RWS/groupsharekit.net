using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Http;
using Sdl.Community.GroupShareKit.Models.Response;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Clients
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

    }
}
