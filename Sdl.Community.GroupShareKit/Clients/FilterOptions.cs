using System;
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
        /// <summary>
        /// Gets or sets the project name
        /// </summary>
        public string ProjectName { get; set; }
        /// <summary>
        /// Gets or sets the organization path
        /// </summary>
        public string OrgPath { get; set; }
        /// <summary>
        /// Gets or sets if the suborganization should be included 
        /// </summary>
        public bool IncludeSubOrgs { get; set; }
        /// <summary>
        /// Gets or sets the created start date
        /// </summary>
        public DateTime? CreatedStart { get; set; }
        /// <summary>
        /// Gets or sets the created end date
        /// </summary>
        public DateTime? CreatedEnd { get; set; }
        /// <summary>
        /// Gets or sets the due start date
        /// </summary>
        public DateTime? DueStart { get; set; }
        /// <summary>
        /// Gets or sets the due end date
        /// </summary>
        public DateTime? DueEnd { get; set; }
        /// <summary>
        /// Gets or sets the status
        /// </summary>
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
