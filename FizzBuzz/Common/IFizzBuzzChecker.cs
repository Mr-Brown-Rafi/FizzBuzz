namespace FizzBuzz.Common
{
    public interface IFizzBuzzChecker
    {
        bool IsBuzz(int number);
        bool IsFizz(int number);
        bool IsFizzBuzz(int number);
        bool IsValidNumber(string input, out int number);
    }
}