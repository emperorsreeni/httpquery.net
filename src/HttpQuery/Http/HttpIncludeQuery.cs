using HttpQuery.Contracts.Query;
using HttpQuery.Query;

namespace HttpQuery.Http
{
    internal class HttpIncludeQuery : BaseHttpQuery, IHttpInclueQuery
    {
        private readonly IHttpQueryContext _httpQueryContext;
        public HttpIncludeQuery(IHttpQueryContext httpQueryContext)
        {
            _httpQueryContext = httpQueryContext;
        }
        public IHttpInclueQuery Cookies(IDictionary<string, string> cookies)
        {
            _httpQueryContext.Cookies = cookies;
            return this;
        }

        public IHttpInclueQuery Headers(IDictionary<string, string> headers)
        {
            if (_httpQueryContext.Headers != null && _httpQueryContext.Headers.Count > 0)
            {
                foreach (var header in headers)
                {
                    _httpQueryContext.Headers.Append(header);
                }
            }
            else
                _httpQueryContext.Headers = headers;
            return this;
        }
    }
}
