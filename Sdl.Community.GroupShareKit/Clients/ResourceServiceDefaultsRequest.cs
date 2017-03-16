using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class ResourceServiceDefaultsRequest
    {
        public string Language { get; set; }
        public ResourceType Type { get; set; }
        public enum  ResourceType
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
