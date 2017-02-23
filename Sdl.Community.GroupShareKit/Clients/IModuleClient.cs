using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Clients
{
    public interface IModuleClient
    {
        Task<ModuleClient> GetModules();
    }
}
