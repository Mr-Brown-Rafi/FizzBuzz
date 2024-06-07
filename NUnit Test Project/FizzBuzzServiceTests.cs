using FizzBuzz.Common;
using FizzBuzz.Services;
using Moq;

namespace FizzBuzz.Tests
{
    [TestFixture]
    public class FizzBuzzServiceTests
    {
        private Mock<IFizzBuzzChecker> _mockFizzBuzzChecker;
        private FizzBuzzService _fizzBuzzService;

        [SetUp]
        public void SetUp()
        {
            _mockFizzBuzzChecker = new Mock<IFizzBuzzChecker>();
            _fizzBuzzService = new FizzBuzzService(_mockFizzBuzzChecker.Object);
        }

        [Test]
        public void ProcessInputs_InvalidInput_ReturnsInvalidItem()
        {
            // Arrange
            var inputs = new List<string> { "abc" };
            _mockFizzBuzzChecker
                .Setup(m => m.IsValidNumber(It.IsAny<string>(), out It.Ref<int>.IsAny))
                .Returns(false);

            // Act
            var results = _fizzBuzzService.ProcessInputs(inputs);

            // Assert
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(FizzBuzzConstants.InvalidItem, results[0]);
        }

        [Test]
        public void ProcessInputs_ValidFizzBuzzNumber_ReturnsFizzBuzz()
        {
            // Arrange
            var inputs = new List<string> { "15" };
            int number;
            _mockFizzBuzzChecker
                .Setup(m => m.IsValidNumber("15", out number))
                .Returns((string s, out int n) => { n = 15; return true; });
            _mockFizzBuzzChecker.Setup(m => m.IsFizzBuzz(15)).Returns(true);

            // Act
            var results = _fizzBuzzService.ProcessInputs(inputs);

            // Assert
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(FizzBuzzConstants.FizzBuzz, results[0]);
        }

        [Test]
        public void ProcessInputs_ValidFizzNumber_ReturnsFizz()
        {
            // Arrange
            var inputs = new List<string> { "3" };
            int number;
            _mockFizzBuzzChecker
                .Setup(m => m.IsValidNumber("3", out number))
                .Returns((string s, out int n) => { n = 3; return true; });
            _mockFizzBuzzChecker.Setup(m => m.IsFizz(3)).Returns(true);

            // Act
            var results = _fizzBuzzService.ProcessInputs(inputs);

            // Assert
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(FizzBuzzConstants.Fizz, results[0]);
        }

        [Test]
        public void ProcessInputs_ValidBuzzNumber_ReturnsBuzz()
        {
            // Arrange
            var inputs = new List<string> { "5" };
            int number;
            _mockFizzBuzzChecker
                .Setup(m => m.IsValidNumber("5", out number))
                .Returns((string s, out int n) => { n = 5; return true; });
            _mockFizzBuzzChecker.Setup(m => m.IsBuzz(5)).Returns(true);

            // Act
            var results = _fizzBuzzService.ProcessInputs(inputs);

            // Assert
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(FizzBuzzConstants.Buzz, results[0]);
        }

        [Test]
        public void ProcessInputs_ValidNumber_ReturnsDividedBy()
        {
            // Arrange
            var inputs = new List<string> { "7" };
            int number;
            _mockFizzBuzzChecker
                .Setup(m => m.IsValidNumber("7", out number))
                .Returns((string s, out int n) => { n = 7; return true; });
            _mockFizzBuzzChecker.Setup(m => m.IsFizz(7)).Returns(false);
            _mockFizzBuzzChecker.Setup(m => m.IsBuzz(7)).Returns(false);

            // Act
            var results = _fizzBuzzService.ProcessInputs(inputs);

            // Assert
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual($"Divided 7 by {FizzBuzzConstants.DivisorFizz} & Divided 7 by {FizzBuzzConstants.DivisorBuzz}", results[0]);
        }
    }
}
