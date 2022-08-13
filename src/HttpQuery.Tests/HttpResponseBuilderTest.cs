

using HttpQuery.Http;

namespace HttpQuery.Tests
{
    [TestClass]
    public class HttpResponseBuilderTest
    {
        [TestMethod]
        public void Build_should_build_reponse_message_from_given_http_message()
        {
            //Arrange
            var responseMessage = new HttpResponseMessage();
            
            var sut = new HttpResponseBuilder(responseMessage);

            //Act
            var result = sut.Build();

            //Assert
            result.ShouldNotBeNull();

        }

        [TestMethod]
        public void Build_should_build_reponse_message_from_given_http_message_with_headers()
        {
            //Arrange
            var responseMessage = new HttpResponseMessage();
            responseMessage.Headers.CacheControl = new System.Net.Http.Headers.CacheControlHeaderValue()
            {
                MaxAge = TimeSpan.FromMinutes(3600),

            };

            responseMessage.Headers.ConnectionClose = true;

            var sut = new HttpResponseBuilder(responseMessage);

            //Act
            var result = sut.Build();

            //Assert
            result.ShouldNotBeNull();
            result.Headers.Count.ShouldBe(2);

        }

        [TestMethod]
        public void Build_should_build_reponse_message_from_given_http_message_with_headers_and_cookies()
        {
            //Arrange
            var responseMessage = new HttpResponseMessage();
            responseMessage.Headers.CacheControl = new System.Net.Http.Headers.CacheControlHeaderValue()
            {
                MaxAge = TimeSpan.FromMinutes(3600),

            };

            responseMessage.Headers.ConnectionClose = true;

            responseMessage.Headers.Add("Set-Cookie", "sessionId=38afes7a8");
            responseMessage.Headers.Add("Set-Cookie", "id=a3fWa; Expires=Wed, 21 Oct 2015 07:28:00 GMT");
            responseMessage.Headers.Add("Set-Cookie", "id=a3fWa; Max-Age=2592000");

            var sut = new HttpResponseBuilder(responseMessage);

            //Act
            var result = sut.Build();

            //Assert
            result.ShouldNotBeNull();
            result.Headers.Count.ShouldBe(2);
            result.Cookies.Count.ShouldBe(3);
        }

    }
}
