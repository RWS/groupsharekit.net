using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
   public  class PhasesWithAssignees
    {
       public string   FileUniqueId { get; set; }
       public string FileName { get; set; }
       public int Status { get; set; }
       public string StatusName { get; set; }
       public int PrecetComplete { get; set; }
       public string LanguageCode { get; set; }
       public int CurrentPhaseId { get; set; }
       public DateTime? DueDate { get; set; }
       public List<Phase> Phases { get; set; }
    }
}
