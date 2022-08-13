namespace HttpQuery.Http
{
    public class HttpResponseParser
    {
        private readonly HttpResponseMessage _message;

        public HttpResponseParser(HttpResponseMessage message)
        {
            _message = message;
        }

        public HttpResponse Parse()
        {
            HttpResponse response = null;
            try
            {
                response = new HttpResponse
                {
                    Status = (int)_message.StatusCode,
                    StatusMessage = _message.ReasonPhrase,
                    Headers = ExtractHeaders(),
                    Cookies = ExtractCookies()
                };
            }
            finally
            {
                _message.Dispose();
            }
           
            return response;
        }

        public async Task<HttpResponse<T>> ParseAsync<T>()
        {
            HttpResponse<T> response = null;
            try
            {
                response = new HttpResponse<T>
                {
                    Status = (int)_message.StatusCode,
                    StatusMessage = _message.ReasonPhrase,
                    Headers = ExtractHeaders(),
                    Cookies = ExtractCookies(),
                    Content = (T)await ExtractContent<T>()

                };
            }
            finally
            {
                _message.Dispose();
            }
            
            return response;
        }
        private Dictionary<string, string?> ExtractHeaders() => _message.Headers.Where(x => x.Key.ToLower() != "set-cookie")
                .ToDictionary(x => x.Key, x => x.Value.Select(v => string.Join(", ", v)).FirstOrDefault());
        private List<System.Net.Cookie> ExtractCookies()
        {
            IEnumerable<string> cookies;
            _message.Headers.TryGetValues("Set-Cookie", out cookies);
            if (cookies == null || cookies.Count() == 0)
                return new List<System.Net.Cookie>();
            var cookieHeader = string.Join(", ", cookies);
            var cookieParser = new CookieParser(cookieHeader);

            return cookieParser.Parse().ToList();
        }

        private async Task<object> ExtractContent<T>()
        {
            return await HttpContentFactory.Instance.CreateContent<T>(_message.Content);
        }
    }
}
