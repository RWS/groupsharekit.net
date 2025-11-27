using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class Attribute
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Delete { get; set; }
        public List<Attribute> Attributes { get; set; }
        public List<Types> Value { get; set; }
    }

    public class Types
    {
        public string Value { get; set; }
        public string Type { get; set; }
    }
}
