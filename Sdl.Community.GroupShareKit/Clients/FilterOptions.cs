using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class FilterOptions: IJsonRequest
    {
        public FilterOptions(string organizationPath, bool includeSubOrgs, int status)
        {
            OrgPath = organizationPath;
            IncludeSubOrgs = includeSubOrgs;
            Status = status;

        }
        public string ProjectName { get; set; }
        public string OrgPath { get; set; }
        public bool IncludeSubOrgs { get; set; }
        public DateTime? CreatedStart { get; set; }
        public DateTime? CreatedEnd { get; set; }
        public DateTime? DueStart { get; set; }
        public DateTime? DueEnd { get; set; }
        public int Status { get; set; }
        public string Stringify()
        {
            var filter = new FilterOptions(OrgPath, IncludeSubOrgs, Status)
            {
                CreatedEnd = CreatedEnd,
                DueEnd = DueEnd,
                CreatedStart = CreatedStart,
                ProjectName = ProjectName,
                DueStart = DueStart             
            };

            return JsonConvert.SerializeObject(filter,
                    Formatting.Indented,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore,ContractResolver = new CamelCasePropertyNamesContractResolver()});
        }
    }
}
