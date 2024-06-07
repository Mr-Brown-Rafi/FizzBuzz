using FizzBuzz.Common;

namespace FizzBuzz.Services
{
    public class FizzBuzzService : IFizzBuzzService
    {
        public List<string> ProcessInputs(List<string> inputs)
        {
            List<string> results = new List<string>();

            foreach (var input in inputs)
            {
                if (string.IsNullOrWhiteSpace(input) || !FizzBuzzChecker.IsValidNumber(input, out int number))
                {
                    results.Add(FizzBuzzConstants.InvalidItem);
                    continue;
                }

                if (FizzBuzzChecker.IsFizzBuzz(number))
                {
                    results.Add(FizzBuzzConstants.FizzBuzz);
                }
                else if (FizzBuzzChecker.IsFizz(number))
                {
                    results.Add(FizzBuzzConstants.Fizz);
                }
                else if (FizzBuzzChecker.IsBuzz(number))
                {
                    results.Add(FizzBuzzConstants.Buzz);
                }
                else
                {
                    results.Add($"Divided {number} by {FizzBuzzConstants.DivisorFizz} & Divided {number} by {FizzBuzzConstants.DivisorBuzz}");
                }
            }


            return results;
        }
    }
}
