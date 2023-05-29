using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class TmServiceInfo
    {
        public string ContainerVersion { get; set; }
        public string ServiceVersion { get; set; }
        public List<ServiceDependencies> Dependencies { get; set; }
    }
}
