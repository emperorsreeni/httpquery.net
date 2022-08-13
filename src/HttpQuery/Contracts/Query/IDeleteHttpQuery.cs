
namespace HttpQuery.Contracts.Query
{
    public interface IDeleteHttpQuery : IHttpQuery
    {
        IHttpQuery Delete();
        IHttpQuery Remove();
    }
}
