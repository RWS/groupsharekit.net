using System.Collections.Generic;

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
