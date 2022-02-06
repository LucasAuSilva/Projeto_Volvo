
using Microsoft.AspNetCore.Mvc;
using Projeto_Volvo.Api.Contracts;

namespace Projeto_Volvo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository carRepository;

        public CarController(ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCars()
        {
            var cars = await carRepository.GetAllEntity();
            return Ok(cars);
        }

    }
}