using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class License
    {
        /// <summary>
        /// Gets or sets Project Server Calls
        /// </summary>
        public LicenseDetails ProjectServerCALs { get; set; }
        /// <summary>
        /// Gets or sets Translation Memory Cals
        /// </summary>
        public LicenseDetails TranslationMemoryCALs { get; set; }
        /// <summary>
        /// Gets or sets Tus
        /// </summary>
        public LicenseDetails TUs { get; set; }
        /// <summary>
        /// Gets or sets Multi TermV iewer Cals
        /// </summary>
        public LicenseDetails MultiTermViewerCALs { get; set; }
        /// <summary>
        /// Gets or sets Multi Term Editor Cals
        /// </summary>
        public LicenseDetails MultiTermEditorCALs { get; set; }
    }
}
