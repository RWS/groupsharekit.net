using System.Collections.Generic;

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
