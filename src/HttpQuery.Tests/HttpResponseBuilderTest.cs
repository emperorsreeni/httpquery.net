

using HttpQuery.Http;
using Newtonsoft.Json;
using System.Drawing;
using System.Net.Http.Headers;
using System.Text;
using System.Xml.Serialization;

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
            
            var sut = new HttpResponseParser(responseMessage);

            //Act
            var result = sut.Parse();

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

            var sut = new HttpResponseParser(responseMessage);

            //Act
            var result = sut.Parse();

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

            var sut = new HttpResponseParser(responseMessage);

            //Act
            var result = sut.Parse();

            //Assert
            result.ShouldNotBeNull();
            result.Headers.Count.ShouldBe(2);
            result.Cookies.Count.ShouldBe(3);
        }

        [TestMethod]
        public async Task Build_should_return_with_string_content_in_the_response_message_when_content_type_is_text()
        {
            //Arrange
            var expected = "Hello Http query!";
            var responseMessage = new HttpResponseMessage();
            var content = new StringContent(expected);
            content.Headers.ContentType.MediaType = "text/plain";
            responseMessage.Headers.CacheControl = new CacheControlHeaderValue()
            {
                MaxAge = TimeSpan.FromMinutes(3600),

            };

            responseMessage.Headers.ConnectionClose = true;

            responseMessage.Headers.Add("Set-Cookie", "sessionId=38afes7a8");
            responseMessage.Headers.Add("Set-Cookie", "id=a3fWa; Expires=Wed, 21 Oct 2015 07:28:00 GMT");
            responseMessage.Headers.Add("Set-Cookie", "id=a3fWa; Max-Age=2592000");
            responseMessage.Content = content;

            var sut = new HttpResponseParser(responseMessage);

            //Act
            var result = await sut.ParseAsync<string>();

            //Assert
            result.ShouldNotBeNull();
            result.Content.ShouldNotBeNullOrEmpty();
            result.Content.ShouldBe(expected);
            content.Dispose();
        }

        [TestMethod]
        public async Task Build_should_return_with_streamcontent_in_response_message_when_content_type_is_json()
        {
            //Arrange
            var expected = new Persion
            {
                FirstName = "Http",
                LastName = "Query"
            };
            var jsonContent = JsonConvert.SerializeObject(expected);
            var responseMessage = new HttpResponseMessage();
            var writer = new MemoryStream();
            writer.Write(Encoding.UTF8.GetBytes(jsonContent));
            writer.Seek(0, SeekOrigin.Begin);
            var content = new StreamContent(writer);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            responseMessage.Headers.CacheControl = new CacheControlHeaderValue()
            {
                MaxAge = TimeSpan.FromMinutes(3600),

            };

            responseMessage.Headers.ConnectionClose = true;
            
            responseMessage.Headers.Add("Set-Cookie", "sessionId=38afes7a8");
            responseMessage.Headers.Add("Set-Cookie", "id=a3fWa; Expires=Wed, 21 Oct 2015 07:28:00 GMT");
            responseMessage.Headers.Add("Set-Cookie", "id=a3fWa; Max-Age=2592000");
            responseMessage.Content = content;

            var sut = new HttpResponseParser(responseMessage);

            //Act
            var result = await sut.ParseAsync<Persion>();

            //Assert
            result.ShouldNotBeNull();
            result.Content.ShouldNotBeNull();
            result.Content.FirstName.ShouldBe(expected.FirstName);
            result.Content.LastName.ShouldBe(expected.LastName);
            result.Headers.Count.ShouldBe(2);
            result.Cookies.Count.ShouldBe(3);
            content.Dispose();
            writer.Dispose();
        }


        [TestMethod]
        public async Task Build_should_return_with_streamcontent_in_response_message_when_content_type_is_xml()
        {
            //Arrange
            var expected = new Persion
            {
                FirstName = "Http",
                LastName = "Query"
            };
            var writer = new MemoryStream();
            
            var serializer = new XmlSerializer(typeof(Persion));
            serializer.Serialize(writer, expected);
            writer.Seek(0, SeekOrigin.Begin);
            var responseMessage = new HttpResponseMessage();
            var content = new StreamContent(writer);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/xml");
            responseMessage.Headers.CacheControl = new CacheControlHeaderValue()
            {
                MaxAge = TimeSpan.FromMinutes(3600),

            };

            responseMessage.Headers.ConnectionClose = true;

            responseMessage.Headers.Add("Set-Cookie", "sessionId=38afes7a8");
            responseMessage.Headers.Add("Set-Cookie", "id=a3fWa; Expires=Wed, 21 Oct 2015 07:28:00 GMT");
            responseMessage.Headers.Add("Set-Cookie", "id=a3fWa; Max-Age=2592000");
            responseMessage.Content = content;

            var sut = new HttpResponseParser(responseMessage);

            //Act
            var result = await sut.ParseAsync<Persion>();

            //Assert
            result.ShouldNotBeNull();
            result.Content.ShouldNotBeNull();
            result.Content.FirstName.ShouldBe(expected.FirstName);
            result.Content.LastName.ShouldBe(expected.LastName);
            result.Headers.Count.ShouldBe(2);
            result.Cookies.Count.ShouldBe(3);
            content.Dispose();
            writer.Dispose();
        }

        [TestMethod]
        public async Task Build_should_return_with_streamcontent_in_response_message_when_content_type_is_file()
        {
            //Arrange
            var image = new Bitmap(16, 16, System.Drawing.Imaging.PixelFormat.Format64bppArgb);
            var writer = new MemoryStream();
            image.Save(writer,System.Drawing.Imaging.ImageFormat.Png);
            writer.Seek(0, SeekOrigin.Begin);
            
            var responseMessage = new HttpResponseMessage();
            var content = new StreamContent(writer);
            content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
            responseMessage.Headers.CacheControl = new CacheControlHeaderValue()
            {
                MaxAge = TimeSpan.FromMinutes(3600),

            };

            responseMessage.Headers.ConnectionClose = true;

            responseMessage.Headers.Add("Set-Cookie", "sessionId=38afes7a8");
            responseMessage.Headers.Add("Set-Cookie", "id=a3fWa; Expires=Wed, 21 Oct 2015 07:28:00 GMT");
            responseMessage.Headers.Add("Set-Cookie", "id=a3fWa; Max-Age=2592000");
            responseMessage.Content = content;

            var sut = new HttpResponseParser(responseMessage);

            //Act
            var result = await sut.ParseAsync<byte[]>();

            //Assert
            result.ShouldNotBeNull();
            result.Content.ShouldNotBeNull();
            result.Content.LongLength.ShouldBe(writer.Length);
            result.Headers.Count.ShouldBe(2);
            result.Cookies.Count.ShouldBe(3);
            content.Dispose();
            writer.Dispose();
        }
    }

    public class Persion
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
    }
}
