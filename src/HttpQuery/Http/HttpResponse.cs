namespace HttpQuery.Http
{
    public class HttpResponse
    {
        public int Status { get; set; }
        public string? StatusMessage { get; set; }
        public IDictionary<string, string?> Headers { get; set; }
        public List<System.Net.Cookie> Cookies { get; set; }
        public byte[] FileContent { get; set; }
    }

    public class HttpResponse<T> : HttpResponse
    {
        public T Content { get; set; }
    }
}
