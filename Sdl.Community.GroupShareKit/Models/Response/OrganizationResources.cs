using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class OrganizationResources
    {
        public Guid  Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ResourceType { get; set; }
        public string ParentOragnizationId { get; set; }
        public List<string> LinkedOragnizationIds { get; set; }
    }
}
