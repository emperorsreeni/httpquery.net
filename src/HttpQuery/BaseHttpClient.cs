using HttpQuery.Contracts.Query;
using HttpQuery.Extensions;
using HttpQuery.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace HttpQuery
{
    public abstract class BaseHttpClient
    {
        protected readonly ILogger _logger;
        protected HttpClient _httpClient;
        
        public BaseHttpClient(ILogger logger)
        {
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                UseCookies = false,
            };
            _httpClient = new HttpClient(handler,true);
            _logger = logger;
        }
        public BaseHttpClient(HttpClient httpClient, ILogger logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        protected async Task<HttpResponse> ExecuteQuery(IHttpQuery query)
        {
            return await HandleException(async () => {
                var builder = (IRequestBuilder)query;
                var requestMessage = builder.Build();
                _logger.LogIfDebug("request message build and initiating the server request");
                var response = await _httpClient.SendAsync(requestMessage);
                _logger.LogIfDebug($"response recieved with status code {(int)response.StatusCode}, response header count is {response.Headers.Count()} and content type is {response.Content?.Headers?.ContentType}");
                var responseBuilder = new HttpResponseBuilder(response);
                var result = responseBuilder.Build();
                _logger.LogIfDebug("reponse extracted from the http response");
                return result;
            });
            
        }
        protected async Task ExecuteQuery(IHttpQuery query,Action<HttpResponseMessage> callback)
        {
            await HandleException(async () =>
            {
                var builder = (IRequestBuilder)query;
                var requestMessage = builder.Build();
                _logger.LogIfDebug("request message build and initiating the server request");
                var response = await _httpClient.SendAsync(requestMessage);
                _logger.LogIfDebug($"response recieved with status code {(int)response.StatusCode}, response header count is {response.Headers.Count()} and content type is {response.Content?.Headers?.ContentType}");
                _logger.LogIfDebug("call back method about to call");
                callback(response);
                _logger.LogIfDebug("call back method completed");
            });
        }
        protected async Task<HttpResponse<T>> ExecuteQuery<T>(IHttpQuery query)
        {
            return await HandleException(async () =>
            {
                var builder = (IRequestBuilder)query;
                var requestMessage = builder.Build();
                var response = await _httpClient.SendAsync(requestMessage);
                _logger.LogIfDebug($"response recieved with status code {(int)response.StatusCode}, response header count is {response.Headers.Count()} and content type is {response.Content?.Headers?.ContentType}");
                _logger.LogIfDebug("call back method completed");
                var responseBuilder = new HttpResponseBuilder(response);
                var result = await responseBuilder.Build<T>();
                _logger.LogIfDebug("reponse extracted from the http response");
                return result;
            });
        }

        private async Task<T> HandleException<T>(Func<Task<T>> action)
        {
            try
            {
                return await action();
            }
            catch (Exception ex)
            {
                _logger.LogIfError(ex);
                throw;
            }
        }

        private async Task HandleException(Func<Task> action)
        {
            try
            {
                await action();
            }
            catch (Exception ex)
            {
                _logger.LogIfError(ex);
                throw;
            }
        }
    }
}
