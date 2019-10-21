using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class FieldRequest
    {
        public string FieldId { get; set; }

        public TypeEnum Type { get; set; }

        public string Name { get; set; }

        public List<string> Values { get; set; }

        public enum TypeEnum
        {
            SingleString,
            MultipleString,
            Integer,
            DateTime,
            SinglePicklist,
            MultiplePicklist
        }
    }
}
