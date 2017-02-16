using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class SortParameters
    {
        public PropertyOption Property { get; set; }
        public DirectionOption Direction{ get; set; }
        public enum PropertyOption
        {
            ProjectName,
            CreatedAt,
            DueDate,
            CustomerName,
            Status,
            SourceLanguage,
            OrganizationPath
        }

       public  enum DirectionOption
        {
            ASC,
            DESC
        }
    }
}
