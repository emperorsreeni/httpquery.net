
namespace HttpQuery.Tests
{
    [TestClass]
    public class HttpQueryClientGETTest
    {
        [TestMethod]
        public void Get_should_return_the_specified_type_of_content()
        {
            //Arrange
            var expected = 1;
            var mockSut = new Mock<string>();
            mockSut.Setup(s => s.Length).Returns(expected);
            var sut = mockSut.Object;

            //Act
            var actual = sut.Length;

            //Assert
            actual.ShouldBe(expected);
        }


        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        //TODO: Change the name of the method with appropriate unit test case
        public void Method_should_throw_a_exception()
        {
            //Arrange

            //Act
            throw new System.ArgumentNullException();

            //Assert

        }
    }
}
