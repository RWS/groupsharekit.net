namespace Sdl.Community.GroupShareKit.Models.Response.TwoFactorAuthentication
{
    public class CreateTwoFaSettingsResponse
    {
        public UserTwoFaSettings Settings { get; set; }

        public bool Require2FA { get; set; }
    }
}
