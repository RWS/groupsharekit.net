using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    /// <summary>
    /// Configurable Idp user settings. 
    /// </summary>
    public class IdpUserSettings
    {
        public bool CreateIdpUser { get; set; } = false;
        public bool UpdateIdpUserInfo { get; set; } = false;
        public bool UpdateIdpMembershipInfo { get; set; } = false;
        public Guid DefaultUserOrganizationId { get; set; } = Guid.Empty;
    }
}
