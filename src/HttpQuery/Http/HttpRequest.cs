namespace HttpQuery.Http
{
    public class HttpRequest
    {
        public string Resource { get; set; }
        public string Server { get; set; }
        public IDictionary<string, string> Queries { get; set; }
        public IDictionary<string, string> Headers { get; set; }
        public IDictionary<string, string> Cookies { get; set; }
    }
    public class HttpRequest<T> : HttpRequest
    {
        public T Content { get; set; }
    }
}
