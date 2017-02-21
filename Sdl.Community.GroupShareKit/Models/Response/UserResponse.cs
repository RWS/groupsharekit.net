using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class UserResponse
    {
        public int Count { get; set; }
        public List<UserDetails> Items { get; set; }
    }
}
