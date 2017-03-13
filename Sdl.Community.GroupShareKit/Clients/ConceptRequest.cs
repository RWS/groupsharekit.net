using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Clients
{
   public  class ConceptRequest:RequestParameters
    {
       public string TermbaseId { get; set; }
       public string ConceptId { get; set; }

       public ConceptRequest(string termbaseId,string conceptId)
       {
           TermbaseId = termbaseId;
           ConceptId = conceptId;

       }
    }
}
