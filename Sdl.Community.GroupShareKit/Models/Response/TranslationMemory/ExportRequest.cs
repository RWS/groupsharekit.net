using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class ExportRequest
    {
        /// <summary>
        /// Gets or sets the filter
        /// </summary>
        public FilterExport Filter { get; set; }
        /// <summary>
        /// Gets or sets the callback url
        /// </summary>
        public string CallbackUrl { get; set; }
    }
}
