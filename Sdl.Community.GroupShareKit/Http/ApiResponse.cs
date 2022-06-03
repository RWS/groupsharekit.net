using Sdl.Community.GroupShareKit.Helpers;

namespace Sdl.Community.GroupShareKit.Http
{
    public class ApiResponse<T> : IApiResponse<T>
    {
        public ApiResponse(IResponse response) : this(response, GetBodyAsObject(response))
        {

        }

        public ApiResponse(IResponse response, T bodyAsObject)
        {
            Ensure.ArgumentNotNull(response, "response");

            HttpResponse = response;
            Body = bodyAsObject;
        }

        private static T GetBodyAsObject(IResponse response)
        {
            var body = response.Body;
            if (body is T t) return t;
            return default;
        }

        public T Body { get; }
        public IResponse HttpResponse { get; }
    }
}
