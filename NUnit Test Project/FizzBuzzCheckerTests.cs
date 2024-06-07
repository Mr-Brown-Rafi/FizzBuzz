using FizzBuzz.Common;

namespace NUnit_Test_Project
{
    [TestFixture]
    public class FizzBuzzCheckerTests
    {
        [Test]
        public void IsFizzBuzz_WhenNumberIsDivisibleByThreeAndFive_ReturnsTrue()
        {
            // Arrange
            int number = 15;

            // Act
            bool result = FizzBuzzChecker.IsFizzBuzz(number);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsFizzBuzz_WhenNumberIsNotDivisibleByThreeAndFive_ReturnsFalse()
        {
            int number = 7;

            bool result = FizzBuzzChecker.IsFizzBuzz(number);

            Assert.IsFalse(result);
        }

        [Test]
        public void IsFizz_WhenNumberIsDivisibleByThree_ReturnsTrue()
        {
            int number = 9;

            bool result = FizzBuzzChecker.IsFizz(number);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsFizz_WhenNumberIsNotDivisibleByThree_ReturnsFalse()
        {
            int number = 8;

            bool result = FizzBuzzChecker.IsFizz(number);

            Assert.IsFalse(result);
        }

        [Test]
        public void IsBuzz_WhenNumberIsDivisibleByFive_ReturnsTrue()
        {
            int number = 10;

            bool result = FizzBuzzChecker.IsBuzz(number);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsBuzz_WhenNumberIsNotDivisibleByFive_ReturnsFalse()
        {
            int number = 11;

            bool result = FizzBuzzChecker.IsBuzz(number);

            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidNumber_WhenInputIsValidInteger_ReturnsTrue()
        {
            string input = "123";

            bool result = FizzBuzzChecker.IsValidNumber(input, out int number);

            Assert.IsTrue(result);
            Assert.AreEqual(123, number);
        }

        [Test]
        public void IsValidNumber_WhenInputIsNotValidInteger_ReturnsFalse()
        {
            string input = "abc";

            bool result = FizzBuzzChecker.IsValidNumber(input, out int number);

            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidNumber_WhenInputIsEmpty_ReturnsFalse()
        {
            string input = "";

            bool result = FizzBuzzChecker.IsValidNumber(input, out int number);

            Assert.IsFalse(result);
        }
    }
}

