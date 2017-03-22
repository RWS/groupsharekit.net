using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class FilterExport
    {
        /// <summary>
        /// Gets or sets a list of fields values
        /// </summary>
        public List<FieldsDuplicate> Fields { get; set; }
        /// <summary>
        /// Gets or sets the expression
        /// </summary>
        public string Expression { get; set; }
    }
}
