//using FizzBuzz.Common;
//using FizzBuzz.Services;
//using Moq;

//namespace NUnit_Test_Project
//{
//    [TestFixture]
//    public class FizzBuzzServiceTests
//    {
//        private Mock<FizzBuzzService> _fizzBuzzService;
//        private Mock<IFizzBuzzChecker> _fizzBuzzChecker;

//        [SetUp]
//        public void Setup()
//        {
//            _fizzBuzzChecker = new Mock<IFizzBuzzChecker>();
//            _fizzBuzzService = new Mock<FizzBuzzService>(_fizzBuzzChecker.Object);
//        }

//        [Test]
//        public void ProcessInputs_ShouldReturnFizz_WhenDivisibleBy3()
//        {
//            var inputs = new List<string> { "3" };
//            var result = _fizzBuzzService.ProcessInputs(inputs);
//            Assert.AreEqual("Fizz", result[0]);
//        }

//        [Test]
//        public void ProcessInputs_ShouldReturnBuzz_WhenDivisibleBy5()
//        {
//            var inputs = new List<string> { "5" };
//            var result = _fizzBuzzService.ProcessInputs(inputs);
//            Assert.AreEqual("Buzz", result[0]);
//        }

//        [Test]
//        public void ProcessInputs_ShouldReturnFizzBuzz_WhenDivisibleBy3And5()
//        {
//            var inputs = new List<string> { "15" };
//            var result = _fizzBuzzService.ProcessInputs(inputs);
//            Assert.AreEqual("FizzBuzz", result[0]);
//        }

//        [Test]
//        public void ProcessInputs_ShouldReturnInvalidItem_WhenInputIsNotANumber()
//        {
//            var inputs = new List<string> { "A" };
//            var result = _fizzBuzzService.ProcessInputs(inputs);
//            Assert.AreEqual("Invalid Item", result[0]);
//        }

//        [Test]
//        public void ProcessInputs_ShouldReturnDividedBy3And5_WhenNotDivisibleBy3Or5()
//        {
//            var inputs = new List<string> { "7" };
//            var result = _fizzBuzzService.ProcessInputs(inputs);
//            Assert.AreEqual("Divided 7 by 3 & Divided 7 by 5", result[0]);

//        }

//        [Test]
//        public void ProcessInputs_ShouldReturnInvalidItem_WhenInputIsEmpty()
//        {
//            var inputs = new List<string> { "" };
//            var result = _fizzBuzzService.ProcessInputs(inputs);
//            Assert.AreEqual("Invalid Item", result[0]);
//        }
//    }
//}


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
