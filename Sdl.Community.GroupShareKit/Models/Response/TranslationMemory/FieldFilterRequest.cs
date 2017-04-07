using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
   public class FieldFilterRequest
    {
        /// <summary>
        /// Gets or sets a list of fields
        /// </summary>
        public List<FieldFilter> Fields { get; set; }
        /// <summary>
        /// Get or sets filter expression
        /// </summary>
       public string Expression { get; set; }

       public FieldFilterRequest(List<FieldFilter> fields,string expression)
       {
           Fields = fields;
           Expression = expression;
       }
    }
}
