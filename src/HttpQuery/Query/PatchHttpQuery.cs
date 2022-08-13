using HttpQuery.Contracts.Query;

namespace HttpQuery.Query
{
    public class PatchHttpQuery : BaseHttpQuery, IPatchHttpQuery
    {
        public IHttpQuery Patch()
        {
            _httpQueryContext.Method = "PATCH";
            return this;
        }

        public IHttpQuery UpdatePartial(string url)
        {
            return Patch();
        }
    }
}
