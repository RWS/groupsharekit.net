using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class UserTwoFaEnforcementStatus
    {
        public Guid UserGuid { get; set; }

        public bool Require2FA { get; set; }
    }
}
