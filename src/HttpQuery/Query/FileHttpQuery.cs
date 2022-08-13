using HttpQuery.Contracts.Query;

namespace HttpQuery.Query
{
    public class FileHttpQuery : BaseHttpQuery, IFileHttpQuery
    {
        public IHttpQuery Download()
        {
            _httpQueryContext.Method = "GET";
            return this;
        }

        public IHttpQuery Upload()
        {
            _httpQueryContext.Method = "POST";
            return this;
        }
    }
}
