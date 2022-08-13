using HttpQuery.Contracts.Query;
using HttpQuery.Http;

namespace HttpQuery.Contracts.Client
{
    public interface IGetHttpClient
    {
        Task<HttpResponse<T>> Read<T>(Action<IGetHttpQuery> query);
        Task<HttpResponse<T>> Fetch<T>(Action<IGetHttpQuery> query);
        Task<HttpResponse<T>> Get<T>(Action<IGetHttpQuery> query);
    }
}
