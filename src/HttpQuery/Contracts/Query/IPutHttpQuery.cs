
namespace HttpQuery.Contracts.Query
{
    public interface IPutHttpQuery : IHttpQuery
    {
        IHttpQuery Put();
        IHttpQuery Update();
        IHttpQuery Replace();
    }
}
