using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class MtCloudToken
    {
        public string AccessToken { get; set; }

        public int ValidityInSeconds { get; set; }

        public string TokenType { get; set; }

        public DateTime ExpiresAt { get; set; }
    }
}
