using System.Web;
using HttpQuery.Extensions;
using System.Net.Http.Headers;
using HttpQuery.Contracts.Query;

namespace HttpQuery.Http
{
    public class HttpRequestMessageBuilder
    {
        private readonly IHttpQueryContext _context;

        public HttpRequestMessageBuilder(IHttpQueryContext context)
        {
            _context = context;
        }
        public HttpRequestMessage BuidGet()
        {
            return BuildBaseRequestMessage(HttpMethod.Get);
        }

        private HttpRequestMessage BuildBaseRequestMessage(HttpMethod httpMethod)
        {
            var httpMessage = new HttpRequestMessage()
            {
                RequestUri = BuildUri(),
                Method = httpMethod,
            };
            AddHeaders(httpMessage);
            AddCookies(httpMessage);
            return httpMessage;
        }
        private Uri BuildUri()
        {
            var url = $"{_context.Server}/{_context.Resource}";
            var builder = new UriBuilder(url);
            var query = HttpUtility.ParseQueryString(builder.Query);

            if (_context.Queries != null && _context.Queries.Any())
            {
                foreach (var queryString in _context.Queries)
                {
                    query.Add(queryString.Key, queryString.Value);
                }
            }


            builder.Query = query.ToString();
            return new Uri(builder.ToString());
        }
        private void AddHeaders(HttpRequestMessage message)
        {
            if (_context.Headers == null || _context.Headers.Count == 0)
                return;

            foreach (var header in _context.Headers)
            {
                message.Headers.Add(header.Key, header.Value);
            }
        }
        private void AddCookies(HttpRequestMessage httpMessage)
        {
            if (_context.Cookies == null || _context.Cookies.Count == 0)
                return;
            httpMessage.Headers.Add("Cookie", string.Join(";", _context.Cookies.Select(x => x.Key + "=" + x.Value)));
        }

        public HttpRequestMessage BuidPost()
        {
            return BuildRequestMessageWithContent(HttpMethod.Post);
        }

        private HttpRequestMessage BuildRequestMessageWithContent(HttpMethod httpMethod)
        {
            var httpMessage = BuildBaseRequestMessage(httpMethod);
            httpMessage.Content = BuildContent();
            return httpMessage;
        }

        private HttpContent BuildContent()
        {
            if (_context.Files != null && _context.Files.Any())
                return BuildMultipartContent();
            if (_context.FormParams != null && _context.FormParams.Any())
                return BuildFormContent();
            if (_context.Content != null && !string.IsNullOrEmpty(_context.Content.Content))
                return BuildStringContent();

            return null;
        }
        private HttpContent BuildMultipartContent()
        {
            var content = new MultipartFormDataContent();

            _context.FormParams.ForEach(x => content.Add(new StringContent(x.Value), x.Key.Quote()));

            _context.Files.ForEach(x =>
            {
                var fileContent = new ByteArrayContent(x.Content);
                fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    Name = x.ContentDispositionName.Quote(),
                    FileName = x.FileName
                };
                fileContent.Headers.ContentType = new MediaTypeHeaderValue(x.ContentType);

                content.Add(fileContent);
            });

            return content;
        }

        private HttpContent BuildFormContent()
        {
            return new FormUrlEncodedContent(
                _context.FormParams.Select(x => new KeyValuePair<string, string>(x.Key, x.Value)).ToList());
        }

        private HttpContent BuildStringContent()
        {
            return new StringContent(_context.Content.Content,
                _context.Content.Encoding,
                _context.Content.ContentType);
        }

        public HttpRequestMessage BuidPut()
        {
            return BuildRequestMessageWithContent(HttpMethod.Put);
        }
        public HttpRequestMessage BuidPatch()
        {
            return BuildRequestMessageWithContent(HttpMethod.Patch);
        }
        public HttpRequestMessage BuidDelete()
        {
            return BuildRequestMessageWithContent(HttpMethod.Delete);
        }

    }
}
