using HttpQuery.Contracts.Query;
namespace HttpQuery.Query
{
    public class PutHttpQuery : BaseHttpQuery, IPutHttpQuery
    {
        public IHttpQuery Put()
        {
            _httpQueryContext.Method = "PUT";
            return this;
        }

        public IHttpQuery Replace()
        {
            return Put();
        }

        public IHttpQuery Update()
        {
            return Put();
        }
    }
}
