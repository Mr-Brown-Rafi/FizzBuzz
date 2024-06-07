using FizzBuzz.Services;

namespace NUnit_Test_Project
{
    [TestFixture]
    public class FizzBuzzServiceTests
    {
        private FizzBuzzService _fizzBuzzService;

        [SetUp]
        public void Setup()
        {
            _fizzBuzzService = new FizzBuzzService();
        }

        [Test]
        public void ProcessInputs_ShouldReturnFizz_WhenDivisibleBy3()
        {
            var inputs = new List<string> { "3" };
            var result = _fizzBuzzService.ProcessInputs(inputs);
            Assert.AreEqual("Fizz", result[0]);
        }

        [Test]
        public void ProcessInputs_ShouldReturnBuzz_WhenDivisibleBy5()
        {
            var inputs = new List<string> { "5" };
            var result = _fizzBuzzService.ProcessInputs(inputs);
            Assert.AreEqual("Buzz", result[0]);
        }

        [Test]
        public void ProcessInputs_ShouldReturnFizzBuzz_WhenDivisibleBy3And5()
        {
            var inputs = new List<string> { "15" };
            var result = _fizzBuzzService.ProcessInputs(inputs);
            Assert.AreEqual("FizzBuzz", result[0]);
        }

        [Test]
        public void ProcessInputs_ShouldReturnInvalidItem_WhenInputIsNotANumber()
        {
            var inputs = new List<string> { "A" };
            var result = _fizzBuzzService.ProcessInputs(inputs);
            Assert.AreEqual("Invalid Item", result[0]);
        }

        [Test]
        public void ProcessInputs_ShouldReturnDividedBy3And5_WhenNotDivisibleBy3Or5()
        {
            var inputs = new List<string> { "7" };
            var result = _fizzBuzzService.ProcessInputs(inputs);
            Assert.AreEqual("Divided 7 by 3 & Divided 7 by 5", result[0]);
            
        }

        [Test]
        public void ProcessInputs_ShouldReturnInvalidItem_WhenInputIsEmpty()
        {
            var inputs = new List<string> { "" };
            var result = _fizzBuzzService.ProcessInputs(inputs);
            Assert.AreEqual("Invalid Item", result[0]);
        }
    }
}
