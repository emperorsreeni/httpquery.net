
namespace HttpQuery.Contracts.Query
{
    public interface IPatchHttpQuery : IHttpQuery
    {
        IHttpQuery Patch();
        IHttpQuery UpdatePartial(string url);
    }
}
