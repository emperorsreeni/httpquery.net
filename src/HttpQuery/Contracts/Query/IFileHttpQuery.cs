
namespace HttpQuery.Contracts.Query
{
    public interface IFileHttpQuery : IHttpQuery
    {
        IHttpQuery Upload();
        IHttpQuery Download();
    }
}
