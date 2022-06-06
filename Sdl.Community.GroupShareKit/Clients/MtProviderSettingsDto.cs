namespace Sdl.Community.GroupShareKit.Clients
{
    public class MtProviderSettingDto
    {
        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public int ProviderSettingId { get; set; }

        public MtProviderType TranslationProviderType { get; set; }
    }
}
