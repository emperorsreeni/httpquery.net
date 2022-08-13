using HttpQuery.Contracts.Query;
using HttpQuery.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpQuery.Http
{
    public class HttpRequestMessageFactory
    {
        private const string GetMethod = "GET";
        private const string PostMethod = "POST";
        private const string PutMethod = "PUT";
        private const string DeleteMethod = "DELETE";
        private const string PatchMethod = "PATCH";
        private static HttpRequestMessageFactory instance;
        public static HttpRequestMessageFactory Instance => instance ?? (instance = new HttpRequestMessageFactory());
        public HttpRequestMessage Create(IHttpQueryContext context)
        {
            var requestBuilder = new HttpRequestMessageBuilder(context);
            if (context.Method == GetMethod)
                return requestBuilder.BuidGet();
            if (context.Method == PostMethod)
                return requestBuilder.BuidPost();
            if (context.Method == PutMethod)
                return requestBuilder.BuidPut();
            if (context.Method == PatchMethod)
                return requestBuilder.BuidPatch();
            if (context.Method == DeleteMethod)
                return requestBuilder.BuidDelete();
            throw new InvalidOperationException("Invalid Http Method");
        }
    }
}
