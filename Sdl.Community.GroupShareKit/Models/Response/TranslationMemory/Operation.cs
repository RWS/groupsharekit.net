using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class Operation
    {
        public string Path { get; set; }

        public string Op { get; set; }

        public object Value { get; set; }
    }

    public class OperationValue
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public List<string> Values { get; set; }
    }
}
