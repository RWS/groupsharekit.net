using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
