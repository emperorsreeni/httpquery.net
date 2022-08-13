using HttpQuery.Contracts.Query;
using HttpQuery.Http;

namespace HttpQuery.Contracts.Client
{
    public interface IFileHttpClient
    {
        Task<HttpResponse<T>> Upload<T>(Action<IFileHttpQuery> query);
        Task<HttpResponse<T>> Download<T>(Action<IFileHttpQuery> query);
        Task<HttpResponse> Upload(Action<IFileHttpQuery> query);
    }
}
