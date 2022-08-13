using HttpQuery.Contracts;
using Newtonsoft.Json;

namespace HttpQuery.Http
{
    public class JsonParser : IHttpContentParser
    {
        public async Task<object> ParseAsync<T>(HttpContent content)
        {
           var json = await content.ReadAsStringAsync();
           return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
