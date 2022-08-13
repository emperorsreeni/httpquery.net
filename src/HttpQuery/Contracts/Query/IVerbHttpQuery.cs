namespace HttpQuery.Contracts.Query
{
    public interface IVerbHttpQuery
    {
        IHttpQuery Verb(string method);
        IHttpQuery Head();
        IHttpQuery Options();
    }
}
