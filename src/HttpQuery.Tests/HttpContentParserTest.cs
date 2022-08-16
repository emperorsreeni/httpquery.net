
using HttpQuery.Http;
using Newtonsoft.Json;
using System.Drawing;
using System.Net.Http.Headers;
using System.Text;
using System.Xml.Serialization;

namespace HttpQuery.Tests
{
    [TestClass]
    public class HttpContentParserTest
    {
        [TestMethod]
        public async Task ParseAsync_of_json_parser_should_return_model_when_content_type_is_json()
        {
            //Arrange
            var expected = new Persion
            {
                FirstName = "Http",
                LastName = "Query"
            };
            var jsonContent = JsonConvert.SerializeObject(expected);
            var writer = new MemoryStream();
            writer.Write(Encoding.UTF8.GetBytes(jsonContent));
            writer.Seek(0, SeekOrigin.Begin);
            var content = new StreamContent(writer);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var sut = new JsonParser();
            //Act
            var actual = await sut.ParseAsync<Persion>(content) as Persion;

            //Assert
            actual.FirstName.ShouldBe(expected.FirstName);
            actual.LastName.ShouldBe(expected.LastName);
            content.Dispose();
        }

        [TestMethod]
        public async Task ParseAsync_of_xml_parser_should_return_model_when_content_type_is_xml()
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
            
            var content = new StreamContent(writer);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var sut = new XmlParser();
            //Act
            var actual = await sut.ParseAsync<Persion>(content) as Persion;

            //Assert
            actual.FirstName.ShouldBe(expected.FirstName);
            actual.LastName.ShouldBe(expected.LastName);
            content.Dispose();
        }

        [TestMethod]
        public async Task ParseAsync_of_text_parser_should_return_text_response()
        {
            //Arrange
            var expected = "Hello, Http Query!";
            var content = new StringContent(expected);

            content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
            var sut = new TextParser();
            //Act
            var actual = await sut.ParseAsync<string>(content) as string;

            //Assert
            actual.ShouldNotBeNull();
            actual.ShouldBe(expected);
            content.Dispose();
        }

        [TestMethod]
        public async Task ParseAsync_of_filecontent_parser_should_return_byte_array_response()
        {
            //Arrange
            var image = new Bitmap(16, 16, System.Drawing.Imaging.PixelFormat.Format64bppArgb);
            var writer = new MemoryStream();
            image.Save(writer, System.Drawing.Imaging.ImageFormat.Png);
            writer.Seek(0, SeekOrigin.Begin);
            
            var expected = writer.Length;
            var content = new StreamContent(writer);
            content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
            var sut = new FileStreamParser();
            //Act
            var actual = await sut.ParseAsync<byte[]>(content) as byte[];

            //Assert
            actual.ShouldNotBeNull();
            actual.LongLength.ShouldBe(expected);
            writer.Dispose();
            content.Dispose();
        }

    }
}
