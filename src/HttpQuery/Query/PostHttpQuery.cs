using HttpQuery.Contracts.Query;


namespace HttpQuery.Query
{
    public class PostHttpQuery : BaseHttpQuery, IPostHttpQuery
    {
        public IHttpQuery Create()
        {
            return Post();
        }

        public IHttpQuery Post()
        {
            _httpQueryContext.Method = "POST";
            return this;
        }
    }
}
