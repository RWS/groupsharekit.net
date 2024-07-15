using Sdl.Community.GroupShareKit.Models.Response;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Clients
{
    public interface IModuleClient
    {
        /// <summary>
        /// Gets <see cref="Modules"/>.
        /// </summary>
        /// <returns><see cref="Modules"/></returns>
        Task<Modules> GetModules();
    }
}
