namespace HttpQuery.Contracts.Query
{
    public interface IHttpQuery
    {
        IHttpQuery Resource(string resource);
        IHttpQuery From(string resourceServer);
        IHttpQuery To(string resourceServer);
        IHttpQuery On(string resourceServer);
        IHttpWithQuery With { get;}
        IHttpInclueQuery Include { get; }
        
    }
}
