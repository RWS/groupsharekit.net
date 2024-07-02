using System;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    [Obsolete("FieldTemplateRequest is deprecated, please use UpdateTemplateRequest instead.")]
    public class FieldTemplateRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsTmSpecific { get; set; }
    }
}
