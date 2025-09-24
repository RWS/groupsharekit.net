using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class PackageExportStatus
    {
        public PackageExportStatusEnum Status { get; set; }
    }

    public enum PackageExportStatusEnum
    {
        InProgress,
        Done,
        Failed
    }
}
