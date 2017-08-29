using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class TmServiceHealth
    {
        public string ContainerVersion { get; set; }
        public string ServiceVersion { get; set; }
        public List<ServiceDependencies> Dependencies { get; set; }
    }
}
