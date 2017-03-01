using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class ProjectTemplates
    {
       
        public string Name { get; set; }
        public string Description { get; set; }
        public string OrganizationId { get; set; }
        public byte[] RawData { get; set; }

        public ProjectTemplates( string name, string description, string organizationId, byte[] rawData)
        {
            Name = name;
            Description = description;
            OrganizationId = organizationId;
            RawData = rawData;
        }
    }
}
