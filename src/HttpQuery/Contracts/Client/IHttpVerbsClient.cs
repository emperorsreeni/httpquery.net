using HttpQuery.Contracts.Query;
using HttpQuery.Http;

namespace HttpQuery.Contracts.Client
{
    public interface IHttpVerbsClient
    {
        Task<HttpResponse> Head(Action<IVerbHttpQuery> query);
        Task<HttpResponse> Options(Action<IVerbHttpQuery> query);
        Task<HttpResponse> Do(Action<IVerbHttpQuery> query);
    }
}
