using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Sdl.Community.GroupShareKit.Helpers;

namespace Sdl.Community.GroupShareKit.Http
{
    /// <summary>
    /// Generic Http client. Useful for those who want to swap out System.Net.HttpClient with something else.
    /// </summary>
    /// <remarks>
    /// Most folks won't ever need to swap this out. But if you're trying to run this on Windows Phone, you might.
    /// </remarks>
    public class HttpClientAdapter: IHttpClient
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        /// <summary>
        /// Constructor for the Http adapter
        /// </summary>
        /// <param name="getHandler"></param>
        public HttpClientAdapter(Func<HttpMessageHandler> getHandler)
        {
            Ensure.ArgumentNotNull(getHandler,"getHandler");
        }

        public async Task<IResponse> Send(IRequest request, CancellationToken cancellationToken)
        {
            Ensure.ArgumentNotNull(request,"request");

            using (var requestMessage = BuildRequestMessage(request))
            {
                var responseMessage = await _httpClient
                    .SendAsync(requestMessage, HttpCompletionOption.ResponseContentRead, cancellationToken)
                    .ConfigureAwait(false);

                return await BuildRespose(responseMessage).ConfigureAwait(false);
            }
        }

        protected virtual async Task<IResponse> BuildRespose(HttpResponseMessage responseMessage)
        {
            Ensure.ArgumentNotNull(responseMessage,"responseMessage");

            object responseBody = null;
            string contentType = null;
            using (var content = responseMessage.Content)
            {
                if (content != null)
                {
                    contentType = GetContentMediaType(responseMessage.Content);

                    if (contentType != null && (contentType.StartsWith("image/")
                                            ||
                                                contentType.Equals("application/zip",
                                                    StringComparison.OrdinalIgnoreCase)
                                            ||
                                                contentType.Equals("application/x-gzip",
                                                    StringComparison.OrdinalIgnoreCase)
                                            ||
                                                contentType.Equals("application/xml",
                                                    StringComparison.OrdinalIgnoreCase)
                                            ||
                                                contentType.Equals("application/octet-stream")
                                                ))
                    {
                        responseBody = await responseMessage.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
                    }
                    else
                    {
                        responseBody = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                    }
                }
            }

            return new Response(responseMessage.StatusCode,
                responseBody,
                responseMessage.Headers.ToDictionary(h => h.Key, h => h.Value.First()),
                contentType);
        }

        private string GetContentMediaType(HttpContent content)
        {
            if (content.Headers != null && content.Headers.ContentType != null)
            {
                return content.Headers.ContentType.MediaType;
            }
            return null;
        }

        private HttpRequestMessage BuildRequestMessage(IRequest request)
        {
            Ensure.ArgumentNotNull(request,"request");
            HttpRequestMessage requestMessage = null;
            try
            {
                var fullUri = new Uri(request.BaseAddress, request.Endpoint);
                requestMessage = new HttpRequestMessage(request.Method, fullUri);

                foreach (var header in request.Headers)
                {
                    requestMessage.Headers.Add(header.Key, header.Value);
                }
                var httpContent = request.Body as HttpContent;
                if (httpContent != null)
                {
                    requestMessage.Content = httpContent;
                }
                var body = request.Body as string;
                if (body != null)
                {
                    requestMessage.Content = new StringContent(body, Encoding.UTF8, request.ContentType);
                }
                else
                { 
                    // for Get methods to set accept header for analyse report as html
                    if (!string.IsNullOrEmpty(request.ContentType))
                    {
                        requestMessage.Headers.Add("Accept", request.ContentType);
                    }
                    
                }

                var bodyStream = request.Body as Stream;
                if (bodyStream != null)
                {
                    requestMessage.Content= new StreamContent(bodyStream);
                    requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue(request.ContentType);
                }
            }
            catch (Exception)
            {
                requestMessage?.Dispose();
                throw;
            }

            return requestMessage;
        }

        private CancellationToken GetCancellationForRequest(IRequest request, CancellationToken cancellationToken)
        {
            var cancellationTokenForRequest = cancellationToken;

            if (request.Timeout != TimeSpan.Zero)
            {
                var timeoutCancellation = new CancellationTokenSource(request.Timeout);
                var unifiedCancellationToken = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken,
                    timeoutCancellation.Token);

                cancellationTokenForRequest = unifiedCancellationToken.Token;
            }

            return cancellationTokenForRequest;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _httpClient?.Dispose();
            }
        }

    }

    internal class RedirectHandler : DelegatingHandler
    {
        public const string RedirectCountKey = "RedirectCount";
        public bool Enabled { get; set; }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

            // Can't redirect without somewhere to redirect too.  Throw?
            if (response.Headers.Location == null) return response;

            // Don't redirect if we exceed max number of redirects
            var redirectCount = 0;
            if (request.Properties.Keys.Contains(RedirectCountKey))
            {
                redirectCount = (int)request.Properties[RedirectCountKey];
            }
            if (redirectCount > 3)
            {
                throw new InvalidOperationException("The redirect count for this request has been exceeded. Aborting.");
            }

            request.Properties[RedirectCountKey] = ++redirectCount;

            if (response.StatusCode == HttpStatusCode.MovedPermanently
                        || response.StatusCode == HttpStatusCode.Redirect
                        || response.StatusCode == HttpStatusCode.Found
                        || response.StatusCode == HttpStatusCode.SeeOther
                        || response.StatusCode == HttpStatusCode.TemporaryRedirect
                        || (int)response.StatusCode == 308)
            {
                var newRequest = CopyRequest(response.RequestMessage);

                if (response.StatusCode == HttpStatusCode.SeeOther)
                {
                    newRequest.Content = null;
                    newRequest.Method = HttpMethod.Get;
                }
                else
                {
                    if (request.Content != null && request.Content.Headers.ContentLength != 0)
                    {
                        var stream = await request.Content.ReadAsStreamAsync();
                        if (stream.CanSeek)
                        {
                            stream.Position = 0;
                        }
                        else
                        {
                            throw new Exception("Cannot redirect a request with an unbuffered body");
                        }
                        newRequest.Content = new StreamContent(stream);
                    }
                }
                newRequest.RequestUri = response.Headers.Location;
                if (String.Compare(newRequest.RequestUri.Host, request.RequestUri.Host, StringComparison.OrdinalIgnoreCase) != 0)
                {
                    newRequest.Headers.Authorization = null;
                }
                response = await this.SendAsync(newRequest, cancellationToken);
            }

            if (response.StatusCode == HttpStatusCode.Created)
            {
                response.Content = new StringContent(response.Headers.Location.ToString());
            }

            return response;
        }

        private static HttpRequestMessage CopyRequest(HttpRequestMessage oldRequest)
        {
            var newRequest = new HttpRequestMessage(oldRequest.Method, oldRequest.RequestUri);

            foreach (var header in oldRequest.Headers)
            {
                newRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
            foreach (var property in oldRequest.Properties)
            {
                newRequest.Properties.Add(property);
            }

            return newRequest;
        }
    }
}
