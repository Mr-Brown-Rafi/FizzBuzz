using FizzBuzz.Common;

namespace FizzBuzz.Services
{
    public class FizzBuzzService : IFizzBuzzService
    {
        private readonly IFizzBuzzChecker _fizzBuzzChecker;
        public FizzBuzzService(IFizzBuzzChecker fizzBuzzChecker)
        {
                _fizzBuzzChecker = fizzBuzzChecker;
        }

        public List<string> ProcessInputs(List<string> inputs)
        {
            List<string> results = new List<string>();

            foreach (var input in inputs)
            {
                if (string.IsNullOrWhiteSpace(input) || !_fizzBuzzChecker.IsValidNumber(input, out int number))
                {
                    results.Add(FizzBuzzConstants.InvalidItem);
                    continue;
                }

                if (_fizzBuzzChecker.IsFizzBuzz(number))
                {
                    results.Add(FizzBuzzConstants.FizzBuzz);
                }
                else if (_fizzBuzzChecker.IsFizz(number))
                {
                    results.Add(FizzBuzzConstants.Fizz);
                }
                else if (_fizzBuzzChecker.IsBuzz(number))
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
