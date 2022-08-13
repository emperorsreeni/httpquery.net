using HttpQuery.Contracts.Query;
namespace HttpQuery.Query
{
    public class DeleteHttpQuery : BaseHttpQuery, IDeleteHttpQuery
    {
        public IHttpQuery Delete()
        {
            _httpQueryContext.Method = "DELETE";
            return this;
        }

        public IHttpQuery Remove()
        {
            return Delete();
        }
    }
}
