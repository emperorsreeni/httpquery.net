

using HttpQuery.Http;

namespace HttpQuery.Tests
{
    [TestClass]
    public class CookieParserTest
    {
        [TestMethod]
        public Task Parser_should_return_collection_of_cookies()
        {
            var sut = new CookieParser("qwerty=219ffwef9w0f; Domain=somecompany.co.uk");
            var result = sut.Parse();

            return Task.CompletedTask;
        }
    }
}
