using FizzBuzz.Common;

namespace FizzBuzz.Tests
{
    [TestFixture]
    public class FizzBuzzCheckerTests
    {

        private FizzBuzzChecker _checker;

        [SetUp]
        public void SetUp()
        {
            _checker = new FizzBuzzChecker();
        }


        [Test]
        public void IsFizzBuzz_WhenNumberIsDivisibleByThreeAndFive_ReturnsTrue()
        {
            // Arrange
            int number = 15;

            // Act
            bool result = _checker.IsFizzBuzz(number);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsFizzBuzz_WhenNumberIsNotDivisibleByThreeAndFive_ReturnsFalse()
        {
            int number = 7;

            bool result = _checker.IsFizzBuzz(number);

            Assert.IsFalse(result);
        }

        [Test]
        public void IsFizz_WhenNumberIsDivisibleByThree_ReturnsTrue()
        {
            int number = 9;

            bool result = _checker.IsFizz(number);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsFizz_WhenNumberIsNotDivisibleByThree_ReturnsFalse()
        {
            int number = 8;

            bool result = _checker.IsFizz(number);

            Assert.IsFalse(result);
        }

        [Test]
        public void IsBuzz_WhenNumberIsDivisibleByFive_ReturnsTrue()
        {
            int number = 10;

            bool result = _checker.IsBuzz(number);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsBuzz_WhenNumberIsNotDivisibleByFive_ReturnsFalse()
        {
            int number = 11;

            bool result = _checker.IsBuzz(number);

            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidNumber_WhenInputIsValidInteger_ReturnsTrue()
        {
            string input = "123";

            bool result = _checker.IsValidNumber(input, out int number);

            Assert.IsTrue(result);
            Assert.AreEqual(123, number);
        }

        [Test]
        public void IsValidNumber_WhenInputIsNotValidInteger_ReturnsFalse()
        {
            string input = "abc";

            bool result = _checker.IsValidNumber(input, out int number);

            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidNumber_WhenInputIsEmpty_ReturnsFalse()
        {
            string input = "";

            bool result = _checker.IsValidNumber(input, out int number);

            Assert.IsFalse(result);
        }
    }
}

