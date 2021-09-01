using Sdl.Community.GroupShareKit.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Clients
{
    public interface IIdpUserSettingsClient
    {
		/// <summary>
		/// Returns the IDP user settings.
		/// </summary>
		/// <remarks>
		///  This method requires authentication.
		///  See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
		///  </remarks>
		///  <exception cref="AuthorizationException">
		///  Thrown when the current user does not have permission to make the request.
		///  </exception>
		///  <exception cref="ApiException">Thrown when a general API error occurs.</exception>
		Task<IdpUserSettings> GetIdpUserSettings();
    }
}
