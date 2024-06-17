using System;
using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class CreateFieldTemplateRequest
    {
        public bool IsTmSpecific { get; set; }

        public Guid OwnerId { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public IList<Field> Fields { get; set; }
    }
}
