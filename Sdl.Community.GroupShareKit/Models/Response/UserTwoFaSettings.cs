using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class UserTwoFaSettings
    {
        public Guid UserGuid { get; set; }

        public bool Enabled { get; set; }

        public string AccountSecret { get; set; }

        public string QrCode { get; set; }

        public string ManualCode { get; set; }

        public string BearerToken { get; set; }

        public string OtpSecret { get; set; }
    }
}
