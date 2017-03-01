using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Http;
using Sdl.Community.GroupShareKit.Models.Response;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class ModuleClient: ApiClient, IModuleClient
    {
      
        public async Task<Modules> GetModules()
        {
            return await ApiConnection.Get<Modules>(ApiUrls.Modules(),null);
        }

        public ModuleClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }
    }
}
