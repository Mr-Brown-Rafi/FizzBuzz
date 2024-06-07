namespace FizzBuzz.Common
{
    public static class FizzBuzzConstants
    {
        public const int DivisorFizz = 3;
        public const int DivisorBuzz = 5;

        public const string Fizz = "Fizz";
        public const string Buzz = "Buzz";
        public const string FizzBuzz = "FizzBuzz";
        public const string InvalidItem = "Invalid Item";
    }

    public class FizzBuzzChecker : IFizzBuzzChecker
    {
        public bool IsFizzBuzz(int number) => number % FizzBuzzConstants.DivisorFizz == 0 && number % FizzBuzzConstants.DivisorBuzz == 0;

        public bool IsFizz(int number) => number % FizzBuzzConstants.DivisorFizz == 0;

        public bool IsBuzz(int number) => number % FizzBuzzConstants.DivisorBuzz == 0;

        public bool IsValidNumber(string input, out int number) => int.TryParse(input, out number);
    }

}
