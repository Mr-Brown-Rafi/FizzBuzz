using FizzBuzz.Controllers;
using FizzBuzz.Models;
using FizzBuzz.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FizzBuzz.Tests
{
    [TestFixture]
    public class FizzBuzzControllerTests
    {
        private FizzBuzzController _controller;
        private Mock<IFizzBuzzService> _mockFizzBuzzService;

        [SetUp]
        public void Setup()
        {
            _mockFizzBuzzService = new Mock<IFizzBuzzService>();
            _controller = new FizzBuzzController(_mockFizzBuzzService.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _controller?.Dispose();
        }

        [Test]
        public void ProcessInputs_ShouldReturnBadRequest_WhenInputsAreNull()
        {
            var result = _controller.Post(null) as BadRequestObjectResult;
            Assert.AreEqual(400, result.StatusCode);
            Assert.AreEqual("Input values cannot be null.", result.Value);
        }

        [Test]
        public void ProcessInputs_ShouldReturnOk_WhenInputsAreValid()
        {
            var inputs = new List<string> { "1", "3", "5" };
            var expectedResults = new List<string> { "Divided 1 by 3 & Divided 1 by 5", "Fizz", "Buzz" };

            _mockFizzBuzzService.Setup(service => service.ProcessInputs(inputs)).Returns(expectedResults);

            var inputModel = new InputModel { Values = inputs };
            var result = _controller.Post(inputModel) as OkObjectResult;

            Assert.AreEqual(200, result.StatusCode);
            CollectionAssert.AreEqual(expectedResults, result.Value as List<string>);
        }

        public void Dispose()
        {
            TearDown();
        }
    }
}
