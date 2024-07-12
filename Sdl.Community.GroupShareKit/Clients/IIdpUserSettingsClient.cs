using Sdl.Community.GroupShareKit.Exceptions;
using Sdl.Community.GroupShareKit.Models.Response;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Clients
{
    public interface IIdpUserSettingsClient
    {
        /// <summary>
        /// Returns the IDP user settings.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        Task<IdpUserSettings> GetIdpUserSettings();
    }
}
