using System.Text;

namespace HttpQuery.Http
{
    public class FluentHttpContent
    {
        public string ContentType { get; set; }
        public string Content { get; set; }
        public Encoding Encoding { get; set; }
    }
}
