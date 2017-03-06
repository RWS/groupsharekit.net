using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Models.Response;

namespace Sdl.Community.GroupShareKit.Clients
{
    public interface IModuleClient
    {
        /// <summary>
        /// Get models
        /// </summary>
        /// <returns><see cref="Modules"/>/// </returns>
        Task<Modules> GetModules();
    }
}
