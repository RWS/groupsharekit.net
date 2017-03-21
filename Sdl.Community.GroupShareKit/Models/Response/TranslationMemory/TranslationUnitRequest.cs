using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class TranslationUnitRequest
    {
        /// <summary>
        /// Gets or sets translation unit details
        /// </summary>
        public TranslationUnitDetails TranslationUnit { get; set; }
        /// <summary>
        /// Gets or sets translation unit settings
        /// </summary>
        public Settings Settings { get; set; }
    }
}
