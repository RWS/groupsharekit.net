namespace Sdl.Community.GroupShareKit.Http
{
    /// <summary>
    /// A response from an API call that includes the deserialized object instance.
    /// </summary>
    public interface IApiResponse<out T>
    {
        /// <summary>
        /// Object deserialized from the JSON response body.
        /// </summary>
        T Body { get; }

        /// <summary>
        /// The original non-deserialized http response.
        /// </summary>
        IResponse HttpResponse { get; }
    }
}