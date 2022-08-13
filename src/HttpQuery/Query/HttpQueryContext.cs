using HttpQuery.Contracts.Query;
using HttpQuery.Http;

namespace HttpQuery.Query
{
    public class HttpQueryContext : IHttpQueryContext
    {
        public string Resource { get;set; }
        public string Method { get; set; }
        public string Server { get; set; }
        public IDictionary<string, string> Queries { get; set; }
        public IDictionary<string, string> Headers { get; set; }
        public IDictionary<string, string> Cookies { get; set; }
        public IDictionary<string, string> FormParams { get; set; }
        public List<FileContent> Files { get; set; }
        public FluentHttpContent Content { get; set; }
    }
}
