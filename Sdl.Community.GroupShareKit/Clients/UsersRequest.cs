using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class UsersRequest :RequestParameters
    {
        public int Page { get; set; }
        public int Start { get; set; }
        public int  Limit { get; set; }

        public UsersRequest(int page,int start, int limit)
        {
            Page = page;
            Start = start;
            Limit = limit;
        }
    }
}
