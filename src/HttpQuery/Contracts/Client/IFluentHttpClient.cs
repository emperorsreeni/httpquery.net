using HttpQuery.Contracts.Query;
using HttpQuery.Http;

namespace HttpQuery.Contracts.Client
{
    public interface IHttpQueryClient : IGetHttpClient,
        IPostHttpClient,
        IPutHttpClient,
        IPatchHttpClient,
        IDeleteHttpClient,
        IFileHttpClient,
        IHttpVerbsClient
    {
        //HttpResponse<T> Read<T>(Action<IHttpQuery> query);
        //HttpResponse<T> Fetch<T>(Action<IHttpQuery> query);
        //HttpResponse<T> Get<T>(Action<IHttpQuery> query);

        //HttpResponse Create(Action<IHttpQuery> query);
        //HttpResponse Post(Action<IHttpQuery> query);
        //HttpResponse Update(Action<IHttpQuery> query);
        //HttpResponse Replace(Action<IHttpQuery> query);
        //HttpResponse Put(Action<IHttpQuery> query);
        //HttpResponse UpdatePartial(Action<IHttpQuery> query);
        //HttpResponse Patch(Action<IHttpQuery> query);

        //HttpResponse<T> Create<T>(Action<IHttpQuery> query);
        //HttpResponse<T> Post<T>(Action<IHttpQuery> query);
        //HttpResponse<T> Update<T>(Action<IHttpQuery> query);
        //HttpResponse<T> Replace<T>(Action<IHttpQuery> query);
        //HttpResponse<T> Put<T>(Action<IHttpQuery> query);
        //HttpResponse<T> UpdatePartial<T>(Action<IHttpQuery> query);
        //HttpResponse<T> Patch<T>(Action<IHttpQuery> query);


        //HttpResponse Delete(Action<IHttpQuery> query);
        //HttpResponse Remove(Action<IHttpQuery> query);

        Task<HttpResponse<T>> Execute<T>(IHttpQuery httpQuery);
    }
}
