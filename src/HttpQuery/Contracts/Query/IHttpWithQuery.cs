using HttpQuery.Http;
using System.Text;

namespace HttpQuery.Contracts.Query
{
    public interface IHttpWithQuery : IHttpQuery
    {
        IHttpWithQuery Queries(IDictionary<string, string> queries);
        IHttpWithQuery Content(string body);
        IHttpWithQuery Content(string body, string contentType);
        IHttpWithQuery Content(string body, Encoding encoding, string contentType);
        IHttpWithQuery File(FileContent content);
        IHttpWithQuery File(FileContent content, Stream stream);
    }
}
