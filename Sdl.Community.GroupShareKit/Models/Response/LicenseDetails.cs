using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class LicenseDetails
    {
        /// <summary>
        /// Gets of sets the number of license in use
        /// </summary>
        public int InUse { get; set; }
        /// <summary>
        /// Gets of sets the license limit
        /// </summary>
        public int Limit { get; set; }
    }
}
