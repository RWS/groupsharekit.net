using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Http;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class ModuleClient: ApiClient,IModuleClient
    {
        public ModuleClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        public async Task<ModuleClient> GetModules()
        {
            return await ApiConnection.Get<ModuleClient>(ApiUrls.Modules(),null);
        }
    }
}
