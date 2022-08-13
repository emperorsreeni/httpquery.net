
using HttpQuery.Http;

namespace HttpQuery.Contracts.Query
{
    public interface IHttpQueryContext
    {
        string Resource { get; set; }
        string Method { get; set; }
        string Server { get; set; }
        IDictionary<string,string> Queries { get; set; }
        IDictionary<string, string> Headers { get; set; }
        IDictionary<string, string> Cookies { get; set; }
        IDictionary<string, string> FormParams { get; set; }
        FluentHttpContent Content { get; set; }
        List<FileContent> Files { get; set; }
    }
}
