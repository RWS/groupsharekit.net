using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class Activity
    {
        public int Id { get; set; }

        public string ActivitySource { get; set; }

        public string ActivitySourceDetails { get; set; }

        public string UserName { get; set; }

        public string UserDisplayName { get; set; }

        public Guid OrganizationId { get; set; }

        public string OrganizationName { get; set; }

        public string CalsConsumed { get; set; }

        public DateTime? Login { get; set; }

        public DateTime? LastActivity { get; set; }
    }
}
