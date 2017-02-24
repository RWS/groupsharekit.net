using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class License
    {
        public LicenseDetails ProjectServerCALs { get; set; }
        public LicenseDetails TranslationMemoryCALs { get; set; }
        public LicenseDetails TUs { get; set; }
        public LicenseDetails MultiTermViewerCALs { get; set; }
        public LicenseDetails MultiTermEditorCALs { get; set; }
    }
}
