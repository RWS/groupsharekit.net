using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using Sdl.Community.GroupShareKit.Helpers;

namespace Sdl.Community.GroupShareKit.Http
{
    public class Response : IResponse
    {

        public Response() : this(new Dictionary<string, string>())
        {

        }

        public Response(IDictionary<string, string> headers)
        {
            Ensure.ArgumentNotNull(headers, "headers");

            Headers = new ReadOnlyDictionary<string, string>(headers);
        }

        public Response(HttpStatusCode statusCode, object body, IDictionary<string, string> headers, string contentType)
        {
            Ensure.ArgumentNotNull(headers, "headers");

            StatusCode = statusCode;
            Body = body;
            Headers = new ReadOnlyDictionary<string, string>(headers);
            ContentType = contentType;
        }
        public object Body { get; }
        public IReadOnlyDictionary<string, string> Headers { get; }
        public HttpStatusCode StatusCode { get; }
        public string ContentType { get; }
    }
}