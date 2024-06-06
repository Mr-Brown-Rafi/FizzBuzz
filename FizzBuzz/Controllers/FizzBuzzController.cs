using FizzBuzz.Models;
using FizzBuzz.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

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
        public IActionResult Post([FromBody] ArrayOfValues model)
        {
           var results = _fizzBuzzService.ProcessInputs(model.Values);
            return Ok(results);
        }
    }

}
