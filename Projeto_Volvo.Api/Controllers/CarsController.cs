#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_Volvo.Api.Contracts;
using Projeto_Volvo.Api.Exceptions;
using Projeto_Volvo.Api.Models;
using Projeto_Volvo.Api.Models.Dto;
using Projeto_Volvo.Api.Service;

namespace Projeto_Volvo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarRepository carRepository;
        private readonly ICarService carService;

        public CarsController(ICarRepository carRepository, ICarService carService)
        {
            this.carService = carService;
            this.carRepository = carRepository;
        }

        // GET: api/Cars
        [HttpGet]
        public async Task<ActionResult<ICollection<Car>>> GetCars()
        {
            var cars = await carRepository.GetAllEntity();
            return Ok(cars);
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            try
            {
                var car = await carRepository.GetOneEntity(id);
                return car;
            }
            catch (EntityException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/Cars/kilometers?km=10223&version=1.2
        [HttpGet("kilometers")]
        public async Task<ActionResult> GetCarsPerKmAndVersion(
            [FromQuery] int km,
            [FromQuery] string version
        )
        {
            var cars = await carRepository.GetCarsPerKmAndSystemVersion(km, version);
            return Ok(cars);
        }

        // PUT: api/Cars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, [FromBody] CarDto car)
        {
            if (id != car.IdCar)
            {
                return BadRequest();
            }

            try
            {
                var updateCar = await carRepository.UpdateEntity(id, car.CreateEntity());
                return Ok(updateCar);
            }
            catch (EntityException ex)
            {
                return NotFound(ex.Message);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        // POST: api/Cars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Car>> PostCar(CarDto carDto)
        {
            var newCar = await carService.CreateCar(carDto);
            var car = await carRepository.AddEntity(newCar);
            return CreatedAtAction("GetCar", new { id = car.IdCar }, car);
        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            try
            {
                await carRepository.DeleteEntity(id);
                return Ok();
            }
            catch (EntityException ex)
            {
                throw new EntityException(ex.Message);
            }
        }
    }
}
