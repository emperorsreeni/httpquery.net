using HttpQuery.Contracts.Query;
using HttpQuery.Http;

namespace HttpQuery.Contracts.Client
{
    public interface IDeleteHttpClient
    {
        Task<HttpResponse> Delete(Action<IDeleteHttpQuery> query);
        Task<HttpResponse> Remove(Action<IDeleteHttpQuery> query);
        Task<HttpResponse<T>> Delete<T>(Action<IDeleteHttpQuery> query);
        Task<HttpResponse<T>> Remove<T>(Action<IDeleteHttpQuery> query);
    }
}
