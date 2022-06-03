using System;

namespace Sdl.Community.GroupShareKit.Models.Response.Logs
{
    public class LogEntry
    {
        public int Id { get; set; }
        public DateTime LogDate { get; set; }
        public string MachineName { get; set; }
        public string Level { get; set; }
        public string ProcessName { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
    }
}
