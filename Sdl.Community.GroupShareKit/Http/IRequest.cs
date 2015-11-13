using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Http
{
    public interface IRequest
    {
        object Body { get; set; }
        Dictionary<string, string> Headers { get; }
        HttpMethod Method { get; }
        Dictionary<string, string> Parameters { get; }
        Uri BaseAddress { get; }
        Uri Endpoint { get; }
        TimeSpan Timeout { get; }
        string ContentType { get; }
    }
}
