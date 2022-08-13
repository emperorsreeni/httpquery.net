using HttpQuery.Contracts.Client;
using HttpQuery.Contracts.Query;
using HttpQuery.Http;
using HttpQuery.Query;
using Microsoft.Extensions.Logging;

namespace HttpQuery
{
    public class HttpQueryClient : BaseHttpClient, IHttpQueryClient
    {
        public HttpQueryClient(ILogger logger) : base(logger)
        {
                        
        }
        public HttpQueryClient(HttpClient httpClient, ILogger logger) : base(httpClient,logger)
        {
            
        }
        public Task<HttpResponse> Create(Action<IPostHttpQuery> query)
        {
            return Post(query);
        }

        public Task<HttpResponse<T>> Create<T>(Action<IPostHttpQuery> query)
        {
            return Post<T>(query);
        }

        public Task<HttpResponse> Delete(Action<IDeleteHttpQuery> query)
        {
            var httpQuery = new DeleteHttpQuery();
            query(httpQuery);
            return ExecuteQuery(httpQuery);
        }

        public Task<HttpResponse<T>> Delete<T>(Action<IDeleteHttpQuery> query)
        {
            var httpQuery = new DeleteHttpQuery();
            query(httpQuery);
            return ExecuteQuery<T>(httpQuery);
        }

        public Task<HttpResponse> Do(Action<IVerbHttpQuery> query)
        {
            var httpQuery = new VerbHttpQuery();
            query(httpQuery);
            return ExecuteQuery(httpQuery);
        }

        public Task<HttpResponse<T>> Download<T>(Action<IFileHttpQuery> query)
        {
            var httpQuery = new FileHttpQuery();
            query(httpQuery);
            return ExecuteQuery<T>(httpQuery);
        }

        public Task<HttpResponse<T>> Execute<T>(IHttpQuery httpQuery)
        {
            return ExecuteQuery<T>(httpQuery);
        }

        public Task Execute(IHttpQuery httpQuery,Action<HttpResponseMessage> callback)
        {
            return ExecuteQuery(httpQuery, callback);
        }

        public Task<HttpResponse<T>> Fetch<T>(Action<IGetHttpQuery> query)
        {
            return Get<T>(query);
        }

        public Task<HttpResponse<T>> Get<T>(Action<IGetHttpQuery> query)
        {
            var httpQuery = new GetHttpQuery();
            query(httpQuery);
            return ExecuteQuery<T>(httpQuery);
        }

        public Task<HttpResponse> Head(Action<IVerbHttpQuery> query)
        {
            return Do(query);
        }

        public Task<HttpResponse> Options(Action<IVerbHttpQuery> query)
        {
            return Do(query);
        }

        public Task<HttpResponse> Patch(Action<IPatchHttpQuery> query)
        {
            var httpQuery = new PatchHttpQuery();
            query(httpQuery);
            return ExecuteQuery(httpQuery);
        }

        public Task<HttpResponse<T>> Patch<T>(Action<IPatchHttpQuery> query)
        {
            var httpQuery = new PatchHttpQuery();
            query(httpQuery);
            return ExecuteQuery<T>(httpQuery);
        }

        public Task<HttpResponse> Post(Action<IPostHttpQuery> query)
        {
            var httpQuery = new PostHttpQuery();
            query(httpQuery);
            return ExecuteQuery(httpQuery);
        }

        public Task<HttpResponse<T>> Post<T>(Action<IPostHttpQuery> query)
        {
            var httpQuery = new PostHttpQuery();
            query(httpQuery);
            return ExecuteQuery<T>(httpQuery);
        }

        public Task<HttpResponse> Put(Action<IPutHttpQuery> query)
        {
            var httpQuery = new PutHttpQuery();
            query(httpQuery);
            return ExecuteQuery(httpQuery);
        }

        public Task<HttpResponse<T>> Put<T>(Action<IPutHttpQuery> query)
        {
            var httpQuery = new PutHttpQuery();
            query(httpQuery);
            return ExecuteQuery<T>(httpQuery);
        }

        public Task<HttpResponse<T>> Read<T>(Action<IGetHttpQuery> query)
        {
            return Get<T>(query);
        }

        public Task<HttpResponse> Remove(Action<IDeleteHttpQuery> query)
        {
            return Delete(query);
        }

        public Task<HttpResponse<T>> Remove<T>(Action<IDeleteHttpQuery> query)
        {
            return Delete<T>(query);
        }

        public Task<HttpResponse> Replace(Action<IPutHttpQuery> query)
        {
            return Put(query);
        }

        public Task<HttpResponse<T>> Replace<T>(Action<IPutHttpQuery> query)
        {
            return Put<T>(query);
        }

        public Task<HttpResponse> Update(Action<IPutHttpQuery> query)
        {
            return Put(query);
        }

        public Task<HttpResponse<T>> Update<T>(Action<IPutHttpQuery> query)
        {
            return Put<T>(query);
        }

        public Task<HttpResponse> UpdatePartial(Action<IPatchHttpQuery> query)
        {
            return Patch(query);
        }

        public Task<HttpResponse<T>> UpdatePartial<T>(Action<IPatchHttpQuery> query)
        {
            return Patch<T>(query);
        }

        public Task<HttpResponse<T>> Upload<T>(Action<IFileHttpQuery> query)
        {
            var httpQuery = new FileHttpQuery();
            query(httpQuery);
            return ExecuteQuery<T>(httpQuery);
        }

        public Task<HttpResponse> Upload(Action<IFileHttpQuery> query)
        {
            var httpQuery = new FileHttpQuery();
            query(httpQuery);
            return ExecuteQuery(httpQuery);
        }
    }
}
