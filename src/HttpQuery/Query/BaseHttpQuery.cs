using HttpQuery.Contracts.Query;
using HttpQuery.Extensions;
using HttpQuery.Http;

namespace HttpQuery.Query
{
    public abstract class BaseHttpQuery : IHttpQuery, IRequestBuilder
    {
        protected readonly IHttpQueryContext _httpQueryContext;
        protected BaseHttpQuery()
        {
            _httpQueryContext = new HttpQueryContext();
            With = new HttpWithQuery(_httpQueryContext);
            Include = new HttpIncludeQuery(_httpQueryContext);
        }
        public IHttpWithQuery With { get; set; }
        public IHttpInclueQuery Include { get; set; }

        public HttpRequestMessage Build()
        {
            return _httpQueryContext.ToRequestMessage();
        }

        public IHttpQuery From(string resourceServer)
        {
            _httpQueryContext.Server = resourceServer;
            return this;
        }
        public IHttpQuery On(string resourceServer)
        {
            return From(resourceServer);
        }
        public IHttpQuery Resource(string resource)
        {
            _httpQueryContext.Resource = resource;
            return this;
        }
        public IHttpQuery To(string resourceServer)
        {
            return From(resourceServer);
        }

    }
}
