using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class ProjectDetails
    {
        public string ProjectId { get; set; }
        public string Name { get; set; }
        public string OrganizationName { get; set; }
        public string ProjectDescription { get; set; }
        public string CustomerName { get; set; }
        public string OrganizationId { get; set; }
        public string SourceLanguage { get; set; }
        public string TargetLanguage { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CompletedAt { get; set; }
        public string CompletedBy { get; set; }
        public int Status { get; set; }
    }
}
