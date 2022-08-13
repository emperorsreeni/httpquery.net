//using FluentHttpClient.Contracts.Query;
//using FluentHttpClient.Http;

//namespace FluentHttpClient
//{
//    public class CreateResource : BaseHttpQuery
//    {

//        public void Query3<T>(HttpRequest<T> httpRequest)
//        {
//            var httpClient = new FluentHttpClient();
//            //more verb specific query
//            httpClient.Create(query =>
//            {
//                query.
//                    Resource(httpRequest.Resource)
//                    .With
//                        .Content("hello")
//                    .On(httpRequest.Server)
//                    .Include
//                        .Cookies(httpRequest.Queries);
//            });

//        }
//        public IHttpQuery Query2<T>(HttpRequest<T> httpRequest)
//        {
//            return
//                Create(query =>
//                {
//                    query
//                    .Resource(httpRequest.Resource)
//                    .With
//                        .Content("hello")
//                    .On(httpRequest.Server)
//                    .Include
//                        .Cookies(httpRequest.Queries);
//                });
                
//        }
//        public IHttpQuery Query<T>(HttpRequest<T> httpRequest)
//        {
//            return
//                Create()
//                .Resource(httpRequest.Resource)
//                .With
//                    .Content("hello")
//                .On(httpRequest.Server)
//                .Include
//                    .Cookies(httpRequest.Queries);
//        }

//        public override HttpResponse<T> Run<T>(HttpRequest<T> httpRequest)
//        {
//            return Execute<T>(() =>
//                Create()
//                .Resource(httpRequest.Resource)
//                .With
//                    .Content("hello")
//                .On(httpRequest.Server)
//                .Include
//                    .Cookies(httpRequest.Queries)
//           );
//        }
//    }
//}
