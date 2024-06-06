using FizzBuzz.Models;
using System.Reflection;

namespace FizzBuzz.Services
{
    public class FizzBuzzService : IFizzBuzzService
    {
        public List<string> ProcessInputs(List<string> inputs)
        {
            List<string> results = new List<string>();

            foreach (var input in inputs)
            {
                if (string.IsNullOrWhiteSpace(input))
                {
                    results.Add("Invalid Item");
                    continue;
                }

                if (!int.TryParse(input, out int number))
                {
                    results.Add("Invalid Item");
                    continue;
                }

                if (number % 3 == 0 && number % 5 == 0)
                {
                    results.Add("FizzBuzz");
                }
                else if (number % 3 == 0)
                {
                    results.Add("Fizz");
                }
                else if (number % 5 == 0)
                {
                    results.Add("Buzz");
                }
                else
                {
                    results.Add($"Divided {number} by 3 & Divided {number} by 5");
                }
            }

            return results;
        }
    }
}
