namespace HttpQuery.Contracts.Query
{
    public interface IHttpInclueQuery : IHttpQuery
    {
        IHttpInclueQuery Headers(IDictionary<string, string> headers);
        IHttpInclueQuery Cookies(IDictionary<string, string> cookies);
    }
}
