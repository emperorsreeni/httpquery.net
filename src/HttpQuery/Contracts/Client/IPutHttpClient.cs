using HttpQuery.Contracts.Query;
using HttpQuery.Http;

namespace HttpQuery.Contracts.Client
{
    public interface IPutHttpClient
    {
        Task<HttpResponse> Update(Action<IPutHttpQuery> query);
        Task<HttpResponse> Replace(Action<IPutHttpQuery> query);
        Task<HttpResponse> Put(Action<IPutHttpQuery> query);

        Task<HttpResponse<T>> Update<T>(Action<IPutHttpQuery> query);
        Task<HttpResponse<T>> Replace<T>(Action<IPutHttpQuery> query);
        Task<HttpResponse<T>> Put<T>(Action<IPutHttpQuery> query);
    }
}
