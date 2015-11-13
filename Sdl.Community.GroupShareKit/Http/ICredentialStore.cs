using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Http
{
    public interface ICredentialStore
    {
        Task<Credentials> GetCredentials();
    }
}