using HttpQuery.Contracts;
using System.Xml.Serialization;

namespace HttpQuery.Http
{
    public class XmlParser : IHttpContentParser
    {
        public async Task<object> ParseAsync<T>(HttpContent content)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var stream = await content.ReadAsStreamAsync())
            {
              return serializer.Deserialize(stream);
            }
        }
    }
}
