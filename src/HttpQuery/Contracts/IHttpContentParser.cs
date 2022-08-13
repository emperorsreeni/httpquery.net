
namespace HttpQuery.Contracts
{
    public interface IHttpContentParser
    {
        Task<object> ParseAsync<T>(HttpContent content);
    }
}
