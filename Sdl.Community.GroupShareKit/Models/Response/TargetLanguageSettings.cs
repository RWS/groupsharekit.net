using Newtonsoft.Json;
using System;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class TargetLanguageSettings
    {
        [JsonProperty(PropertyName = "targetLanguageCode")]
        public string TargetLanguageCode { get; set; }

        [JsonProperty(PropertyName = "settingsBundleGuid")]
        public Guid SettingsBundleGuid { get; set; }
    }
}
