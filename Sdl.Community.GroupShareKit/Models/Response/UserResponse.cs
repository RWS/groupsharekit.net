using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class UserResponse
    {
        /// <summary>
        /// Gets or sets the users number
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the users list <see cref="UserDetails"/>
        /// </summary>
        public List<UserDetails> Items { get; set; }
    }
}
