using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Http;
using Sdl.Community.GroupShareKit.Models.Response;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class ModuleClient : ApiClient, IModuleClient
    {

        /// <summary>
        /// Gets modules
        /// </summary>
        /// <returns><see cref="Modules"/> </returns>
        public async Task<Modules> GetModules()
        {
            return await ApiConnection.Get<Modules>(ApiUrls.Modules(), null);
        }

        public ModuleClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }
    }
}
