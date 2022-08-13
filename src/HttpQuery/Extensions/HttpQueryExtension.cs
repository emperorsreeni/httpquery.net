using HttpQuery.Contracts.Query;
using HttpQuery.Http;


namespace HttpQuery.Extensions
{
    public static class HttpQueryExtension
    {
        public static HttpRequestMessage ToRequestMessage(this IHttpQueryContext httpQueryContext)
        {
            return HttpRequestMessageFactory.Instance.Create(httpQueryContext);
        }


    }
}
