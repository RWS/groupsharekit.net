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
        /// <summary>
        /// Gets or sets number of pages to be displayed
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// Gets or sets the start page
        /// </summary>
        public int Start { get; set; }
        /// <summary>
        /// Gets or sets max number of users per page
        /// </summary>
        public int  Limit { get; set; }

        public UsersRequest(int page,int start, int limit)
        {
            Page = page;
            Start = start;
            Limit = limit;
        }
    }
}
