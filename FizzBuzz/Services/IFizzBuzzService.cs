using FizzBuzz.Models;

namespace FizzBuzz.Services
{
    public interface IFizzBuzzService
    {
        List<string> ProcessInputs(List<string> inputs);
    }
}
