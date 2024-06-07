using FizzBuzz.Models;
using FizzBuzz.Services;
using Microsoft.AspNetCore.Mvc;

namespace FizzBuzz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FizzBuzzController : Controller
    {
        private readonly IFizzBuzzService _fizzBuzzService;

        public FizzBuzzController(IFizzBuzzService fizzBuzzService)
        {
                _fizzBuzzService = fizzBuzzService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] InputModel model)
        {

            if (model?.Values == null)
            {
                return BadRequest("Input values cannot be null.");
            }

            var results = _fizzBuzzService.ProcessInputs(model.Values);
            return Ok(results);
        }
    }

}
