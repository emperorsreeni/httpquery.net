using HttpQuery.Contracts.Query;
using HttpQuery.Query;
using System.Text;

namespace HttpQuery.Http
{
    internal class HttpWithQuery : BaseHttpQuery, IHttpWithQuery
    {
        private readonly IHttpQueryContext _httpQueryContext;
        public HttpWithQuery(IHttpQueryContext httpQueryContext)
        {
            _httpQueryContext = httpQueryContext;
        }
        public IHttpWithQuery Content(string body)
        {
            return Content(body, Encoding.UTF8, "application/json");

        }
        public IHttpWithQuery Content(string body, string contentType)
        {
            return Content(body, Encoding.UTF8, contentType);
        }

        public IHttpWithQuery Content(string body, Encoding encoding, string contentType)
        {
            _httpQueryContext.Content = new FluentHttpContent
            {
                Content = body,
                ContentType = contentType,
                Encoding = encoding
            };
            return this;
        }

        public IHttpWithQuery File(FileContent content)
        {
            throw new NotImplementedException();
        }

        public IHttpWithQuery File(FileContent content, Stream stream)
        {
            throw new NotImplementedException();
        }


        public IHttpWithQuery Queries(IDictionary<string, string> queries)
        {
            _httpQueryContext.Queries = queries;
            return this;
        }
        public IHttpWithQuery Form(IDictionary<string, string> formParams)
        {
            _httpQueryContext.FormParams = formParams;
            return this;
        }

    }
}
