using System;

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
