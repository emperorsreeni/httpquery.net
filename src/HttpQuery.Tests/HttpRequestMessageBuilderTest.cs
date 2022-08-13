using HttpQuery.Http;
using HttpQuery.Query;

namespace HttpQuery.Tests
{
    [TestClass]
    public class HttpRequestMessageBuilderTest
    {
        [TestMethod]
        public void BuidGet_should_return_http_request_message_for_get()
        {
            //Arrange
            var httpContext = new HttpQueryContext
            {
                Method = "GET",
                Resource = "resource",
                Server = "https://localhost:40304"
            };

            var sut = new HttpRequestMessageBuilder(httpContext);

            //Act
            var actual = sut.BuidGet();

            //Assert
            actual.ShouldNotBeNull();
            actual.Method.ShouldBe(HttpMethod.Get);
            actual.Headers.Count().ShouldBe(0);
        }

        [TestMethod]
        public void BuidGet_should_return_http_request_message_for_get_with_query_string()
        {
            //Arrange
            var httpContext = new HttpQueryContext
            {
                Method = "GET",
                Resource = "resource",
                Server = "https://localhost:40304",
                Queries = new Dictionary<string, string>()
                {
                    {"query1","value1" },
                    {"query2","value2 %344" }
                }
            };

            var sut = new HttpRequestMessageBuilder(httpContext);

            //Act
            var actual = sut.BuidGet();

            //Assert
            actual.ShouldNotBeNull();
            actual.Method.ShouldBe(HttpMethod.Get);
            actual.RequestUri.Query.ShouldContain("query1");
        }

        [TestMethod]
        public void BuidGet_should_return_http_request_message_for_get_with_header()
        {
            //Arrange
            var httpContext = new HttpQueryContext
            {
                Method = "GET",
                Resource = "resource",
                Server = "https://localhost:40304",
                Headers = new Dictionary<string, string>()
                {
                    {"Accept","application/json" },
                    {"User-Agent","HttpQueryClient/V1.0" }
                }
            };

            var sut = new HttpRequestMessageBuilder(httpContext);

            //Act
            var actual = sut.BuidGet();

            //Assert
            actual.ShouldNotBeNull();
            actual.Method.ShouldBe(HttpMethod.Get);
            actual.Headers.Count().ShouldBe(httpContext.Headers.Count);
        }
        [TestMethod]
        public void BuidGet_should_return_http_request_message_for_get_with_cookies()
        {
            //Arrange
            var httpContext = new HttpQueryContext
            {
                Method = "GET",
                Resource = "resource",
                Server = "https://localhost:40304",
                Cookies = new Dictionary<string, string>()
                {
                    {"cookie1",Guid.NewGuid().ToString() },
                    {"cookie2",Guid.NewGuid().ToString() },
                    {"cookie3",Guid.NewGuid().ToString() },
                }
            };

            var sut = new HttpRequestMessageBuilder(httpContext);

            //Act
            var actual = sut.BuidGet();

            //Assert
            actual.ShouldNotBeNull();
            actual.Method.ShouldBe(HttpMethod.Get);
            actual.Headers.Count().ShouldBe(1);
        }

        

        [TestMethod]
        public void BuidPost_should_return_http_request_message_for_post_with_string_content()
        {
            //Arrange
            var httpContext = new HttpQueryContext
            {
                Method = "POST",
                Resource = "resource",
                Server = "https://localhost:40304",
                Content = new Http.FluentHttpContent
                {
                    Content = "{message:\"Hello world\"}"
                }
            };

            var sut = new HttpRequestMessageBuilder(httpContext);

            //Act
            var actual = sut.BuidPost();

            //Assert
            actual.ShouldNotBeNull();
            actual.Method.ShouldBe(HttpMethod.Post);
            actual.Headers.Count().ShouldBe(0);
            actual.Content.ShouldNotBeNull();
            actual.Content.ShouldBeOfType<StringContent>();
        }

        [TestMethod]
        public void BuidPost_should_return_http_request_message_for_post_with_multi_part_content()
        {
            //Arrange
            var httpContext = new HttpQueryContext
            {
                Method = "POST",
                Resource = "resource",
                Server = "https://localhost:40304",
                Content = new Http.FluentHttpContent
                {
                    Content = "{message:\"Hello world\"}"
                }
            };

            var sut = new HttpRequestMessageBuilder(httpContext);

            //Act
            var actual = sut.BuidPost();

            //Assert
            actual.ShouldNotBeNull();
            actual.Method.ShouldBe(HttpMethod.Post);
            actual.Headers.Count().ShouldBe(0);
            actual.Content.ShouldNotBeNull();
            actual.Content.ShouldBeOfType<StringContent>();
        }

        [TestMethod]
        public void BuidPost_should_return_http_request_message_for_post_with_form_content()
        {
            //Arrange
            var httpContext = new HttpQueryContext
            {
                Method = "POST",
                Resource = "resource",
                Server = "https://localhost:40304",
                FormParams = new Dictionary<string, string>()
                {
                    {"params1",Guid.NewGuid().ToString() },
                    {"params2",Guid.NewGuid().ToString() },
                    {"params3",Guid.NewGuid().ToString() },
                }
            };

            var sut = new HttpRequestMessageBuilder(httpContext);

            //Act
            var actual = sut.BuidPost();

            //Assert
            actual.ShouldNotBeNull();
            actual.Method.ShouldBe(HttpMethod.Post);
            actual.Headers.Count().ShouldBe(0);
            actual.Content.ShouldNotBeNull();
            actual.Content.ShouldBeOfType<FormUrlEncodedContent>();
        }
    }
}
