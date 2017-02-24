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
   public class LicenseClient:ApiClient, ILicense
    {
       public LicenseClient(IApiConnection apiConnection) : base(apiConnection)
       {
       }

       public async Task<License> GetLicenseInformations()
       {
           return await ApiConnection.Get<License>(ApiUrls.GetLicenseInformations(), null);
       }
    }
}
