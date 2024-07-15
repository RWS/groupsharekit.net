using System;
using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    [Obsolete("FieldTemplatePatchRequest is deprecated, please use List<Operation> instead.")]
    public class FieldTemplatePatchRequest
    {
        public List<Operation> Operations { get; set; }
    }
}
