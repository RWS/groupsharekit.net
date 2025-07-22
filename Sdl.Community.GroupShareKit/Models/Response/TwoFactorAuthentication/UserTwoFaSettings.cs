using System;

namespace Sdl.Community.GroupShareKit.Models.Response.TwoFactorAuthentication
{
    public class UserTwoFaSettings
    {
        public Guid UserId { get; set; }

        public bool Enabled { get; set; }

        public string AccountSecret { get; set; }

        public string QrCode { get; set; }

        public string ManualCode { get; set; }

        public string BearerToken { get; set; }

        public string OtpSecret { get; set; }
    }
}
