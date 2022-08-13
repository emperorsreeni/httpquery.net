using HttpQuery.Contracts;

namespace HttpQuery.Http
{
    public class NullContentParser : IHttpContentParser
    {
        public Task<object> ParseAsync<T>(HttpContent content)
        {
            return null;
        }
    }
}
