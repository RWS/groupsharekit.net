using System;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class AiProviderSettings
    {
        public string ProviderId { get; set; }

        public string ProviderName { get; set; }

        public string DisplayName { get; set; }

        public string Url { get; set; }

        public string ApiKey { get; set; }

        public string ModelsPath { get; set; }

        public string AuthType { get; set; }

        public string TenantId { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string Region { get; set; }

        public string RefreshToken { get; set; }

        public int ProviderSettingId { get; set; }

        public string TranslationProviderType { get; set; }
    }
}
