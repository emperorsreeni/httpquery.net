
using HttpQuery.Contracts;
using HttpQuery.Extensions;

namespace HttpQuery.Http
{
    public class HttpContentFactory
    {
        private static HttpContentFactory _instance;
        public static HttpContentFactory Instance => _instance ?? (_instance = new HttpContentFactory());
       
        public async Task<object> CreateContent<T>(HttpContent content)
        {
            var parser =  CreateParser<T>(content);
            return await parser.ParseAsync<T>(content);
        }

        private static IHttpContentParser CreateParser<T>(HttpContent content)
        {
            if (content.Headers.ContentType.MediaType.Contains("json"))
                return new JsonParser();
            if (content.Headers.ContentType.MediaType.Contains("xml"))
                return new XmlParser();
            if (typeof(T).IsByteArray())
                return new FileStreamParser();
            if (content.Headers.ContentType.MediaType.Contains("text") || typeof(T) == typeof(string))
                return new TextParser();

            return new NullContentParser();
        }
    }
}
