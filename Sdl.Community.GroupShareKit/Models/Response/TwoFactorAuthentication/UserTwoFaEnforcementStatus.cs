using System;

namespace Sdl.Community.GroupShareKit.Models.Response.TwoFactorAuthentication
{
    public class UserTwoFaEnforcementStatus
    {
        public Guid UserGuid { get; set; }

        public bool Require2FA { get; set; }
    }
}
