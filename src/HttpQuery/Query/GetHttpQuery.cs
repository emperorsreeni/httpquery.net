using HttpQuery.Contracts.Query;


namespace HttpQuery.Query
{
    public class GetHttpQuery : BaseHttpQuery, IGetHttpQuery
    {
        public IHttpQuery Fetch()
        {
            return Get();
        }

        public IHttpQuery Get()
        {
            _httpQueryContext.Method = "GET";
            return this;
        }

        public IHttpQuery Read()
        {
            return Get();
        }
    }
}
