using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class FilterDuplicates
    {
        /// <summary>
        /// Gets or sets a list of fields
        /// </summary>
        public List<FieldsDuplicate> Fields { get; set; }
        /// <summary>
        /// Gets or sets searched expression
        /// </summary>
        public string Expression { get; set; }
    }
}
