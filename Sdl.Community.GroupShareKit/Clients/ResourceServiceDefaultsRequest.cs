using System;

namespace Sdl.Community.GroupShareKit.Clients
{
    [Obsolete("ResourceServiceDefaultsRequest is deprecated, please use LanguageResourceServiceDefaultsRequest instead.")]
    public class ResourceServiceDefaultsRequest
    {
        public string Language { get; set; }
        public ResourceType Type { get; set; }
        public enum ResourceType
        {
            Undefined,
            Variables,
            Abbreviations,
            OrdinalFollowers,
            SegmentationRules
        }

        public ResourceServiceDefaultsRequest(ResourceType type, string language)
        {
            Type = type;
            Language = language;
        }
    }
}
