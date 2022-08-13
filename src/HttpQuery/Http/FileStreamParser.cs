using HttpQuery.Contracts;

namespace HttpQuery.Http
{
    public class FileStreamParser : IHttpContentParser
    {
        public async Task<object> ParseAsync<T>(HttpContent content)
        {
            return await content.ReadAsByteArrayAsync();
        }
    }
}
