using HttpQuery.Contracts.Query;
using HttpQuery.Http;

namespace HttpQuery.Contracts.Client
{
    public interface IPatchHttpClient
    {
        Task<HttpResponse> UpdatePartial(Action<IPatchHttpQuery> query);
        Task<HttpResponse> Patch(Action<IPatchHttpQuery> query);

        Task<HttpResponse<T>> UpdatePartial<T>(Action<IPatchHttpQuery> query);
        Task<HttpResponse<T>> Patch<T>(Action<IPatchHttpQuery> query);
    }
}
