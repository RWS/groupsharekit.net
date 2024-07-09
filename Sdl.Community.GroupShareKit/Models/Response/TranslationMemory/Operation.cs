using System;
using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class Operation
    {
        public string Path { get; set; }

        public string Op { get; set; }

        public List<OperationValue> Value { get; set; }
    }

    public class OperationValue
    {
        public Guid FieldId { get; set; }

        public Guid FieldTemplateId { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public List<string> Values { get; set; }
    }
}
