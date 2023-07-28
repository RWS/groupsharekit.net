using System;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    [Obsolete("Trial is deprecated, please use Trail instead.")]
    public class Trial
    {
        public string Action { get; set; }
        public string Timestamp { get; set; }
        public string User { get; set; }
        public string Comment { get; set; }
        public int Version { get; set; }
    }
}
