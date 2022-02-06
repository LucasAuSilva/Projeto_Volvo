
using Microsoft.AspNetCore.Mvc;
using Projeto_Curso_Volvo.Api.Models;
using Projeto_Volvo.Api.Repository;

namespace Projeto_Volvo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly CarRepository carRepository;

        public CarController(CarRepository carRepository)
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