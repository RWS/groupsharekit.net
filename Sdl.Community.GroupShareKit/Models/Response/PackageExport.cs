using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class PackageExport
    {
        public Guid ProjectId { get; set; }
        public List<Guid> LanguageFileIds { get; set; } = new List<Guid>();

    }
}
