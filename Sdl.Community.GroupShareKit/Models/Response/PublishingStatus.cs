using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class PublishingStatus
    {
        public string Description { get; set; }
        public string ErrorMessage { get; set; }
        public int PercentComplete { get; set; }
        public int Status { get; set; }
    }
}
