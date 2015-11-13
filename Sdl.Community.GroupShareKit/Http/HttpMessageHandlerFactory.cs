using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Http
{
    public static class HttpMessageHandlerFactory
    {
        public static HttpMessageHandler CreateDefault()
        {
            return CreateDefault(null);
        }

        public static HttpMessageHandler CreateDefault(IWebProxy proxy)
        {
            var handler = new HttpClientHandler()
            {
                AllowAutoRedirect = false
            };

            if (handler.SupportsAutomaticDecompression)
            {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            }
            if (handler.SupportsProxy && proxy != null)
            {
                handler.UseProxy = true;
                handler.Proxy = proxy;
            }

            return handler;
        }

    }
}
