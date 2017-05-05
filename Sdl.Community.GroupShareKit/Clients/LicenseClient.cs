using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Exceptions;
using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Http;
using Sdl.Community.GroupShareKit.Models.Response;

namespace Sdl.Community.GroupShareKit.Clients
{
   public class LicenseClient:ApiClient, ILicense
    {
       public LicenseClient(IApiConnection apiConnection) : base(apiConnection)
       {
       }

        /// <summary>
        /// Gets license  informations<see cref="License"/>.
        /// </summary>
        /// <remarks>
        /// This method requires authentication.
        /// See the <a href="http://gs2017dev.sdl.com:41234/documentation/api/index#/">API documentation</a> for more information.
        /// </remarks>
        /// <exception cref="AuthorizationException">
        /// Thrown when the current user does not have permission to make the request.
        /// </exception>
        /// <exception cref="ApiException">Thrown when a general API error occurs.</exception>
        /// <returns>  <see cref="License"/></returns>
        public async Task<License> GetLicenseInformations()
       {
           return await ApiConnection.Get<License>(ApiUrls.GetLicenseInformations(), null);
       }
    }
}
