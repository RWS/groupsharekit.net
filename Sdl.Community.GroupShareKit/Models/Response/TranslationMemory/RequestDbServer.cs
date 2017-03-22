using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class RequestDbServer
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public RequestDbServer(string name,string description,string userName,string password)
        {
            Name = name;
            Description = description;
            Password = password;
            UserName = userName;

        }
    }
}
