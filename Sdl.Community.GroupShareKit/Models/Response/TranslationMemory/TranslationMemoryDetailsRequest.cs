using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class TranslationMemoryDetailsRequest
    {
        public Guid TmId { get; set; }
        public int StartTuId { get; set; }
        public int Count { get; set; }

        public TranslationMemoryDetailsRequest(Guid id, int startTuId,int count)
        {
            TmId = id;
            StartTuId = startTuId;
            Count = count;
        }
    }
}
