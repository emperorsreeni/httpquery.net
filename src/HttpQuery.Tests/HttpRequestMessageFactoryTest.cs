using HttpQuery.Contracts.Query;
using HttpQuery.Http;

namespace HttpQuery.Tests
{
    [TestClass]
    public class HttpRequestMessageFactoryTestTest
    {
        [TestMethod]
        public void Instance_should_return_a_new_instance_of_HttpRequestMessageFactory_for_first_time()
        {
            //Act
            var result = HttpRequestMessageFactory.Instance;

            //Assert
            result.ShouldNotBeNull();  
        }

        [TestMethod]
        public void Instance_should_return_the_same_instance_of_HttpRequestMessageFactory_again_and_again_for_subsequent_access()
        {
            //Arrange
            var expected = HttpRequestMessageFactory.Instance;

            //Act
            var actual = HttpRequestMessageFactory.Instance;

            //Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void Create_should_return_get_http_requestmessage_for_given_get_http_query()
        {
            //Arrange
            var mockHttpQuery = new Mock<IHttpQueryContext>();
            mockHttpQuery.Setup(m => m.Method).Returns("GET")
                .Verifiable();
            mockHttpQuery.Setup(m => m.Server).Returns("https://localhost:40304")
                .Verifiable();
            mockHttpQuery.Setup(m => m.Resource).Returns("resource")
                .Verifiable();
            var sut = HttpRequestMessageFactory.Instance;

            //Act
            var actual = sut.Create(mockHttpQuery.Object);

            //Assert
            actual.Method.ShouldBe(HttpMethod.Get);
            actual.RequestUri.AbsolutePath.ShouldBe("/resource");
            mockHttpQuery.VerifyAll();
        }

        [TestMethod]
        public void Create_should_return_post_http_requestmessage_for_given_post_http_query()
        {
            //Arrange
            var mockHttpQuery = new Mock<IHttpQueryContext>();
            mockHttpQuery.Setup(m => m.Method).Returns("POST")
                .Verifiable();
            mockHttpQuery.Setup(m => m.Server).Returns("https://localhost:40304")
                .Verifiable();
            mockHttpQuery.Setup(m => m.Resource).Returns("resource")
                .Verifiable();
            var sut = HttpRequestMessageFactory.Instance;

            //Act
            var actual = sut.Create(mockHttpQuery.Object);

            //Assert
            actual.Method.ShouldBe(HttpMethod.Post);
            actual.RequestUri.AbsolutePath.ShouldBe("/resource");
            actual.Content.ShouldBeNull();
            mockHttpQuery.VerifyAll();
        }


        [TestMethod]
        public void Create_should_return_put_http_requestmessage_for_given_put_http_query()
        {
            //Arrange
            var mockHttpQuery = new Mock<IHttpQueryContext>();
            mockHttpQuery.Setup(m => m.Method).Returns("PUT")
                .Verifiable();
            mockHttpQuery.Setup(m => m.Server).Returns("https://localhost:40304")
                .Verifiable();
            mockHttpQuery.Setup(m => m.Resource).Returns("resource")
                .Verifiable();
            var sut = HttpRequestMessageFactory.Instance;

            //Act
            var actual = sut.Create(mockHttpQuery.Object);

            //Assert
            actual.Method.ShouldBe(HttpMethod.Put);
            actual.RequestUri.AbsolutePath.ShouldBe("/resource");
            actual.Content.ShouldBeNull();
            mockHttpQuery.VerifyAll();
        }

        [TestMethod]
        public void Create_should_return_patch_http_requestmessage_for_given_patch_http_query()
        {
            //Arrange
            var mockHttpQuery = new Mock<IHttpQueryContext>();
            mockHttpQuery.Setup(m => m.Method).Returns("PATCH")
                .Verifiable();
            mockHttpQuery.Setup(m => m.Server).Returns("https://localhost:40304")
                .Verifiable();
            mockHttpQuery.Setup(m => m.Resource).Returns("resource")
                .Verifiable();
            var sut = HttpRequestMessageFactory.Instance;

            //Act
            var actual = sut.Create(mockHttpQuery.Object);

            //Assert
            actual.Method.ShouldBe(HttpMethod.Patch);
            actual.RequestUri.AbsolutePath.ShouldBe("/resource");
            actual.Content.ShouldBeNull();
            mockHttpQuery.VerifyAll();
        }

        [TestMethod]
        public void Create_should_return_delete_http_requestmessage_for_given_delete_http_query()
        {
            //Arrange
            var mockHttpQuery = new Mock<IHttpQueryContext>();
            mockHttpQuery.Setup(m => m.Method).Returns("DELETE")
                .Verifiable();
            mockHttpQuery.Setup(m => m.Server).Returns("https://localhost:40304")
                .Verifiable();
            mockHttpQuery.Setup(m => m.Resource).Returns("resource")
                .Verifiable();
            var sut = HttpRequestMessageFactory.Instance;

            //Act
            var actual = sut.Create(mockHttpQuery.Object);

            //Assert
            actual.Method.ShouldBe(HttpMethod.Delete);
            actual.RequestUri.AbsolutePath.ShouldBe("/resource");
            actual.Content.ShouldBeNull();
            mockHttpQuery.VerifyAll();
        }

    }
}
