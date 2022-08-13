using HttpQuery.Contracts.Query;

namespace HttpQuery.Query
{
    public class VerbHttpQuery : BaseHttpQuery, IVerbHttpQuery
    {
        public IHttpQuery Head()
        {
            return Verb("HEAD");
        }

        public IHttpQuery Options()
        {
            return Verb("OPTIONS");
        }

        public IHttpQuery Verb(string method)
        {
            _httpQueryContext.Method = method.ToUpper();
            return this;
        }

    }
}
