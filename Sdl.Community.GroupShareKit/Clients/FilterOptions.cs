using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class FilterOptions
    {
        public string ProjectName { get; set; }
        public string OrganizationPath { get; set; }
        public bool IncludeSubOrgs { get; set; }
        public DateTime? CreatedStart { get; set; }
        public DateTime? CreatedEnd { get; set; }
        public DateTime? DueStart { get; set; }
        public DateTime? DueEnd { get; set; }
        public int Status { get; set; }
    }
}
