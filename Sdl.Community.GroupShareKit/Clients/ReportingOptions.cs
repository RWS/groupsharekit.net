using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class ReportingOptions : IJsonRequest
    {
        /// <summary>
        /// The start of the project creation date range
        /// </summary>
        public DateTime? CreatedStart { get; set; }

        /// <summary>
        /// The end of the project creation date range
        /// </summary>
        public DateTime? CreatedEnd { get; set; }

        /// <summary>
        /// The start of delivery date range
        /// </summary>
        public DateTime? DueStart { get; set; }

        /// <summary>
        /// The end of delivery date range
        /// </summary>
        public DateTime? DueEnd { get; set; }

        /// <summary>
        /// Organization Path filter to restrict the projects created under this particular organization
        /// </summary>
        public string OrganizationPath { get; set; }

        /// <summary>
        /// Ignore the Organization Path and show the projects in all organizations where the user has permission
        /// </summary>
        public bool ShowAll { get; set; }

        /// <summary>
        /// The project status. The status could be any or combination of  (Pending = 1, Started = 2, Completed = 4, Archived = 8, Detached = 16) 
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Source language code
        /// </summary>
        public string[] SourceLanguages { get; set; }

        /// <summary>
        /// list of target language code.
        /// </summary>
        public string[] TargetLanguages { get; set; }

        /// <summary>
        /// list of the assigned users. Each user is represented by user GUID in string format.
        /// </summary>
        public string[] AssignedUserIds { get; set; }

        public string Stringify()
        {
            return JsonConvert.SerializeObject(this,
                    Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    });
        }


    }
}
