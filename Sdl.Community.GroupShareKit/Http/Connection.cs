using Sdl.Community.GroupShareKit.Authentication;
using Sdl.Community.GroupShareKit.Exceptions;
using Sdl.Community.GroupShareKit.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Http
{
    public class Connection : IConnection
    {
        readonly Authenticator _authenticator;
        readonly JsonHttpPipeline _jsonPipeline;
        readonly IHttpClient _httpClient;

        /// <summary>
        /// Creates a new connection instance used to make requests of the GroupShare API.
        /// </summary>
        /// <param name="baseAddress">
        /// The address to point this client to such as http://sdldevelopmentpartners.sdlproducts.com </param>
        /// <param name="credentialStore">Provides credentials to the client when making requests</param>
        public Connection(Uri baseAddress, ICredentialStore credentialStore)
            : this(baseAddress, credentialStore, new HttpClientAdapter(HttpMessageHandlerFactory.CreateDefault), new SimpleJsonSerializer())
        {
        }

        /// <summary>
        /// Creates a new connection instance used to make requests of the GroupShare API.
        /// </summary>
        /// <param name="baseAddress">
        /// The address to point this client to such as http://sdldevelopmentpartners.sdlproducts.com </param>
        /// <param name="credentialStore">Provides credentials to the client when making requests</param>
        /// <param name="httpClient">A raw <see cref="IHttpClient"/> used to make requests</param>
        /// <param name="serializer">Class used to serialize and deserialize JSON requests</param>
        public Connection(
            Uri baseAddress,
            ICredentialStore credentialStore,
            IHttpClient httpClient,
            IJsonSerializer serializer)
        {
            Ensure.ArgumentNotNull(baseAddress, "baseAddress");
            Ensure.ArgumentNotNull(credentialStore, "credentialStore");
            Ensure.ArgumentNotNull(httpClient, "httpClient");
            Ensure.ArgumentNotNull(serializer, "serializer");

            if (!baseAddress.IsAbsoluteUri)
            {
                throw new ArgumentException(
                    string.Format(CultureInfo.InvariantCulture, "The base address '{0}' must be an absolute URI",
                        baseAddress), nameof(baseAddress));
            }

            UserAgent = FormatUserAgent();
            BaseAddress = baseAddress;
            CredentialStore = credentialStore;
            _authenticator = new Authenticator(credentialStore);
            _httpClient = httpClient;
            _jsonPipeline = new JsonHttpPipeline();
        }

        private string FormatUserAgent()
        {
            return string.Format(CultureInfo.InvariantCulture,
                "({0} {1}; {2}; {3}; GroupShare kit)", "WindowsRT",
                "8+",
                "unknown", CultureInfo.CurrentCulture.Name);
        }

        public Task<IApiResponse<T>> Get<T>(Uri uri, IDictionary<string, string> parameters)
        {
            Ensure.ArgumentNotNull(uri, "uri");

            return SendData<T>(uri.ApplyParameters(parameters), HttpMethod.Get, null, null, CancellationToken.None);
        }

        public Task<IApiResponse<T>> Get<T>(Uri uri, string contentType)
        {
            Ensure.ArgumentNotNull(uri, "uri");
            return SendData<T>(uri, HttpMethod.Get, null, contentType, CancellationToken.None);
        }


        public Task<IApiResponse<T>> Get<T>(Uri uri, TimeSpan timeout)
        {
            Ensure.ArgumentNotNull(uri, "uri");

            return SendData<T>(uri, HttpMethod.Get, null, null, timeout, CancellationToken.None);
        }

        public async Task<HttpStatusCode> Post(Uri uri)
        {
            Ensure.ArgumentNotNull(uri, "uri");

            var response = await SendData<object>(uri, HttpMethod.Post, null, null, CancellationToken.None);
            return response.HttpResponse.StatusCode;
        }

        public Task<IApiResponse<T>> Post<T>(Uri uri, object body, string contentType)
        {
            Ensure.ArgumentNotNull(uri, "uri");

            return SendData<T>(uri, HttpMethod.Post, body, contentType, CancellationToken.None);
        }

        public Task<IApiResponse<T>> Post<T>(string uri, object body, string contentType)
        {
            Ensure.ArgumentNotNull(uri, "uri");

            return SendData<T>(uri, HttpMethod.Post, body, contentType, CancellationToken.None);
        }

        public Task<IApiResponse<T>> Post<T>(Uri uri, object body, string contentType, TimeSpan timeout)
        {
            Ensure.ArgumentNotNull(uri, "uri");

            return SendData<T>(uri, HttpMethod.Post, body, contentType, timeout, CancellationToken.None);
        }

        public Task<IApiResponse<T>> Post<T>(Uri uri)
        {
            Ensure.ArgumentNotNull(uri, "uri");

            return SendData<T>(uri, HttpMethod.Post, null, null, CancellationToken.None);
        }
        public Task<IApiResponse<T>> Put<T>(Uri uri, object body)
        {
            Ensure.ArgumentNotNull(uri, "uri");

            return SendData<T>(uri, HttpMethod.Put, body, "application/json", CancellationToken.None);
        }

        public async Task<HttpStatusCode> Put(Uri uri)
        {
            Ensure.ArgumentNotNull(uri, "uri");

            var response = await SendData<object>(uri, HttpMethod.Put, null, null, CancellationToken.None);
            return response.HttpResponse.StatusCode;
        }

        public async Task<HttpStatusCode> Patch(Uri uri, object body, string contentType)
        {
            Ensure.ArgumentNotNull(uri, "uri");
            var method = new HttpMethod("PATCH");
            var response = await SendData<object>(uri, method, body, null, CancellationToken.None);
            return response.HttpResponse.StatusCode;
        }

        public async Task<HttpStatusCode> Delete(Uri uri)
        {
            Ensure.ArgumentNotNull(uri, "uri");

            var request = new Request
            {
                Method = HttpMethod.Delete,
                BaseAddress = BaseAddress,
                Endpoint = uri
            };

            var response = await Run<object>(request, CancellationToken.None);
            return response.HttpResponse.StatusCode;
        }

        public async Task<HttpStatusCode> Delete(Uri uri, object data)
        {
            Ensure.ArgumentNotNull(uri, "uri");
            Ensure.ArgumentNotNull(data, "data");

            var request = new Request
            {
                Method = HttpMethod.Delete,
                Body = data,
                BaseAddress = BaseAddress,
                Endpoint = uri
            };

            var response = await Run<object>(request, CancellationToken.None);
            return response.HttpResponse.StatusCode;
        }

        public async Task<HttpStatusCode> Delete(Uri uri, object data, string contentType)
        {
            Ensure.ArgumentNotNull(uri, "uri");
            Ensure.ArgumentNotNull(data, "data");

            var request = new Request
            {
                Method = HttpMethod.Delete,
                Body = data,
                BaseAddress = BaseAddress,
                Endpoint = uri,
                ContentType = contentType
            };

            var response = await Run<object>(request, CancellationToken.None);
            return response.HttpResponse.StatusCode;
        }


        private Task<IApiResponse<T>> SendData<T>(Uri uri, HttpMethod method, object body, string contentType,
            TimeSpan timeout,
            CancellationToken cancellationToken, Uri baseAddress = null)
        {
            Ensure.ArgumentNotNull(uri, "uri");
            var request = new Request
            {
                Method = method,
                BaseAddress = baseAddress ?? BaseAddress,
                Endpoint = uri,
                Timeout = timeout
            };

            return SendDataInternal<T>(body, contentType, cancellationToken, request);
        }

        private Task<IApiResponse<T>> SendData<T>(Uri uri, HttpMethod method, object body, string contentType,
            CancellationToken cancellationToken, Uri baseAddress = null)
        {
            Ensure.ArgumentNotNull(uri, "uri");
            var request = new Request
            {
                Method = method,
                BaseAddress = baseAddress ?? BaseAddress,
                Endpoint = uri,
                ContentType = contentType
            };

            return SendDataInternal<T>(body, contentType, cancellationToken, request);
        }

        private Task<IApiResponse<T>> SendData<T>(string uri, HttpMethod method, object body, string contentType,
            CancellationToken cancellationToken, Uri baseAddress = null)
        {
            Ensure.ArgumentNotNull(uri, "uri");
            baseAddress = baseAddress ?? BaseAddress;
            var request = new Request
            {
                Method = method,
                BaseAddress = baseAddress,
                Endpoint = baseAddress == null ? new Uri(uri) : new Uri(baseAddress, uri),
                ContentType = contentType
            };

            return SendDataInternal<T>(body, contentType, cancellationToken, request);
        }

        private Task<IApiResponse<T>> SendDataInternal<T>(object body, string contentType, CancellationToken cancellationToken, Request request)
        {
            if (body == null) return Run<T>(request, cancellationToken);
            request.Body = body;
            request.ContentType = contentType ?? "application/x-www-form-urlencoded";

            return Run<T>(request, cancellationToken);
        }

        private async Task<IApiResponse<T>> Run<T>(Request request, CancellationToken cancellationToken)
        {
            _jsonPipeline.SerializeRequest(request);
            var response = await RunRequest(request, CancellationToken.None).ConfigureAwait(false);
            return _jsonPipeline.DeserializeResponse<T>(response);
        }

        private async Task<IResponse> RunRequest(Request request, CancellationToken cancellationToken)
        {
            request.Headers.Add("User-Agent", UserAgent);

            await _authenticator.Apply(request).ConfigureAwait(false);

            var response = await _httpClient.Send(request, cancellationToken).ConfigureAwait(false);
            HandleErrors(response);
            return response;
        }

        static readonly Dictionary<HttpStatusCode, Func<IResponse, Exception>> HttpExceptionMap =
           new Dictionary<HttpStatusCode, Func<IResponse, Exception>>
           {
                { HttpStatusCode.Unauthorized, response => new AuthorizationException(response) },
                { HttpStatusCode.Forbidden, response =>  new ForbiddenException(response)},
                { HttpStatusCode.NotFound, response => new NotFoundException(response) },
                { (HttpStatusCode)422, response => new ApiValidationException(response) }
           };

        static void HandleErrors(IResponse response)
        {
            Func<IResponse, Exception> exceptionFunc;
            if (HttpExceptionMap.TryGetValue(response.StatusCode, out exceptionFunc))
            {
                throw exceptionFunc(response);
            }

            if ((int)response.StatusCode >= 400)
            {
                throw new ApiException(response);
            }
        }

        public Uri BaseAddress { get; }
        public ICredentialStore CredentialStore { get; }

        public Credentials Credentials
        {
            get
            {
                var credentialTask = CredentialStore.GetCredentials();
                return credentialTask.Result;
            }
            set
            {
                Ensure.ArgumentNotNull(value, "value");

                _authenticator.CredentialStore = new InMemoryCredentialStore(value);
            }
        }

        public string UserAgent { get; private set; }

    }
}