using HttpQuery.Contracts.Query;
using HttpQuery.Http;

namespace HttpQuery.Contracts.Client
{
    public interface IPostHttpClient
    {
        Task<HttpResponse> Create(Action<IPostHttpQuery> query);
        Task<HttpResponse> Post(Action<IPostHttpQuery> query);

        Task<HttpResponse<T>> Create<T>(Action<IPostHttpQuery> query);
        Task<HttpResponse<T>> Post<T>(Action<IPostHttpQuery> query);

    }
}
